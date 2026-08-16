using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

/// <summary>
/// Message reçu d'un destinataire. Il ouvre la fenêtre de 24 h pendant laquelle un texte libre
/// peut lui être adressé : sans cette trace, impossible de savoir si un envoi hors modèle est permis.
/// </summary>
public class WhatsAppInboundMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(20)]
    public string FromPhone { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? ProfileName { get; set; }

    [MaxLength(128)]
    public string? ProviderMessageId { get; set; }

    [MaxLength(32)]
    public string? PhoneNumberId { get; set; }

    [MaxLength(32)]
    public string MessageType { get; set; } = "text";

    [MaxLength(4000)]
    public string? Text { get; set; }

    public string? RawJson { get; set; }

    public DateTimeOffset ReceivedAt { get; set; } = DateTimeOffset.UtcNow;
}
