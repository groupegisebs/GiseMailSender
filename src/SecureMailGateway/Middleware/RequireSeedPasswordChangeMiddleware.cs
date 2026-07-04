using Microsoft.AspNetCore.Identity;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Middleware;

public class RequireSeedPasswordChangeMiddleware(RequestDelegate next)
{
    private static readonly PathString ChangePasswordPath = new("/Identity/Account/Manage/ChangePassword");
    private static readonly PathString LogoutPath = new("/Identity/Account/Logout");
    private static readonly PathString LoginPath = new("/Identity/Account/Login");

    public async Task InvokeAsync(
        HttpContext context,
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        if (!ShouldInspect(context))
        {
            await next(context);
            return;
        }

        var seedEmail = configuration["Seed:AdminEmail"];
        var seedPassword = configuration["Seed:AdminPassword"];
        if (string.IsNullOrWhiteSpace(seedEmail) || string.IsNullOrWhiteSpace(seedPassword))
        {
            await next(context);
            return;
        }

        var signedInEmail = context.User.Identity?.Name;
        if (!string.Equals(signedInEmail, seedEmail, StringComparison.OrdinalIgnoreCase))
        {
            await next(context);
            return;
        }

        var user = await userManager.GetUserAsync(context.User);
        if (user is null)
        {
            await next(context);
            return;
        }

        var stillUsingSeedPassword = await userManager.CheckPasswordAsync(user, seedPassword);
        if (!stillUsingSeedPassword)
        {
            await next(context);
            return;
        }

        if (context.Request.Path.StartsWithSegments(ChangePasswordPath) ||
            context.Request.Path.StartsWithSegments(LogoutPath))
        {
            await next(context);
            return;
        }

        var returnUrl = $"{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";
        var target = QueryString.Create("returnUrl", returnUrl ?? "/");
        context.Response.Redirect($"{ChangePasswordPath}{target}");
    }

    private static bool ShouldInspect(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated != true)
            return false;

        if (HttpMethods.IsOptions(context.Request.Method))
            return false;

        if (context.Request.Path.StartsWithSegments("/api") ||
            context.Request.Path.StartsWithSegments("/health") ||
            context.Request.Path.StartsWithSegments("/metrics") ||
            context.Request.Path.StartsWithSegments("/hangfire"))
            return false;

        if (context.Request.Path.StartsWithSegments("/lib") ||
            context.Request.Path.StartsWithSegments("/css") ||
            context.Request.Path.StartsWithSegments("/js") ||
            context.Request.Path.StartsWithSegments("/images") ||
            context.Request.Path.StartsWithSegments("/favicon"))
            return false;

        return true;
    }
}
