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

        if (!await db.EmailTemplates.AnyAsync())
        {
            db.EmailTemplates.Add(new EmailTemplate
            {
                TemplateCode = "WELCOME",
                Name = "Bienvenue",
                SubjectTemplate = "Bienvenue {{FirstName}} chez {{CompanyName}}",
                HtmlBody = """
                    <div style="font-family:Arial,sans-serif;max-width:600px;margin:0 auto;padding:24px;">
                      <h1 style="color:#2563eb;">Bienvenue {{FirstName}} !</h1>
                      <p>Nous sommes ravis de vous accueillir chez <strong>{{CompanyName}}</strong>.</p>
                      <p>Votre compte est maintenant actif.</p>
                    </div>
                    """,
                TextBody = "Bienvenue {{FirstName}} chez {{CompanyName}}. Votre compte est actif.",
                Language = "fr",
                Version = 1,
                IsActive = true
            });
            await db.SaveChangesAsync();
        }
    }
}
