using SecureMailGateway.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Dtos;

public class SendMailRequest
{
    [Required, MaxLength(50)]
    public string ClientCode { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string TemplateCode { get; set; } = string.Empty;

    [Required, MinLength(1)]
    public List<string> To { get; set; } = [];

    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }

    public Dictionary<string, string>? SubjectData { get; set; }
    public Dictionary<string, string>? BodyData { get; set; }

    public List<MailAttachmentDto>? Attachments { get; set; }

    public EmailPriority Priority { get; set; } = EmailPriority.Normal;

    [MaxLength(500), Url]
    public string? CallbackUrl { get; set; }
}

public class MailAttachmentDto
{
    [Required, MaxLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string ContentType { get; set; } = "application/octet-stream";

    [Required]
    public string Base64Content { get; set; } = string.Empty;
}

public class SendMailResponse
{
    public bool Success { get; set; }
    public string? MailCode { get; set; }
    public Guid? TrackingId { get; set; }
    public string? Status { get; set; }
    public string? Error { get; set; }
}
