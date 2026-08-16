using System.ComponentModel.DataAnnotations;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Models.Dtos;

/// <summary>
/// Demande d'envoi WhatsApp. Même esprit que <see cref="SendMailRequest"/> : l'application fournit
/// un code fonctionnel et des données nommées, la passerelle se charge du reste.
/// </summary>
public class SendWhatsAppRequest
{
    [Required, MaxLength(50)]
    public string ClientCode { get; set; } = string.Empty;

    /// <summary>Numéro du destinataire. Accepte +237…, 00237…, ou local si un indicatif par défaut est configuré.</summary>
    [Required, MaxLength(32)]
    public string To { get; set; } = string.Empty;

    /// <summary>template (défaut) ou text. Le texte libre n'est permis que dans la fenêtre de 24 h.</summary>
    [MaxLength(20)]
    public string? Kind { get; set; }

    /// <summary>Code fonctionnel, résolu via les correspondances enregistrées (ex. MEETING_REMINDER).</summary>
    [MaxLength(50)]
    public string? TemplateCode { get; set; }

    /// <summary>
    /// Nom du modèle approuvé chez Meta. À renseigner uniquement si aucune correspondance
    /// n'est enregistrée pour <see cref="TemplateCode"/>.
    /// </summary>
    [MaxLength(128)]
    public string? MetaTemplateName { get; set; }

    [MaxLength(16)]
    public string? Language { get; set; }

    /// <summary>Valeurs nommées des variables du modèle, converties en paramètres positionnels.</summary>
    public Dictionary<string, string>? BodyData { get; set; }

    /// <summary>Paramètres déjà ordonnés : repli lorsque le modèle n'a pas de correspondance nommée.</summary>
    public List<string>? Parameters { get; set; }

    /// <summary>Paramètres de l'en-tête, ordonnés, si le modèle en possède.</summary>
    public List<string>? HeaderParameters { get; set; }

    /// <summary>Suffixe d'URL du bouton dynamique, si le modèle en contient un.</summary>
    [MaxLength(500)]
    public string? ButtonUrlParameter { get; set; }

    /// <summary>Corps du message pour Kind = text.</summary>
    [MaxLength(4000)]
    public string? Text { get; set; }

    public EmailPriority Priority { get; set; } = EmailPriority.Normal;

    [MaxLength(500), Url]
    public string? CallbackUrl { get; set; }
}

public class SendWhatsAppResponse
{
    public bool Success { get; set; }
    public string? MessageCode { get; set; }
    public Guid? TrackingId { get; set; }
    public string? Status { get; set; }

    /// <summary>Numéro retenu après normalisation, pour lever tout doute sur l'indicatif.</summary>
    public string? To { get; set; }

    public string? Error { get; set; }
}

public class WhatsAppStatusResponse
{
    public string MessageCode { get; set; } = string.Empty;
    public Guid TrackingId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string? TemplateCode { get; set; }
    public string? MetaTemplateName { get; set; }
    public string Language { get; set; } = "fr";
    public string Kind { get; set; } = "Template";
    public string? BodyPreview { get; set; }
    public string? ProviderMessageId { get; set; }
    public int RetryCount { get; set; }
    public DateTimeOffset QueuedAt { get; set; }
    public DateTimeOffset? SentAt { get; set; }
    public DateTimeOffset? DeliveredAt { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public DateTimeOffset? FailedAt { get; set; }
    public string? ErrorMessage { get; set; }
    public int? ErrorCode { get; set; }
    public List<MailStatusEventDto> Events { get; set; } = [];
}

/// <summary>Déclaration d'une correspondance code fonctionnel → modèle approuvé chez Meta.</summary>
public class UpsertWhatsAppTemplateRequest
{
    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [MaxLength(16)]
    public string? Language { get; set; }

    [Required, MaxLength(128)]
    public string MetaTemplateName { get; set; } = string.Empty;

    [MaxLength(16)]
    public string? MetaLanguageCode { get; set; }

    /// <summary>Variables du corps dans l'ordre des {{1}}, {{2}}… du modèle approuvé.</summary>
    public List<string>? BodyParameters { get; set; }

    public List<string>? HeaderParameters { get; set; }

    [MaxLength(100)]
    public string? ButtonUrlParameter { get; set; }

    [MaxLength(2000)]
    public string? PreviewText { get; set; }

    public bool IsActive { get; set; } = true;
}

public class WhatsAppTemplateDto
{
    public string TemplateCode { get; set; } = string.Empty;
    public string Language { get; set; } = "fr";
    public string MetaTemplateName { get; set; } = string.Empty;
    public string MetaLanguageCode { get; set; } = "fr";
    public List<string> BodyParameters { get; set; } = [];
    public List<string> HeaderParameters { get; set; } = [];
    public string? ButtonUrlParameter { get; set; }
    public string? PreviewText { get; set; }
    public bool IsActive { get; set; }

    /// <summary>Vrai si la correspondance appartient à l'application appelante et non au catalogue partagé.</summary>
    public bool IsClientSpecific { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}

public class WhatsAppTemplateListResponse
{
    public int Count { get; set; }
    public List<WhatsAppTemplateDto> Templates { get; set; } = [];
    public List<string> Missing { get; set; } = [];
}

/// <summary>État de configuration du canal, sans jamais exposer de secret.</summary>
public class WhatsAppDiagnosticsResponse
{
    public bool Configured { get; set; }
    public string? Provider { get; set; }
    public string? PhoneNumberIdMasked { get; set; }
    public string? DisplayPhoneNumber { get; set; }
    public string? ApiVersion { get; set; }
    public string? DefaultCountryCode { get; set; }
    public bool WebhookVerifyTokenSet { get; set; }
    public bool AppSecretSet { get; set; }
    public string Source { get; set; } = "none";
    public List<string> Problems { get; set; } = [];
}
