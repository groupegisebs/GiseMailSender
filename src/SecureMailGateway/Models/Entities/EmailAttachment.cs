using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class EmailAttachment
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EmailMessageId { get; set; }
    public EmailMessage EmailMessage { get; set; } = null!;

    [Required, MaxLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string ContentType { get; set; } = "application/octet-stream";

    public byte[] Content { get; set; } = [];
    public long SizeBytes { get; set; }
}
