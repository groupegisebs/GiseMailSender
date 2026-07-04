using System.ComponentModel.DataAnnotations;
using SecureMailGateway.Configuration;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;

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
    [Display(Name = "Domaines autorisés")]
    public string? AllowedDomains { get; set; }

    [Display(Name = "Autoriser tous les domaines destinataires")]
    public bool AllowAllDomains { get; set; } = true;

    [MaxLength(2000)]
    [Display(Name = "IPs autorisées")]
    public string? AllowedIpAddresses { get; set; }

    public void ApplyDomainRestrictions() =>
        AllowedDomains = AllowAllDomains ? null : AllowedDomains?.Trim();

    public static ClientApplicationViewModel FromEntity(ClientApplication entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        ClientCode = entity.ClientCode,
        IsActive = entity.IsActive,
        DailyQuota = entity.DailyQuota,
        MonthlyQuota = entity.MonthlyQuota,
        AllowAllDomains = ClientApplicationDomainRules.AllowsAllDomains(entity.AllowedDomains),
        AllowedDomains = entity.AllowedDomains,
        AllowedIpAddresses = entity.AllowedIpAddresses
    };
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

public class TemplateApplicationFilterOption
{
    public string ClientCode { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public class TemplatesIndexViewModel
{
    public IReadOnlyList<EmailTemplate> Templates { get; set; } = [];
    public IReadOnlyList<TemplateApplicationFilterOption> ApplicationFilters { get; set; } = [];
    public string? SelectedClientCode { get; set; }
    public string? SearchTerm { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public int TotalItems { get; set; }
    public int TotalPages => Math.Max(1, (int)Math.Ceiling(TotalItems / (double)PageSize));
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

    /// <summary>Clé du fournisseur prédéfini (<see cref="SmtpProviderPresets"/>) ou <c>custom</c>.</summary>
    [Display(Name = "Fournisseur")]
    public string SelectedProviderKey { get; set; } = SmtpProviderPresets.All[0].Key;

    [Required, MaxLength(100)]
    [Display(Name = "Nom du profil")]
    public string ProviderName { get; set; } = SmtpProviderPresets.All[0].ProviderName;

    [Required]
    [Display(Name = "Serveur (host)")]
    public string Host { get; set; } = SmtpProviderPresets.All[0].Host;

    [Range(1, 65535)]
    [Display(Name = "Port")]
    public int Port { get; set; } = 587;

    [Display(Name = "Identifiant")]
    public string? Username { get; set; }
    public string? Password { get; set; }

    [Required, EmailAddress]
    [Display(Name = "E-mail expéditeur")]
    public string FromEmail { get; set; } = string.Empty;

    [Display(Name = "Nom expéditeur")]
    public string? FromName { get; set; }

    [Display(Name = "SSL/TLS")]
    public bool UseSsl { get; set; } = true;
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; } = true;

    public void ApplySelectedProvider()
    {
        var preset = SmtpProviderPresets.FindByKey(SelectedProviderKey);
        if (preset is null) return;

        ProviderName = preset.ProviderName;
        Host = preset.Host;
        Port = preset.Port;
        UseSsl = preset.UseSsl;
    }

    public void ResolveProviderKeyFromHost()
    {
        SelectedProviderKey = SmtpProviderPresets.FindKeyByHost(Host) ?? SmtpProviderPresets.CustomKey;
    }
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
