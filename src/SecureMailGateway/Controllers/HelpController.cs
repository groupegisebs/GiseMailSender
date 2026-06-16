using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureMailGateway.Controllers;

[Authorize]
public class HelpController : Controller
{
    public IActionResult Index() => View();
}
