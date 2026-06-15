using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<ClientApplication> ClientApplications => Set<ClientApplication>();
    public DbSet<ApiToken> ApiTokens => Set<ApiToken>();
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();
    public DbSet<EmailTemplateVersion> EmailTemplateVersions => Set<EmailTemplateVersion>();
    public DbSet<EmailMessage> EmailMessages => Set<EmailMessage>();
    public DbSet<EmailAttachment> EmailAttachments => Set<EmailAttachment>();
    public DbSet<EmailSendLog> EmailSendLogs => Set<EmailSendLog>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<SmtpConfiguration> SmtpConfigurations => Set<SmtpConfiguration>();
    public DbSet<ApiCallLog> ApiCallLogs => Set<ApiCallLog>();
    public DbSet<MailCodeSequence> MailCodeSequences => Set<MailCodeSequence>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ClientApplication>(e =>
        {
            e.HasIndex(x => x.ClientCode).IsUnique();
        });

        builder.Entity<ApiToken>(e =>
        {
            e.HasIndex(x => x.TokenHash);
            e.HasOne(x => x.ClientApplication)
                .WithMany(x => x.ApiTokens)
                .HasForeignKey(x => x.ClientApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<EmailTemplate>(e =>
        {
            e.HasIndex(x => x.TemplateCode).IsUnique();
        });

        builder.Entity<EmailTemplateVersion>(e =>
        {
            e.HasOne(x => x.EmailTemplate)
                .WithMany(x => x.Versions)
                .HasForeignKey(x => x.EmailTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.EmailTemplateId, x.Version }).IsUnique();
        });

        builder.Entity<EmailMessage>(e =>
        {
            e.HasIndex(x => x.MailCode).IsUnique();
            e.HasIndex(x => x.Status);
            e.HasIndex(x => x.QueuedAt);
            e.HasOne(x => x.ClientApplication)
                .WithMany(x => x.EmailMessages)
                .HasForeignKey(x => x.ClientApplicationId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EmailAttachment>(e =>
        {
            e.HasOne(x => x.EmailMessage)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.EmailMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<EmailSendLog>(e =>
        {
            e.HasOne(x => x.EmailMessage)
                .WithMany(x => x.SendLogs)
                .HasForeignKey(x => x.EmailMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<AuditLog>(e =>
        {
            e.HasIndex(x => x.CreatedAt);
            e.HasIndex(x => x.Action);
        });

        builder.Entity<ApiCallLog>(e =>
        {
            e.HasIndex(x => x.CreatedAt);
        });

        builder.Entity<MailCodeSequence>(e =>
        {
            e.HasKey(x => x.Year);
        });

        builder.Entity<SmtpConfiguration>(e =>
        {
            e.HasIndex(x => x.IsDefault);
        });
    }
}
