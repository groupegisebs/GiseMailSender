using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = AppRoles.Admin)]
public class SmtpController(
    ApplicationDbContext db,
    IDataProtectionProvider dataProtection,
    IAuditService auditService) : Controller
{
    private readonly IDataProtector _protector = dataProtection.CreateProtector("SmtpPassword");

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var configs = await db.SmtpConfigurations.OrderBy(s => s.ProviderName).ToListAsync(ct);
        return View(configs);
    }

    public IActionResult Create() => View(new SmtpConfigViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SmtpConfigViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(model);

        if (model.IsDefault)
            await ClearDefaultAsync(ct);

        var entity = new SmtpConfiguration
        {
            ProviderName = model.ProviderName,
            Host = model.Host,
            Port = model.Port,
            Username = model.Username,
            PasswordEncrypted = string.IsNullOrEmpty(model.Password) ? null : _protector.Protect(model.Password),
            FromEmail = model.FromEmail,
            FromName = model.FromName,
            UseSsl = model.UseSsl,
            IsDefault = model.IsDefault,
            IsActive = model.IsActive
        };

        db.SmtpConfigurations.Add(entity);
        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.SmtpConfigUpdated, User.Identity?.Name,
            entityType: nameof(SmtpConfiguration), entityId: entity.Id.ToString());

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
    {
        var entity = await db.SmtpConfigurations.FindAsync([id], ct);
        if (entity is null) return NotFound();

        return View(new SmtpConfigViewModel
        {
            Id = entity.Id,
            ProviderName = entity.ProviderName,
            Host = entity.Host,
            Port = entity.Port,
            Username = entity.Username,
            FromEmail = entity.FromEmail,
            FromName = entity.FromName,
            UseSsl = entity.UseSsl,
            IsDefault = entity.IsDefault,
            IsActive = entity.IsActive
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, SmtpConfigViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(model);

        var entity = await db.SmtpConfigurations.FindAsync([id], ct);
        if (entity is null) return NotFound();

        if (model.IsDefault && !entity.IsDefault)
            await ClearDefaultAsync(ct);

        entity.ProviderName = model.ProviderName;
        entity.Host = model.Host;
        entity.Port = model.Port;
        entity.Username = model.Username;
        if (!string.IsNullOrEmpty(model.Password))
            entity.PasswordEncrypted = _protector.Protect(model.Password);
        entity.FromEmail = model.FromEmail;
        entity.FromName = model.FromName;
        entity.UseSsl = model.UseSsl;
        entity.IsDefault = model.IsDefault;
        entity.IsActive = model.IsActive;
        entity.UpdatedAt = DateTimeOffset.UtcNow;

        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.SmtpConfigUpdated, User.Identity?.Name,
            entityType: nameof(SmtpConfiguration), entityId: entity.Id.ToString());

        return RedirectToAction(nameof(Index));
    }

    private async Task ClearDefaultAsync(CancellationToken ct)
    {
        await db.SmtpConfigurations.Where(s => s.IsDefault).ExecuteUpdateAsync(
            s => s.SetProperty(x => x.IsDefault, false), ct);
    }
}
