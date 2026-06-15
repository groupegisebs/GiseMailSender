using System.Net;
using System.Net.Mail;
using System.Text.Json;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IEmailSenderService
{
    Task SendAsync(Guid emailMessageId, CancellationToken ct = default);
}

public class EmailSenderService(
    ApplicationDbContext db,
    IDataProtectionProvider dataProtection,
    IAuditService auditService,
    IHttpClientFactory httpClientFactory,
    ILogger<EmailSenderService> logger) : IEmailSenderService
{
    private readonly IDataProtector _protector = dataProtection.CreateProtector("SmtpPassword");

    public async Task SendAsync(Guid emailMessageId, CancellationToken ct = default)
    {
        var message = await db.EmailMessages
            .Include(m => m.Attachments)
            .FirstOrDefaultAsync(m => m.Id == emailMessageId, ct);

        if (message is null || message.Status is EmailStatus.Sent or EmailStatus.Cancelled)
            return;

        message.Status = EmailStatus.Sending;
        message.SendingAt = DateTimeOffset.UtcNow;
        await db.SaveChangesAsync(ct);

        var smtp = await db.SmtpConfigurations
            .Where(s => s.IsActive && s.IsDefault)
            .FirstOrDefaultAsync(ct)
            ?? await db.SmtpConfigurations.Where(s => s.IsActive).FirstOrDefaultAsync(ct);

        if (smtp is null)
        {
            await FailAsync(message, "No active SMTP configuration found.", ct);
            return;
        }

        try
        {
            using var mail = BuildMailMessage(message, smtp);
            using var client = new SmtpClient(smtp.Host, smtp.Port)
            {
                EnableSsl = smtp.UseSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 30000
            };

            if (!string.IsNullOrEmpty(smtp.Username))
            {
                var password = string.IsNullOrEmpty(smtp.PasswordEncrypted)
                    ? ""
                    : _protector.Unprotect(smtp.PasswordEncrypted);
                client.Credentials = new NetworkCredential(smtp.Username, password);
            }

            await client.SendMailAsync(mail, ct);

            message.Status = EmailStatus.Sent;
            message.SentAt = DateTimeOffset.UtcNow;
            message.SmtpResponse = "OK";

            db.EmailSendLogs.Add(new EmailSendLog
            {
                EmailMessageId = message.Id,
                EventType = "Sent",
                Message = "Email sent successfully"
            });

            await db.SaveChangesAsync(ct);

            if (message.SendingAt.HasValue && message.SentAt.HasValue)
            {
                var duration = (message.SentAt.Value - message.SendingAt.Value).TotalSeconds;
                MetricsRegistry.SendDuration.Observe(duration);
            }
            MetricsRegistry.EmailsSent.Inc();

            await auditService.LogAsync(AuditAction.EmailSent, clientId: message.ClientApplicationId,
                entityType: nameof(EmailMessage), entityId: message.Id.ToString(),
                details: new { message.MailCode });

            await NotifyCallbackAsync(message, ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send email {MailCode}", message.MailCode);
            await FailAsync(message, ex.Message, ct);
            await auditService.LogAsync(AuditAction.SmtpError, clientId: message.ClientApplicationId,
                entityType: nameof(EmailMessage), entityId: message.Id.ToString(),
                details: new { message.MailCode, Error = ex.Message });
        }
    }

    private MailMessage BuildMailMessage(EmailMessage msg, SmtpConfiguration smtp)
    {
        var mail = new MailMessage
        {
            From = new MailAddress(smtp.FromEmail, smtp.FromName ?? smtp.FromEmail),
            Subject = msg.Subject,
            Body = msg.HtmlBody,
            IsBodyHtml = true
        };

        if (!string.IsNullOrEmpty(msg.TextBody))
            mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(msg.TextBody, null, "text/plain"));

        AddAddresses(mail.To, msg.ToAddresses);
        if (msg.CcAddresses is not null) AddAddresses(mail.CC, msg.CcAddresses);
        if (msg.BccAddresses is not null) AddAddresses(mail.Bcc, msg.BccAddresses);

        foreach (var att in msg.Attachments)
        {
            var stream = new MemoryStream(att.Content);
            mail.Attachments.Add(new Attachment(stream, att.FileName, att.ContentType));
        }

        return mail;
    }

    private static void AddAddresses(MailAddressCollection collection, string json)
    {
        var addresses = JsonSerializer.Deserialize<List<string>>(json) ?? [];
        foreach (var addr in addresses)
            collection.Add(addr);
    }

    private async Task FailAsync(EmailMessage message, string error, CancellationToken ct)
    {
        message.Status = EmailStatus.Failed;
        message.FailedAt = DateTimeOffset.UtcNow;
        message.ErrorMessage = error;

        db.EmailSendLogs.Add(new EmailSendLog
        {
            EmailMessageId = message.Id,
            EventType = "Failed",
            Message = error
        });

        await db.SaveChangesAsync(ct);

        MetricsRegistry.EmailsFailed.Inc();

        await auditService.LogAsync(AuditAction.EmailFailed, clientId: message.ClientApplicationId,
            entityType: nameof(EmailMessage), entityId: message.Id.ToString(),
            details: new { message.MailCode, Error = error });

        await NotifyCallbackAsync(message, ct);
    }

    private async Task NotifyCallbackAsync(EmailMessage message, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(message.CallbackUrl)) return;

        try
        {
            var client = httpClientFactory.CreateClient("callback");
            var payload = JsonSerializer.Serialize(new
            {
                message.MailCode,
                trackingId = message.Id,
                status = message.Status.ToString(),
                message.SentAt,
                message.FailedAt,
                message.ErrorMessage
            });
            using var content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            await client.PostAsync(message.CallbackUrl, content, ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Callback failed for {MailCode}", message.MailCode);
        }
    }
}
