using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = AppRoles.Admin)]
public class UsersController(UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await userManager.Users.OrderBy(u => u.Email).ToListAsync();
        var model = new List<UserRoleViewModel>();

        foreach (var user in users)
        {
            var roles = await userManager.GetRolesAsync(user);
            model.Add(new UserRoleViewModel
            {
                Id = user.Id,
                Email = user.Email ?? "",
                DisplayName = user.DisplayName,
                Roles = roles.ToList(),
                MfaEnabled = user.MfaEnabled,
                IsLocked = user.LockoutUntil.HasValue && user.LockoutUntil > DateTimeOffset.UtcNow
            });
        }

        ViewBag.AllRoles = AppRoles.All;
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SetRole(string userId, string role)
    {
        if (!AppRoles.All.Contains(role)) return BadRequest();

        var user = await userManager.FindByIdAsync(userId);
        if (user is null) return NotFound();

        var currentRoles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, currentRoles);
        await userManager.AddToRoleAsync(user, role);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Unlock(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null) return NotFound();

        user.FailedLoginAttempts = 0;
        user.LockoutUntil = null;
        await userManager.SetLockoutEndDateAsync(user, null);
        await userManager.UpdateAsync(user);

        return RedirectToAction(nameof(Index));
    }
}

public class UserRoleViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public List<string> Roles { get; set; } = [];
    public bool MfaEnabled { get; set; }
    public bool IsLocked { get; set; }
}
