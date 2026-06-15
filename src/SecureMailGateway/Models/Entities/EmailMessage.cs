using SecureMailGateway.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SecureMailGateway.Models.Entities;

public class EmailMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(20)]
    public string MailCode { get; set; } = string.Empty;

    public Guid ClientApplicationId { get; set; }
    public ClientApplication ClientApplication { get; set; } = null!;

    public Guid? EmailTemplateId { get; set; }
    public EmailTemplate? EmailTemplate { get; set; }

    [MaxLength(50)]
    public string? TemplateCode { get; set; }

    [Required]
    public string ToAddresses { get; set; } = "[]";

    public string? CcAddresses { get; set; }
    public string? BccAddresses { get; set; }

    [Required, MaxLength(500)]
    public string Subject { get; set; } = string.Empty;

    public string HtmlBody { get; set; } = string.Empty;
    public string? TextBody { get; set; }

    public EmailStatus Status { get; set; } = EmailStatus.Queued;
    public EmailPriority Priority { get; set; } = EmailPriority.Normal;

    [MaxLength(500)]
    public string? CallbackUrl { get; set; }

    [MaxLength(2000)]
    public string? ErrorMessage { get; set; }

    [MaxLength(2000)]
    public string? SmtpResponse { get; set; }

    public DateTimeOffset QueuedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? SendingAt { get; set; }
    public DateTimeOffset? SentAt { get; set; }
    public DateTimeOffset? FailedAt { get; set; }

    public ICollection<EmailAttachment> Attachments { get; set; } = [];
    public ICollection<EmailSendLog> SendLogs { get; set; } = [];
}
