using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

/// <summary>
/// Historique du canal WhatsApp, pendant de <see cref="EmailsController"/>. Nommé
/// WhatsAppMessages pour ne pas entrer en conflit avec le contrôleur d'API du même canal.
/// </summary>
[Authorize]
public class WhatsAppMessagesController(
    ApplicationDbContext db,
    IWhatsAppQueueService queueService,
    IWhatsAppSenderService senderService,
    IWhatsAppSettingsProvider settingsProvider) : Controller
{
    public async Task<IActionResult> Index(string? status, string? search, CancellationToken ct)
    {
        var query = db.WhatsAppMessages
            .Include(m => m.ClientApplication)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<WhatsAppStatus>(status, out var st))
            query = query.Where(m => m.Status == st);

        if (!string.IsNullOrWhiteSpace(search))
        {
            // Un numéro se recherche aussi bien écrit +237… que 237… : on ne garde que les chiffres.
            var digits = new string(search.Where(char.IsDigit).ToArray());
            query = query.Where(m =>
                m.MessageCode.Contains(search) ||
                (digits.Length >= 4 && m.ToPhone.Contains(digits)) ||
                (m.MetaTemplateName != null && m.MetaTemplateName.Contains(search)) ||
                (m.TemplateCode != null && m.TemplateCode.Contains(search)));
        }

        var messages = await query.OrderByDescending(m => m.QueuedAt).Take(200).ToListAsync(ct);

        ViewBag.Status = status;
        ViewBag.Search = search;
        return View(messages);
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken ct)
    {
        var message = await db.WhatsAppMessages
            .Include(m => m.ClientApplication)
            .Include(m => m.SendLogs.OrderByDescending(l => l.CreatedAt))
            .FirstOrDefaultAsync(m => m.Id == id, ct);

        if (message is null) return NotFound();
        return View(message);
    }

    /// <summary>Messages reçus : ils ouvrent la fenêtre de 24 h où un texte libre est autorisé.</summary>
    public async Task<IActionResult> Inbound(string? search, CancellationToken ct)
    {
        var query = db.WhatsAppInboundMessages.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var digits = new string(search.Where(char.IsDigit).ToArray());
            query = query.Where(m =>
                (digits.Length >= 4 && m.FromPhone.Contains(digits)) ||
                (m.Text != null && m.Text.Contains(search)) ||
                (m.ProfileName != null && m.ProfileName.Contains(search)));
        }

        var messages = await query.OrderByDescending(m => m.ReceivedAt).Take(200).ToListAsync(ct);

        ViewBag.Search = search;
        return View(messages);
    }

    /// <summary>
    /// Envoi de contrôle vers un numéro réel. Réservé aux profils techniques : chaque message
    /// part vraiment et est facturé par Meta.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
    public async Task<IActionResult> Test(CancellationToken ct)
    {
        var model = new WhatsAppTestViewModel();
        await FillContextAsync(model, ct);
        model.ClientApplicationId = model.Clients.FirstOrDefault()?.Id ?? Guid.Empty;
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    [Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
    public async Task<IActionResult> Test(WhatsAppTestViewModel model, CancellationToken ct)
    {
        await FillContextAsync(model, ct);

        if (!ModelState.IsValid)
            return View(model);

        var client = model.Clients.FirstOrDefault(c => c.Id == model.ClientApplicationId);
        if (client is null)
        {
            model.Error = "Choisissez l'application émettrice.";
            return View(model);
        }

        var request = new SendWhatsAppRequest
        {
            ClientCode = client.ClientCode,
            To = model.To,
            Kind = model.Kind,
            MetaTemplateName = model.Kind == "text" ? null : model.MetaTemplateName,
            Language = model.Language,
            Parameters = SplitLines(model.Parameters),
            Text = model.Text,
            Priority = EmailPriority.High
        };

        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

        // Envoi immédiat plutôt que par Hangfire, pour montrer le verdict de l'opérateur sur la page.
        var queued = await queueService.QueueAsync(request, client.Id, ip, ct, dispatchInBackground: false);
        if (!queued.Success || queued.TrackingId is null)
        {
            model.Error = queued.Error ?? "Échec de la mise en file.";
            return View(model);
        }

        await senderService.SendAsync(queued.TrackingId.Value, ct);

        model.Result = await db.WhatsAppMessages
            .Include(m => m.SendLogs.OrderByDescending(l => l.CreatedAt))
            .FirstOrDefaultAsync(m => m.Id == queued.TrackingId.Value, ct);

        if (model.Result?.Status == WhatsAppStatus.Sent)
            TempData["TestResult"] = $"Message WhatsApp {model.Result.MessageCode} accepté par l'opérateur pour +{model.Result.ToPhone}.";

        return View(model);
    }

    private async Task FillContextAsync(WhatsAppTestViewModel model, CancellationToken ct)
    {
        model.Clients = await db.ClientApplications
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .ToListAsync(ct);

        model.Settings = await settingsProvider.GetAsync(ct);
    }

    private static List<string> SplitLines(string? value) =>
        [.. (value ?? string.Empty)
            .Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)];
}
