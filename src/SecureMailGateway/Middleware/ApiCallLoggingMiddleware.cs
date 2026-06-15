using System.Diagnostics;
using SecureMailGateway.Middleware;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Middleware;

public class ApiCallLoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, Services.IApiCallLogService logService)
    {
        if (!context.Request.Path.StartsWithSegments("/api"))
        {
            await next(context);
            return;
        }

        var sw = Stopwatch.StartNew();
        await next(context);
        sw.Stop();

        Guid? clientId = null;
        if (context.Items.TryGetValue(ApiClientContext.ItemKey, out var clientObj) && clientObj is ClientApplication client)
            clientId = client.Id;

        await logService.LogAsync(
            clientId,
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            sw.ElapsedMilliseconds);
    }
}
