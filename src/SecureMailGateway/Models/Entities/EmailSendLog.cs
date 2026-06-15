using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class EmailSendLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EmailMessageId { get; set; }
    public EmailMessage EmailMessage { get; set; } = null!;

    [Required, MaxLength(50)]
    public string EventType { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? Message { get; set; }

    public string? Details { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
