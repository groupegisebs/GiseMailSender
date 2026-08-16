using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

/// <summary>
/// Identifiants du compte WhatsApp Business, à l'image de <see cref="SmtpConfiguration"/> :
/// stockés en base et chiffrés par la Data Protection API, jamais dans appsettings.
/// </summary>
public class WhatsAppConfiguration
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    public string ProviderName { get; set; } = "MetaCloud";

    /// <summary>Identifiant du numéro expéditeur (Phone Number ID de l'API Cloud).</summary>
    [Required, MaxLength(64)]
    public string PhoneNumberId { get; set; } = string.Empty;

    /// <summary>Identifiant du WhatsApp Business Account, utile au rapprochement des webhooks.</summary>
    [MaxLength(64)]
    public string? BusinessAccountId { get; set; }

    /// <summary>Numéro affiché aux destinataires, à titre informatif.</summary>
    [MaxLength(32)]
    public string? DisplayPhoneNumber { get; set; }

    /// <summary>Jeton permanent d'utilisateur système, chiffré via Data Protection.</summary>
    public string? AccessTokenEncrypted { get; set; }

    /// <summary>Secret de l'application Meta, chiffré : sert à valider la signature des webhooks.</summary>
    public string? AppSecretEncrypted { get; set; }

    /// <summary>Jeton de vérification choisi lors de l'abonnement au webhook.</summary>
    [MaxLength(128)]
    public string? WebhookVerifyToken { get; set; }

    [MaxLength(16)]
    public string ApiVersion { get; set; } = "v21.0";

    /// <summary>Indicatif appliqué aux numéros saisis sans indicatif (ex. 237 pour le Cameroun).</summary>
    [MaxLength(6)]
    public string? DefaultCountryCode { get; set; }

    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
