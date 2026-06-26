namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail TutorSphere. Insérés au démarrage s'ils n'existent pas (par TemplateCode).
/// Client code : TUTORSPHERE.
/// </summary>
public static class TutorSphereTemplates
{
    private const string PrimaryColor = "#5831E0";

    private const string BrandHeader = """
        <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
        """;

    private const string BrandFooter = """
        <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>
          © 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
        """;

    private static string Wrap(string body, int seedRevision = 1) => $"""
        <div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            {BrandHeader}
            <div style="padding:32px 32px 24px;">
              {body}
              {BrandFooter}
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:{seedRevision} -->
        """;

    private static string PrimaryBtn(string url, string label) =>
        $"""<p style="text-align:center;margin:28px 0;"><a href="{url}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;">{label}</a></p>""";

    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        // ── Existing 4 ──────────────────────────────────────────────────────────

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Bienvenue",
            SubjectTemplate: "Bienvenue {{FirstName}} sur TutorSphere !",
            HtmlBody: Wrap("""
                <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">Bienvenue {{FirstName}} !</h1>
                <p>Votre compte TutorSphere est prêt. Connectez-vous pour accéder à votre espace personnel.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Accéder à mon espace")),
            TextBody: "Bienvenue {{FirstName}} sur TutorSphere."),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — Confirmation e-mail (école)",
            SubjectTemplate: "Confirmez votre adresse e-mail — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Confirmez votre adresse e-mail</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Cliquez sur le bouton ci-dessous pour activer votre compte école.</p>
                """ + PrimaryBtn("{{ConfirmationUrl}}", "Confirmer mon e-mail") + """
                <p style="font-size:13px;color:#888;">Si vous n'avez pas créé de compte, ignorez cet e-mail.</p>
                """),
            TextBody: "Confirmez votre e-mail : {{ConfirmationUrl}}"),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Rapport de cours au parent",
            SubjectTemplate: "Rapport de cours pour {{StudentName}} — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Rapport de cours</h2>
                <p>Bonjour {{ParentFirstName}},</p>
                <p>Voici le rapport de la dernière séance de <strong>{{StudentName}}</strong> avec <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">
                  Connectez-vous à votre espace pour consulter le rapport complet.
                </p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Voir le rapport")),
            TextBody: "Rapport de cours pour {{StudentName}} avec {{TutorName}}."),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — École créée (en attente)",
            SubjectTemplate: "Votre école {{SchoolName}} est en cours de validation — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">École enregistrée</h2>
                <p>Bonjour {{OwnerFirstName}},</p>
                <p>Votre école <strong>{{SchoolName}}</strong> a bien été enregistrée et est en attente de validation par l'équipe TutorSphere.</p>
                <p>Vous serez notifié par e-mail dès qu'une décision sera prise (délai habituel : 1 à 2 jours ouvrables).</p>
                """),
            TextBody: "École {{SchoolName}} enregistrée, en attente de validation."),

        // ── Auth ─────────────────────────────────────────────────────────────────

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — Confirmation e-mail (standard)",
            SubjectTemplate: "Confirmez votre adresse e-mail — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Confirmez votre adresse e-mail</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Merci de confirmer votre adresse e-mail pour finaliser la création de votre compte.</p>
                """ + PrimaryBtn("{{ConfirmationUrl}}", "Confirmer mon e-mail") + """
                <p style="font-size:13px;color:#888;">Si vous n'avez pas créé de compte, ignorez cet e-mail.</p>
                """),
            TextBody: "Confirmez votre e-mail : {{ConfirmationUrl}}"),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Réinitialisation mot de passe",
            SubjectTemplate: "Réinitialisez votre mot de passe — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Réinitialisation du mot de passe</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez demandé à réinitialiser votre mot de passe TutorSphere. Cliquez ci-dessous :</p>
                """ + PrimaryBtn("{{ResetUrl}}", "Réinitialiser mon mot de passe") + """
                <p style="font-size:13px;color:#888;">Ce lien est valide 24 heures. Si vous n'avez pas fait cette demande, ignorez cet e-mail.</p>
                """),
            TextBody: "Réinitialisez votre mot de passe : {{ResetUrl}}"),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Mot de passe modifié",
            SubjectTemplate: "Votre mot de passe a été modifié — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Mot de passe modifié</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre mot de passe TutorSphere a bien été modifié.</p>
                <p>Si vous n'êtes pas à l'origine de cette modification, contactez immédiatement le support.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Se connecter")),
            TextBody: "Bonjour {{FirstName}}, votre mot de passe TutorSphere a été modifié."),

        // ── Tutor billing ─────────────────────────────────────────────────────────

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Essai gratuit tuteur démarré",
            SubjectTemplate: "Votre essai gratuit TutorSphere a commencé !",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Votre essai gratuit a commencé !</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Bienvenue dans TutorSphere ! Votre période d'essai gratuit est maintenant active.</p>
                <p>Profitez de toutes les fonctionnalités pour gérer vos cours, vos élèves et vos paiements.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/dashboard", "Accéder à mon tableau de bord")),
            TextBody: "Bonjour {{FirstName}}, votre essai gratuit TutorSphere a commencé."),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Reçu de paiement tuteur",
            SubjectTemplate: "Reçu de paiement — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Reçu de paiement</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Nous avons bien reçu votre paiement pour votre abonnement TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Montant</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                """ + PrimaryBtn("{{InvoiceUrl}}", "Voir ma facture")),
            TextBody: "Reçu de paiement {{Amount}}. Facture : {{InvoiceUrl}}"),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Rappel de renouvellement tuteur",
            SubjectTemplate: "Votre abonnement TutorSphere se renouvelle bientôt",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Renouvellement à venir</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre abonnement TutorSphere se renouvellera le <strong>{{RenewalDate}}</strong>.</p>
                <p>Assurez-vous que vos informations de paiement sont à jour.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/settings/billing", "Gérer mon abonnement")),
            TextBody: "Votre abonnement TutorSphere se renouvelle le {{RenewalDate}}."),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Échec de paiement tuteur",
            SubjectTemplate: "Problème de paiement — votre abonnement TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 12px;">Problème de paiement</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Nous n'avons pas pu traiter votre paiement pour votre abonnement TutorSphere.</p>
                <p>Veuillez mettre à jour vos informations de paiement pour éviter l'interruption de votre service.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/settings/billing", "Mettre à jour mes informations")),
            TextBody: "Bonjour {{FirstName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour."),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Abonnement tuteur annulé",
            SubjectTemplate: "Votre abonnement TutorSphere a été annulé",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Abonnement annulé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre abonnement TutorSphere a bien été annulé. Vous conservez l'accès jusqu'à la fin de la période en cours.</p>
                <p>Nous espérons vous revoir bientôt !</p>
                """ + PrimaryBtn("https://tutorsphere.gisebs.com", "Revenir sur TutorSphere")),
            TextBody: "Bonjour {{FirstName}}, votre abonnement TutorSphere a été annulé."),

        // ── Account lifecycle ─────────────────────────────────────────────────────

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Compte activé",
            SubjectTemplate: "Votre compte TutorSphere a été activé",
            HtmlBody: Wrap("""
                <h2 style="color:#16a34a;margin:0 0 12px;">Compte activé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre compte TutorSphere a été <strong>activé</strong>. Vous pouvez désormais vous connecter normalement.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Se connecter")),
            TextBody: "Bonjour {{FirstName}}, votre compte TutorSphere a été activé."),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Compte désactivé",
            SubjectTemplate: "Votre compte TutorSphere a été désactivé",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 12px;">Compte désactivé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre compte TutorSphere a été désactivé par l'administration.</p>
                <p><strong>Motif :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">Pour toute question, contactez le support TutorSphere.</p>
                """),
            TextBody: "Bonjour {{FirstName}}, votre compte a été désactivé. Motif : {{Reason}}"),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — École approuvée",
            SubjectTemplate: "Félicitations ! Votre école {{SchoolName}} est approuvée",
            HtmlBody: Wrap("""
                <h2 style="color:#16a34a;margin:0 0 12px;">École approuvée !</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Bonne nouvelle : votre école <strong>{{SchoolName}}</strong> a été <strong>approuvée</strong> par l'équipe TutorSphere.</p>
                <p>Vous pouvez maintenant vous connecter et commencer à gérer vos cours et vos élèves.</p>
                """ + PrimaryBtn("{{LoginUrl}}", "Accéder à mon espace école")),
            TextBody: "Bonjour {{FirstName}}, votre école {{SchoolName}} est approuvée. Connexion : {{LoginUrl}}"),

        // ── Lessons ───────────────────────────────────────────────────────────────

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Cours planifié",
            SubjectTemplate: "Nouveau cours planifié — {{Subject}}",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Cours planifié</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Un nouveau cours a été planifié pour vous.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Voir mon calendrier")),
            TextBody: "Cours planifié — {{Subject}} avec {{TutorName}} le {{LessonDate}}."),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Rappel de cours",
            SubjectTemplate: "Rappel : votre cours de {{Subject}} est demain",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Rappel de cours</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>N'oubliez pas votre cours de demain !</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Voir les détails")),
            TextBody: "Rappel : cours de {{Subject}} avec {{TutorName}} le {{LessonDate}}."),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Cours annulé",
            SubjectTemplate: "Cours annulé — {{Subject}}",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 12px;">Cours annulé</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Nous vous informons que le cours suivant a été <strong>annulé</strong> :</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date prévue</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/login", "Consulter mon calendrier")),
            TextBody: "Cours annulé — {{Subject}} avec {{TutorName}} prévu le {{LessonDate}}."),

        // ── Parent billing ─────────────────────────────────────────────────────────

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Reçu de paiement parent",
            SubjectTemplate: "Reçu de paiement pour {{StudentName}} — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Reçu de paiement</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Nous avons bien reçu votre paiement pour les cours de <strong>{{StudentName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Élève</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Montant</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                """ + PrimaryBtn("{{InvoiceUrl}}", "Voir ma facture")),
            TextBody: "Reçu de paiement pour {{StudentName}} — {{Amount}}. Facture : {{InvoiceUrl}}"),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Échec de paiement parent",
            SubjectTemplate: "Problème de paiement — TutorSphere",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 12px;">Problème de paiement</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Nous n'avons pas pu traiter votre paiement pour les cours de votre enfant.</p>
                <p>Veuillez mettre à jour vos informations de paiement pour maintenir l'accès aux cours.</p>
                """ + PrimaryBtn("https://app.tutorsphere.gisebs.com/settings/billing", "Mettre à jour mes informations")),
            TextBody: "Bonjour {{ParentName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour."),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Facture disponible",
            SubjectTemplate: "Votre facture TutorSphere est disponible",
            HtmlBody: Wrap("""
                <h2 style="color:#5831E0;margin:0 0 12px;">Facture disponible</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Votre nouvelle facture TutorSphere est disponible au téléchargement.</p>
                """ + PrimaryBtn("{{InvoiceUrl}}", "Télécharger ma facture")),
            TextBody: "Bonjour {{ParentName}}, votre facture TutorSphere est disponible : {{InvoiceUrl}}")
    ];
}
