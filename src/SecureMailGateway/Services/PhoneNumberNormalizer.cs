using System.Text;

namespace SecureMailGateway.Services;

public interface IPhoneNumberNormalizer
{
    /// <summary>
    /// Ramène un numéro saisi librement au format attendu par l'API Cloud : chiffres uniquement,
    /// indicatif pays inclus, sans le signe plus.
    /// </summary>
    bool TryNormalize(string? input, string? defaultCountryCode, out string normalized, out string? error);
}

public class PhoneNumberNormalizer : IPhoneNumberNormalizer
{
    public bool TryNormalize(string? input, string? defaultCountryCode, out string normalized, out string? error)
    {
        normalized = string.Empty;
        error = null;

        if (string.IsNullOrWhiteSpace(input))
        {
            error = "Numéro de téléphone manquant.";
            return false;
        }

        var raw = input.Trim();
        var hadPlus = raw.StartsWith('+') || raw.StartsWith("00", StringComparison.Ordinal);

        var digits = new StringBuilder();
        foreach (var c in raw)
        {
            if (char.IsDigit(c)) digits.Append(c);
        }

        var value = digits.ToString();
        if (value.StartsWith("00", StringComparison.Ordinal))
            value = value[2..];

        if (value.Length == 0)
        {
            error = $"Numéro « {input} » invalide : aucun chiffre exploitable.";
            return false;
        }

        // Numéro national : on ne devine jamais l'indicatif, il doit être configuré explicitement.
        if (!hadPlus)
        {
            var country = new string((defaultCountryCode ?? string.Empty).Where(char.IsDigit).ToArray());
            if (country.Length > 0 && !value.StartsWith(country, StringComparison.Ordinal))
            {
                value = country + value.TrimStart('0');
            }
            else if (country.Length == 0 && value.Length <= 10)
            {
                error = $"Numéro « {input} » sans indicatif pays. Utilisez le format international (+237…) " +
                        "ou configurez un indicatif par défaut.";
                return false;
            }
        }

        if (value.Length is < 8 or > 15)
        {
            error = $"Numéro « {input} » invalide : {value.Length} chiffres après normalisation, 8 à 15 attendus.";
            return false;
        }

        normalized = value;
        return true;
    }
}
