using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SecureMailGateway.Authorization;
using SecureMailGateway.Configuration;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize]
public class EmailsController(
    ApplicationDbContext db,
    IEmailHistoryCleanupService cleanup,
    IOptions<MailHistoryOptions> historyOptions) : Controller
{
    private const int PageSize = 25;

    public async Task<IActionResult> Index(string? status, string? search, int page = 1, CancellationToken ct = default)
    {
        page = Math.Max(1, page);
        var query = db.EmailMessages
            .AsNoTracking()
            .Include(m => m.ClientApplication)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<EmailStatus>(status, out var st))
            query = query.Where(m => m.Status == st);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim();
            var like = $"%{term}%";
            query = query.Where(m =>
                EF.Functions.ILike(m.MailCode, like)
                || EF.Functions.ILike(m.Subject, like)
                || (m.TemplateCode != null && EF.Functions.ILike(m.TemplateCode, like))
                || EF.Functions.ILike(m.ClientApplication.Name, like));
        }

        var totalItems = await query.CountAsync(ct);
        var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)PageSize));
        if (page > totalPages)
            page = totalPages;

        var emails = await query
            .OrderByDescending(m => m.QueuedAt)
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync(ct);

        return View(new EmailsIndexViewModel
        {
            Emails = emails,
            Status = status,
            Search = search,
            CurrentPage = page,
            PageSize = PageSize,
            TotalItems = totalItems,
            RetentionDays = Math.Max(1, historyOptions.Value.RetentionDays),
            CanPurge = User.IsInRole(AppRoles.Admin)
        });
    }

    public async Task<IActionResult> Details(Guid id, CancellationToken ct)
    {
        var email = await db.EmailMessages
            .Include(m => m.ClientApplication)
            .Include(m => m.EmailTemplate)
            .Include(m => m.Attachments)
            .Include(m => m.SendLogs.OrderByDescending(l => l.CreatedAt))
            .FirstOrDefaultAsync(m => m.Id == id, ct);

        if (email is null) return NotFound();
        return View(email);
    }

    [HttpPost, ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.Admin)]
    public async Task<IActionResult> Purge(int olderThanDays, CancellationToken ct)
    {
        var minDays = Math.Max(1, historyOptions.Value.MinManualPurgeDays);
        if (olderThanDays < minDays)
        {
            TempData["Error"] = $"Conservez au moins {minDays} jours d’historique.";
            return RedirectToAction(nameof(Index));
        }

        var deleted = await cleanup.PurgeOlderThanAsync(olderThanDays, ct);
        TempData["Success"] = deleted == 0
            ? $"Aucun e-mail de plus de {olderThanDays} jours à supprimer."
            : $"{deleted} e-mail(s) de plus de {olderThanDays} jours ont été retirés de l’historique.";
        return RedirectToAction(nameof(Index));
    }
}
