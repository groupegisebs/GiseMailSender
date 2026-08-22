namespace SecureMailGateway.Configuration;

public sealed class MailHistoryOptions
{
    public const string SectionName = "MailHistory";

    /// <summary>Supprime les e-mails Sent / Failed / Cancelled plus anciens que ce délai.</summary>
    public int RetentionDays { get; set; } = 90;

    public bool Enabled { get; set; } = true;

    public int BatchSize { get; set; } = 200;

    /// <summary>Nombre minimum de jours imposé pour une purge manuelle (évite un vidage accidentel).</summary>
    public int MinManualPurgeDays { get; set; } = 14;
}
