using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Viewer}")]
public class AuditController(ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index(string? action, CancellationToken ct)
    {
        var query = db.AuditLogs
            .Include(a => a.ClientApplication)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(action) && Enum.TryParse<Models.Enums.AuditAction>(action, out var act))
            query = query.Where(a => a.Action == act);

        var logs = await query.OrderByDescending(a => a.CreatedAt).Take(500).ToListAsync(ct);
        ViewBag.Action = action;
        return View(logs);
    }
}
