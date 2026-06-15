using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureMailGateway.Authorization;
using SecureMailGateway.Services;

namespace SecureMailGateway.Controllers;

[Authorize]
public class DashboardController(IDashboardService dashboardService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        ViewBag.Stats = await dashboardService.GetStatsAsync(ct);
        return View();
    }
}
