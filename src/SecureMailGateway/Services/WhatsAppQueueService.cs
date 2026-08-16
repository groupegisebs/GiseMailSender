using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Services;

public interface IWhatsAppQueueService
{
    /// <param name="dispatchInBackground">
    /// Faux pour que l'appelant expédie lui-même : l'écran de test affiche ainsi le verdict de
    /// l'opérateur immédiatement, au lieu d'attendre la reprise du job Hangfire.
    /// </param>
    Task<SendWhatsAppResponse> QueueAsync(
        SendWhatsAppRequest request, Guid clientId, string? ip, CancellationToken ct = default,
        bool dispatchInBackground = true);
}

public class WhatsAppQueueService(
    ApplicationDbContext db,
    IWhatsAppCodeGenerator codeGenerator,
    IWhatsAppSettingsProvider settingsProvider,
    IPhoneNumberNormalizer phoneNormalizer,
    IAuditService auditService,
    IBackgroundJobScheduler jobScheduler) : IWhatsAppQueueService
{
    /// <summary>Fenêtre de service : hors de ce délai, seul un modèle approuvé peut être expédié.</summary>
    private static readonly TimeSpan CustomerCareWindow = TimeSpan.FromHours(24);

    public async Task<SendWhatsAppResponse> QueueAsync(
        SendWhatsAppRequest request, Guid clientId, string? ip, CancellationToken ct = default,
        bool dispatchInBackground = true)
    {
        var client = await db.ClientApplications.FindAsync([clientId], ct)
            ?? throw new InvalidOperationException("Client not found.");

        if (!client.IsActive)
            return Fail("Application cliente désactivée.");

        if (!string.Equals(client.ClientCode, request.ClientCode, StringComparison.OrdinalIgnoreCase))
            return Fail("Le clientCode ne correspond pas à la clé d'API utilisée.");

        var settings = await settingsProvider.GetAsync(ct);
        if (!settings.IsUsable)
            return Fail("Canal WhatsApp non configuré sur la passerelle. Renseignez le numéro expéditeur et le jeton d'accès.");

        if (!phoneNormalizer.TryNormalize(request.To, settings.DefaultCountryCode, out var to, out var phoneError))
            return Fail(phoneError!);

        if (!await CheckQuotaAsync(client, ct))
            return Fail("Quota d'envoi dépassé.");

        var kind = (request.Kind ?? "template").Trim().ToLowerInvariant() switch
        {
            "text" => WhatsAppMessageKind.Text,
            "template" or "" => WhatsAppMessageKind.Template,
            _ => (WhatsAppMessageKind?)null
        };

        if (kind is null)
            return Fail("Champ kind attendu : template ou text.");

        var language = NormalizeLanguage(request.Language);

        var built = kind == WhatsAppMessageKind.Text
            ? await BuildTextAsync(request, to, ct)
            : await BuildTemplateAsync(request, to, language, clientId, ct);

        if (built.Error is not null)
            return Fail(built.Error);

        var message = new WhatsAppMessage
        {
            MessageCode = await codeGenerator.GenerateAsync(ct),
            ClientApplicationId = clientId,
            TemplateCode = string.IsNullOrWhiteSpace(request.TemplateCode) ? null : request.TemplateCode.Trim().ToUpperInvariant(),
            MetaTemplateName = built.MetaTemplateName,
            Language = language,
            Kind = kind.Value,
            ToPhone = to,
            BodyPreview = built.Preview,
            PayloadJson = built.Payload!,
            Status = WhatsAppStatus.Queued,
            Priority = request.Priority,
            CallbackUrl = request.CallbackUrl
        };

        db.WhatsAppMessages.Add(message);
        db.WhatsAppSendLogs.Add(new WhatsAppSendLog
        {
            WhatsAppMessageId = message.Id,
            EventType = "Queued",
            Message = $"Message {kind} mis en file pour {to}"
        });
        await db.SaveChangesAsync(ct);

        await auditService.LogAsync(AuditAction.WhatsAppQueued, clientId: clientId,
            entityType: nameof(WhatsAppMessage), entityId: message.Id.ToString(),
            ipAddress: ip, details: new { message.MessageCode, message.TemplateCode, message.MetaTemplateName },
            ct: ct);

        if (dispatchInBackground)
            jobScheduler.EnqueueWhatsAppSend(message.Id);

        return new SendWhatsAppResponse
        {
            Success = true,
            MessageCode = message.MessageCode,
            TrackingId = message.Id,
            Status = WhatsAppStatus.Queued.ToString(),
            To = to
        };
    }

    private sealed record BuiltMessage(
        string? Payload = null, string? Preview = null, string? MetaTemplateName = null, string? Error = null);

    private async Task<BuiltMessage> BuildTextAsync(SendWhatsAppRequest request, string to, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
            return new BuiltMessage(Error: "Champ text requis pour kind = text.");

        // WhatsApp n'accepte du texte libre que si le destinataire a écrit dans les 24 dernières heures.
        var since = DateTimeOffset.UtcNow - CustomerCareWindow;
        var hasOpenWindow = await db.WhatsAppInboundMessages
            .AnyAsync(m => m.FromPhone == to && m.ReceivedAt >= since, ct);

        if (!hasOpenWindow)
            return new BuiltMessage(Error:
                $"Aucun message reçu de {to} dans les 24 dernières heures : WhatsApp n'autorise " +
                "que l'envoi d'un modèle approuvé (kind = template) en dehors de cette fenêtre.");

        var text = request.Text.Trim();
        var payload = new JsonObject
        {
            ["messaging_product"] = "whatsapp",
            ["recipient_type"] = "individual",
            ["to"] = to,
            ["type"] = "text",
            ["text"] = new JsonObject
            {
                ["preview_url"] = true,
                ["body"] = text
            }
        };

        return new BuiltMessage(payload.ToJsonString(), Truncate(text, 2000));
    }

    private async Task<BuiltMessage> BuildTemplateAsync(
        SendWhatsAppRequest request, string to, string language, Guid clientId, CancellationToken ct)
    {
        var code = request.TemplateCode?.Trim().ToUpperInvariant();
        var mapping = code is null ? null : await ResolveTemplateAsync(code, language, clientId, ct);

        string metaName;
        string metaLanguage;
        List<string> bodyValues;
        List<string> headerValues;
        string? buttonValue;

        if (mapping is not null)
        {
            if (!mapping.IsActive)
                return new BuiltMessage(Error: $"La correspondance du modèle « {code} » est désactivée.");

            metaName = mapping.MetaTemplateName;
            metaLanguage = mapping.MetaLanguageCode;

            var data = new Dictionary<string, string>(request.BodyData ?? [], StringComparer.OrdinalIgnoreCase);

            if (!TryTakeNamed(WhatsAppTemplate.SplitParameters(mapping.BodyParameters), data, out bodyValues, out var missingBody))
                return new BuiltMessage(Error: MissingVariablesError(code!, missingBody));

            if (!TryTakeNamed(WhatsAppTemplate.SplitParameters(mapping.HeaderParameters), data, out headerValues, out var missingHeader))
                return new BuiltMessage(Error: MissingVariablesError(code!, missingHeader));

            buttonValue = null;
            if (!string.IsNullOrWhiteSpace(mapping.ButtonUrlParameter))
            {
                if (!data.TryGetValue(mapping.ButtonUrlParameter, out var value) || string.IsNullOrWhiteSpace(value))
                    return new BuiltMessage(Error: MissingVariablesError(code!, [mapping.ButtonUrlParameter]));
                buttonValue = value;
            }
        }
        else
        {
            // Aucune correspondance enregistrée : l'appelant doit fournir le nom Meta et l'ordre exact.
            if (string.IsNullOrWhiteSpace(request.MetaTemplateName))
                return new BuiltMessage(Error: code is null
                    ? "Fournissez templateCode (avec une correspondance enregistrée) ou metaTemplateName."
                    : $"Aucune correspondance enregistrée pour le modèle « {code} » en langue « {language} ». " +
                      "Déclarez-la via POST /api/whatsapp/templates ou fournissez metaTemplateName et parameters.");

            metaName = request.MetaTemplateName.Trim();
            metaLanguage = language;
            bodyValues = [.. request.Parameters ?? []];
            headerValues = [.. request.HeaderParameters ?? []];
            buttonValue = request.ButtonUrlParameter;
        }

        var components = new JsonArray();

        if (headerValues.Count > 0)
            components.Add(Component("header", headerValues));

        if (bodyValues.Count > 0)
            components.Add(Component("body", bodyValues));

        if (!string.IsNullOrWhiteSpace(buttonValue))
        {
            var button = Component("button", [buttonValue]);
            button["sub_type"] = "url";
            button["index"] = "0";
            components.Add(button);
        }

        var template = new JsonObject
        {
            ["name"] = metaName,
            ["language"] = new JsonObject { ["code"] = metaLanguage }
        };

        if (components.Count > 0)
            template["components"] = components;

        var payload = new JsonObject
        {
            ["messaging_product"] = "whatsapp",
            ["recipient_type"] = "individual",
            ["to"] = to,
            ["type"] = "template",
            ["template"] = template
        };

        var preview = bodyValues.Count > 0
            ? $"{metaName} [{string.Join(" | ", bodyValues)}]"
            : metaName;

        return new BuiltMessage(payload.ToJsonString(), Truncate(preview, 2000), metaName);
    }

    private static JsonObject Component(string type, IReadOnlyList<string> values)
    {
        var parameters = new JsonArray();
        foreach (var value in values)
        {
            parameters.Add(new JsonObject
            {
                ["type"] = "text",
                // Meta refuse les retours à la ligne et les tabulations dans un paramètre de modèle.
                ["text"] = value.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")
            });
        }

        return new JsonObject
        {
            ["type"] = type,
            ["parameters"] = parameters
        };
    }

    private static bool TryTakeNamed(
        List<string> names,
        Dictionary<string, string> data,
        out List<string> values,
        out List<string> missing)
    {
        values = [];
        missing = [];

        foreach (var name in names)
        {
            if (data.TryGetValue(name, out var value) && !string.IsNullOrWhiteSpace(value))
                values.Add(value);
            else
                missing.Add(name);
        }

        return missing.Count == 0;
    }

    private static string MissingVariablesError(string code, List<string> missing) =>
        $"Variables manquantes pour le modèle « {code} » : [{string.Join(", ", missing)}]. " +
        "Renseignez-les dans bodyData.";

    private async Task<WhatsAppTemplate?> ResolveTemplateAsync(
        string code, string language, Guid clientId, CancellationToken ct)
    {
        var candidates = await db.WhatsAppTemplates
            .Where(t => t.TemplateCode == code &&
                        (t.ClientApplicationId == clientId || t.ClientApplicationId == null))
            .ToListAsync(ct);

        if (candidates.Count == 0) return null;

        // La correspondance propre au client prime sur le catalogue partagé, puis la langue demandée
        // avant le repli français.
        return candidates
            .OrderByDescending(t => t.ClientApplicationId == clientId)
            .ThenByDescending(t => string.Equals(t.Language, language, StringComparison.OrdinalIgnoreCase))
            .ThenByDescending(t => t.Language == "fr")
            .FirstOrDefault();
    }

    private async Task<bool> CheckQuotaAsync(ClientApplication client, CancellationToken ct)
    {
        var today = DateTimeOffset.UtcNow.Date;
        var monthStart = new DateTimeOffset(today.Year, today.Month, 1, 0, 0, 0, TimeSpan.Zero);

        var dailyCount = await db.WhatsAppMessages
            .CountAsync(m => m.ClientApplicationId == client.Id && m.QueuedAt >= today, ct);

        if (dailyCount >= client.DailyQuota) return false;

        var monthlyCount = await db.WhatsAppMessages
            .CountAsync(m => m.ClientApplicationId == client.Id && m.QueuedAt >= monthStart, ct);

        return monthlyCount < client.MonthlyQuota;
    }

    private static string NormalizeLanguage(string? language)
    {
        if (string.IsNullOrWhiteSpace(language)) return "fr";
        var trimmed = language.Trim();
        return trimmed.Length <= 16 ? trimmed : "fr";
    }

    private static string Truncate(string value, int max) =>
        value.Length <= max ? value : value[..max];

    private static SendWhatsAppResponse Fail(string error) => new() { Success = false, Error = error };
}
