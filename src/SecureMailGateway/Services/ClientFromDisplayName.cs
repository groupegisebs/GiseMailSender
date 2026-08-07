using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

/// <summary>
/// Nom d'expéditeur affiché : toujours <c>[GISEBS_{NomApplication}]</c>
/// (ex. [GISEBS_TutorSphere], [GISEBS_HoloTuto]).
/// </summary>
public static class ClientFromDisplayName
{
    public static string For(ClientApplication? client)
    {
        var raw = client?.Name?.Trim();
        if (string.IsNullOrWhiteSpace(raw))
            raw = client?.ClientCode?.Trim();
        if (string.IsNullOrWhiteSpace(raw))
            return "[GISEBS]";

        // "BoutiqueGise — Agentia Market" → "BoutiqueGise"
        foreach (var sep in new[] { " — ", " - ", " – ", " | " })
        {
            var idx = raw.IndexOf(sep, StringComparison.Ordinal);
            if (idx > 0)
            {
                raw = raw[..idx].Trim();
                break;
            }
        }

        // Nettoyer si un ancien format ou préfixe était déjà présent
        raw = raw.Trim().Trim('[', ']');
        if (raw.StartsWith("GISEBS_", StringComparison.OrdinalIgnoreCase))
            raw = raw["GISEBS_".Length..].Trim();
        if (raw.EndsWith("_GISEBS", StringComparison.OrdinalIgnoreCase))
            raw = raw[..^"_GISEBS".Length].Trim();
        if (raw.Equals("GISEBS", StringComparison.OrdinalIgnoreCase))
            return "[GISEBS]";

        return $"[GISEBS_{raw}]";
    }
}
