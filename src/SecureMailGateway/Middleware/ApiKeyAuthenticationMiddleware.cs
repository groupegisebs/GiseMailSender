using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Middleware;

public static class ApiClientContext
{
    public const string ItemKey = "ApiClient";
}

public class ApiKeyAuthenticationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, Services.IApiTokenService tokenService, Services.IAuditService auditService)
    {
        if (!context.Request.Path.StartsWithSegments("/api"))
        {
            await next(context);
            return;
        }

        if (context.Request.Path.StartsWithSegments("/api/health") ||
            context.Request.Path.StartsWithSegments("/health") ||
            context.Request.Path.StartsWithSegments("/metrics"))
        {
            await next(context);
            return;
        }

        var token = ExtractToken(context);
        if (token is null)
        {
            await auditService.LogAsync(Models.Enums.AuditAction.UnauthorizedAttempt,
                ipAddress: context.Connection.RemoteIpAddress?.ToString(),
                details: new { Path = context.Request.Path.Value, Reason = "Missing token" });
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { error = "API key required. Use Authorization: Bearer <token> or X-Api-Key header." });
            return;
        }

        var ip = context.Connection.RemoteIpAddress?.ToString();
        var apiToken = await tokenService.ValidateTokenAsync(token, ip);
        if (apiToken is null)
        {
            await auditService.LogAsync(Models.Enums.AuditAction.UnauthorizedAttempt,
                ipAddress: ip, details: new { Path = context.Request.Path.Value, Reason = "Invalid token" });
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { error = "Invalid or expired API key." });
            return;
        }

        context.Items[ApiClientContext.ItemKey] = apiToken.ClientApplication;
        await next(context);
    }

    private static string? ExtractToken(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey) && !string.IsNullOrWhiteSpace(apiKey))
            return apiKey.ToString();

        var auth = context.Request.Headers.Authorization.ToString();
        if (auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return auth["Bearer ".Length..].Trim();

        return null;
    }
}
