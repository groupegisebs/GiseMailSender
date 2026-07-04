namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail HoloTuteur. Client code : HOLOTUTO.
/// Le template RAW permet à l'API HoloTuteur d'envoyer du HTML déjà composé (passe-plat).
/// </summary>
public static class HoloTutoTemplates
{
    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        new(
            TemplateCode: "RAW",
            Name: "HoloTuto — HTML brut (passe-plat)",
            SubjectTemplate: "{{Subject}}",
            HtmlBody: "{{Body}}<!-- holotuto-seed:1 -->",
            TextBody: "{{Body}}",
            Language: "fr"),
    ];
}
