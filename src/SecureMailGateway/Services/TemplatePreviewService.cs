using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Services;

public interface ITemplatePreviewService
{
    TemplatePreviewResult BuildPreview(TemplatePreviewRequest request);
}

public sealed class TemplatePreviewResult
{
    public string Subject { get; set; } = string.Empty;
    public string Html { get; set; } = string.Empty;
    public string? Text { get; set; }
    public IReadOnlyCollection<string> UnknownVariables { get; set; } = [];
}

public class TemplatePreviewService(
    ITemplateRenderer templateRenderer,
    IHtmlSanitizerService htmlSanitizerService) : ITemplatePreviewService
{
    private static readonly Dictionary<string, string> DefaultSampleData = new(StringComparer.OrdinalIgnoreCase)
    {
        ["FirstName"] = "Jean",
        ["CompanyName"] = "Acme Corp",
        ["Title"] = "Bienvenue",
        ["Message"] = "Votre compte est pret.",
        ["Amount"] = "29,00 $",
        ["OrderId"] = "ORD-2026-001"
    };

    public TemplatePreviewResult BuildPreview(TemplatePreviewRequest request)
    {
        var unknownVariables = htmlSanitizerService.GetUnknownVariables(request.SubjectTemplate, request.HtmlBody, request.TextBody);

        var mergedData = new Dictionary<string, string>(DefaultSampleData, StringComparer.OrdinalIgnoreCase);
        foreach (var pair in request.SampleData)
        {
            mergedData[pair.Key] = pair.Value;
        }

        var renderedSubject = templateRenderer.Render(request.SubjectTemplate, mergedData);
        var renderedHtmlBody = templateRenderer.Render(request.HtmlBody, mergedData);
        var renderedText = request.TextBody is not null ? templateRenderer.Render(request.TextBody, mergedData) : null;

        var safeHtmlBody = htmlSanitizerService.Sanitize(renderedHtmlBody);

        var previewHtml = $"""
            <div class="securemail-preview-email-shell">
                <div class="securemail-preview-email-card">
                    <div class="securemail-preview-email-header">SecureMail</div>
                    <div class="securemail-preview-email-body">{safeHtmlBody}</div>
                    <div class="securemail-preview-email-legal">
                        Ce message est confidentiel. Merci de ne pas repondre directement a cet e-mail.
                    </div>
                </div>
            </div>
            """;

        return new TemplatePreviewResult
        {
            Subject = renderedSubject,
            Html = previewHtml,
            Text = renderedText,
            UnknownVariables = unknownVariables
        };
    }
}
