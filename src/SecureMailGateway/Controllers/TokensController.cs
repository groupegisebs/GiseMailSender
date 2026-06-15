using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
public class TokensController(
    ApplicationDbContext db,
    IApiTokenService tokenService,
    IAuditService auditService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var tokens = await db.ApiTokens
            .Include(t => t.ClientApplication)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(ct);

        ViewBag.Clients = await db.ClientApplications.OrderBy(c => c.Name).ToListAsync(ct);
        return View(tokens);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTokenViewModel model, CancellationToken ct)
    {
        var client = await db.ClientApplications.FindAsync([model.ClientApplicationId], ct);
        if (client is null) return NotFound();

        var (entity, plain) = await tokenService.CreateTokenAsync(model.ClientApplicationId, model.Name, model.ExpiresAt, ct);

        TempData["NewToken"] = plain;
        TempData["TokenPrefix"] = entity.TokenPrefix;
        TempData["ClientName"] = client.Name;

        return RedirectToAction(nameof(TokenCreated));
    }

    public IActionResult TokenCreated()
    {
        if (TempData["NewToken"] is not string token) return RedirectToAction(nameof(Index));

        return View(new TokenCreatedViewModel
        {
            PlainToken = token,
            TokenPrefix = TempData["TokenPrefix"]?.ToString() ?? "",
            ClientName = TempData["ClientName"]?.ToString() ?? ""
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Rotate(Guid id, CancellationToken ct)
    {
        var result = await tokenService.RotateTokenAsync(id, ct);
        if (result is null) return NotFound();

        TempData["NewToken"] = result.Value.PlainToken;
        TempData["TokenPrefix"] = result.Value.Entity.TokenPrefix;
        var client = await db.ClientApplications.FindAsync([result.Value.Entity.ClientApplicationId], ct);
        TempData["ClientName"] = client?.Name ?? "";

        return RedirectToAction(nameof(TokenCreated));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Revoke(Guid id, CancellationToken ct)
    {
        var token = await db.ApiTokens.FindAsync([id], ct);
        if (token is null) return NotFound();

        token.IsActive = false;
        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.TokenRevoked, User.Identity?.Name,
            token.ClientApplicationId, nameof(Models.Entities.ApiToken), token.Id.ToString());

        return RedirectToAction(nameof(Index));
    }
}
