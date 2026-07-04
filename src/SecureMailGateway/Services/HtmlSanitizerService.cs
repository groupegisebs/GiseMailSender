using System.Text.RegularExpressions;
using Ganss.Xss;

namespace SecureMailGateway.Services;

public interface IHtmlSanitizerService
{
    string Sanitize(string? html);
    IReadOnlyCollection<string> GetUnknownVariables(params string?[] templateParts);
    bool HasUnknownVariables(params string?[] templateParts);
    IReadOnlyCollection<string> AllowedVariables { get; }
}

public partial class HtmlSanitizerService : IHtmlSanitizerService
{
    private static readonly HashSet<string> AllowedVariableSet = new(StringComparer.OrdinalIgnoreCase)
    {
        "FirstName", "LastName", "CompanyName", "Email", "ResetLink", "OrderId", "Amount", "InvoiceDate", "Message"
    };

    private static readonly HtmlSanitizer Sanitizer = CreateSanitizer();

    [GeneratedRegex(@"\{\{([A-Za-z][A-Za-z0-9_]*)\}\}", RegexOptions.Compiled)]
    private static partial Regex VariableRegex();

    public IReadOnlyCollection<string> AllowedVariables => AllowedVariableSet.OrderBy(x => x).ToArray();

    public string Sanitize(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return string.Empty;
        return Sanitizer.Sanitize(html);
    }

    public bool HasUnknownVariables(params string?[] templateParts) => GetUnknownVariables(templateParts).Count > 0;

    public IReadOnlyCollection<string> GetUnknownVariables(params string?[] templateParts)
    {
        var content = string.Join(" ", templateParts.Where(x => !string.IsNullOrWhiteSpace(x)));
        if (string.IsNullOrWhiteSpace(content)) return [];

        var unknown = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in VariableRegex().Matches(content))
        {
            var variableName = match.Groups[1].Value;
            if (!AllowedVariableSet.Contains(variableName))
            {
                unknown.Add(variableName);
            }
        }

        return unknown.OrderBy(x => x).ToArray();
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
        sanitizer.AllowedAttributes.UnionWith(
        [
            // CRITICAL: inline styles carry the whole email design.
            "style", "class",
            "href", "target", "rel", "src", "alt", "title",
            "width", "height", "align", "valign",
            "bgcolor", "background", "color", "border",
            "cellpadding", "cellspacing", "role",
            "colspan", "rowspan"
        ]);

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

        // Preserve {{Variable}} placeholders that appear inside URL attributes
        // (e.g. href="{{ResetLink}}"). Ganss would otherwise drop the attribute
        // because "{{ResetLink}}" is not a valid URL scheme.
        sanitizer.RemovingAttribute += (_, e) =>
        {
            var value = e.Attribute?.Value;
            if (!string.IsNullOrEmpty(value) && VariableRegex().IsMatch(value))
            {
                e.Cancel = true;
            }
        };

        return sanitizer;
    }
}
