using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.ViewModels;

public class ClientApplicationViewModel
{
    public Guid? Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string ClientCode { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [Range(1, 1_000_000)]
    public int DailyQuota { get; set; } = 1000;

    [Range(1, 10_000_000)]
    public int MonthlyQuota { get; set; } = 30000;

    [MaxLength(2000)]
    public string? AllowedDomains { get; set; }

    [MaxLength(2000)]
    public string? AllowedIpAddresses { get; set; }
}

public class EmailTemplateViewModel
{
    public Guid? Id { get; set; }

    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string SubjectTemplate { get; set; } = string.Empty;

    [Required]
    public string HtmlBody { get; set; } = string.Empty;

    public string? TextBody { get; set; }

    [MaxLength(10)]
    public string Language { get; set; } = "fr";

    public bool IsActive { get; set; } = true;

    public List<string> Variables { get; set; } = [];
}

public class TemplatePreviewRequest
{
    public string SubjectTemplate { get; set; } = string.Empty;
    public string HtmlBody { get; set; } = string.Empty;
    public string? TextBody { get; set; }
    public Dictionary<string, string> SampleData { get; set; } = new();
}

public class TemplateTestRequest
{
    public Guid? TemplateId { get; set; }
    public string? SubjectTemplate { get; set; }
    public string? HtmlBody { get; set; }
    public string? TextBody { get; set; }

    [Required, EmailAddress]
    public string TestEmail { get; set; } = string.Empty;

    public Dictionary<string, string> SampleData { get; set; } = new();
}

public class SmtpConfigViewModel
{
    public Guid? Id { get; set; }

    [Required, MaxLength(100)]
    public string ProviderName { get; set; } = "Default";

    [Required]
    public string Host { get; set; } = string.Empty;

    [Range(1, 65535)]
    public int Port { get; set; } = 587;

    public string? Username { get; set; }
    public string? Password { get; set; }

    [Required, EmailAddress]
    public string FromEmail { get; set; } = string.Empty;

    public string? FromName { get; set; }
    public bool UseSsl { get; set; } = true;
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CreateTokenViewModel
{
    public Guid ClientApplicationId { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = "Production";

    public DateTimeOffset? ExpiresAt { get; set; }
}

public class TokenCreatedViewModel
{
    public string PlainToken { get; set; } = string.Empty;
    public string TokenPrefix { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
}
