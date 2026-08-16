namespace SecureMailGateway.Models.Enums;

/// <summary>
/// Cycle de vie d'un message WhatsApp. Contrairement au courriel, l'opérateur renvoie aussi
/// la remise et la lecture par webhook : ces états arrivent après l'envoi.
/// </summary>
public enum WhatsAppStatus
{
    Queued = 0,
    Sending = 1,
    Sent = 2,
    Delivered = 3,
    Read = 4,
    Failed = 5,
    Cancelled = 6
}

public enum WhatsAppMessageKind
{
    /// <summary>Modèle approuvé par Meta : seul type autorisé pour un message que l'on initie.</summary>
    Template = 0,

    /// <summary>Texte libre : accepté uniquement dans les 24 h suivant un message du destinataire.</summary>
    Text = 1
}
