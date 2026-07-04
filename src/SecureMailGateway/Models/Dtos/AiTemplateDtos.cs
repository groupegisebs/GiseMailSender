using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Dtos;

/// <summary>
/// Brief sent from the editor's "Générer avec l'IA" modal to the server. The API key stays
/// server-side; this DTO only carries the user's creative intent.
/// </summary>
public class AiTemplateGenerateRequest
{
    [Required, MaxLength(2000)]
    public string Objective { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? BrandName { get; set; }

    [MaxLength(120)]
    public string? EmailType { get; set; }

    [MaxLength(120)]
    public string? Tone { get; set; }

    [MaxLength(20)]
    public string? Language { get; set; } = "fr";

    [MaxLength(300)]
    public string? CtaText { get; set; }

    [MaxLength(2000)]
    public string? DesiredVariables { get; set; }

    [MaxLength(40)]
    public string? PrimaryColor { get; set; }

    [MaxLength(2000)]
    public string? AdditionalInstructions { get; set; }
}

/// <summary>
/// Result returned to the editor after generation and server-side sanitization. HTML is already
/// sanitized and every well-formed {{Variable}} is preserved.
/// </summary>
public class AiTemplateGenerateResponse
{
    public string Subject { get; set; } = string.Empty;
    public string BodyHtml { get; set; } = string.Empty;
    public string BodyText { get; set; } = string.Empty;
    public Dictionary<string, string> TestData { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public List<AiTemplateVariable> Variables { get; set; } = [];
    public List<string> Warnings { get; set; } = [];
}

public class AiTemplateVariable
{
    public string Name { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string SampleValue { get; set; } = string.Empty;
}
