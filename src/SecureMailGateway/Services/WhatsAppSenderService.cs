using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IWhatsAppSenderService
{
    Task SendAsync(Guid whatsAppMessageId, CancellationToken ct = default);
}

public class WhatsAppSenderService(
    ApplicationDbContext db,
    IWhatsAppProvider provider,
    IWhatsAppSettingsProvider settingsProvider,
    IAuditService auditService,
    IBackgroundJobScheduler jobScheduler,
    IWhatsAppCallbackNotifier callbackNotifier,
    ILogger<WhatsAppSenderService> logger) : IWhatsAppSenderService
{
    /// <summary>Attente avant chaque nouvelle tentative : le pas grandit pour laisser passer un incident.</summary>
    private static readonly TimeSpan[] Backoff =
    [
        TimeSpan.FromMinutes(1),
        TimeSpan.FromMinutes(5),
        TimeSpan.FromMinutes(15),
        TimeSpan.FromHours(1)
    ];

    public async Task SendAsync(Guid whatsAppMessageId, CancellationToken ct = default)
    {
        var message = await db.WhatsAppMessages
            .Include(m => m.ClientApplication)
            .FirstOrDefaultAsync(m => m.Id == whatsAppMessageId, ct);

        if (message is null)
            return;

        // Un webhook de remise peut arriver avant la reprise du job : ne jamais réexpédier.
        if (message.Status is WhatsAppStatus.Sent or WhatsAppStatus.Delivered
            or WhatsAppStatus.Read or WhatsAppStatus.Cancelled)
            return;

        message.Status = WhatsAppStatus.Sending;
        message.SendingAt = DateTimeOffset.UtcNow;
        await db.SaveChangesAsync(ct);

        var settings = await settingsProvider.GetAsync(ct);
        var outcome = await provider.SendAsync(settings, message.PayloadJson, ct);

        if (outcome.Success)
        {
            message.Status = WhatsAppStatus.Sent;
            message.SentAt = DateTimeOffset.UtcNow;
            message.ProviderMessageId = outcome.ProviderMessageId;
            message.RecipientWaId = outcome.RecipientWaId;
            message.ProviderResponse = outcome.RawResponse;
            message.ErrorMessage = null;
            message.ErrorCode = null;

            db.WhatsAppSendLogs.Add(new WhatsAppSendLog
            {
                WhatsAppMessageId = message.Id,
                EventType = "Sent",
                Message = $"Accepté par l'opérateur ({provider.Name})",
                Details = outcome.ProviderMessageId
            });

            await db.SaveChangesAsync(ct);

            if (message.SendingAt.HasValue && message.SentAt.HasValue)
                MetricsRegistry.WhatsAppSendDuration.Observe((message.SentAt.Value - message.SendingAt.Value).TotalSeconds);
            MetricsRegistry.WhatsAppSent.Inc();

            await auditService.LogAsync(AuditAction.WhatsAppSent, clientId: message.ClientApplicationId,
                entityType: nameof(WhatsAppMessage), entityId: message.Id.ToString(),
                details: new { message.MessageCode, message.ProviderMessageId }, ct: ct);

            await NotifyCallbackAsync(message, ct);
            return;
        }

        var canRetry = outcome.Transient && message.RetryCount < Math.Max(0, settings.MaxRetries);
        if (canRetry)
        {
            var delay = Backoff[Math.Min(message.RetryCount, Backoff.Length - 1)];
            message.RetryCount++;
            message.Status = WhatsAppStatus.Queued;
            message.ErrorMessage = Truncate(outcome.Error, 2000);
            message.ErrorCode = outcome.ErrorCode;
            message.ProviderResponse = outcome.RawResponse;

            db.WhatsAppSendLogs.Add(new WhatsAppSendLog
            {
                WhatsAppMessageId = message.Id,
                EventType = "Retry",
                Message = $"Tentative {message.RetryCount} dans {delay.TotalMinutes:0} min : {outcome.Error}"
            });

            await db.SaveChangesAsync(ct);

            logger.LogWarning("Envoi WhatsApp {Code} différé (tentative {Attempt}) : {Error}",
                message.MessageCode, message.RetryCount, outcome.Error);

            jobScheduler.ScheduleWhatsAppRetry(message.Id, delay);
            return;
        }

        await FailAsync(message, outcome, ct);
    }

    private async Task FailAsync(WhatsAppMessage message, WhatsAppSendOutcome outcome, CancellationToken ct)
    {
        message.Status = WhatsAppStatus.Failed;
        message.FailedAt = DateTimeOffset.UtcNow;
        message.ErrorMessage = Truncate(outcome.Error, 2000);
        message.ErrorCode = outcome.ErrorCode;
        message.ProviderResponse = outcome.RawResponse;

        db.WhatsAppSendLogs.Add(new WhatsAppSendLog
        {
            WhatsAppMessageId = message.Id,
            EventType = "Failed",
            Message = Truncate(outcome.Error, 2000),
            Details = outcome.RawResponse
        });

        await db.SaveChangesAsync(ct);

        MetricsRegistry.WhatsAppFailed.Inc();

        logger.LogError("Envoi WhatsApp {Code} en échec : {Error}", message.MessageCode, outcome.Error);

        await auditService.LogAsync(AuditAction.WhatsAppFailed, clientId: message.ClientApplicationId,
            entityType: nameof(WhatsAppMessage), entityId: message.Id.ToString(),
            details: new { message.MessageCode, Error = outcome.Error, outcome.ErrorCode }, ct: ct);

        await NotifyCallbackAsync(message, ct);
    }

    private Task NotifyCallbackAsync(WhatsAppMessage message, CancellationToken ct) =>
        callbackNotifier.NotifyAsync(message, ct);

    private static string? Truncate(string? value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= max ? value : value[..max];
    }
}
