using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class WhatsAppSendLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid WhatsAppMessageId { get; set; }
    public WhatsAppMessage WhatsAppMessage { get; set; } = null!;

    [Required, MaxLength(50)]
    public string EventType { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Message { get; set; }

    public string? Details { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
