using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Middleware;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;

namespace SecureMailGateway.Controllers.Api;

/// <summary>
/// Canal WhatsApp de la passerelle. Mêmes clés d'API, quotas et journaux que /api/mail :
/// une application peut ainsi joindre un destinataire sans adresse électronique.
/// </summary>
[ApiController]
[Route("api/whatsapp")]
public class WhatsAppController(
    IWhatsAppQueueService queueService,
    IWhatsAppSettingsProvider settingsProvider,
    ApplicationDbContext db) : ControllerBase
{
    [HttpPost("send")]
    public async Task<ActionResult<SendWhatsAppResponse>> Send(
        [FromBody] SendWhatsAppRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new SendWhatsAppResponse { Success = false, Error = "Requête invalide." });

        if (Client is not { } client)
            return Unauthorized(new SendWhatsAppResponse { Success = false, Error = "Unauthorized." });

        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        var result = await queueService.QueueAsync(request, client.Id, ip, ct);

        MetricsRegistry.ApiCalls.WithLabels(client.ClientCode, result.Success ? "success" : "error").Inc();

        return result.Success ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Suivi d'un message après sa mise en file. La remise et la lecture n'arrivent que plus tard,
    /// par webhook de l'opérateur : seul ce point d'entrée les rend visibles.
    /// </summary>
    [HttpGet("status/{messageCode}")]
    public async Task<ActionResult<WhatsAppStatusResponse>> Status(string messageCode, CancellationToken ct)
    {
        if (Client is not { } client)
            return Unauthorized(new { error = "Unauthorized." });

        var normalized = messageCode.Trim();
        var message = await db.WhatsAppMessages
            .AsNoTracking()
            .Include(m => m.SendLogs)
            .FirstOrDefaultAsync(m => m.MessageCode == normalized && m.ClientApplicationId == client.Id, ct);

        if (message is null)
            return NotFound(new { error = $"Message « {normalized} » introuvable pour le client « {client.ClientCode} »." });

        return Ok(new WhatsAppStatusResponse
        {
            MessageCode = message.MessageCode,
            TrackingId = message.Id,
            Status = message.Status.ToString(),
            To = message.ToPhone,
            TemplateCode = message.TemplateCode,
            MetaTemplateName = message.MetaTemplateName,
            Language = message.Language,
            Kind = message.Kind.ToString(),
            BodyPreview = message.BodyPreview,
            ProviderMessageId = message.ProviderMessageId,
            RetryCount = message.RetryCount,
            QueuedAt = message.QueuedAt,
            SentAt = message.SentAt,
            DeliveredAt = message.DeliveredAt,
            ReadAt = message.ReadAt,
            FailedAt = message.FailedAt,
            ErrorMessage = message.ErrorMessage,
            ErrorCode = message.ErrorCode,
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

    /// <summary>Correspondances visibles par l'application : les siennes et celles partagées.</summary>
    [HttpGet("templates")]
    public async Task<ActionResult<WhatsAppTemplateListResponse>> Templates(
        [FromQuery] string? codes, CancellationToken ct)
    {
        if (Client is not { } client)
            return Unauthorized(new { error = "Unauthorized." });

        var requested = (codes ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(c => c.ToUpperInvariant())
            .Distinct()
            .ToList();

        var query = db.WhatsAppTemplates
            .AsNoTracking()
            .Where(t => t.ClientApplicationId == client.Id || t.ClientApplicationId == null);

        if (requested.Count > 0)
            query = query.Where(t => requested.Contains(t.TemplateCode));

        var rows = await query
            .OrderBy(t => t.TemplateCode)
            .ThenBy(t => t.Language)
            .ToListAsync(ct);

        var items = rows.Select(t => ToDto(t, client.Id)).ToList();
        var found = items.Select(i => i.TemplateCode).ToHashSet(StringComparer.OrdinalIgnoreCase);

        return Ok(new WhatsAppTemplateListResponse
        {
            Count = items.Count,
            Templates = items,
            Missing = [.. requested.Where(c => !found.Contains(c))]
        });
    }

    /// <summary>
    /// Déclare ou met à jour la correspondance entre un code fonctionnel et un modèle approuvé
    /// chez Meta, avec l'ordre des variables. Elle appartient à l'application appelante.
    /// </summary>
    [HttpPost("templates")]
    public async Task<ActionResult<WhatsAppTemplateDto>> UpsertTemplate(
        [FromBody] UpsertWhatsAppTemplateRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { error = "Requête invalide." });

        if (Client is not { } client)
            return Unauthorized(new { error = "Unauthorized." });

        var code = request.TemplateCode.Trim().ToUpperInvariant();
        var language = string.IsNullOrWhiteSpace(request.Language) ? "fr" : request.Language.Trim();

        var row = await db.WhatsAppTemplates.FirstOrDefaultAsync(
            t => t.TemplateCode == code && t.Language == language && t.ClientApplicationId == client.Id, ct);

        if (row is null)
        {
            row = new WhatsAppTemplate
            {
                TemplateCode = code,
                Language = language,
                ClientApplicationId = client.Id
            };
            db.WhatsAppTemplates.Add(row);
        }

        row.MetaTemplateName = request.MetaTemplateName.Trim();
        row.MetaLanguageCode = string.IsNullOrWhiteSpace(request.MetaLanguageCode)
            ? language
            : request.MetaLanguageCode.Trim();
        row.BodyParameters = Join(request.BodyParameters);
        row.HeaderParameters = Join(request.HeaderParameters);
        row.ButtonUrlParameter = string.IsNullOrWhiteSpace(request.ButtonUrlParameter)
            ? null
            : request.ButtonUrlParameter.Trim();
        row.PreviewText = request.PreviewText;
        row.IsActive = request.IsActive;
        row.UpdatedAt = DateTimeOffset.UtcNow;

        await db.SaveChangesAsync(ct);

        return Ok(ToDto(row, client.Id));
    }

    [HttpDelete("templates/{templateCode}")]
    public async Task<IActionResult> DeleteTemplate(
        string templateCode, [FromQuery] string? language, CancellationToken ct)
    {
        if (Client is not { } client)
            return Unauthorized(new { error = "Unauthorized." });

        var code = templateCode.Trim().ToUpperInvariant();
        var lang = string.IsNullOrWhiteSpace(language) ? "fr" : language.Trim();

        var row = await db.WhatsAppTemplates.FirstOrDefaultAsync(
            t => t.TemplateCode == code && t.Language == lang && t.ClientApplicationId == client.Id, ct);

        if (row is null)
            return NotFound(new { error = $"Aucune correspondance « {code} » ({lang}) pour cette application." });

        db.WhatsAppTemplates.Remove(row);
        await db.SaveChangesAsync(ct);
        return NoContent();
    }

    /// <summary>Messages reçus des destinataires : ils ouvrent la fenêtre de 24 h du texte libre.</summary>
    [HttpGet("inbound")]
    public async Task<IActionResult> Inbound(
        [FromQuery] string? from, [FromQuery] int hours = 24, [FromQuery] int limit = 50, CancellationToken ct = default)
    {
        if (Client is null)
            return Unauthorized(new { error = "Unauthorized." });

        var since = DateTimeOffset.UtcNow.AddHours(-Math.Clamp(hours, 1, 24 * 30));
        var take = Math.Clamp(limit, 1, 200);

        var query = db.WhatsAppInboundMessages.AsNoTracking().Where(m => m.ReceivedAt >= since);

        if (!string.IsNullOrWhiteSpace(from))
        {
            var digits = new string(from.Where(char.IsDigit).ToArray());
            query = query.Where(m => m.FromPhone == digits);
        }

        var items = await query
            .OrderByDescending(m => m.ReceivedAt)
            .Take(take)
            .Select(m => new
            {
                m.FromPhone,
                m.ProfileName,
                m.MessageType,
                m.Text,
                m.ReceivedAt
            })
            .ToListAsync(ct);

        return Ok(new { count = items.Count, since, messages = items });
    }

    /// <summary>État de configuration du canal, sans exposer de secret : à appeler avant de déboguer un envoi.</summary>
    [HttpGet("diagnostics")]
    public async Task<ActionResult<WhatsAppDiagnosticsResponse>> Diagnostics(CancellationToken ct)
    {
        if (Client is null)
            return Unauthorized(new { error = "Unauthorized." });

        var settings = await settingsProvider.GetAsync(ct);
        var response = new WhatsAppDiagnosticsResponse
        {
            Configured = settings.IsUsable,
            Provider = "MetaCloud",
            PhoneNumberIdMasked = Mask(settings.PhoneNumberId),
            DisplayPhoneNumber = settings.DisplayPhoneNumber,
            ApiVersion = settings.ApiVersion,
            DefaultCountryCode = settings.DefaultCountryCode,
            WebhookVerifyTokenSet = !string.IsNullOrWhiteSpace(settings.WebhookVerifyToken),
            AppSecretSet = !string.IsNullOrWhiteSpace(settings.AppSecret),
            Source = settings.Source
        };

        if (string.IsNullOrWhiteSpace(settings.PhoneNumberId))
            response.Problems.Add("Numéro expéditeur (PhoneNumberId) non configuré.");
        if (string.IsNullOrWhiteSpace(settings.AccessToken))
            response.Problems.Add("Jeton d'accès non configuré.");
        if (!response.WebhookVerifyTokenSet)
            response.Problems.Add("Jeton de vérification du webhook absent : les statuts de remise ne remonteront pas.");
        if (!response.AppSecretSet)
            response.Problems.Add("Secret d'application absent : la signature des webhooks n'est pas vérifiée.");

        return Ok(response);
    }

    private ClientApplication? Client =>
        HttpContext.Items.TryGetValue(ApiClientContext.ItemKey, out var obj) && obj is ClientApplication client
            ? client
            : null;

    private static WhatsAppTemplateDto ToDto(WhatsAppTemplate t, Guid clientId) => new()
    {
        TemplateCode = t.TemplateCode,
        Language = t.Language,
        MetaTemplateName = t.MetaTemplateName,
        MetaLanguageCode = t.MetaLanguageCode,
        BodyParameters = WhatsAppTemplate.SplitParameters(t.BodyParameters),
        HeaderParameters = WhatsAppTemplate.SplitParameters(t.HeaderParameters),
        ButtonUrlParameter = t.ButtonUrlParameter,
        PreviewText = t.PreviewText,
        IsActive = t.IsActive,
        IsClientSpecific = t.ClientApplicationId == clientId,
        UpdatedAt = t.UpdatedAt
    };

    private static string? Join(List<string>? values) =>
        values is { Count: > 0 }
            ? string.Join(',', values.Select(v => v.Trim()).Where(v => v.Length > 0))
            : null;

    private static string? Mask(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        return value.Length <= 4 ? new string('•', value.Length) : new string('•', value.Length - 4) + value[^4..];
    }
}

/// <summary>
/// Point d'entrée appelé par Meta : ni clé d'API ni session, l'authenticité repose sur le jeton
/// de vérification puis sur la signature HMAC du corps de la requête.
/// </summary>
[ApiController]
[Route("api/whatsapp/webhook")]
public class WhatsAppWebhookController(
    IWhatsAppWebhookService webhookService,
    ILogger<WhatsAppWebhookController> logger) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Verify(
        [FromQuery(Name = "hub.mode")] string? mode,
        [FromQuery(Name = "hub.verify_token")] string? verifyToken,
        [FromQuery(Name = "hub.challenge")] string? challenge,
        CancellationToken ct)
    {
        if (!string.Equals(mode, "subscribe", StringComparison.OrdinalIgnoreCase))
            return BadRequest(new { error = "hub.mode attendu : subscribe." });

        if (!await webhookService.VerifyTokenAsync(verifyToken, ct))
        {
            logger.LogWarning("Vérification de webhook WhatsApp refusée : jeton incorrect.");
            return StatusCode(StatusCodes.Status403Forbidden, new { error = "Jeton de vérification incorrect." });
        }

        return Content(challenge ?? string.Empty, "text/plain");
    }

    [HttpPost("")]
    public async Task<IActionResult> Receive(CancellationToken ct)
    {
        using var reader = new StreamReader(Request.Body);
        var rawBody = await reader.ReadToEndAsync(ct);

        var signature = Request.Headers["X-Hub-Signature-256"].ToString();
        if (!await webhookService.VerifySignatureAsync(signature, rawBody, ct))
        {
            logger.LogWarning("Webhook WhatsApp rejeté : signature invalide.");
            return Unauthorized();
        }

        var result = await webhookService.ProcessAsync(rawBody, ct);

        // Toujours répondre 200 : un autre code pousse Meta à rejouer la notification en boucle.
        return Ok(new { statuses = result.StatusUpdates, inbound = result.InboundMessages });
    }
}
