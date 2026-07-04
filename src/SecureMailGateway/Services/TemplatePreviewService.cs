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
    public TemplatePreviewResult BuildPreview(TemplatePreviewRequest request)
    {
        var unknownVariables = htmlSanitizerService.GetUnknownVariables(request.SubjectTemplate, request.HtmlBody, request.TextBody);

        // Default sample values come from the central catalog so every known variable
        // renders in the preview even when the user leaves a test-data field blank.
        var mergedData = TemplateVariableCatalog.BuildSampleData();
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
