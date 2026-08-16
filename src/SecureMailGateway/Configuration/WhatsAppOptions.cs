namespace SecureMailGateway.Configuration;

/// <summary>
/// Identifiants WhatsApp lus dans l'environnement. Ils servent de repli lorsque aucune ligne
/// WhatsAppConfiguration n'existe en base, ce qui permet de déployer le canal sans écran d'admin.
/// </summary>
public sealed class WhatsAppOptions
{
    public const string SectionName = "WhatsApp";

    public string? PhoneNumberId { get; set; }
    public string? BusinessAccountId { get; set; }
    public string? DisplayPhoneNumber { get; set; }
    public string? AccessToken { get; set; }

    /// <summary>Secret de l'application Meta : sans lui, la signature des webhooks n'est pas vérifiable.</summary>
    public string? AppSecret { get; set; }

    public string? WebhookVerifyToken { get; set; }
    public string ApiVersion { get; set; } = "v21.0";
    public string BaseUrl { get; set; } = "https://graph.facebook.com/";

    /// <summary>Indicatif ajouté aux numéros fournis sans indicatif pays (ex. 237).</summary>
    public string? DefaultCountryCode { get; set; }

    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>Nombre de nouvelles tentatives après une erreur passagère (réseau, 429, 5xx).</summary>
    public int MaxRetries { get; set; } = 4;
}
