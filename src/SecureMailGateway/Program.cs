using AspNetCoreRateLimit;
using Hangfire.Dashboard;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Middleware;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, services, config) => config
        .ReadFrom.Configuration(ctx.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/securemail-.log", rollingInterval: RollingInterval.Day));

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 12;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        .AddDefaultUI();

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", p => p.RequireRole(AppRoles.Admin));
        options.AddPolicy("DevOrAdmin", p => p.RequireRole(AppRoles.Admin, AppRoles.Developer));
    });

    builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
    builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
    builder.Services.AddInMemoryRateLimiting();
    builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(
            builder.Configuration["DataProtection:KeysPath"] ?? Path.Combine(builder.Environment.ContentRootPath, "keys")));

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddHttpClient("callback", c => c.Timeout = TimeSpan.FromSeconds(10));

    builder.Services.AddScoped<ITokenHashService, TokenHashService>();
    builder.Services.AddScoped<ITemplateRenderer, TemplateRenderer>();
    builder.Services.AddScoped<IMailCodeGenerator, MailCodeGenerator>();
    builder.Services.AddScoped<IEmailQueueService, EmailQueueService>();
    builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();
    builder.Services.AddScoped<IAuditService, AuditService>();
    builder.Services.AddScoped<IApiCallLogService, ApiCallLogService>();
    builder.Services.AddScoped<IApiTokenService, ApiTokenService>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
    builder.Services.AddSingleton<IBackgroundJobScheduler, HangfireJobScheduler>();

    builder.Services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UsePostgreSqlStorage(c => c.UseNpgsqlConnection(connectionString)));

    builder.Services.AddHangfireServer();

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    builder.Services.AddHealthChecks()
        .AddNpgSql(connectionString, name: "postgresql");

    var app = builder.Build();

    await DataSeeder.SeedAsync(app.Services);

    if (app.Environment.IsDevelopment())
        app.UseMigrationsEndPoint();
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseIpRateLimiting();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<ApiKeyAuthenticationMiddleware>();
    app.UseMiddleware<ApiCallLoggingMiddleware>();

    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = [new HangfireAuthFilter()]
    });

    app.UseHttpMetrics();
    app.MapMetrics("/metrics");
    app.MapHealthChecks("/health");

    app.MapStaticAssets();
    app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
    app.MapRazorPages().WithStaticAssets();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public class HangfireAuthFilter : Hangfire.Dashboard.IDashboardAuthorizationFilter
{
    public bool Authorize(Hangfire.Dashboard.DashboardContext context)
    {
        var http = context.GetHttpContext();
        return http.User.Identity?.IsAuthenticated == true &&
               http.User.IsInRole(AppRoles.Admin);
    }
}
