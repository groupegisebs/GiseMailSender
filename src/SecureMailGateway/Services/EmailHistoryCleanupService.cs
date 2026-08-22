using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IEmailHistoryCleanupService
{
    Task<int> PurgeExpiredAsync(CancellationToken ct = default);

    Task<int> PurgeOlderThanAsync(int olderThanDays, CancellationToken ct = default);
}

public sealed class EmailHistoryCleanupService(
    ApplicationDbContext db,
    IOptions<MailHistoryOptions> options,
    IAuditService auditService,
    ILogger<EmailHistoryCleanupService> logger) : IEmailHistoryCleanupService
{
    private static readonly EmailStatus[] Purgeable =
    [
        EmailStatus.Sent,
        EmailStatus.Failed,
        EmailStatus.Cancelled
    ];

    public Task<int> PurgeExpiredAsync(CancellationToken ct = default)
    {
        var opt = options.Value;
        if (!opt.Enabled)
            return Task.FromResult(0);
        return PurgeOlderThanAsync(opt.RetentionDays, ct);
    }

    public async Task<int> PurgeOlderThanAsync(int olderThanDays, CancellationToken ct = default)
    {
        var days = Math.Max(1, olderThanDays);
        var cutoff = DateTimeOffset.UtcNow.AddDays(-days);
        var batchSize = Math.Clamp(options.Value.BatchSize, 50, 1000);
        var total = 0;

        while (true)
        {
            ct.ThrowIfCancellationRequested();

            var ids = await db.EmailMessages
                .Where(m => Purgeable.Contains(m.Status)
                            && (m.SentAt ?? m.FailedAt ?? m.QueuedAt) < cutoff)
                .OrderBy(m => m.QueuedAt)
                .Select(m => m.Id)
                .Take(batchSize)
                .ToListAsync(ct);

            if (ids.Count == 0)
                break;

            await db.EmailSendLogs.Where(l => ids.Contains(l.EmailMessageId)).ExecuteDeleteAsync(ct);
            await db.EmailAttachments.Where(a => ids.Contains(a.EmailMessageId)).ExecuteDeleteAsync(ct);
            var deleted = await db.EmailMessages.Where(m => ids.Contains(m.Id)).ExecuteDeleteAsync(ct);
            total += deleted;

            if (deleted < batchSize)
                break;
        }

        if (total > 0)
        {
            logger.LogInformation(
                "Purged {Count} e-mail history row(s) older than {Days} days (cutoff {Cutoff:u}).",
                total, days, cutoff);
            await auditService.LogAsync(
                AuditAction.EmailHistoryPurged,
                userId: "system",
                entityType: nameof(Models.Entities.EmailMessage),
                details: new { total, days, cutoff },
                ct: ct);
        }

        return total;
    }
}
