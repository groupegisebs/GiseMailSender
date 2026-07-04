using System.Net;
using System.Text.RegularExpressions;

namespace SecureMailGateway.Services;

/// <summary>
/// Convertit du HTML en texte brut et détecte les chaînes contenant du HTML.
/// Utilisé pour garantir que la partie text/plain d'un e-mail ne transporte jamais
/// le code source HTML (ce qui s'affichait sinon tel quel chez le destinataire).
/// </summary>
public static partial class PlainTextConverter
{
    [GeneratedRegex(@"<(style|script)[^>]*>[\s\S]*?</\s*\1\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex StyleScriptRegex();

    [GeneratedRegex(@"<\s*br\s*/?\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex LineBreakRegex();

    [GeneratedRegex(@"</\s*(p|div|tr|li|h[1-6]|table|ul|ol|blockquote|section|header|footer)\s*>", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex BlockEndRegex();

    [GeneratedRegex(@"<[^>]+>", RegexOptions.Compiled)]
    private static partial Regex AnyTagRegex();

    [GeneratedRegex(@"[ \t\f\v\r]+", RegexOptions.Compiled)]
    private static partial Regex HorizontalWhitespaceRegex();

    [GeneratedRegex(@"[ \t]*\n[ \t]*", RegexOptions.Compiled)]
    private static partial Regex AroundNewlineRegex();

    [GeneratedRegex(@"\n{3,}", RegexOptions.Compiled)]
    private static partial Regex ExtraBlankLinesRegex();

    /// <summary>
    /// Indique si la chaîne ressemble à du HTML (document complet ou simples balises).
    /// </summary>
    public static bool LooksLikeHtml(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        if (value.Contains("<!doctype", StringComparison.OrdinalIgnoreCase)) return true;
        if (value.Contains("<html", StringComparison.OrdinalIgnoreCase)) return true;
        return AnyTagRegex().IsMatch(value);
    }

    /// <summary>
    /// Dérive une version texte brut lisible à partir d'un fragment ou document HTML.
    /// </summary>
    public static string FromHtml(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return string.Empty;

        var text = StyleScriptRegex().Replace(html, " ");
        text = LineBreakRegex().Replace(text, "\n");
        text = BlockEndRegex().Replace(text, "\n");
        text = AnyTagRegex().Replace(text, string.Empty);
        text = WebUtility.HtmlDecode(text);
        text = HorizontalWhitespaceRegex().Replace(text, " ");
        text = AroundNewlineRegex().Replace(text, "\n");
        text = ExtraBlankLinesRegex().Replace(text, "\n\n");
        return text.Trim();
    }
}
