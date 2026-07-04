using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Areas.Identity.Pages.Account;

public class LoginModel(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration,
    ILogger<LoginModel> logger) : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? ReturnUrl { get; set; }

    [TempData]
    public string? ErrorMessage { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "L'e-mail est requis.")]
        [EmailAddress(ErrorMessage = "Adresse e-mail invalide.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = "";

        [Display(Name = "Se souvenir de moi")]
        public bool RememberMe { get; set; }
    }

    public async Task OnGetAsync(string? returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
            ModelState.AddModelError(string.Empty, ErrorMessage);

        returnUrl ??= Url.Content("~/");
        ReturnUrl = returnUrl;
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
        {
            ReturnUrl = returnUrl;
            return Page();
        }

        var result = await signInManager.PasswordSignInAsync(
            Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            logger.LogInformation("Connexion réussie pour {Email}.", Input.Email);

            var seedEmail = configuration["Seed:AdminEmail"];
            var seedPassword = configuration["Seed:AdminPassword"];
            if (!string.IsNullOrWhiteSpace(seedEmail) &&
                !string.IsNullOrWhiteSpace(seedPassword) &&
                string.Equals(Input.Email, seedEmail, StringComparison.OrdinalIgnoreCase))
            {
                var user = await userManager.FindByEmailAsync(Input.Email);
                if (user is not null)
                {
                    var stillUsingSeedPassword = await userManager.CheckPasswordAsync(user, seedPassword);
                    if (stillUsingSeedPassword)
                        return Redirect("/Identity/Account/Manage/ChangePassword");
                }
            }

            return LocalRedirect(returnUrl);
        }

        if (result.IsLockedOut)
        {
            logger.LogWarning("Compte verrouillé : {Email}.", Input.Email);
            return RedirectToPage("./Lockout");
        }

        ModelState.AddModelError(string.Empty, "Identifiants incorrects.");
        ReturnUrl = returnUrl;
        return Page();
    }
}
