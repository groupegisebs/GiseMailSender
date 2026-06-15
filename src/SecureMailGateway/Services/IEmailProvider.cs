namespace SecureMailGateway.Services;

/// <summary>
/// Abstraction pour ajouter SendGrid, Amazon SES, Mailgun, Microsoft Graph, etc.
/// </summary>
public interface IEmailProvider
{
    string ProviderName { get; }
    Task<EmailProviderResult> SendAsync(EmailProviderMessage message, CancellationToken ct = default);
}

public record EmailProviderMessage(
    string FromEmail,
    string? FromName,
    List<string> To,
    List<string>? Cc,
    List<string>? Bcc,
    string Subject,
    string HtmlBody,
    string? TextBody,
    List<EmailProviderAttachment>? Attachments);

public record EmailProviderAttachment(string FileName, string ContentType, byte[] Content);

public record EmailProviderResult(bool Success, string? Response, string? Error);

public class SmtpEmailProvider : IEmailProvider
{
    public string ProviderName => "SMTP";
    public Task<EmailProviderResult> SendAsync(EmailProviderMessage message, CancellationToken ct = default)
        => Task.FromResult(new EmailProviderResult(false, null, "Use EmailSenderService for SMTP delivery."));
}
