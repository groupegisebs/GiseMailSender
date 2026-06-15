using Microsoft.AspNetCore.Identity;

namespace SecureMailGateway.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string? DisplayName { get; set; }
    public bool MfaEnabled { get; set; }
    public string? MfaSecret { get; set; }
    public int FailedLoginAttempts { get; set; }
    public DateTimeOffset? LockoutUntil { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
