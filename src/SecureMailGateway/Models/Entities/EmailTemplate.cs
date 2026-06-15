using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class EmailTemplate
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string SubjectTemplate { get; set; } = string.Empty;

    public string HtmlBody { get; set; } = string.Empty;
    public string? TextBody { get; set; }

    [MaxLength(10)]
    public string Language { get; set; } = "fr";

    public int Version { get; set; } = 1;
    public bool IsActive { get; set; } = true;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<EmailTemplateVersion> Versions { get; set; } = [];
}
