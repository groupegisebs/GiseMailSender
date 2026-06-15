using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class SmtpConfiguration
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    public string ProviderName { get; set; } = "Default";

    [Required, MaxLength(255)]
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; } = 587;

    [MaxLength(255)]
    public string? Username { get; set; }

    /// <summary>Encrypted via Data Protection API.</summary>
    public string? PasswordEncrypted { get; set; }

    [Required, MaxLength(255)]
    public string FromEmail { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? FromName { get; set; }

    public bool UseSsl { get; set; } = true;
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
