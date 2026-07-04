using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Data;

public static partial class DataSeeder
{
    [GeneratedRegex(@"<!--\s*boutiquegise-seed:(\d+)\s*-->", RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex SeedRevisionRegex();
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

        var adminEmail = config["Seed:AdminEmail"] ?? "bediga.jean@gisebs.com";
        var adminPassword = config["Seed:AdminPassword"] ?? "Mcd!35578";

        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin is null)
        {
            admin = new ApplicationUser
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
            else
            {
                logger.LogWarning(
                    "Failed to create admin user {Email}: {Errors}",
                    adminEmail,
                    string.Join("; ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            admin.UserName = adminEmail;
            admin.Email = adminEmail;
            admin.EmailConfirmed = true;
            admin.AccessFailedCount = 0;
            admin.LockoutEnabled = true;
            admin.LockoutEnd = null;
            if (string.IsNullOrWhiteSpace(admin.DisplayName))
                admin.DisplayName = "Administrator";

            var updateResult = await userManager.UpdateAsync(admin);
            if (!updateResult.Succeeded)
            {
                logger.LogWarning(
                    "Failed to update admin user {Email}: {Errors}",
                    adminEmail,
                    string.Join("; ", updateResult.Errors.Select(e => e.Description)));
            }

            var hasExpectedPassword = await userManager.CheckPasswordAsync(admin, adminPassword);
            if (!hasExpectedPassword)
            {
                var resetToken = await userManager.GeneratePasswordResetTokenAsync(admin);
                var passwordResetResult = await userManager.ResetPasswordAsync(admin, resetToken, adminPassword);
                if (!passwordResetResult.Succeeded)
                {
                    logger.LogWarning(
                        "Failed to reset admin password for {Email}: {Errors}",
                        adminEmail,
                        string.Join("; ", passwordResetResult.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.IsInRoleAsync(admin, AppRoles.Admin))
            {
                var addRoleResult = await userManager.AddToRoleAsync(admin, AppRoles.Admin);
                if (!addRoleResult.Succeeded)
                {
                    logger.LogWarning(
                        "Failed to assign Admin role to {Email}: {Errors}",
                        adminEmail,
                        string.Join("; ", addRoleResult.Errors.Select(e => e.Description)));
                }
            }

            logger.LogInformation("Admin user reset on seed: {Email}", adminEmail);
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

        if (!await db.ClientApplications.AnyAsync(c => c.ClientCode == "TUTORSPHERE"))
        {
            db.ClientApplications.Add(new ClientApplication
            {
                Name = "TutorSphere",
                ClientCode = "TUTORSPHERE",
                DailyQuota = 5000,
                MonthlyQuota = 100000,
                AllowedDomains = "tutorsphere.gisebs.com,gmail.com,outlook.com,yahoo.com,hotmail.com"
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Client application TUTORSPHERE seeded.");
        }

        if (!await db.ClientApplications.AnyAsync(c => c.ClientCode == "HOLOTUTO"))
        {
            db.ClientApplications.Add(new ClientApplication
            {
                Name = "HoloTuto — API & portails",
                ClientCode = "HOLOTUTO",
                DailyQuota = 5000,
                MonthlyQuota = 100000,
                AllowedDomains = "holotuto.com,gisebs.com,gmail.com,outlook.com,yahoo.com,hotmail.com,icloud.com"
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Client application HOLOTUTO seeded.");
        }

        await SeedTemplatesAsync(db, logger);
    }

    private static async Task SeedTemplatesAsync(ApplicationDbContext db, ILogger logger)
    {
        var existing = await db.EmailTemplates.ToListAsync();
        var byCode = existing.ToDictionary(t => t.TemplateCode, StringComparer.OrdinalIgnoreCase);

        var added = 0;
        var updated = 0;

        foreach (var definitions in new IReadOnlyList<EmailTemplateSeed>[]
            { BoutiqueGiseTemplates.Definitions, TutorSphereTemplates.Definitions, HoloTutoTemplates.Definitions })
        {
            foreach (var definition in definitions)
            {
                if (!byCode.TryGetValue(definition.TemplateCode, out var entity))
                {
                    db.EmailTemplates.Add(definition.ToEntity());
                    added++;
                    continue;
                }

                var currentRevision = GetSeedRevision(entity.HtmlBody);
                if (definition.SeedRevision <= currentRevision)
                    continue;

                entity.Name = definition.Name;
                entity.SubjectTemplate = definition.SubjectTemplate;
                entity.HtmlBody = definition.HtmlBody;
                entity.TextBody = definition.TextBody;
                entity.Language = definition.Language;
                entity.IsActive = definition.IsActive;
                entity.Version++;
                entity.UpdatedAt = DateTimeOffset.UtcNow;
                updated++;
            }
        }

        if (added > 0 || updated > 0)
        {
            await db.SaveChangesAsync();
            logger.LogInformation(
                "Templates: {Added} created, {Updated} updated.",
                added, updated);
        }
    }

    private static int GetSeedRevision(string html)
    {
        var match = SeedRevisionRegex().Match(html);
        return match.Success && int.TryParse(match.Groups[1].Value, out var revision)
            ? revision
            : 0;
    }
}
