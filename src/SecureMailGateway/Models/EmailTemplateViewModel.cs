using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.ViewModels;

public class EmailTemplateViewModel
{
    public Guid? Id { get; set; }

    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string SubjectTemplate { get; set; } = string.Empty;

    [Required]
    public string HtmlBody { get; set; } = string.Empty;

    public string? TextBody { get; set; }

    [MaxLength(10)]
    public string Language { get; set; } = "fr";

    public bool IsActive { get; set; } = true;

    public List<string> Variables { get; set; } = [];
}
