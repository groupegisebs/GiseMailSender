using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Enums;

namespace SecureMailGateway.Controllers;

[Authorize]
public class EmailsController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index(string? status, string? search, CancellationToken ct)
    {
        var query = db.EmailMessages
            .Include(m => m.ClientApplication)
            .Include(m => m.EmailTemplate)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<EmailStatus>(status, out var st))
            query = query.Where(m => m.Status == st);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(m => m.MailCode.Contains(search) || m.Subject.Contains(search));

        var emails = await query.OrderByDescending(m => m.QueuedAt).Take(200).ToListAsync(ct);
        ViewBag.Status = status;
        ViewBag.Search = search;
        return View(emails);
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
}
