using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

/// <summary>
/// Correspondance entre un code fonctionnel (MEETING_REMINDER) et un modèle approuvé par Meta.
/// Les modèles WhatsApp n'ont que des paramètres positionnels ({{1}}, {{2}}…) : cette table
/// mémorise l'ordre des variables pour que les applications continuent d'envoyer des données
/// nommées, comme pour le courriel.
/// </summary>
public class WhatsAppTemplate
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required, MaxLength(16)]
    public string Language { get; set; } = "fr";

    /// <summary>Null : correspondance partagée par toutes les applications clientes.</summary>
    public Guid? ClientApplicationId { get; set; }
    public ClientApplication? ClientApplication { get; set; }

    /// <summary>Nom exact du modèle tel qu'approuvé dans le gestionnaire WhatsApp.</summary>
    [Required, MaxLength(128)]
    public string MetaTemplateName { get; set; } = string.Empty;

    /// <summary>Code langue attendu par Meta (fr, en_US…), qui diffère parfois du code interne.</summary>
    [Required, MaxLength(16)]
    public string MetaLanguageCode { get; set; } = "fr";

    /// <summary>Variables du corps, séparées par des virgules et dans l'ordre des {{n}} du modèle.</summary>
    [MaxLength(1000)]
    public string? BodyParameters { get; set; }

    /// <summary>Variables de l'en-tête, si le modèle possède un en-tête texte à paramètres.</summary>
    [MaxLength(500)]
    public string? HeaderParameters { get; set; }

    /// <summary>
    /// Variable fournissant le suffixe d'URL du bouton dynamique (bouton d'index 0).
    /// Meta n'accepte que la partie variable de l'URL, pas l'adresse complète.
    /// </summary>
    [MaxLength(100)]
    public string? ButtonUrlParameter { get; set; }

    /// <summary>Aperçu du texte approuvé, pour le support et l'inventaire renvoyé par l'API.</summary>
    [MaxLength(2000)]
    public string? PreviewText { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public static List<string> SplitParameters(string? value) =>
        [.. (value ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];
}
