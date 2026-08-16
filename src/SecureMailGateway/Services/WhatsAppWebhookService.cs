using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public sealed record WhatsAppWebhookResult(int StatusUpdates, int InboundMessages);

public interface IWhatsAppWebhookService
{
    /// <summary>Compare le jeton présenté par Meta lors de l'abonnement au webhook.</summary>
    Task<bool> VerifyTokenAsync(string? presentedToken, CancellationToken ct = default);

    /// <summary>
    /// Contrôle l'entête X-Hub-Signature-256. Retourne faux si la signature est absente ou fausse
    /// alors qu'un secret d'application est configuré ; vrai si aucun secret n'est configuré.
    /// </summary>
    Task<bool> VerifySignatureAsync(string? signatureHeader, string rawBody, CancellationToken ct = default);

    Task<WhatsAppWebhookResult> ProcessAsync(string rawBody, CancellationToken ct = default);
}

public class WhatsAppWebhookService(
    ApplicationDbContext db,
    IWhatsAppSettingsProvider settingsProvider,
    IWhatsAppCallbackNotifier callbackNotifier,
    ILogger<WhatsAppWebhookService> logger) : IWhatsAppWebhookService
{
    public async Task<bool> VerifyTokenAsync(string? presentedToken, CancellationToken ct = default)
    {
        var settings = await settingsProvider.GetAsync(ct);
        if (string.IsNullOrWhiteSpace(settings.WebhookVerifyToken)) return false;
        if (string.IsNullOrWhiteSpace(presentedToken)) return false;

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(settings.WebhookVerifyToken),
            Encoding.UTF8.GetBytes(presentedToken));
    }

    public async Task<bool> VerifySignatureAsync(
        string? signatureHeader, string rawBody, CancellationToken ct = default)
    {
        var settings = await settingsProvider.GetAsync(ct);
        if (string.IsNullOrWhiteSpace(settings.AppSecret))
        {
            logger.LogWarning("Webhook WhatsApp accepté sans vérification : aucun secret d'application configuré.");
            return true;
        }

        if (string.IsNullOrWhiteSpace(signatureHeader)) return false;

        var provided = signatureHeader.StartsWith("sha256=", StringComparison.OrdinalIgnoreCase)
            ? signatureHeader["sha256=".Length..]
            : signatureHeader;

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(settings.AppSecret));
        var expected = Convert.ToHexStringLower(hmac.ComputeHash(Encoding.UTF8.GetBytes(rawBody)));

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(expected),
            Encoding.UTF8.GetBytes(provided.Trim().ToLowerInvariant()));
    }

    public async Task<WhatsAppWebhookResult> ProcessAsync(string rawBody, CancellationToken ct = default)
    {
        var statuses = 0;
        var inbound = 0;

        JsonDocument doc;
        try
        {
            doc = JsonDocument.Parse(rawBody);
        }
        catch (JsonException ex)
        {
            logger.LogWarning(ex, "Charge utile de webhook WhatsApp illisible");
            return new WhatsAppWebhookResult(0, 0);
        }

        using (doc)
        {
            if (!doc.RootElement.TryGetProperty("entry", out var entries) ||
                entries.ValueKind != JsonValueKind.Array)
                return new WhatsAppWebhookResult(0, 0);

            foreach (var entry in entries.EnumerateArray())
            {
                if (!entry.TryGetProperty("changes", out var changes) || changes.ValueKind != JsonValueKind.Array)
                    continue;

                foreach (var change in changes.EnumerateArray())
                {
                    if (!change.TryGetProperty("value", out var value)) continue;

                    var phoneNumberId = value.TryGetProperty("metadata", out var meta) &&
                                        meta.TryGetProperty("phone_number_id", out var pid)
                        ? pid.GetString()
                        : null;

                    if (value.TryGetProperty("statuses", out var statusArray) &&
                        statusArray.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var status in statusArray.EnumerateArray())
                            statuses += await ApplyStatusAsync(status, ct) ? 1 : 0;
                    }

                    if (value.TryGetProperty("messages", out var messageArray) &&
                        messageArray.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var incoming in messageArray.EnumerateArray())
                            inbound += await RecordInboundAsync(incoming, value, phoneNumberId, ct) ? 1 : 0;
                    }
                }
            }
        }

        return new WhatsAppWebhookResult(statuses, inbound);
    }

    private async Task<bool> ApplyStatusAsync(JsonElement status, CancellationToken ct)
    {
        var providerId = status.TryGetProperty("id", out var id) ? id.GetString() : null;
        var state = status.TryGetProperty("status", out var s) ? s.GetString() : null;
        if (string.IsNullOrWhiteSpace(providerId) || string.IsNullOrWhiteSpace(state))
            return false;

        var message = await db.WhatsAppMessages
            .FirstOrDefaultAsync(m => m.ProviderMessageId == providerId, ct);

        if (message is null)
        {
            // Message expédié hors de cette passerelle, ou base réinitialisée : on ne bloque pas Meta.
            logger.LogDebug("Statut WhatsApp ignoré : identifiant {ProviderId} inconnu", providerId);
            return false;
        }

        var at = ReadTimestamp(status) ?? DateTimeOffset.UtcNow;
        var previous = message.Status;

        switch (state.ToLowerInvariant())
        {
            case "sent":
                message.SentAt ??= at;
                if (message.Status == WhatsAppStatus.Queued || message.Status == WhatsAppStatus.Sending)
                    message.Status = WhatsAppStatus.Sent;
                break;

            case "delivered":
                message.DeliveredAt ??= at;
                // La lecture est un état plus avancé : ne jamais revenir en arrière.
                if (message.Status != WhatsAppStatus.Read)
                    message.Status = WhatsAppStatus.Delivered;
                break;

            case "read":
                message.ReadAt ??= at;
                message.Status = WhatsAppStatus.Read;
                break;

            case "failed":
                message.FailedAt ??= at;
                message.Status = WhatsAppStatus.Failed;
                var (error, code) = ReadStatusError(status);
                message.ErrorMessage = error ?? message.ErrorMessage;
                message.ErrorCode = code ?? message.ErrorCode;
                MetricsRegistry.WhatsAppFailed.Inc();
                break;

            default:
                return false;
        }

        db.WhatsAppSendLogs.Add(new WhatsAppSendLog
        {
            WhatsAppMessageId = message.Id,
            EventType = Capitalize(state),
            Message = $"Statut opérateur : {state}",
            Details = status.GetRawText()
        });

        await db.SaveChangesAsync(ct);

        if (previous != message.Status)
            await callbackNotifier.NotifyAsync(message, ct);

        return true;
    }

    private async Task<bool> RecordInboundAsync(
        JsonElement incoming, JsonElement value, string? phoneNumberId, CancellationToken ct)
    {
        var from = incoming.TryGetProperty("from", out var f) ? f.GetString() : null;
        if (string.IsNullOrWhiteSpace(from)) return false;

        var providerId = incoming.TryGetProperty("id", out var id) ? id.GetString() : null;

        if (!string.IsNullOrWhiteSpace(providerId) &&
            await db.WhatsAppInboundMessages.AnyAsync(m => m.ProviderMessageId == providerId, ct))
            return false; // Meta rejoue un webhook non acquitté : éviter les doublons.

        var type = incoming.TryGetProperty("type", out var t) ? t.GetString() ?? "text" : "text";
        var text = type switch
        {
            "text" when incoming.TryGetProperty("text", out var textNode) &&
                        textNode.TryGetProperty("body", out var body) => body.GetString(),
            "button" when incoming.TryGetProperty("button", out var buttonNode) &&
                          buttonNode.TryGetProperty("text", out var buttonText) => buttonText.GetString(),
            "interactive" => ReadInteractive(incoming),
            _ => null
        };

        var profileName = value.TryGetProperty("contacts", out var contacts) &&
                          contacts.ValueKind == JsonValueKind.Array && contacts.GetArrayLength() > 0 &&
                          contacts[0].TryGetProperty("profile", out var profile) &&
                          profile.TryGetProperty("name", out var name)
            ? name.GetString()
            : null;

        db.WhatsAppInboundMessages.Add(new WhatsAppInboundMessage
        {
            FromPhone = Truncate(from, 20)!,
            ProfileName = Truncate(profileName, 200),
            ProviderMessageId = Truncate(providerId, 128),
            PhoneNumberId = Truncate(phoneNumberId, 32),
            MessageType = Truncate(type, 32)!,
            Text = Truncate(text, 4000),
            RawJson = incoming.GetRawText(),
            ReceivedAt = ReadTimestamp(incoming) ?? DateTimeOffset.UtcNow
        });

        await db.SaveChangesAsync(ct);
        MetricsRegistry.WhatsAppInbound.Inc();
        return true;
    }

    private static string? ReadInteractive(JsonElement incoming)
    {
        if (!incoming.TryGetProperty("interactive", out var interactive)) return null;

        if (interactive.TryGetProperty("button_reply", out var button) &&
            button.TryGetProperty("title", out var buttonTitle))
            return buttonTitle.GetString();

        if (interactive.TryGetProperty("list_reply", out var list) &&
            list.TryGetProperty("title", out var listTitle))
            return listTitle.GetString();

        return null;
    }

    private static (string? Error, int? Code) ReadStatusError(JsonElement status)
    {
        if (!status.TryGetProperty("errors", out var errors) ||
            errors.ValueKind != JsonValueKind.Array || errors.GetArrayLength() == 0)
            return (null, null);

        var first = errors[0];
        var title = first.TryGetProperty("title", out var t) ? t.GetString() : null;
        var details = first.TryGetProperty("error_data", out var data) &&
                      data.TryGetProperty("details", out var d)
            ? d.GetString()
            : first.TryGetProperty("message", out var m) ? m.GetString() : null;
        var code = first.TryGetProperty("code", out var c) && c.TryGetInt32(out var parsed) ? parsed : (int?)null;

        var text = string.IsNullOrWhiteSpace(details) ? title : $"{title} — {details}";
        return (Truncate(text, 2000), code);
    }

    private static DateTimeOffset? ReadTimestamp(JsonElement element)
    {
        if (!element.TryGetProperty("timestamp", out var ts)) return null;

        var raw = ts.ValueKind == JsonValueKind.String ? ts.GetString() : ts.ToString();
        return long.TryParse(raw, out var seconds)
            ? DateTimeOffset.FromUnixTimeSeconds(seconds)
            : null;
    }

    private static string Capitalize(string value) =>
        value.Length == 0 ? value : char.ToUpperInvariant(value[0]) + value[1..];

    private static string? Truncate(string? value, int max)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= max ? value : value[..max];
    }
}
