using System.ComponentModel.DataAnnotations;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Models.Entities;

/// <summary>
/// File d'attente des messages WhatsApp, pendant de <see cref="EmailMessage"/> pour le canal WhatsApp.
/// </summary>
public class WhatsAppMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>Référence lisible rendue à l'appelant (ex. WHAP-2026-000123).</summary>
    [Required, MaxLength(24)]
    public string MessageCode { get; set; } = string.Empty;

    public Guid ClientApplicationId { get; set; }
    public ClientApplication ClientApplication { get; set; } = null!;

    /// <summary>Code fonctionnel côté application appelante (ex. MEETING_REMINDER).</summary>
    [MaxLength(50)]
    public string? TemplateCode { get; set; }

    /// <summary>Nom du modèle approuvé chez Meta réellement expédié.</summary>
    [MaxLength(128)]
    public string? MetaTemplateName { get; set; }

    [MaxLength(16)]
    public string Language { get; set; } = "fr";

    public WhatsAppMessageKind Kind { get; set; } = WhatsAppMessageKind.Template;

    /// <summary>Destinataire normalisé au format E.164 sans le signe plus.</summary>
    [Required, MaxLength(20)]
    public string ToPhone { get; set; } = string.Empty;

    /// <summary>Rendu lisible du message, pour le support et l'écran de suivi.</summary>
    [MaxLength(2000)]
    public string? BodyPreview { get; set; }

    /// <summary>Corps JSON envoyé à l'opérateur, figé à la mise en file.</summary>
    [Required]
    public string PayloadJson { get; set; } = "{}";

    /// <summary>Identifiant opérateur (wamid…) qui relie les webhooks de statut à ce message.</summary>
    [MaxLength(128)]
    public string? ProviderMessageId { get; set; }

    /// <summary>Identifiant du contact WhatsApp résolu par l'opérateur.</summary>
    [MaxLength(32)]
    public string? RecipientWaId { get; set; }

    public WhatsAppStatus Status { get; set; } = WhatsAppStatus.Queued;
    public EmailPriority Priority { get; set; } = EmailPriority.Normal;

    /// <summary>Nombre de tentatives déjà consommées : l'envoi est réessayé avec un délai croissant.</summary>
    public int RetryCount { get; set; }

    [MaxLength(500)]
    public string? CallbackUrl { get; set; }

    [MaxLength(2000)]
    public string? ErrorMessage { get; set; }

    /// <summary>Code d'erreur Meta (ex. 131047 : fenêtre de 24 h dépassée).</summary>
    public int? ErrorCode { get; set; }

    [MaxLength(4000)]
    public string? ProviderResponse { get; set; }

    public DateTimeOffset QueuedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? SendingAt { get; set; }
    public DateTimeOffset? SentAt { get; set; }
    public DateTimeOffset? DeliveredAt { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public DateTimeOffset? FailedAt { get; set; }

    public ICollection<WhatsAppSendLog> SendLogs { get; set; } = [];
}
