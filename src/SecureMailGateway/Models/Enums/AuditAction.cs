namespace SecureMailGateway.Models.Enums;

public enum AuditAction
{
    TokenCreated,
    TokenRotated,
    TokenRevoked,
    ApiCall,
    TemplateCreated,
    TemplateUpdated,
    TemplateDeleted,
    EmailQueued,
    EmailSent,
    EmailFailed,
    SmtpError,
    UnauthorizedAttempt,
    ClientCreated,
    ClientUpdated,
    SmtpConfigUpdated,
    UserLogin,
    UserLoginFailed,
    UserLocked
}
