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

    // Canal WhatsApp : tables distinctes du courriel, qui continue de fonctionner à l'identique.
    public DbSet<WhatsAppConfiguration> WhatsAppConfigurations => Set<WhatsAppConfiguration>();
    public DbSet<WhatsAppTemplate> WhatsAppTemplates => Set<WhatsAppTemplate>();
    public DbSet<WhatsAppMessage> WhatsAppMessages => Set<WhatsAppMessage>();
    public DbSet<WhatsAppSendLog> WhatsAppSendLogs => Set<WhatsAppSendLog>();
    public DbSet<WhatsAppInboundMessage> WhatsAppInboundMessages => Set<WhatsAppInboundMessage>();
    public DbSet<WhatsAppCodeSequence> WhatsAppCodeSequences => Set<WhatsAppCodeSequence>();

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
            // Une variante par langue (fr, en, …) pour le même TemplateCode.
            e.HasIndex(x => new { x.TemplateCode, x.Language }).IsUnique();
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

        builder.Entity<WhatsAppConfiguration>(e =>
        {
            e.HasIndex(x => x.IsDefault);
        });

        builder.Entity<WhatsAppTemplate>(e =>
        {
            // Une correspondance par code, langue et application (null = catalogue partagé).
            e.HasIndex(x => new { x.TemplateCode, x.Language, x.ClientApplicationId }).IsUnique();
            e.HasOne(x => x.ClientApplication)
                .WithMany()
                .HasForeignKey(x => x.ClientApplicationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<WhatsAppMessage>(e =>
        {
            e.HasIndex(x => x.MessageCode).IsUnique();
            e.HasIndex(x => x.Status);
            e.HasIndex(x => x.QueuedAt);
            // Les webhooks de statut ne portent que l'identifiant opérateur : il doit être indexé.
            e.HasIndex(x => x.ProviderMessageId);
            e.HasOne(x => x.ClientApplication)
                .WithMany()
                .HasForeignKey(x => x.ClientApplicationId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<WhatsAppSendLog>(e =>
        {
            e.HasOne(x => x.WhatsAppMessage)
                .WithMany(x => x.SendLogs)
                .HasForeignKey(x => x.WhatsAppMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<WhatsAppInboundMessage>(e =>
        {
            // La fenêtre de 24 h se calcule sur ce couple.
            e.HasIndex(x => new { x.FromPhone, x.ReceivedAt });
            e.HasIndex(x => x.ProviderMessageId);
        });

        builder.Entity<WhatsAppCodeSequence>(e =>
        {
            e.HasKey(x => x.Year);
        });
    }
}
