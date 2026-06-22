using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
public class ClientsController(
    ApplicationDbContext db,
    IAuditService auditService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var clients = await db.ClientApplications.OrderBy(c => c.Name).ToListAsync(ct);
        return View(clients);
    }

    public IActionResult Create() => View(new ClientApplicationViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClientApplicationViewModel model, CancellationToken ct)
    {
        model.ApplyDomainRestrictions();
        if (!ModelState.IsValid) return View(model);

        if (await db.ClientApplications.AnyAsync(c => c.ClientCode == model.ClientCode, ct))
        {
            ModelState.AddModelError(nameof(model.ClientCode), "Ce code client existe déjà.");
            return View(model);
        }

        var entity = new ClientApplication
        {
            Name = model.Name,
            ClientCode = model.ClientCode.ToUpperInvariant(),
            IsActive = model.IsActive,
            DailyQuota = model.DailyQuota,
            MonthlyQuota = model.MonthlyQuota,
            AllowedDomains = model.AllowedDomains,
            AllowedIpAddresses = model.AllowedIpAddresses
        };

        db.ClientApplications.Add(entity);
        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.ClientCreated, User.Identity?.Name,
            entity.Id, nameof(ClientApplication), entity.Id.ToString());

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
    {
        var entity = await db.ClientApplications.FindAsync([id], ct);
        if (entity is null) return NotFound();

        return View(ClientApplicationViewModel.FromEntity(entity));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ClientApplicationViewModel model, CancellationToken ct)
    {
        model.ApplyDomainRestrictions();
        if (!ModelState.IsValid) return View(model);

        var entity = await db.ClientApplications.FindAsync([id], ct);
        if (entity is null) return NotFound();

        entity.Name = model.Name;
        entity.IsActive = model.IsActive;
        entity.DailyQuota = model.DailyQuota;
        entity.MonthlyQuota = model.MonthlyQuota;
        entity.AllowedDomains = model.AllowedDomains;
        entity.AllowedIpAddresses = model.AllowedIpAddresses;
        entity.UpdatedAt = DateTimeOffset.UtcNow;

        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.ClientUpdated, User.Identity?.Name,
            entity.Id, nameof(ClientApplication), entity.Id.ToString());

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Toggle(Guid id, CancellationToken ct)
    {
        var entity = await db.ClientApplications.FindAsync([id], ct);
        if (entity is null) return NotFound();

        entity.IsActive = !entity.IsActive;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        await db.SaveChangesAsync(ct);
        return RedirectToAction(nameof(Index));
    }
}
