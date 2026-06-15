using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IAuditService
{
    Task LogAsync(AuditAction action, string? userId = null, Guid? clientId = null,
        string? entityType = null, string? entityId = null,
        string? ipAddress = null, string? userAgent = null, object? details = null,
        CancellationToken ct = default);
}

public class AuditService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) : IAuditService
{
    public async Task LogAsync(AuditAction action, string? userId = null, Guid? clientId = null,
        string? entityType = null, string? entityId = null,
        string? ipAddress = null, string? userAgent = null, object? details = null,
        CancellationToken ct = default)
    {
        var ctx = httpContextAccessor.HttpContext;
        ipAddress ??= ctx?.Connection.RemoteIpAddress?.ToString();
        userAgent ??= ctx?.Request.Headers.UserAgent.ToString();

        db.AuditLogs.Add(new AuditLog
        {
            UserId = userId,
            ClientApplicationId = clientId,
            Action = action,
            EntityType = entityType,
            EntityId = entityId,
            IpAddress = ipAddress,
            UserAgent = userAgent,
            Details = details is not null ? JsonSerializer.Serialize(details) : null
        });

        await db.SaveChangesAsync(ct);
    }
}

public interface IApiCallLogService
{
    Task LogAsync(Guid? clientId, string method, string path, int statusCode,
        long durationMs, string? requestSummary = null, string? responseSummary = null,
        CancellationToken ct = default);
}

public class ApiCallLogService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) : IApiCallLogService
{
    public async Task LogAsync(Guid? clientId, string method, string path, int statusCode,
        long durationMs, string? requestSummary = null, string? responseSummary = null,
        CancellationToken ct = default)
    {
        var ctx = httpContextAccessor.HttpContext;
        db.ApiCallLogs.Add(new ApiCallLog
        {
            ClientApplicationId = clientId,
            HttpMethod = method,
            Path = path,
            StatusCode = statusCode,
            DurationMs = durationMs,
            IpAddress = ctx?.Connection.RemoteIpAddress?.ToString(),
            UserAgent = ctx?.Request.Headers.UserAgent.ToString(),
            RequestSummary = requestSummary,
            ResponseSummary = responseSummary
        });
        await db.SaveChangesAsync(ct);
    }
}
