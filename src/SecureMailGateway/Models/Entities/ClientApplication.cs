using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class ClientApplication
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string ClientCode { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public int DailyQuota { get; set; } = 1000;
    public int MonthlyQuota { get; set; } = 30000;

    /// <summary>Comma-separated allowed sender/recipient domains.</summary>
    [MaxLength(2000)]
    public string? AllowedDomains { get; set; }

    /// <summary>Comma-separated allowed IP addresses (optional).</summary>
    [MaxLength(2000)]
    public string? AllowedIpAddresses { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<ApiToken> ApiTokens { get; set; } = [];
    public ICollection<EmailMessage> EmailMessages { get; set; } = [];
}
