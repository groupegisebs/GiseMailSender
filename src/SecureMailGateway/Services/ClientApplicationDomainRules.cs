namespace SecureMailGateway.Services;

public static class ClientApplicationDomainRules
{
    public const string AllowAllWildcard = "*";

    public static bool AllowsAllDomains(string? allowedDomains)
    {
        if (string.IsNullOrWhiteSpace(allowedDomains))
            return true;

        return Parse(allowedDomains).Contains(AllowAllWildcard);
    }

    public static string? NormalizeAllowedDomains(bool allowAllDomains, string? allowedDomains)
    {
        if (allowAllDomains)
            return null;

        var trimmed = allowedDomains?.Trim();
        return string.IsNullOrEmpty(trimmed) ? null : trimmed;
    }

    public static IReadOnlySet<string> ParseAllowedDomains(string? allowedDomains) => Parse(allowedDomains);

    private static HashSet<string> Parse(string? allowedDomains) =>
        (allowedDomains ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(d => d.ToLowerInvariant())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
}
