using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;

namespace SecureMailGateway.Data;

public static partial class DataSeeder
{
    [GeneratedRegex(@"<!--\s*[a-z0-9]+-seed:(\d+)\s*-->", RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    private static partial Regex SeedRevisionRegex();
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
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

        if (!await db.ClientApplications.AnyAsync(c => c.ClientCode == "COMPTADOC"))
        {
            db.ClientApplications.Add(new ClientApplication
            {
                Name = "ComptaDoc PME",
                ClientCode = "COMPTADOC",
                DailyQuota = 5000,
                MonthlyQuota = 100000,
                // null = tous domaines (factures / invites vers n'importe quel client PME)
                AllowedDomains = null
            });
            await db.SaveChangesAsync();
            logger.LogInformation("Client application COMPTADOC seeded.");
        }
        else
        {
            // Assouplir les domaines si un seed antérieur avait une allowlist trop stricte.
            var compta = await db.ClientApplications.FirstAsync(c => c.ClientCode == "COMPTADOC");
            if (!string.IsNullOrWhiteSpace(compta.AllowedDomains)
                && !ClientApplicationDomainRules.AllowsAllDomains(compta.AllowedDomains))
            {
                compta.AllowedDomains = null;
                await db.SaveChangesAsync();
                logger.LogInformation("Client COMPTADOC : AllowedDomains ouvert à tous les domaines.");
            }
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
            {
                BoutiqueGiseTemplates.Definitions,
                TutorSphereTemplates.Definitions,
                HoloTutoTemplates.Definitions,
                ComptaDocTemplates.Definitions
            })
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
