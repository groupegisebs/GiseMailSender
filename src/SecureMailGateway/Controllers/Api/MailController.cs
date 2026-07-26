using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;
using SecureMailGateway.Data;
using SecureMailGateway.Middleware;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;

namespace SecureMailGateway.Controllers.Api;

[ApiController]
[Route("api/mail")]
public class MailController(IEmailQueueService emailQueueService, ApplicationDbContext db) : ControllerBase
{
    [HttpPost("send")]
    public async Task<ActionResult<SendMailResponse>> Send([FromBody] SendMailRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new SendMailResponse { Success = false, Error = "Invalid request." });

        if (!HttpContext.Items.TryGetValue(ApiClientContext.ItemKey, out var obj) || obj is not ClientApplication client)
            return Unauthorized(new SendMailResponse { Success = false, Error = "Unauthorized." });

        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        var result = await emailQueueService.QueueEmailAsync(request, client.Id, ip, ct);

        MetricsRegistry.ApiCalls.WithLabels(client.ClientCode, result.Success ? "success" : "error").Inc();

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    /// <summary>
    /// Suit le devenir d'un envoi après sa mise en file. L'appel POST /send ne rend compte que de
    /// la mise en file : seul ce point d'entrée permet de constater la remise effective ou l'échec SMTP.
    /// </summary>
    [HttpGet("status/{mailCode}")]
    public async Task<ActionResult<MailStatusResponse>> Status(string mailCode, CancellationToken ct)
    {
        if (!HttpContext.Items.TryGetValue(ApiClientContext.ItemKey, out var obj) || obj is not ClientApplication client)
            return Unauthorized(new { error = "Unauthorized." });

        var normalized = mailCode.Trim();
        var message = await db.EmailMessages
            .AsNoTracking()
            .Include(m => m.SendLogs)
            .FirstOrDefaultAsync(m => m.MailCode == normalized && m.ClientApplicationId == client.Id, ct);

        if (message is null)
            return NotFound(new { error = $"Mail '{normalized}' introuvable pour le client '{client.ClientCode}'." });

        return Ok(new MailStatusResponse
        {
            MailCode = message.MailCode,
            TrackingId = message.Id,
            Status = message.Status.ToString(),
            TemplateCode = message.TemplateCode,
            Subject = message.Subject,
            To = DeserializeAddresses(message.ToAddresses),
            QueuedAt = message.QueuedAt,
            SendingAt = message.SendingAt,
            SentAt = message.SentAt,
            FailedAt = message.FailedAt,
            ErrorMessage = message.ErrorMessage,
            SmtpResponse = message.SmtpResponse,
            Events = [.. message.SendLogs
                .OrderBy(l => l.CreatedAt)
                .Select(l => new MailStatusEventDto
                {
                    EventType = l.EventType,
                    Message = l.Message,
                    CreatedAt = l.CreatedAt
                })]
        });
    }

    private static List<string> DeserializeAddresses(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<List<string>>(json) ?? [];
        }
        catch (JsonException)
        {
            return [];
        }
    }
}

/// <summary>
/// Inventaire en lecture seule du catalogue de templates. Sans lui, une application ne peut pas
/// vérifier que les codes qu'elle envoie existent réellement : un code inconnu est accepté par
/// /api/mail/send, qui fabrique alors un template de remplacement au lieu de signaler l'erreur.
/// </summary>
[ApiController]
[Route("api/templates")]
public class TemplatesApiController(ApplicationDbContext db, ITemplateRenderer renderer) : ControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<TemplateInventoryResponse>> Get([FromQuery] string? codes, CancellationToken ct)
    {
        if (!HttpContext.Items.TryGetValue(ApiClientContext.ItemKey, out var obj) || obj is not ClientApplication)
            return Unauthorized(new { error = "Unauthorized." });

        var requested = (codes ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(c => c.ToUpperInvariant())
            .Distinct()
            .ToList();

        var query = db.EmailTemplates.AsNoTracking();
        if (requested.Count > 0)
            query = query.Where(t => requested.Contains(t.TemplateCode));

        var templates = await query.OrderBy(t => t.TemplateCode).ToListAsync(ct);

        var items = templates
            .Select(t => new TemplateInventoryItemDto
            {
                TemplateCode = t.TemplateCode,
                Name = t.Name,
                Language = t.Language,
                Version = t.Version,
                IsActive = t.IsActive,
                IsAutoGenerated = EmailTemplate.IsAutoGeneratedName(t.Name),
                RequiredVariables = renderer.ExtractVariables(t.SubjectTemplate, t.HtmlBody, t.TextBody),
                UpdatedAt = t.UpdatedAt
            })
            .ToList();

        var found = items.Select(i => i.TemplateCode).ToHashSet(StringComparer.OrdinalIgnoreCase);

        return Ok(new TemplateInventoryResponse
        {
            Count = items.Count,
            Templates = items,
            Missing = [.. requested.Where(c => !found.Contains(c))]
        });
    }
}

[ApiController]
[Route("api/health")]
public class HealthController(ApplicationDbContext db, IOptions<DeploymentSettings> deployment) : ControllerBase
{
    private readonly ApplicationDbContext _db = db;
    private readonly DeploymentSettings _deployment = deployment.Value;

    [HttpGet("")]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        try
        {
            await _db.Database.CanConnectAsync(ct);
            return Ok(new
            {
                status = "Healthy",
                timestamp = DateTimeOffset.UtcNow,
                service = _deployment.ServiceName,
                appRoot = _deployment.AppRoot,
                listenPort = _deployment.ListenPort
            });
        }
        catch
        {
            return StatusCode(503, new { status = "Unhealthy", timestamp = DateTimeOffset.UtcNow });
        }
    }
}
