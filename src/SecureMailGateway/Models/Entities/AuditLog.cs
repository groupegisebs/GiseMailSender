using SecureMailGateway.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class AuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(450)]
    public string? UserId { get; set; }

    public Guid? ClientApplicationId { get; set; }
    public ClientApplication? ClientApplication { get; set; }

    public AuditAction Action { get; set; }

    [MaxLength(100)]
    public string? EntityType { get; set; }

    [MaxLength(100)]
    public string? EntityId { get; set; }

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    public string? Details { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
