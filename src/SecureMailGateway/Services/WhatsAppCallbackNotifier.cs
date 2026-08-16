using System.Text;
using System.Text.Json;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

public interface IWhatsAppCallbackNotifier
{
    /// <summary>
    /// Pousse l'état courant vers l'application appelante. Utilisé après l'envoi puis à chaque
    /// changement signalé par l'opérateur (remise, lecture, échec).
    /// </summary>
    Task NotifyAsync(WhatsAppMessage message, CancellationToken ct = default);
}

public class WhatsAppCallbackNotifier(
    IHttpClientFactory httpClientFactory,
    ILogger<WhatsAppCallbackNotifier> logger) : IWhatsAppCallbackNotifier
{
    public async Task NotifyAsync(WhatsAppMessage message, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(message.CallbackUrl)) return;

        try
        {
            var client = httpClientFactory.CreateClient("callback");
            var payload = JsonSerializer.Serialize(new
            {
                channel = "whatsapp",
                message.MessageCode,
                trackingId = message.Id,
                status = message.Status.ToString(),
                to = message.ToPhone,
                message.ProviderMessageId,
                message.SentAt,
                message.DeliveredAt,
                message.ReadAt,
                message.FailedAt,
                message.ErrorMessage,
                message.ErrorCode
            });
            using var content = new StringContent(payload, Encoding.UTF8, "application/json");
            await client.PostAsync(message.CallbackUrl, content, ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Rappel client en échec pour {Code}", message.MessageCode);
        }
    }
}
