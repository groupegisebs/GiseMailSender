namespace SecureMailGateway.Models.Entities;

/// <summary>Numérotation annuelle propre au canal WhatsApp, indépendante de celle du courriel.</summary>
public class WhatsAppCodeSequence
{
    public int Year { get; set; }
    public int LastNumber { get; set; }
}
