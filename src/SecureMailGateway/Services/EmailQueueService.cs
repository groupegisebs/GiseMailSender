using System.Net.Mail;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IEmailQueueService
{
    Task<SendMailResponse> QueueEmailAsync(SendMailRequest request, Guid clientId, string? ip, CancellationToken ct = default);
}

public partial class EmailQueueService(
    ApplicationDbContext db,
    IMailCodeGenerator mailCodeGenerator,
    ITemplateRenderer templateRenderer,
    IAuditService auditService,
    IBackgroundJobScheduler jobScheduler) : IEmailQueueService
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    public async Task<SendMailResponse> QueueEmailAsync(SendMailRequest request, Guid clientId, string? ip, CancellationToken ct = default)
    {
        var client = await db.ClientApplications.FindAsync([clientId], ct)
            ?? throw new InvalidOperationException("Client not found.");

        if (!client.IsActive)
            return Fail("Client application is disabled.");

        if (!string.Equals(client.ClientCode, request.ClientCode, StringComparison.OrdinalIgnoreCase))
            return Fail("Client code mismatch.");

        var requestedTemplateCode = request.TemplateCode.Trim().ToUpperInvariant();
        var template = await db.EmailTemplates
            .FirstOrDefaultAsync(t => t.TemplateCode == requestedTemplateCode, ct);

        if (template is null)
        {
            template = CreateAutoTemplate(requestedTemplateCode, client.ClientCode);
            db.EmailTemplates.Add(template);
            db.EmailTemplateVersions.Add(new EmailTemplateVersion
            {
                EmailTemplateId = template.Id,
                Version = 1,
                SubjectTemplate = template.SubjectTemplate,
                HtmlBody = template.HtmlBody,
                TextBody = template.TextBody,
                CreatedBy = "system:auto"
            });

            await db.SaveChangesAsync(ct);
            await auditService.LogAsync(
                AuditAction.TemplateCreated,
                userId: "system:auto",
                clientId: clientId,
                entityType: nameof(EmailTemplate),
                entityId: template.Id.ToString(),
                ipAddress: ip,
                details: new
                {
                    template.TemplateCode,
                    Reason = "Auto-created from first API send call"
                },
                ct: ct);
        }
        else if (!template.IsActive)
        {
            return Fail($"Template '{requestedTemplateCode}' is inactive.");
        }

        if (!await CheckQuotaAsync(client, ct))
            return Fail("Quota exceeded.");

        var allRecipients = request.To.Concat(request.Cc ?? []).Concat(request.Bcc ?? []).ToList();
        if (!ValidateRecipients(allRecipients, client))
            return Fail("Invalid or unauthorized recipient domain.");

        var mergedData = MergeTemplateData(request.SubjectData, request.BodyData);
        var requiredVariables = templateRenderer.ExtractVariables(
            template.SubjectTemplate,
            template.HtmlBody,
            template.TextBody);
        var missingVariables = requiredVariables
            .Where(variable => !mergedData.TryGetValue(variable, out var value) || string.IsNullOrWhiteSpace(value))
            .ToList();

        if (missingVariables.Count > 0)
            return Fail(BuildMissingVariablesError(requiredVariables, missingVariables));

        var subject = templateRenderer.Render(template.SubjectTemplate, mergedData);
        var html = templateRenderer.SanitizeHtml(templateRenderer.Render(template.HtmlBody, mergedData));
        var text = template.TextBody is not null
            ? templateRenderer.Render(template.TextBody, mergedData)
            : null;

        var mailCode = await mailCodeGenerator.GenerateAsync(ct);
        var message = new EmailMessage
        {
            MailCode = mailCode,
            ClientApplicationId = clientId,
            EmailTemplateId = template.Id,
            TemplateCode = template.TemplateCode,
            ToAddresses = JsonSerializer.Serialize(request.To),
            CcAddresses = request.Cc is { Count: > 0 } ? JsonSerializer.Serialize(request.Cc) : null,
            BccAddresses = request.Bcc is { Count: > 0 } ? JsonSerializer.Serialize(request.Bcc) : null,
            Subject = subject,
            HtmlBody = html,
            TextBody = text,
            Status = EmailStatus.Queued,
            Priority = request.Priority,
            CallbackUrl = request.CallbackUrl
        };

        if (request.Attachments is { Count: > 0 })
        {
            foreach (var att in request.Attachments)
            {
                var bytes = Convert.FromBase64String(att.Base64Content);
                if (bytes.Length > 10 * 1024 * 1024)
                    return Fail("Attachment exceeds 10 MB limit.");

                message.Attachments.Add(new EmailAttachment
                {
                    FileName = att.FileName,
                    ContentType = att.ContentType,
                    Content = bytes,
                    SizeBytes = bytes.Length
                });
            }
        }

        db.EmailMessages.Add(message);
        db.EmailSendLogs.Add(new EmailSendLog
        {
            EmailMessageId = message.Id,
            EventType = "Queued",
            Message = "Email queued for delivery"
        });
        await db.SaveChangesAsync(ct);

        await auditService.LogAsync(AuditAction.EmailQueued, clientId: clientId,
            entityType: nameof(EmailMessage), entityId: message.Id.ToString(),
            ipAddress: ip, details: new { message.MailCode, request.TemplateCode });

        jobScheduler.EnqueueSend(message.Id);

        return new SendMailResponse
        {
            Success = true,
            MailCode = mailCode,
            TrackingId = message.Id,
            Status = EmailStatus.Queued.ToString()
        };
    }

    private async Task<bool> CheckQuotaAsync(ClientApplication client, CancellationToken ct)
    {
        var today = DateTimeOffset.UtcNow.Date;
        var monthStart = new DateTimeOffset(today.Year, today.Month, 1, 0, 0, 0, TimeSpan.Zero);

        var dailyCount = await db.EmailMessages
            .CountAsync(m => m.ClientApplicationId == client.Id && m.QueuedAt >= today, ct);

        if (dailyCount >= client.DailyQuota) return false;

        var monthlyCount = await db.EmailMessages
            .CountAsync(m => m.ClientApplicationId == client.Id && m.QueuedAt >= monthStart, ct);

        return monthlyCount < client.MonthlyQuota;
    }

    private static Dictionary<string, string> MergeTemplateData(
        Dictionary<string, string>? subjectData,
        Dictionary<string, string>? bodyData)
    {
        var merged = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (subjectData is not null)
        {
            foreach (var kv in subjectData)
            {
                if (string.IsNullOrWhiteSpace(kv.Key)) continue;
                merged[kv.Key] = kv.Value;
            }
        }

        if (bodyData is not null)
        {
            foreach (var kv in bodyData)
            {
                if (string.IsNullOrWhiteSpace(kv.Key)) continue;
                merged[kv.Key] = kv.Value;
            }
        }

        return merged;
    }

    private static string BuildMissingVariablesError(List<string> requiredVariables, List<string> missingVariables)
    {
        var requiredList = string.Join(", ", requiredVariables);
        var missingList = string.Join(", ", missingVariables);
        return $"Missing required template variables. Required: [{requiredList}]. Missing or empty: [{missingList}]. Provide values in subjectData/bodyData.";
    }

    private static bool ValidateRecipients(List<string> recipients, ClientApplication client)
    {
        if (recipients.Count == 0) return false;

        var allowAll = ClientApplicationDomainRules.AllowsAllDomains(client.AllowedDomains);
        var allowedDomains = ClientApplicationDomainRules.ParseAllowedDomains(client.AllowedDomains);

        foreach (var email in recipients)
        {
            if (!EmailRegex().IsMatch(email)) return false;
            if (allowAll) continue;

            var domain = email.Split('@').Last().ToLowerInvariant();
            if (!allowedDomains.Contains(domain)) return false;
        }

        return true;
    }

    private static EmailTemplate CreateAutoTemplate(string templateCode, string clientCode) => new()
    {
        TemplateCode = templateCode,
        Name = $"AUTO - {clientCode} - {templateCode}",
        SubjectTemplate = $"[{clientCode}] Notification {templateCode}",
        HtmlBody = $"""
            <div style="font-family:Arial,sans-serif;line-height:1.5;color:#222;">
              <h2>Template auto-cree: {templateCode}</h2>
              <p>Ce template a ete cree automatiquement lors du premier appel API.</p>
              <p>Editez-le dans l'interface d'administration (menu Templates) pour definir le contenu final.</p>
            </div>
            """,
        TextBody = $"Template auto-cree: {templateCode}. Editez ce template dans l'interface d'administration.",
        Language = "fr",
        IsActive = true
    };

    private static SendMailResponse Fail(string error) => new() { Success = false, Error = error };
}
