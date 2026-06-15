using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

public interface IApiTokenService
{
    Task<(ApiToken Entity, string PlainToken)> CreateTokenAsync(Guid clientId, string name, DateTimeOffset? expiresAt, CancellationToken ct = default);
    Task<(ApiToken Entity, string PlainToken)?> RotateTokenAsync(Guid tokenId, CancellationToken ct = default);
    Task<ApiToken?> ValidateTokenAsync(string plainToken, string? ipAddress, CancellationToken ct = default);
}

public class ApiTokenService(
    ApplicationDbContext db,
    ITokenHashService hashService,
    IAuditService auditService) : IApiTokenService
{
    public async Task<(ApiToken Entity, string PlainToken)> CreateTokenAsync(
        Guid clientId, string name, DateTimeOffset? expiresAt, CancellationToken ct = default)
    {
        var plain = hashService.GenerateToken();
        var token = new ApiToken
        {
            ClientApplicationId = clientId,
            Name = name,
            TokenHash = hashService.HashToken(plain),
            TokenPrefix = hashService.GetPrefix(plain),
            ExpiresAt = expiresAt
        };

        db.ApiTokens.Add(token);
        await db.SaveChangesAsync(ct);

        await auditService.LogAsync(Models.Enums.AuditAction.TokenCreated,
            clientId: clientId, entityType: nameof(ApiToken), entityId: token.Id.ToString(),
            details: new { token.Name, token.TokenPrefix });

        return (token, plain);
    }

    public async Task<(ApiToken Entity, string PlainToken)?> RotateTokenAsync(Guid tokenId, CancellationToken ct = default)
    {
        var token = await db.ApiTokens.FindAsync([tokenId], ct);
        if (token is null) return null;

        var plain = hashService.GenerateToken();
        token.TokenHash = hashService.HashToken(plain);
        token.TokenPrefix = hashService.GetPrefix(plain);
        token.RotatedAt = DateTimeOffset.UtcNow;
        token.IsActive = true;
        await db.SaveChangesAsync(ct);

        await auditService.LogAsync(Models.Enums.AuditAction.TokenRotated,
            clientId: token.ClientApplicationId, entityType: nameof(ApiToken), entityId: token.Id.ToString());

        return (token, plain);
    }

    public async Task<ApiToken?> ValidateTokenAsync(string plainToken, string? ipAddress, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(plainToken)) return null;

        var prefix = hashService.GetPrefix(plainToken);
        var candidates = await db.ApiTokens
            .Include(t => t.ClientApplication)
            .Where(t => t.IsActive && t.TokenPrefix == prefix)
            .ToListAsync(ct);

        foreach (var token in candidates)
        {
            if (!hashService.VerifyToken(plainToken, token.TokenHash)) continue;
            if (token.ExpiresAt.HasValue && token.ExpiresAt < DateTimeOffset.UtcNow) continue;

            var client = token.ClientApplication;
            if (!client.IsActive) return null;

            if (!string.IsNullOrWhiteSpace(client.AllowedIpAddresses) && ipAddress is not null)
            {
                var allowed = client.AllowedIpAddresses
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (!allowed.Contains(ipAddress)) return null;
            }

            token.LastUsedAt = DateTimeOffset.UtcNow;
            await db.SaveChangesAsync(ct);
            return token;
        }

        return null;
    }
}
