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

        sanitizer.AllowedTags.Clear();
        sanitizer.AllowedTags.UnionWith(
        [
            "div", "table", "tr", "td", "p", "span", "strong", "em", "u", "a", "img",
            "h1", "h2", "h3", "ul", "ol", "li", "br", "hr", "button"
        ]);

        sanitizer.AllowedAttributes.Clear();
        sanitizer.AllowedAttributes.UnionWith(
        [
            "href", "target", "rel", "src", "alt", "title",
            "style", "class", "width", "height", "align",
            "border", "cellpadding", "cellspacing"
        ]);

        sanitizer.AllowedSchemes.Clear();
        sanitizer.AllowedSchemes.UnionWith(["http", "https", "mailto"]);

        sanitizer.AllowedCssProperties.Clear();
        sanitizer.AllowedCssProperties.UnionWith(
        [
            "color", "background", "background-color", "font-size", "font-weight",
            "font-family", "line-height", "letter-spacing", "text-align", "text-decoration",
            "padding", "padding-left", "padding-right", "padding-top", "padding-bottom",
            "margin", "margin-left", "margin-right", "margin-top", "margin-bottom",
            "border", "border-top", "border-right", "border-bottom", "border-left",
            "border-radius", "display", "max-width", "min-width", "width", "height"
        ]);

        return sanitizer;
    }
}
