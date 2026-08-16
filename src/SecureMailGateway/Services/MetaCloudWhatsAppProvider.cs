using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SecureMailGateway.Services;

/// <summary>Résultat d'un appel à l'opérateur. <c>Transient</c> autorise une nouvelle tentative.</summary>
public sealed record WhatsAppSendOutcome(
    bool Success,
    string? ProviderMessageId = null,
    string? RecipientWaId = null,
    string? RawResponse = null,
    string? Error = null,
    int? ErrorCode = null,
    bool Transient = false);

/// <summary>
/// Abstraction de l'opérateur WhatsApp. Une seule implémentation aujourd'hui (API Cloud de Meta) ;
/// elle isole le reste de la passerelle si un agrégateur type Twilio est retenu plus tard.
/// </summary>
public interface IWhatsAppProvider
{
    string Name { get; }

    Task<WhatsAppSendOutcome> SendAsync(WhatsAppSettings settings, string payloadJson, CancellationToken ct = default);
}

public class MetaCloudWhatsAppProvider(
    IHttpClientFactory httpClientFactory,
    ILogger<MetaCloudWhatsAppProvider> logger) : IWhatsAppProvider
{
    public const string HttpClientName = "whatsapp";

    public string Name => "MetaCloud";

    public async Task<WhatsAppSendOutcome> SendAsync(
        WhatsAppSettings settings, string payloadJson, CancellationToken ct = default)
    {
        if (!settings.IsUsable)
            return new WhatsAppSendOutcome(false, Error: "Canal WhatsApp non configuré (PhoneNumberId ou jeton d'accès manquant).");

        var baseUrl = settings.BaseUrl.TrimEnd('/');
        var url = $"{baseUrl}/{settings.ApiVersion.Trim('/')}/{settings.PhoneNumberId}/messages";

        try
        {
            var client = httpClientFactory.CreateClient(HttpClientName);
            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(payloadJson, Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", settings.AccessToken);

            using var response = await client.SendAsync(request, ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            var raw = Truncate(body, 4000);

            if (response.IsSuccessStatusCode)
            {
                var (messageId, waId) = ReadSuccess(body);
                return new WhatsAppSendOutcome(true, messageId, waId, raw);
            }

            var (message, code) = ReadError(body);
            var transient = response.StatusCode is HttpStatusCode.TooManyRequests
                or HttpStatusCode.InternalServerError or HttpStatusCode.BadGateway
                or HttpStatusCode.ServiceUnavailable or HttpStatusCode.GatewayTimeout
                or HttpStatusCode.RequestTimeout;

            return new WhatsAppSendOutcome(
                false,
                RawResponse: raw,
                Error: $"HTTP {(int)response.StatusCode} : {message}",
                ErrorCode: code,
                Transient: transient);
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            logger.LogWarning(ex, "Appel WhatsApp injoignable");
            return new WhatsAppSendOutcome(false, Error: $"Opérateur injoignable : {ex.Message}", Transient: true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Échec inattendu d'un envoi WhatsApp");
            return new WhatsAppSendOutcome(false, Error: ex.Message);
        }
    }

    private static (string? MessageId, string? WaId) ReadSuccess(string body)
    {
        try
        {
            using var doc = JsonDocument.Parse(body);
            string? messageId = null;
            string? waId = null;

            if (doc.RootElement.TryGetProperty("messages", out var messages) &&
                messages.ValueKind == JsonValueKind.Array && messages.GetArrayLength() > 0 &&
                messages[0].TryGetProperty("id", out var id))
                messageId = id.GetString();

            if (doc.RootElement.TryGetProperty("contacts", out var contacts) &&
                contacts.ValueKind == JsonValueKind.Array && contacts.GetArrayLength() > 0 &&
                contacts[0].TryGetProperty("wa_id", out var wa))
                waId = wa.GetString();

            return (messageId, waId);
        }
        catch (JsonException)
        {
            return (null, null);
        }
    }

    private static (string Message, int? Code) ReadError(string body)
    {
        try
        {
            using var doc = JsonDocument.Parse(body);
            if (doc.RootElement.TryGetProperty("error", out var error))
            {
                var message = error.TryGetProperty("message", out var m) ? m.GetString() : null;
                var details = error.TryGetProperty("error_data", out var d) &&
                              d.TryGetProperty("details", out var dd)
                    ? dd.GetString()
                    : null;
                var code = error.TryGetProperty("code", out var c) && c.TryGetInt32(out var parsed) ? parsed : (int?)null;

                var text = string.IsNullOrWhiteSpace(details) ? message : $"{message} ({details})";
                return (text ?? "erreur non détaillée", code);
            }
        }
        catch (JsonException)
        {
            // Corps non JSON (page d'erreur d'un intermédiaire) : on garde le texte brut.
        }

        return (Truncate(body, 500), null);
    }

    private static string Truncate(string? value, int max)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        return value.Length <= max ? value : value[..max];
    }
}
