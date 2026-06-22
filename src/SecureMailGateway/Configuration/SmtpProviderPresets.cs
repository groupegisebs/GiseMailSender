namespace SecureMailGateway.Configuration;

public sealed record SmtpProviderPreset(
    string Key,
    string DisplayName,
    string ProviderName,
    string Host,
    int Port,
    bool UseSsl);

public static class SmtpProviderPresets
{
    public const string CustomKey = "custom";

    public static IReadOnlyList<SmtpProviderPreset> All { get; } =
    [
        new("office365", "Microsoft 365 / Outlook", "Microsoft 365", "smtp.office365.com", 587, true),
        new("gmail", "Gmail (mot de passe d'application)", "Gmail", "smtp.gmail.com", 587, true),
        new("sendgrid", "SendGrid", "SendGrid", "smtp.sendgrid.net", 587, true),
        new("brevo", "Brevo (ex-Sendinblue)", "Brevo", "smtp-relay.brevo.com", 587, true),
        new("mailgun", "Mailgun", "Mailgun", "smtp.mailgun.org", 587, true),
        new("ovh", "OVH", "OVH", "ssl0.ovh.net", 587, true),
        new("ionos", "IONOS", "IONOS", "smtp.ionos.fr", 587, true),
        new("zoho", "Zoho Mail", "Zoho Mail", "smtp.zoho.com", 587, true),
        new("yahoo", "Yahoo Mail", "Yahoo Mail", "smtp.mail.yahoo.com", 587, true),
        new("ses-eu-west-1", "Amazon SES (eu-west-1)", "Amazon SES", "email-smtp.eu-west-1.amazonaws.com", 587, true),
    ];

    public static SmtpProviderPreset? FindByKey(string? key) =>
        string.IsNullOrWhiteSpace(key) || key == CustomKey
            ? null
            : All.FirstOrDefault(p => p.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

    public static string? FindKeyByHost(string? host)
    {
        if (string.IsNullOrWhiteSpace(host)) return null;
        return All.FirstOrDefault(p => p.Host.Equals(host, StringComparison.OrdinalIgnoreCase))?.Key
               ?? CustomKey;
    }
}
