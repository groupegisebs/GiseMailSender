using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail ComptaDoc PME (fr + en). Codes EN = suffixe _EN.
/// </summary>
public static class ComptaDocTemplates
{
    private const string BrandHeaderFr = """
        <p style="margin:0 0 24px;font-size:18px;font-weight:bold;color:#0f766e;">ComptaDoc PME</p>
        """;

    private const string BrandHeaderEn = """
        <p style="margin:0 0 24px;font-size:18px;font-weight:bold;color:#0f766e;">ComptaDoc SME</p>
        """;

    private const string BrandFooterFr = """
        <hr style="border:none;border-top:1px solid #eee;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#666;margin:0;">
          Cet e-mail a été envoyé par ComptaDoc PME. Ne répondez pas directement à ce message.
        </p>
        """;

    private const string BrandFooterEn = """
        <hr style="border:none;border-top:1px solid #eee;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#666;margin:0;">
          This email was sent by ComptaDoc SME. Please do not reply directly to this message.
        </p>
        """;

    private static string WrapFr(string body, int seedRevision = 1) => $"""
        <div style="font-family:Arial,sans-serif;line-height:1.5;color:#222;max-width:600px;margin:0 auto;padding:24px;">
          {BrandHeaderFr}
          {body}
          {BrandFooterFr}
        </div>
        <!-- comptadoc-seed:{seedRevision} -->
        """;

    private static string WrapEn(string body, int seedRevision = 1) => $"""
        <div style="font-family:Arial,sans-serif;line-height:1.5;color:#222;max-width:600px;margin:0 auto;padding:24px;">
          {BrandHeaderEn}
          {body}
          {BrandFooterEn}
        </div>
        <!-- comptadoc-seed:{seedRevision} -->
        """;

    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        new("CD_TRANSACTIONAL", "ComptaDoc — Transactionnel générique",
            "{{Subject}}", WrapFr("{{HtmlBody}}"), "{{Subject}}", "fr", true, 1),

        new("CD_WELCOME", "ComptaDoc — Bienvenue",
            "Bienvenue sur ComptaDoc PME, {{FirstName}}",
            WrapFr("""
                <h1 style="color:#0f766e;margin:0 0 16px;">Bienvenue {{FirstName}} !</h1>
                <p>Votre compte <strong>{{CompanyName}}</strong> est prêt. Profitez de votre essai de {{TrialDays}} jours.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Accéder à ComptaDoc</a>
                </p>
                """),
            "Bienvenue {{FirstName}}. Essai {{TrialDays}} jours. {{LoginLink}}", "fr", true, 1),

        new("CD_WELCOME_EN", "ComptaDoc — Welcome",
            "Welcome to ComptaDoc SME, {{FirstName}}",
            WrapEn("""
                <h1 style="color:#0f766e;margin:0 0 16px;">Welcome {{FirstName}}!</h1>
                <p>Your <strong>{{CompanyName}}</strong> account is ready. Enjoy your {{TrialDays}}-day trial.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Open ComptaDoc</a>
                </p>
                """),
            "Welcome {{FirstName}}. {{TrialDays}}-day trial. {{LoginLink}}", "en", true, 1),

        new("CD_RESET_PASSWORD", "ComptaDoc — Réinitialisation mot de passe",
            "Réinitialisation de votre mot de passe — ComptaDoc",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Réinitialisation du mot de passe</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>Cliquez sur le bouton ci-dessous pour choisir un nouveau mot de passe. Ce lien expire bientôt.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ResetLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Réinitialiser</a>
                </p>
                <p style="font-size:12px;color:#666;">Si vous n'avez pas demandé cette réinitialisation, ignorez cet e-mail.</p>
                """),
            "Réinitialisez votre mot de passe : {{ResetLink}}", "fr", true, 1),

        new("CD_RESET_PASSWORD_EN", "ComptaDoc — Password reset",
            "Reset your password — ComptaDoc",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Password reset</h1>
                <p>Hello {{FirstName}},</p>
                <p>Click the button below to choose a new password. This link will expire soon.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ResetLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Reset password</a>
                </p>
                <p style="font-size:12px;color:#666;">If you did not request this, you can ignore this email.</p>
                """),
            "Reset your password: {{ResetLink}}", "en", true, 1),

        new("CD_USER_INVITE", "ComptaDoc — Invitation utilisateur",
            "Invitation ComptaDoc PME — {{CompanyName}}",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Vous êtes invité(e)</h1>
                <p>Bonjour,</p>
                <p>Un compte a été créé pour vous sur <strong>{{CompanyName}}</strong>.</p>
                <p>Courriel : <strong>{{Email}}</strong><br/>Mot de passe temporaire : <strong>{{TemporaryPassword}}</strong></p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Se connecter</a>
                </p>
                <p>Changez votre mot de passe après la première connexion.</p>
                """),
            "Invitation {{CompanyName}}. Mot de passe temporaire : {{TemporaryPassword}}. {{LoginLink}}", "fr", true, 1),

        new("CD_USER_INVITE_EN", "ComptaDoc — User invite",
            "ComptaDoc SME invitation — {{CompanyName}}",
            WrapEn("""
                <h1 style="margin:0 0 16px;">You're invited</h1>
                <p>Hello,</p>
                <p>An account was created for you on <strong>{{CompanyName}}</strong>.</p>
                <p>Email: <strong>{{Email}}</strong><br/>Temporary password: <strong>{{TemporaryPassword}}</strong></p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Sign in</a>
                </p>
                <p>Please change your password after your first sign-in.</p>
                """),
            "Invite {{CompanyName}}. Temp password: {{TemporaryPassword}}. {{LoginLink}}", "en", true, 1),

        new("CD_SUBSCRIPTION_ACTIVATED", "ComptaDoc — Abonnement activé",
            "Abonnement activé — ComptaDoc PME",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Abonnement activé</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre abonnement <strong>{{Plan}}</strong> est actif jusqu'au <strong>{{EndsAt}}</strong>.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Ouvrir ComptaDoc</a>
                </p>
                """),
            "Abonnement {{Plan}} actif jusqu'au {{EndsAt}}. {{LoginLink}}", "fr", true, 1),

        new("CD_SUBSCRIPTION_ACTIVATED_EN", "ComptaDoc — Subscription activated",
            "Subscription activated — ComptaDoc SME",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Subscription activated</h1>
                <p>Hello {{FirstName}},</p>
                <p>Your <strong>{{Plan}}</strong> subscription is active until <strong>{{EndsAt}}</strong>.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Open ComptaDoc</a>
                </p>
                """),
            "Subscription {{Plan}} active until {{EndsAt}}. {{LoginLink}}", "en", true, 1),

        new("CD_TRIAL_ENDING", "ComptaDoc — Fin d'essai",
            "Votre essai ComptaDoc se termine dans {{DaysRemaining}} jour(s)",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Fin d'essai approche</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>L'essai de <strong>{{CompanyName}}</strong> se termine dans <strong>{{DaysRemaining}} jour(s)</strong> ({{EndsAt}}).</p>
                <p>Renouvelez sur Agentia Market pour continuer sans interruption.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">S'abonner</a>
                </p>
                """),
            "Essai {{CompanyName}} : {{DaysRemaining}} j restants. {{BoutiqueLink}}", "fr", true, 1),

        new("CD_TRIAL_ENDING_EN", "ComptaDoc — Trial ending",
            "Your ComptaDoc trial ends in {{DaysRemaining}} day(s)",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Trial ending soon</h1>
                <p>Hello {{FirstName}},</p>
                <p>The trial for <strong>{{CompanyName}}</strong> ends in <strong>{{DaysRemaining}} day(s)</strong> ({{EndsAt}}).</p>
                <p>Renew on Agentia Market to keep uninterrupted access.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Subscribe</a>
                </p>
                """),
            "Trial {{CompanyName}}: {{DaysRemaining}} days left. {{BoutiqueLink}}", "en", true, 1),

        new("CD_SUBSCRIPTION_EXPIRED", "ComptaDoc — Abonnement expiré",
            "Abonnement ComptaDoc expiré — {{CompanyName}}",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Abonnement expiré</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>L'accès comptable de <strong>{{CompanyName}}</strong> est suspendu. Renouvelez pour réactiver votre compte.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Renouveler</a>
                </p>
                """),
            "Abonnement {{CompanyName}} expiré. {{BoutiqueLink}}", "fr", true, 1),

        new("CD_SUBSCRIPTION_EXPIRED_EN", "ComptaDoc — Subscription expired",
            "ComptaDoc subscription expired — {{CompanyName}}",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Subscription expired</h1>
                <p>Hello {{FirstName}},</p>
                <p>Accounting access for <strong>{{CompanyName}}</strong> is suspended. Renew to reactivate your account.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Renew</a>
                </p>
                """),
            "Subscription {{CompanyName}} expired. {{BoutiqueLink}}", "en", true, 1),

        new("CD_RENEWAL_REMINDER", "ComptaDoc — Rappel renouvellement",
            "Renouvellement ComptaDoc dans {{DaysRemaining}} jour(s)",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Rappel de renouvellement</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>L'abonnement de <strong>{{CompanyName}}</strong> ({{Plan}}) se termine le <strong>{{EndsAt}}</strong> — dans {{DaysRemaining}} jour(s).</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Renouveler maintenant</a>
                </p>
                """),
            "Renouvellement {{CompanyName}} dans {{DaysRemaining}} j. {{BoutiqueLink}}", "fr", true, 1),

        new("CD_RENEWAL_REMINDER_EN", "ComptaDoc — Renewal reminder",
            "ComptaDoc renewal in {{DaysRemaining}} day(s)",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Renewal reminder</h1>
                <p>Hello {{FirstName}},</p>
                <p>The subscription for <strong>{{CompanyName}}</strong> ({{Plan}}) ends on <strong>{{EndsAt}}</strong> — in {{DaysRemaining}} day(s).</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{BoutiqueLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Renew now</a>
                </p>
                """),
            "Renewal {{CompanyName}} in {{DaysRemaining}} days. {{BoutiqueLink}}", "en", true, 1),

        new("CD_INVOICE", "ComptaDoc — Facture client",
            "Facture {{InvoiceNumber}} — {{CompanyName}}",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Facture {{InvoiceNumber}}</h1>
                <p>Bonjour,</p>
                <p>Veuillez trouver ci-joint la facture <strong>{{InvoiceNumber}}</strong> de <strong>{{CompanyName}}</strong>.</p>
                <p>Montant : <strong>{{Amount}}</strong><br/>Échéance : {{DueDate}}</p>
                """),
            "Facture {{InvoiceNumber}} — {{Amount}}. Échéance {{DueDate}}.", "fr", true, 1),

        new("CD_INVOICE_EN", "ComptaDoc — Customer invoice",
            "Invoice {{InvoiceNumber}} — {{CompanyName}}",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Invoice {{InvoiceNumber}}</h1>
                <p>Hello,</p>
                <p>Please find attached invoice <strong>{{InvoiceNumber}}</strong> from <strong>{{CompanyName}}</strong>.</p>
                <p>Amount: <strong>{{Amount}}</strong><br/>Due date: {{DueDate}}</p>
                """),
            "Invoice {{InvoiceNumber}} — {{Amount}}. Due {{DueDate}}.", "en", true, 1),

        new("CD_INVOICE_REMINDER", "ComptaDoc — Rappel facture",
            "Rappel : facture {{InvoiceNumber}} en retard ({{DaysOverdue}} j)",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Rappel de paiement</h1>
                <p>Bonjour,</p>
                <p>La facture <strong>{{InvoiceNumber}}</strong> de <strong>{{CompanyName}}</strong> est en retard de <strong>{{DaysOverdue}} jour(s)</strong>.</p>
                <p>Montant dû : <strong>{{Amount}}</strong><br/>Échéance initiale : {{DueDate}}</p>
                <p>Merci de procéder au règlement dès que possible. La facture est jointe en PDF.</p>
                """),
            "Rappel facture {{InvoiceNumber}} — {{DaysOverdue}} j de retard. {{Amount}}.", "fr", true, 1),

        new("CD_INVOICE_REMINDER_EN", "ComptaDoc — Invoice reminder",
            "Reminder: invoice {{InvoiceNumber}} overdue ({{DaysOverdue}} d)",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Payment reminder</h1>
                <p>Hello,</p>
                <p>Invoice <strong>{{InvoiceNumber}}</strong> from <strong>{{CompanyName}}</strong> is <strong>{{DaysOverdue}} day(s)</strong> overdue.</p>
                <p>Amount due: <strong>{{Amount}}</strong><br/>Original due date: {{DueDate}}</p>
                <p>Please settle this invoice as soon as possible. The PDF is attached.</p>
                """),
            "Invoice reminder {{InvoiceNumber}} — {{DaysOverdue}} days overdue. {{Amount}}.", "en", true, 1),

        new("CD_PASSWORD_CHANGED", "ComptaDoc — Mot de passe modifié",
            "Votre mot de passe ComptaDoc a été modifié",
            WrapFr("""
                <h1 style="margin:0 0 16px;">Mot de passe modifié</h1>
                <p>Bonjour {{FirstName}},</p>
                <p>Le mot de passe de votre compte ComptaDoc a été modifié. Si ce n'était pas vous, réinitialisez-le immédiatement.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Se connecter</a>
                </p>
                """),
            "Mot de passe ComptaDoc modifié. {{LoginLink}}", "fr", true, 1),

        new("CD_PASSWORD_CHANGED_EN", "ComptaDoc — Password changed",
            "Your ComptaDoc password was changed",
            WrapEn("""
                <h1 style="margin:0 0 16px;">Password changed</h1>
                <p>Hello {{FirstName}},</p>
                <p>The password for your ComptaDoc account was changed. If this wasn't you, reset it immediately.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{LoginLink}}" style="background:#0d9488;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Sign in</a>
                </p>
                """),
            "ComptaDoc password changed. {{LoginLink}}", "en", true, 1)
    ];
}
