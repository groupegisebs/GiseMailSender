using System.Text.RegularExpressions;
using Ganss.Xss;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

public interface ITemplateRenderer
{
    string Render(string template, Dictionary<string, string>? data);
    string SanitizeHtml(string html);
    List<string> ExtractVariables(string subject, string html, string? text);
}

public partial class TemplateRenderer : ITemplateRenderer
{
    private static readonly HtmlSanitizer Sanitizer = CreateSanitizer();

    [GeneratedRegex(@"\{\{(\w+)\}\}", RegexOptions.Compiled)]
    private static partial Regex VariableRegex();

    public string Render(string template, Dictionary<string, string>? data)
    {
        if (string.IsNullOrEmpty(template) || data is null || data.Count == 0)
            return template;

        return VariableRegex().Replace(template, match =>
        {
            var key = match.Groups[1].Value;
            return data.TryGetValue(key, out var value) ? value : match.Value;
        });
    }

    public string SanitizeHtml(string html)
    {
        if (string.IsNullOrWhiteSpace(html)) return string.Empty;
        return Sanitizer.Sanitize(html);
    }

    public List<string> ExtractVariables(string subject, string html, string? text)
    {
        var vars = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match m in VariableRegex().Matches(subject + html + (text ?? "")))
            vars.Add(m.Groups[1].Value);
        return vars.OrderBy(v => v).ToList();
    }

    private static HtmlSanitizer CreateSanitizer()
    {
        var s = new HtmlSanitizer();
        s.AllowedTags.Add("style");
        s.AllowedAttributes.Add("class");
        s.AllowedAttributes.Add("style");
        s.AllowedCssProperties.Add("color");
        s.AllowedCssProperties.Add("background-color");
        s.AllowedCssProperties.Add("font-size");
        s.AllowedCssProperties.Add("text-align");
        s.AllowedCssProperties.Add("padding");
        s.AllowedCssProperties.Add("margin");
        return s;
    }
}
