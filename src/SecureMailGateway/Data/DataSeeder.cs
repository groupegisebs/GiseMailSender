using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

        // Schéma géré par EF Core — la base doit exister (créée par deploy-gha.sh ou manuellement).
        try
        {
            await db.Database.MigrateAsync();
        }
        catch (PostgresException ex) when (ex.SqlState == "42501" && ex.MessageText.Contains("create database", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "La base PostgreSQL n'existe pas et l'utilisateur applicatif ne peut pas la créer (CREATEDB). " +
                "Sur le serveur, exécutez : sudo -u postgres psql -c \"CREATE DATABASE \\\"GiseMailSenderService\\\" OWNER gisedocuser;\" " +
                "ou relancez le déploiement (deploy-gha.sh crée la base automatiquement).", ex);
        }

        foreach (var role in AppRoles.All)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var adminEmail = config["Seed:AdminEmail"] ?? "admin@securemail.local";
        var adminPassword = config["Seed:AdminPassword"] ?? "ChangeMe!SecureMail2026";

        if (await userManager.FindByEmailAsync(adminEmail) is null)
        {
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                DisplayName = "Administrator"
            };

            var result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
                logger.LogInformation("Admin user created: {Email}", adminEmail);
            }
        }

        if (!await db.ClientApplications.AnyAsync())
        {
            db.ClientApplications.Add(new ClientApplication
            {
                Name = "Demo Application",
                ClientCode = "DEMO",
                DailyQuota = 500,
                MonthlyQuota = 10000,
                AllowedDomains = "example.com,gmail.com"
            });
            await db.SaveChangesAsync();
        }

        if (!await db.ClientApplications.AnyAsync(c => c.ClientCode == "BOUTIQUEGISE"))
        {
            db.ClientApplications.Add(new ClientApplication
            {
                Name = "BoutiqueGise — Agentia Market",
                ClientCode = "BOUTIQUEGISE",
                DailyQuota = 2000,
                MonthlyQuota = 50000,
                AllowedDomains = "agentiamarket.com,gmail.com,outlook.com,yahoo.com,hotmail.com"
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Client application BOUTIQUEGISE seeded.");
        }

        await SeedTemplatesAsync(db, logger);
    }

    private static async Task SeedTemplatesAsync(ApplicationDbContext db, ILogger logger)
    {
        var existingCodes = await db.EmailTemplates
            .Select(t => t.TemplateCode)
            .ToListAsync();

        var added = 0;
        foreach (var definition in BoutiqueGiseTemplates.Definitions)
        {
            if (existingCodes.Contains(definition.TemplateCode, StringComparer.OrdinalIgnoreCase))
                continue;

            db.EmailTemplates.Add(definition.ToEntity());
            added++;
        }

        if (added > 0)
        {
            await db.SaveChangesAsync();
            logger.LogInformation("Seeded {Count} email template(s) for BoutiqueGise / Agentia Market.", added);
        }
    }
}
