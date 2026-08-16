using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;
using SecureMailGateway.Data;

namespace SecureMailGateway.Services;

/// <summary>Identifiants effectifs du canal, une fois les secrets déchiffrés.</summary>
public sealed class WhatsAppSettings
{
    public string PhoneNumberId { get; init; } = string.Empty;
    public string AccessToken { get; init; } = string.Empty;
    public string ApiVersion { get; init; } = "v21.0";
    public string BaseUrl { get; init; } = "https://graph.facebook.com/";
    public string? BusinessAccountId { get; init; }
    public string? DisplayPhoneNumber { get; init; }
    public string? AppSecret { get; init; }
    public string? WebhookVerifyToken { get; init; }
    public string? DefaultCountryCode { get; init; }
    public int MaxRetries { get; init; } = 4;

    /// <summary>« database » ou « configuration » : indique d'où viennent les identifiants retenus.</summary>
    public string Source { get; init; } = "none";

    public bool IsUsable => !string.IsNullOrWhiteSpace(PhoneNumberId) && !string.IsNullOrWhiteSpace(AccessToken);
}

public interface IWhatsAppSettingsProvider
{
    /// <summary>Configuration active : la ligne par défaut en base, sinon les variables d'environnement.</summary>
    Task<WhatsAppSettings> GetAsync(CancellationToken ct = default);

    string Protect(string value);
}

public class WhatsAppSettingsProvider(
    ApplicationDbContext db,
    IOptions<WhatsAppOptions> options,
    IDataProtectionProvider dataProtection,
    ILogger<WhatsAppSettingsProvider> logger) : IWhatsAppSettingsProvider
{
    public const string ProtectorPurpose = "WhatsAppSecrets";

    private readonly IDataProtector _protector = dataProtection.CreateProtector(ProtectorPurpose);
    private readonly WhatsAppOptions _options = options.Value;

    public string Protect(string value) => _protector.Protect(value);

    public async Task<WhatsAppSettings> GetAsync(CancellationToken ct = default)
    {
        var row = await db.WhatsAppConfigurations
            .AsNoTracking()
            .Where(c => c.IsActive)
            .OrderByDescending(c => c.IsDefault)
            .ThenByDescending(c => c.UpdatedAt)
            .FirstOrDefaultAsync(ct);

        if (row is not null)
        {
            return new WhatsAppSettings
            {
                PhoneNumberId = row.PhoneNumberId,
                AccessToken = Unprotect(row.AccessTokenEncrypted) ?? _options.AccessToken ?? string.Empty,
                ApiVersion = string.IsNullOrWhiteSpace(row.ApiVersion) ? _options.ApiVersion : row.ApiVersion,
                BaseUrl = _options.BaseUrl,
                BusinessAccountId = row.BusinessAccountId ?? _options.BusinessAccountId,
                DisplayPhoneNumber = row.DisplayPhoneNumber ?? _options.DisplayPhoneNumber,
                AppSecret = Unprotect(row.AppSecretEncrypted) ?? _options.AppSecret,
                WebhookVerifyToken = row.WebhookVerifyToken ?? _options.WebhookVerifyToken,
                DefaultCountryCode = row.DefaultCountryCode ?? _options.DefaultCountryCode,
                MaxRetries = _options.MaxRetries,
                Source = "database"
            };
        }

        return new WhatsAppSettings
        {
            PhoneNumberId = _options.PhoneNumberId ?? string.Empty,
            AccessToken = _options.AccessToken ?? string.Empty,
            ApiVersion = _options.ApiVersion,
            BaseUrl = _options.BaseUrl,
            BusinessAccountId = _options.BusinessAccountId,
            DisplayPhoneNumber = _options.DisplayPhoneNumber,
            AppSecret = _options.AppSecret,
            WebhookVerifyToken = _options.WebhookVerifyToken,
            DefaultCountryCode = _options.DefaultCountryCode,
            MaxRetries = _options.MaxRetries,
            Source = string.IsNullOrWhiteSpace(_options.PhoneNumberId) ? "none" : "configuration"
        };
    }

    private string? Unprotect(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        try
        {
            return _protector.Unprotect(value);
        }
        catch (Exception ex)
        {
            // Clés Data Protection régénérées : le secret est illisible, on retombe sur l'environnement.
            logger.LogError(ex, "Déchiffrement impossible d'un secret WhatsApp stocké en base.");
            return null;
        }
    }
}
