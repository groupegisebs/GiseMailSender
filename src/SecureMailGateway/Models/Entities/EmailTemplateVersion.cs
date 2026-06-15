using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class EmailTemplateVersion
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EmailTemplateId { get; set; }
    public EmailTemplate EmailTemplate { get; set; } = null!;

    public int Version { get; set; }

    [Required, MaxLength(500)]
    public string SubjectTemplate { get; set; } = string.Empty;

    public string HtmlBody { get; set; } = string.Empty;
    public string? TextBody { get; set; }

    [MaxLength(450)]
    public string? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
