using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class ApiCallLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? ClientApplicationId { get; set; }
    public ClientApplication? ClientApplication { get; set; }

    [Required, MaxLength(10)]
    public string HttpMethod { get; set; } = "POST";

    [Required, MaxLength(500)]
    public string Path { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    public long DurationMs { get; set; }

    [MaxLength(2000)]
    public string? RequestSummary { get; set; }

    [MaxLength(2000)]
    public string? ResponseSummary { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
