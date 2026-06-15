using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class ApiToken
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ClientApplicationId { get; set; }
    public ClientApplication ClientApplication { get; set; } = null!;

    [Required, MaxLength(200)]
    public string Name { get; set; } = "Default";

    [Required, MaxLength(128)]
    public string TokenHash { get; set; } = string.Empty;

    /// <summary>First 8 chars of token for identification in UI.</summary>
    [Required, MaxLength(12)]
    public string TokenPrefix { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset? LastUsedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? RotatedAt { get; set; }
}
