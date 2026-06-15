using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IDashboardService
{
    Task<DashboardStats> GetStatsAsync(CancellationToken ct = default);
}

public record DashboardStats(
    int Queued,
    int Sending,
    int SentToday,
    int FailedToday,
    int TotalClients,
    int ActiveTemplates,
    double AvgSendTimeMs,
    List<ClientApiStats> ApiCallsByClient);

public record ClientApiStats(string ClientCode, string Name, int CallCount);

public class DashboardService(ApplicationDbContext db) : IDashboardService
{
    public async Task<DashboardStats> GetStatsAsync(CancellationToken ct = default)
    {
        var today = DateTimeOffset.UtcNow.Date;

        var queued = await db.EmailMessages.CountAsync(m => m.Status == EmailStatus.Queued, ct);
        var sending = await db.EmailMessages.CountAsync(m => m.Status == EmailStatus.Sending, ct);
        var sentToday = await db.EmailMessages.CountAsync(m => m.Status == EmailStatus.Sent && m.SentAt >= today, ct);
        var failedToday = await db.EmailMessages.CountAsync(m => m.Status == EmailStatus.Failed && m.FailedAt >= today, ct);

        var avgSend = await db.EmailMessages
            .Where(m => m.Status == EmailStatus.Sent && m.SentAt != null && m.SendingAt != null)
            .Select(m => (m.SentAt!.Value - m.SendingAt!.Value).TotalMilliseconds)
            .DefaultIfEmpty(0)
            .AverageAsync(ct);

        var apiCalls = await db.ApiCallLogs
            .Where(l => l.CreatedAt >= today && l.ClientApplicationId != null)
            .GroupBy(l => l.ClientApplicationId)
            .Select(g => new { ClientId = g.Key, Count = g.Count() })
            .ToListAsync(ct);

        var clientIds = apiCalls.Select(a => a.ClientId!.Value).ToList();
        var clients = await db.ClientApplications
            .Where(c => clientIds.Contains(c.Id))
            .ToDictionaryAsync(c => c.Id, ct);

        var apiStats = apiCalls.Select(a =>
        {
            var c = clients.GetValueOrDefault(a.ClientId!.Value);
            return new ClientApiStats(c?.ClientCode ?? "?", c?.Name ?? "?", a.Count);
        }).ToList();

        return new DashboardStats(
            queued, sending, sentToday, failedToday,
            await db.ClientApplications.CountAsync(ct),
            await db.EmailTemplates.CountAsync(t => t.IsActive, ct),
            avgSend, apiStats);
    }
}
