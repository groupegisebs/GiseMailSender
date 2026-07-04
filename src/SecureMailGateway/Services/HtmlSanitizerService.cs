using System.Text.RegularExpressions;
using Ganss.Xss;

namespace SecureMailGateway.Services;

public interface IHtmlSanitizerService
{
    string Sanitize(string? html);

    /// <summary>Recommended/default catalog variables. NOT an exclusive whitelist: templates may
    /// also declare their own custom variables, which are preserved through sanitization.</summary>
    IReadOnlyCollection<string> AllowedVariables { get; }
}

public partial class HtmlSanitizerService : IHtmlSanitizerService
{
    // Recommended default variable set (the catalog). This is surfaced to the AI and the editor
    // palette as suggestions; it is NOT used to strip unknown variables — any well-formed
    // {{Identifier}} placeholder (catalog or custom) is preserved.
    private static readonly HashSet<string> RecommendedVariableSet =
        new(TemplateVariableCatalog.NameSet, StringComparer.OrdinalIgnoreCase);

    // Attributes allowed on email markup. Reused by the RemovingAttribute guard so that a
    // disallowed attribute (e.g. onclick) is never resurrected just because it holds a token.
    private static readonly string[] AllowedAttributeNames =
    [
        // CRITICAL: inline styles carry the whole email design.
        "style", "class",
        "href", "target", "rel", "src", "alt", "title",
        "width", "height", "align", "valign",
        "bgcolor", "background", "color", "border",
        "cellpadding", "cellspacing", "role",
        "colspan", "rowspan"
    ];

    private static readonly HashSet<string> AllowedAttributeSet =
        new(AllowedAttributeNames, StringComparer.OrdinalIgnoreCase);

    private static readonly HtmlSanitizer Sanitizer = CreateSanitizer();

    [GeneratedRegex(@"\{\{([A-Za-z][A-Za-z0-9_]*)\}\}", RegexOptions.Compiled)]
    private static partial Regex VariableRegex();

    // Dangerous URL schemes that must never be resurrected, even if the value also contains a token.
    [GeneratedRegex(@"(?i)(?:javascript|vbscript|data)\s*:", RegexOptions.Compiled)]
    private static partial Regex DangerousUrlValueRegex();

    public IReadOnlyCollection<string> AllowedVariables => RecommendedVariableSet.OrderBy(x => x).ToArray();

    public string Sanitize(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return string.Empty;
        return Sanitizer.Sanitize(html);
    }

    private static HtmlSanitizer CreateSanitizer()
    {
        var sanitizer = new HtmlSanitizer();

        // Email-grade markup: table-based layouts with inline styles must survive.
        sanitizer.AllowedTags.Clear();
        sanitizer.AllowedTags.UnionWith(
        [
            "div", "span", "p", "center", "font",
            "table", "thead", "tbody", "tfoot", "tr", "td", "th",
            "a", "img",
            "h1", "h2", "h3", "h4",
            "ul", "ol", "li",
            "strong", "em", "b", "i", "u", "br", "hr"
        ]);

        sanitizer.AllowedAttributes.Clear();
        sanitizer.AllowedAttributes.UnionWith(AllowedAttributeNames);

        sanitizer.AllowedSchemes.Clear();
        sanitizer.AllowedSchemes.UnionWith(["http", "https", "mailto", "tel"]);

        // Inline CSS properties transactional emails rely on.
        sanitizer.AllowedCssProperties.Clear();
        sanitizer.AllowedCssProperties.UnionWith(
        [
            "color", "background", "background-color", "background-image", "background-position",
            "background-repeat", "background-size",
            "font", "font-size", "font-weight", "font-family", "font-style",
            "line-height", "letter-spacing", "text-align", "text-decoration", "text-transform",
            "vertical-align", "white-space", "list-style", "list-style-type",
            "padding", "padding-left", "padding-right", "padding-top", "padding-bottom",
            "margin", "margin-left", "margin-right", "margin-top", "margin-bottom",
            "border", "border-top", "border-right", "border-bottom", "border-left",
            "border-color", "border-width", "border-style", "border-collapse", "border-spacing",
            "border-radius", "box-shadow", "outline",
            "display", "overflow", "float", "clear",
            "max-width", "min-width", "width", "max-height", "min-height", "height"
        ]);

        // Preserve well-formed {{Variable}} placeholders inside URL attributes (e.g.
        // href="{{ResetLink}}" or href="{{CustomLink}}"). Ganss would otherwise drop the
        // attribute because "{{...}}" is not a recognised URL scheme.
        //
        // Security: this exemption is deliberately narrow. It only applies when
        //   (1) the attribute itself is on the allow-list (so onclick / on* handlers are never
        //       resurrected just because they contain a token), AND
        //   (2) the value contains a syntactically valid {{Identifier}} token, AND
        //   (3) the value carries no dangerous scheme (javascript:/vbscript:/data:).
        sanitizer.RemovingAttribute += (_, e) =>
        {
            var name = e.Attribute?.Name;
            var value = e.Attribute?.Value;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value)) return;
            if (!AllowedAttributeSet.Contains(name)) return;
            if (!VariableRegex().IsMatch(value)) return;
            if (DangerousUrlValueRegex().IsMatch(value)) return;

            e.Cancel = true;
        };

        return sanitizer;
    }
}
