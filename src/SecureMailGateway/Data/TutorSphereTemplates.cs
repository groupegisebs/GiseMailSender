namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail TutorSphere (fr, en, es, de, pt, zh-Hans, ar).
/// Généré par tools/generate-tutorsphere-templates.mjs — ne pas éditer à la main.
/// Client code : TUTORSPHERE.
/// </summary>
public static class TutorSphereTemplates
{
    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Bienvenue",
            SubjectTemplate: "Bienvenue {{FirstName}} sur TutorSphere !",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">Bienvenue {{FirstName}} !</h1>
                <p>Votre compte TutorSphere est prêt. Connectez-vous pour accéder à votre espace personnel.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accéder à mon espace</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bienvenue {{FirstName}} sur TutorSphere.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — Validation espace parent",
            SubjectTemplate: "Validez votre espace parent — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Activez votre espace parent</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Bienvenue sur TutorSphere. Pour accéder à <strong>l'espace parent</strong> et suivre le parcours scolaire de vos enfants, veuillez d'abord <strong>valider votre adresse e-mail</strong>. Sans cette validation, la connexion reste bloquée.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Valider mon espace parent</a></p>
                <p style="font-size:13px;color:#888;">Si vous n'avez pas créé de compte, ignorez cet e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Validez votre espace parent TutorSphere : {{ConfirmationUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — Confirmation e-mail (école)",
            SubjectTemplate: "Confirmez votre adresse e-mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirmez votre adresse e-mail</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Cliquez sur le bouton ci-dessous pour activer votre compte école.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmer mon e-mail</a></p>
                <p style="font-size:13px;color:#888;">Si vous n'avez pas créé de compte, ignorez cet e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirmez votre e-mail : {{ConfirmationUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Rapport de cours au parent",
            SubjectTemplate: "Rapport de cours pour {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Rapport de cours</h2>
                <p>Bonjour {{ParentFirstName}},</p>
                <p>Voici le rapport de la dernière séance de <strong>{{StudentName}}</strong> avec <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Connectez-vous à votre espace pour consulter le rapport complet.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir le rapport</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Rapport de cours pour {{StudentName}} avec {{TutorName}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — École créée (en attente)",
            SubjectTemplate: "Votre école {{SchoolName}} est en cours de validation — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">École enregistrée</h2>
                <p>Bonjour {{OwnerFirstName}},</p>
                <p>Votre école <strong>{{SchoolName}}</strong> a bien été enregistrée et est en attente de validation par l'équipe TutorSphere.</p>
                <p>Vous serez notifié par e-mail dès qu'une décision sera prise (délai habituel : 1 à 2 jours ouvrables).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "École {{SchoolName}} enregistrée, en attente de validation.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — Confirmation e-mail (standard)",
            SubjectTemplate: "Confirmez votre adresse e-mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirmez votre adresse e-mail</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Merci de confirmer votre adresse e-mail pour finaliser la création de votre compte.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmer mon e-mail</a></p>
                <p style="font-size:13px;color:#888;">Si vous n'avez pas créé de compte, ignorez cet e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirmez votre e-mail : {{ConfirmationUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Réinitialisation mot de passe",
            SubjectTemplate: "Réinitialisez votre mot de passe — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Réinitialisation du mot de passe</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez demandé à réinitialiser votre mot de passe TutorSphere. Cliquez ci-dessous :</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Réinitialiser mon mot de passe</a></p>
                <p style="font-size:13px;color:#888;">Ce lien est valide 24 heures. Si vous n'avez pas fait cette demande, ignorez cet e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Réinitialisez votre mot de passe : {{ResetUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Mot de passe modifié",
            SubjectTemplate: "Votre mot de passe a été modifié — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Mot de passe modifié</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre mot de passe TutorSphere a bien été modifié.</p>
                <p>Si vous n'êtes pas à l'origine de cette modification, contactez immédiatement le support.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Se connecter</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre mot de passe TutorSphere a été modifié.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Essai gratuit tuteur démarré",
            SubjectTemplate: "Votre essai gratuit TutorSphere a commencé !",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Votre essai gratuit a commencé !</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Bienvenue dans TutorSphere ! Votre période d'essai gratuit est maintenant active.</p>
                <p>Profitez de toutes les fonctionnalités pour gérer vos cours, vos élèves et vos paiements.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accéder à mon tableau de bord</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre essai gratuit TutorSphere a commencé.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Reçu de paiement tuteur",
            SubjectTemplate: "Reçu de paiement — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Reçu de paiement</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Nous avons bien reçu votre paiement pour votre abonnement TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Montant</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir ma facture</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reçu de paiement {{Amount}}. Facture : {{InvoiceUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Rappel de renouvellement tuteur",
            SubjectTemplate: "Votre abonnement TutorSphere se renouvelle bientôt",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Renouvellement à venir</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre abonnement TutorSphere se renouvellera le <strong>{{RenewalDate}}</strong>.</p>
                <p>Assurez-vous que vos informations de paiement sont à jour.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gérer mon abonnement</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Votre abonnement TutorSphere se renouvelle le {{RenewalDate}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Échec de paiement tuteur",
            SubjectTemplate: "Problème de paiement — votre abonnement TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problème de paiement</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Nous n'avons pas pu traiter votre paiement pour votre abonnement TutorSphere.</p>
                <p>Veuillez mettre à jour vos informations de paiement pour éviter l'interruption de votre service.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Mettre à jour mes informations</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Abonnement tuteur annulé",
            SubjectTemplate: "Votre abonnement TutorSphere a été annulé",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Abonnement annulé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre abonnement TutorSphere a bien été annulé. Vous conservez l'accès jusqu'à la fin de la période en cours.</p>
                <p>Nous espérons vous revoir bientôt !</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Revenir sur TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre abonnement TutorSphere a été annulé.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Compte activé",
            SubjectTemplate: "Votre compte TutorSphere a été activé",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Compte activé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre compte TutorSphere a été <strong>activé</strong>. Vous pouvez désormais vous connecter normalement.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Se connecter</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre compte TutorSphere a été activé.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Compte désactivé",
            SubjectTemplate: "Votre compte TutorSphere a été désactivé",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Compte désactivé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre compte TutorSphere a été désactivé par l'administration.</p>
                <p><strong>Motif :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">Pour toute question, contactez le support TutorSphere.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre compte a été désactivé. Motif : {{Reason}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — École approuvée",
            SubjectTemplate: "Félicitations ! Votre école {{SchoolName}} est approuvée",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">École approuvée !</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Bonne nouvelle : votre école <strong>{{SchoolName}}</strong> a été <strong>approuvée</strong> par l'équipe TutorSphere.</p>
                <p>Vous pouvez maintenant vous connecter et commencer à gérer vos cours et vos élèves.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accéder à mon espace école</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre école {{SchoolName}} est approuvée. Connexion : {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Cours planifié",
            SubjectTemplate: "Nouveau cours planifié — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Cours planifié</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Un nouveau cours a été planifié pour vous.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir mon calendrier</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Cours planifié — {{Subject}} avec {{TutorName}} le {{LessonDate}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Rappel de cours",
            SubjectTemplate: "Rappel : votre cours de {{Subject}} est demain",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Rappel de cours</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>N'oubliez pas votre cours de demain !</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir les détails</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Rappel : cours de {{Subject}} avec {{TutorName}} le {{LessonDate}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Cours annulé",
            SubjectTemplate: "Cours annulé — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Cours annulé</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Nous vous informons que le cours suivant a été <strong>annulé</strong> :</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Matière</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tuteur</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date prévue</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Consulter mon calendrier</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Cours annulé — {{Subject}} avec {{TutorName}} prévu le {{LessonDate}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — Suppléant proposé",
            SubjectTemplate: "Votre accord est demandé : suppléant pour {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Un suppléant est proposé</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p><strong>{{OriginalTeacherName}}</strong> ne pourra pas assurer la séance ci-dessous. <strong>{{SubstituteTeacherName}}</strong>, enseignant du même groupe, peut la prendre en charge : <strong>votre accord est nécessaire</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Séance</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date prévue</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Élève</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Enseignant initial</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suppléant</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>Sans réponse de votre part avant l'heure prévue, la séance reste au nom de l'enseignant initial et pourra être reportée.</p>
                <p><strong>Motif de l'absence :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accepter ou refuser</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} est indisponible pour {{LessonTitle}} le {{LessonDate}}. Suppléant proposé : {{SubstituteTeacherName}}. Votre accord : {{ActionUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — Proposition de suppléance",
            SubjectTemplate: "Suppléance proposée : {{LessonCount}} séance(s) de {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Vous êtes proposé comme suppléant</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Le groupe vous propose d'assurer les séances de <strong>{{OriginalTeacherName}}</strong>, indisponible. Chaque famille doit donner son accord ; les séances acceptées apparaissent ensuite dans votre agenda.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Première séance</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Enseignant remplacé</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Séances concernées</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>Motif de l'absence :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir mon agenda</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Suppléance proposée : {{LessonCount}} séance(s) de {{OriginalTeacherName}}, à partir du {{LessonDate}}. Agenda : {{ActionUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — Remplacement accepté",
            SubjectTemplate: "Remplacement accepté — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Remplacement accepté</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>La famille a <strong>accepté</strong> le remplacement : <strong>{{SubstituteTeacherName}}</strong> assurera la séance à la place de <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Séance</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date prévue</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Enseignant initial</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suppléant</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir mon agenda</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Remplacement accepté : {{SubstituteTeacherName}} assure {{LessonTitle}} le {{LessonDate}} à la place de {{OriginalTeacherName}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — Remplacement refusé",
            SubjectTemplate: "Remplacement refusé — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Remplacement refusé</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>La famille a <strong>refusé</strong> le remplacement : la séance reste au nom de <strong>{{OriginalTeacherName}}</strong>. Si l'absence est confirmée, la séance devra être reportée ou annulée.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Séance</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date prévue</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suppléant proposé</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir mon agenda</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Remplacement refusé : {{LessonTitle}} du {{LessonDate}} reste au nom de {{OriginalTeacherName}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Reçu de paiement parent",
            SubjectTemplate: "Reçu de paiement pour {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Reçu de paiement</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Nous avons bien reçu votre paiement pour les cours de <strong>{{StudentName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Élève</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Montant</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir ma facture</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reçu de paiement pour {{StudentName}} — {{Amount}}. Facture : {{InvoiceUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — Remboursement parent",
            SubjectTemplate: "Remboursement pour {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Paiement remboursé</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Le profil de l'enseignant <strong>{{TutorName}}</strong> a été retiré. Les cours programmés sont annulés. Votre paiement pour <strong>{{StudentName}}</strong> a été <strong>remboursé</strong> — aucune action de votre part n'est requise.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Élève</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Montant remboursé</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ouvrir mon espace</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Remboursement {{Amount}} pour {{StudentName}} (enseignant {{TutorName}}). Les cours programmés sont annulés.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Échec de paiement parent",
            SubjectTemplate: "Problème de paiement — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problème de paiement</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Nous n'avons pas pu traiter votre paiement pour les cours de votre enfant.</p>
                <p>Veuillez mettre à jour vos informations de paiement pour maintenir l'accès aux cours.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Mettre à jour mes informations</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{ParentName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Facture disponible",
            SubjectTemplate: "Votre facture TutorSphere est disponible",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Facture disponible</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Votre nouvelle facture TutorSphere est disponible au téléchargement.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Télécharger ma facture</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{ParentName}}, votre facture TutorSphere est disponible : {{InvoiceUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — Paiement en retard",
            SubjectTemplate: "Rappel : paiement en attente pour {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Paiement en retard</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>Le paiement pour le cours <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> est toujours en attente.</p>
                <p>Merci de régulariser dès que possible afin d'activer ou de maintenir l'accès aux séances.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Payer maintenant</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Rappel : paiement en retard pour {{StudentName}} — {{CourseTitle}}. Payer : {{PayUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — Demande d'inscription à un cours",
            SubjectTemplate: "Nouvelle demande d'inscription — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Nouvelle demande d'inscription</h2>
                <p>Bonjour {{TutorName}},</p>
                <p><strong>{{StudentName}}</strong> souhaite s'inscrire au cours <strong>{{CourseTitle}}</strong>.</p>
                <p>Connectez-vous pour accepter ou refuser la demande.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gérer les inscriptions</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Demande d'inscription de {{StudentName}} au cours {{CourseTitle}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — Inscription au cours acceptée",
            SubjectTemplate: "Inscription acceptée — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Inscription acceptée</h2>
                <p>Bonjour {{ParentName}},</p>
                <p>L'inscription de <strong>{{StudentName}}</strong> au cours <strong>{{CourseTitle}}</strong> a été acceptée.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Continuer</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Inscription de {{StudentName}} à {{CourseTitle}} acceptée. {{StatusNote}} {{ActionUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — Paiement reçu (cours élève)",
            SubjectTemplate: "Paiement reçu — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Paiement reçu</h2>
                <p>Bonjour {{TutorName}},</p>
                <p>Un paiement a été reçu pour <strong>{{StudentName}}</strong> — cours <strong>{{CourseTitle}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Montant</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voir mon espace</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Paiement reçu : {{Amount}} pour {{StudentName}} — {{CourseTitle}}.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — Enseignant en attente (expert)",
            SubjectTemplate: "Nouvelle demande enseignant à valider — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Demande enseignant à valider</h2>
                <p>Bonjour {{ExpertFirstName}},</p>
                <p>Une école a soumis un compte enseignant en attente de validation.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">École</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Pays</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>Connectez-vous pour examiner le dossier et approuver ou refuser la demande.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Examiner la demande</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{ExpertFirstName}}, demande enseignant à valider — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — Invitation expert",
            SubjectTemplate: "Bienvenue {{FirstName}} — accès expert {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Votre accès à l'espace expert</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez été invité(e) à rejoindre le groupe d'experts <strong>{{GroupName}}</strong> sur TutorSphere. Voici vos identifiants de connexion :</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Groupe d'experts</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">E-mail de connexion</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Mot de passe temporaire</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Page de connexion expert</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Pour votre sécurité, <strong>changez ce mot de passe</strong> dès la première connexion à l'espace expert.</p>
                <p>Étapes : 1) Ouvrez la page de connexion expert ci-dessous 2) Saisissez l'e-mail et le mot de passe temporaire 3) Choisissez un nouveau mot de passe.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Se connecter à l'espace expert</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">Page de connexion expert</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Connectez-vous uniquement sur l’espace expert :<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(équivalent : <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Écosystème GISEBS — nos produits</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Cet e-mail a été envoyé par TutorSphere (GISEBS). Ne répondez pas directement à ce message.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, invitation expert {{GroupName}}. E-mail : {{Email}}. Mot de passe temporaire : {{TemporaryPassword}}. Changez ce mot de passe à la première connexion. Connexion expert : {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS : https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — Ajouté au groupe expert",
            SubjectTemplate: "{{FirstName}}, vous avez été ajouté(e) à {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Ajouté à un groupe d'experts</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez été ajouté(e) au groupe d'experts <strong>{{GroupName}}</strong> sur TutorSphere. Utilisez vos identifiants existants pour vous connecter.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Groupe d'experts</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Compte</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Se connecter à l'espace expert</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, vous avez été ajouté(e) au groupe {{GroupName}} (compte {{Email}}). Connexion : {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — Enseignant approuvé (expert)",
            SubjectTemplate: "Bonne nouvelle : votre profil enseignant est approuvé",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Profil enseignant approuvé</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre demande pour <strong>{{SchoolName}}</strong> a été <strong>approuvée</strong> par le groupe d'experts <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">École / profil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Groupe d'experts</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Commentaire</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Vous pouvez vous connecter à votre espace enseignant pour poursuivre votre activité sur TutorSphere.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accéder à mon espace enseignant</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre profil {{SchoolName}} a été approuvé par {{GroupName}}. Commentaire : {{Notes}}. Connexion : {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — Enseignant refusé (expert)",
            SubjectTemplate: "Décision sur votre demande enseignant — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Demande enseignant non approuvée</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Après examen, votre demande pour <strong>{{SchoolName}}</strong> n'a pas été approuvée par le groupe d'experts <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">École / profil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Groupe d'experts</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Motif / commentaire</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Vous pouvez mettre à jour votre dossier (documents, diplômes, présentation) puis soumettre à nouveau une demande si besoin.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ouvrir mon espace enseignant</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre demande {{SchoolName}} n'a pas été approuvée par {{GroupName}}. Motif : {{Notes}}. Connexion : {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — Invitation candidature enseignant",
            SubjectTemplate: "{{ExpertName}} vous invite à déposer votre candidature enseignant",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitation à candidater</h2>
                <p>Bonjour {{FirstName}},</p>
                <p><strong>{{ExpertName}}</strong> (groupe d'experts <strong>{{GroupName}}</strong>) vous invite à déposer votre candidature enseignant sur TutorSphere pour examen.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>Créez votre compte et soumettez votre dossier via le lien ci-dessous. URL : {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Déposer ma candidature</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, {{ExpertName}} ({{GroupName}}) vous invite à candidater. {{PersonalMessage}} Lien : {{ApplyUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — Invitation membre Expert",
            SubjectTemplate: "{{InviterName}} vous invite dans le groupe {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Espace Expert</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">Rejoignez le groupe {{GroupName}}</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Le Responsable <strong>{{InviterName}}</strong> vous invite à devenir <strong>expert</strong> du groupe <strong>{{GroupName}}</strong> sur TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Groupe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Responsable</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Rôle proposé</td><td style="padding:10px 14px;font-weight:600;">Expert</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Validité</td><td style="padding:10px 14px;font-weight:600;">30 jours</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Message</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>Prochaines étapes</strong><br/>1. Ouvrez le lien sécurisé ci-dessous.<br/>2. Acceptez ou refusez l'invitation.<br/>3. Selon le groupe, votre admission peut ensuite être soumise au vote des membres.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Répondre à l'invitation</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, le Responsable {{InviterName}} vous invite à rejoindre le groupe d'experts {{GroupName}} sur TutorSphere. {{PersonalMessage}} Répondre : {{JoinUrl}} (valable 30 jours).",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — Vote d'admission Expert",
            SubjectTemplate: "Vote ouvert : candidature de {{CandidateName}} — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Un vote d'admission est ouvert</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>La candidature de <strong>{{CandidateName}}</strong> pour rejoindre le groupe <strong>{{GroupName}}</strong> est ouverte au vote des membres.</p>
                <p>Merci de voter dès que possible. L'admission nécessite l'accord d'au moins 75&nbsp;% des autres membres actifs.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ouvrir les admissions</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, vote ouvert pour {{CandidateName}} ({{GroupName}}). Lien : {{VoteUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — Candidature Expert non retenue",
            SubjectTemplate: "Votre candidature Expert n'a pas été retenue — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Candidature non retenue</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Après examen, votre candidature pour rejoindre un groupe d'experts TutorSphere n'a pas été retenue.</p>
                <p><strong>Motif :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{FirstName}}, votre candidature Expert n'a pas été retenue. Motif : {{Reason}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — Invitation réunion (membre)",
            SubjectTemplate: "Réunion « {{Title}} » — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Réunion du groupe</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitation à une réunion du groupe</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> vous invite à une réunion de travail sur TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Objet</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date et heure</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Code de la réunion</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organisateur</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ordre du jour</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>Le bouton ouvre directement la salle dans <strong>votre espace expert</strong> : le code est déjà inclus dans le lien, aucune saisie n'est nécessaire (connectez-vous simplement à votre compte TutorSphere si ce n'est pas déjà fait). Réunion privée du groupe — ne transférez ni ce lien ni ce code.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rejoindre la réunion</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{RecipientName}}, {{OrganizerName}} vous invite à la réunion « {{Title}} » le {{StartLocal}} ({{TimeZone}}). Ordre du jour : {{Agenda}}. {{RecordingAndAi}} Le lien contient déjà le code de la réunion ({{AccessCode}}) : un seul clic ouvre la salle. Rejoindre : {{JoinUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — Invitation réunion (invité externe)",
            SubjectTemplate: "Vous êtes invité(e) à la réunion « {{Title}} » — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Invité externe</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Invitation à une réunion</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> vous invite à participer à une réunion en ligne organisée sur TutorSphere. <strong>Aucun compte n'est nécessaire</strong> : votre lien d'accès personnel est ci-dessous.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Objet</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date et heure</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Votre code d'invitation</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organisateur</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ordre du jour</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Lien valable jusqu'au</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>Comment rejoindre</strong><br/>1. Cliquez sur le bouton ci-dessous : votre nom et votre code sont déjà inclus dans le lien, la réunion s'ouvre directement.<br/>2. Patientez dans la salle d'attente : l'organisateur vous admettra.<br/>Le code ci-dessus ne sert qu'en secours, si le lien est ouvert sans ses paramètres.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rejoindre la réunion</a></p>
                <p style="font-size:13px;color:#888;">Ce lien est personnel, temporaire et non transférable. Il ne donne accès qu'à cette réunion, pas au reste de TutorSphere. Si vous n'attendiez pas cette invitation, ignorez ce message.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{RecipientName}}, {{OrganizerName}} vous invite à la réunion « {{Title}} » le {{StartLocal}} ({{TimeZone}}). Ordre du jour : {{Agenda}}. {{RecordingAndAi}} Cliquez simplement sur votre lien personnel : votre nom et votre code ({{AccessCode}}) y sont déjà inclus. Lien valable jusqu'au {{LinkValidity}} : {{JoinUrl}}. Ne transférez ni ce lien ni ce code.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — Code de vérification invité",
            SubjectTemplate: "Votre code d'accès à la réunion « {{Title}} »",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Invité externe</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Votre code de vérification</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Saisissez ce code dans la page d'accès pour confirmer votre adresse e-mail et rejoindre la réunion <strong>{{Title}}</strong>.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">Ce code est valable pour cette seule session. Ne le communiquez à personne.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{RecipientName}}, votre code de vérification pour la réunion « {{Title}} » est {{Code}}. Ne le communiquez à personne.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — Rappel de réunion",
            SubjectTemplate: "Rappel : réunion « {{Title}} » le {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Rappel</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Votre réunion approche</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>La réunion <strong>{{Title}}</strong> est prévue le <strong>{{StartLocal}}</strong>. Le bouton ouvre la salle en un clic : le code (<strong>{{AccessCode}}</strong>) est déjà dans le lien. Pensez à tester votre micro et votre caméra avant de rejoindre.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rejoindre la réunion</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{RecipientName}}, rappel : la réunion « {{Title}} » a lieu le {{StartLocal}}. Code de la réunion : {{AccessCode}}. Rejoindre : {{JoinUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — Réunion annulée",
            SubjectTemplate: "Annulation : réunion « {{Title}} » du {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Réunion annulée</h2>
                <p>La réunion <strong>{{Title}}</strong> prévue le <strong>{{StartLocal}}</strong> a été annulée par l'organisateur. Le lien d'accès n'est plus valable.</p>
                <p>Si une nouvelle date est fixée, vous recevrez une nouvelle invitation.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "La réunion « {{Title}} » prévue le {{StartLocal}} a été annulée.",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — Compte rendu de réunion",
            SubjectTemplate: "Compte rendu de la réunion « {{Title}} »",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Le compte rendu est disponible</h2>
                <p>Bonjour {{RecipientName}},</p>
                <p>Le compte rendu de la réunion <strong>{{Title}}</strong> est disponible. Relisez-le et signalez toute correction nécessaire à l'organisateur.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ouvrir le compte rendu</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bonjour {{RecipientName}}, le compte rendu de la réunion « {{Title}} » est disponible : {{MinutesUrl}}",
            Language: "fr",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Welcome",
            SubjectTemplate: "Welcome {{FirstName}} to TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">Welcome {{FirstName}}!</h1>
                <p>Your TutorSphere account is ready. Sign in to access your personal space.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Go to my space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Welcome {{FirstName}} to TutorSphere.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — Parent space validation",
            SubjectTemplate: "Validate your parent space — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Activate your parent space</h2>
                <p>Hello {{FirstName}},</p>
                <p>Welcome to TutorSphere. To access the <strong>parent space</strong> and follow your children's learning journey, please <strong>validate your email address</strong> first. Without this validation, sign-in remains blocked.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Validate my parent space</a></p>
                <p style="font-size:13px;color:#888;">If you did not create an account, please ignore this email.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Validate your TutorSphere parent space: {{ConfirmationUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — Email confirmation (school)",
            SubjectTemplate: "Confirm your email address — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirm your email address</h2>
                <p>Hello {{FirstName}},</p>
                <p>Click the button below to activate your school account.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirm my email</a></p>
                <p style="font-size:13px;color:#888;">If you did not create an account, please ignore this email.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirm your email: {{ConfirmationUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Lesson report to parent",
            SubjectTemplate: "Lesson report for {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Lesson report</h2>
                <p>Hello {{ParentFirstName}},</p>
                <p>Here is the report from <strong>{{StudentName}}</strong>'s latest session with <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Sign in to your space to view the full report.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View report</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Lesson report for {{StudentName}} with {{TutorName}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — School created (pending)",
            SubjectTemplate: "Your school {{SchoolName}} is being reviewed — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">School registered</h2>
                <p>Hello {{OwnerFirstName}},</p>
                <p>Your school <strong>{{SchoolName}}</strong> has been registered and is awaiting approval by the TutorSphere team.</p>
                <p>You will be notified by email once a decision is made (usually 1–2 business days).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "School {{SchoolName}} registered, awaiting approval.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — Email confirmation (standard)",
            SubjectTemplate: "Confirm your email address — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirm your email address</h2>
                <p>Hello {{FirstName}},</p>
                <p>Please confirm your email address to finish creating your account.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirm my email</a></p>
                <p style="font-size:13px;color:#888;">If you did not create an account, please ignore this email.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirm your email: {{ConfirmationUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Password reset",
            SubjectTemplate: "Reset your password — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Password reset</h2>
                <p>Hello {{FirstName}},</p>
                <p>You requested to reset your TutorSphere password. Click below:</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Reset my password</a></p>
                <p style="font-size:13px;color:#888;">This link is valid for 24 hours. If you did not request this, ignore this email.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reset your password: {{ResetUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Password changed",
            SubjectTemplate: "Your password was changed — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Password changed</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your TutorSphere password has been changed.</p>
                <p>If you did not make this change, contact support immediately.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Sign in</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your TutorSphere password was changed.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Tutor free trial started",
            SubjectTemplate: "Your TutorSphere free trial has started!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Your free trial has started!</h2>
                <p>Hello {{FirstName}},</p>
                <p>Welcome to TutorSphere! Your free trial period is now active.</p>
                <p>Enjoy all features to manage your lessons, students, and payments.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Go to my dashboard</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your TutorSphere free trial has started.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Tutor payment receipt",
            SubjectTemplate: "Payment receipt — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Payment receipt</h2>
                <p>Hello {{FirstName}},</p>
                <p>We have received your payment for your TutorSphere subscription.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Amount</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my invoice</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Payment receipt {{Amount}}. Invoice: {{InvoiceUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Tutor renewal reminder",
            SubjectTemplate: "Your TutorSphere subscription renews soon",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Upcoming renewal</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your TutorSphere subscription will renew on <strong>{{RenewalDate}}</strong>.</p>
                <p>Please make sure your payment details are up to date.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Manage my subscription</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Your TutorSphere subscription renews on {{RenewalDate}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Tutor payment failed",
            SubjectTemplate: "Payment issue — your TutorSphere subscription",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Payment issue</h2>
                <p>Hello {{FirstName}},</p>
                <p>We could not process your payment for your TutorSphere subscription.</p>
                <p>Please update your payment details to avoid service interruption.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Update my details</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your TutorSphere payment failed. Please update your details.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Tutor subscription cancelled",
            SubjectTemplate: "Your TutorSphere subscription was cancelled",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Subscription cancelled</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your TutorSphere subscription has been cancelled. You keep access until the end of the current period.</p>
                <p>We hope to see you again soon!</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Return to TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your TutorSphere subscription was cancelled.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Account activated",
            SubjectTemplate: "Your TutorSphere account was activated",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Account activated</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your TutorSphere account has been <strong>activated</strong>. You can now sign in normally.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Sign in</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your TutorSphere account was activated.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Account deactivated",
            SubjectTemplate: "Your TutorSphere account was deactivated",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Account deactivated</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your TutorSphere account was deactivated by administration.</p>
                <p><strong>Reason :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">For any questions, contact TutorSphere support.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your account was deactivated. Reason: {{Reason}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — School approved",
            SubjectTemplate: "Congratulations! Your school {{SchoolName}} is approved",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">School approved!</h2>
                <p>Hello {{FirstName}},</p>
                <p>Good news: your school <strong>{{SchoolName}}</strong> has been <strong>approved</strong> by the TutorSphere team.</p>
                <p>You can now sign in and start managing your lessons and students.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Go to my school space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{FirstName}}, your school {{SchoolName}} is approved. Sign in: {{LoginUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Lesson scheduled",
            SubjectTemplate: "New lesson scheduled — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Lesson scheduled</h2>
                <p>Hello {{RecipientName}},</p>
                <p>A new lesson has been scheduled for you.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Subject</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my calendar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Lesson scheduled — {{Subject}} with {{TutorName}} on {{LessonDate}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Lesson reminder",
            SubjectTemplate: "Reminder: your {{Subject}} lesson is tomorrow",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Lesson reminder</h2>
                <p>Hello {{RecipientName}},</p>
                <p>Don't forget your lesson tomorrow!</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Subject</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View details</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reminder: {{Subject}} lesson with {{TutorName}} on {{LessonDate}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Lesson cancelled",
            SubjectTemplate: "Lesson cancelled — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Lesson cancelled</h2>
                <p>Hello {{RecipientName}},</p>
                <p>We are writing to let you know the following lesson was <strong>cancelled</strong>:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Subject</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Scheduled date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my calendar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Lesson cancelled — {{Subject}} with {{TutorName}} scheduled for {{LessonDate}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — Substitute proposed",
            SubjectTemplate: "Your approval is needed: substitute for {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">A substitute is proposed</h2>
                <p>Hello {{RecipientName}},</p>
                <p><strong>{{OriginalTeacherName}}</strong> cannot teach the session below. <strong>{{SubstituteTeacherName}}</strong>, a teacher from the same group, can take it over: <strong>your approval is required</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Lesson</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Scheduled date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Student</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Original teacher</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Substitute</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>Without your answer before the scheduled time, the session stays with the original teacher and may be postponed.</p>
                <p><strong>Reason for the absence :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Accept or decline</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} is unavailable for {{LessonTitle}} on {{LessonDate}}. Proposed substitute: {{SubstituteTeacherName}}. Your approval: {{ActionUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — Substitution request",
            SubjectTemplate: "Substitution proposed: {{LessonCount}} session(s) of {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">You are proposed as substitute</h2>
                <p>Hello {{RecipientName}},</p>
                <p>The group is proposing that you take over the sessions of <strong>{{OriginalTeacherName}}</strong>, who is unavailable. Each family must approve; accepted sessions then appear in your calendar.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">First session</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Teacher being covered</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Sessions involved</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>Reason for the absence :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my calendar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substitution proposed: {{LessonCount}} session(s) of {{OriginalTeacherName}}, from {{LessonDate}}. Calendar: {{ActionUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — Substitution accepted",
            SubjectTemplate: "Substitution accepted — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Substitution accepted</h2>
                <p>Hello {{RecipientName}},</p>
                <p>The family has <strong>accepted</strong> the substitution: <strong>{{SubstituteTeacherName}}</strong> will teach the session instead of <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Lesson</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Scheduled date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Original teacher</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Substitute</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my calendar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substitution accepted: {{SubstituteTeacherName}} will teach {{LessonTitle}} on {{LessonDate}} instead of {{OriginalTeacherName}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — Substitution declined",
            SubjectTemplate: "Substitution declined — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Substitution declined</h2>
                <p>Hello {{RecipientName}},</p>
                <p>The family has <strong>declined</strong> the substitution: the session stays with <strong>{{OriginalTeacherName}}</strong>. If the absence is confirmed, the session will have to be rescheduled or cancelled.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Lesson</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Scheduled date</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Proposed substitute</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my calendar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substitution declined: {{LessonTitle}} on {{LessonDate}} stays with {{OriginalTeacherName}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Parent payment receipt",
            SubjectTemplate: "Payment receipt for {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Payment receipt</h2>
                <p>Hello {{ParentName}},</p>
                <p>We have received your payment for <strong>{{StudentName}}</strong>'s lessons.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Student</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Amount</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my invoice</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Payment receipt for {{StudentName}} — {{Amount}}. Invoice: {{InvoiceUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — Parent refund",
            SubjectTemplate: "Refund for {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Payment refunded</h2>
                <p>Hello {{ParentName}},</p>
                <p>Teacher profile <strong>{{TutorName}}</strong> has been removed. Scheduled lessons are cancelled. Your payment for <strong>{{StudentName}}</strong> has been <strong>refunded</strong> — no action is required from you.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Student</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Refunded amount</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Open my account</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Refund {{Amount}} for {{StudentName}} (teacher {{TutorName}}). Scheduled lessons are cancelled.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Parent payment failed",
            SubjectTemplate: "Payment issue — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Payment issue</h2>
                <p>Hello {{ParentName}},</p>
                <p>We could not process your payment for your child's lessons.</p>
                <p>Please update your payment details to keep access to lessons.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Update my details</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{ParentName}}, your TutorSphere payment failed. Please update your details.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Invoice ready",
            SubjectTemplate: "Your TutorSphere invoice is ready",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invoice ready</h2>
                <p>Hello {{ParentName}},</p>
                <p>Your new TutorSphere invoice is available to download.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Download my invoice</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hi {{ParentName}}, your TutorSphere invoice is ready: {{InvoiceUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — Overdue payment",
            SubjectTemplate: "Reminder: payment pending for {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Overdue payment</h2>
                <p>Hello {{ParentName}},</p>
                <p>Payment for <strong>{{StudentName}}</strong>'s course <strong>{{CourseTitle}}</strong> is still pending.</p>
                <p>Please settle as soon as possible to activate or keep access to sessions.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Pay now</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reminder: overdue payment for {{StudentName}} — {{CourseTitle}}. Pay: {{PayUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — Course enrollment request",
            SubjectTemplate: "New enrollment request — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">New enrollment request</h2>
                <p>Hello {{TutorName}},</p>
                <p><strong>{{StudentName}}</strong> wants to enroll in <strong>{{CourseTitle}}</strong>.</p>
                <p>Sign in to accept or decline the request.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Manage enrollments</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Enrollment request from {{StudentName}} for {{CourseTitle}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — Course enrollment accepted",
            SubjectTemplate: "Enrollment accepted — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Enrollment accepted</h2>
                <p>Hello {{ParentName}},</p>
                <p><strong>{{StudentName}}</strong>'s enrollment in <strong>{{CourseTitle}}</strong> has been accepted.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Continue</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Enrollment of {{StudentName}} in {{CourseTitle}} accepted. {{StatusNote}} {{ActionUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — Payment received (student course)",
            SubjectTemplate: "Payment received — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Payment received</h2>
                <p>Hello {{TutorName}},</p>
                <p>A payment was received for <strong>{{StudentName}}</strong> — course <strong>{{CourseTitle}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Amount</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">View my space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Payment received: {{Amount}} for {{StudentName}} — {{CourseTitle}}.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — Teacher pending (expert)",
            SubjectTemplate: "New teacher application to review — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Teacher application to review</h2>
                <p>Hello {{ExpertFirstName}},</p>
                <p>A school has submitted a teacher account pending validation.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">School</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Country</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>Sign in to review the file and approve or decline the application.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Review application</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{ExpertFirstName}}, teacher application to review — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — Expert invitation",
            SubjectTemplate: "Welcome {{FirstName}} — expert access {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Your expert space access</h2>
                <p>Hello {{FirstName}},</p>
                <p>You have been invited to join the expert group <strong>{{GroupName}}</strong> on TutorSphere. Here are your sign-in credentials:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Expert group</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Sign-in email</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Temporary password</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Expert sign-in page</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">For your security, <strong>change this password</strong> as soon as you first sign in to the expert space.</p>
                <p>Steps: 1) Open the expert sign-in page below 2) Enter the email and temporary password 3) Choose a new password.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Sign in to expert space</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">Expert sign-in page</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Sign in only on the expert space:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canonical: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">GISEBS ecosystem — our products</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
This email was sent by TutorSphere (GISEBS). Please do not reply directly.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, expert invite {{GroupName}}. Email: {{Email}}. Temporary password: {{TemporaryPassword}}. Change this password on first login. Expert login: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — Added to expert group",
            SubjectTemplate: "{{FirstName}}, you were added to {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Added to an expert group</h2>
                <p>Hello {{FirstName}},</p>
                <p>You have been added to the expert group <strong>{{GroupName}}</strong> on TutorSphere. Use your existing credentials to sign in.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Expert group</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Account</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Sign in to expert space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, you were added to group {{GroupName}} (account {{Email}}). Login: {{LoginUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — Teacher approved (expert)",
            SubjectTemplate: "Good news: your teacher profile is approved",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Teacher profile approved</h2>
                <p>Hello {{FirstName}},</p>
                <p>Your application for <strong>{{SchoolName}}</strong> has been <strong>approved</strong> by the expert group <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">School / profile</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Expert group</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Comment</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>You can sign in to your teacher space to continue on TutorSphere.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Go to my teacher space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, your profile {{SchoolName}} was approved by {{GroupName}}. Comment: {{Notes}}. Login: {{LoginUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — Teacher rejected (expert)",
            SubjectTemplate: "Decision on your teacher application — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Teacher application not approved</h2>
                <p>Hello {{FirstName}},</p>
                <p>After review, your application for <strong>{{SchoolName}}</strong> was not approved by the expert group <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">School / profile</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Expert group</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Reason / comment</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>You can update your file (documents, diplomas, presentation) and submit a new application if needed.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Open my teacher space</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, your application {{SchoolName}} was not approved by {{GroupName}}. Reason: {{Notes}}. Login: {{LoginUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — Teacher application invite",
            SubjectTemplate: "{{ExpertName}} invites you to submit your teacher application",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitation to apply</h2>
                <p>Hello {{FirstName}},</p>
                <p><strong>{{ExpertName}}</strong> (expert group <strong>{{GroupName}}</strong>) invites you to submit your teacher application on TutorSphere for review.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>Create your account and submit your file using the link below. URL: {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Submit my application</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, {{ExpertName}} ({{GroupName}}) invites you to apply. {{PersonalMessage}} Link: {{ApplyUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — Expert membership invite",
            SubjectTemplate: "{{InviterName}} invites you to {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Expert space</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">Join the {{GroupName}} group</h2>
                <p>Hello {{FirstName}},</p>
                <p>Group manager <strong>{{InviterName}}</strong> invites you to become an <strong>expert</strong> in <strong>{{GroupName}}</strong> on TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Group</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Group manager</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Proposed role</td><td style="padding:10px 14px;font-weight:600;">Expert</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Validity</td><td style="padding:10px 14px;font-weight:600;">30 days</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Message</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>Next steps</strong><br/>1. Open the secure link below.<br/>2. Accept or decline the invitation.<br/>3. Depending on the group, your admission may then go to a member vote.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Respond to the invitation</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, group manager {{InviterName}} invites you to join expert group {{GroupName}} on TutorSphere. {{PersonalMessage}} Reply: {{JoinUrl}} (valid 30 days).",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — Expert admission vote",
            SubjectTemplate: "Vote open: {{CandidateName}} application — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">An admission vote is open</h2>
                <p>Hello {{FirstName}},</p>
                <p>The application of <strong>{{CandidateName}}</strong> to join <strong>{{GroupName}}</strong> is open for member voting.</p>
                <p>Please vote as soon as possible. Admission requires approval from at least 75% of the other active members.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Open admissions</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, vote open for {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — Expert application not retained",
            SubjectTemplate: "Your Expert application was not retained — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Application not retained</h2>
                <p>Hello {{FirstName}},</p>
                <p>After review, your application to join a TutorSphere expert group was not retained.</p>
                <p><strong>Reason :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{FirstName}}, your Expert application was not retained. Reason: {{Reason}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — Meeting invitation (member)",
            SubjectTemplate: "Meeting “{{Title}}” — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Group meeting</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitation to a group meeting</h2>
                <p>Hello {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> invites you to a working meeting on TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Subject</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date and time</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Meeting code</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizer</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Agenda</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>The button opens the room directly in <strong>your expert space</strong>: the code is already included in the link, so there is nothing to type (just sign in to your TutorSphere account if you are not already). This is a private group meeting — please do not forward this link or code.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Join the meeting</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{RecipientName}}, {{OrganizerName}} invites you to the meeting “{{Title}}” on {{StartLocal}} ({{TimeZone}}). Agenda: {{Agenda}}. {{RecordingAndAi}} The link already contains the meeting code ({{AccessCode}}): a single click opens the room. Join: {{JoinUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — Meeting invitation (external guest)",
            SubjectTemplate: "You are invited to the meeting “{{Title}}” — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">External guest</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Invitation to a meeting</h2>
                <p>Hello {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> invites you to join an online meeting hosted on TutorSphere. <strong>No account is required</strong>: your personal access link is below.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Subject</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Date and time</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Your invitation code</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizer</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Agenda</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Link valid until</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>How to join</strong><br/>1. Click the button below: your name and code are already in the link, so the meeting opens straight away.<br/>2. Wait in the waiting room: the organizer will let you in.<br/>The code above is only a fallback, in case the link is opened without its parameters.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Join the meeting</a></p>
                <p style="font-size:13px;color:#888;">This link is personal, temporary and non-transferable. It only grants access to this meeting, not to the rest of TutorSphere. If you were not expecting this invitation, please ignore this message.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{RecipientName}}, {{OrganizerName}} invites you to the meeting “{{Title}}” on {{StartLocal}} ({{TimeZone}}). Agenda: {{Agenda}}. {{RecordingAndAi}} Just click your personal link: your name and code ({{AccessCode}}) are already included. Link valid until {{LinkValidity}}: {{JoinUrl}}. Please do not forward this link or code.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — Guest verification code",
            SubjectTemplate: "Your access code for the meeting “{{Title}}”",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">External guest</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Your verification code</h2>
                <p>Hello {{RecipientName}},</p>
                <p>Enter this code on the access page to confirm your email address and join the meeting <strong>{{Title}}</strong>.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">This code is valid for this session only. Do not share it with anyone.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{RecipientName}}, your verification code for the meeting “{{Title}}” is {{Code}}. Do not share it.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — Meeting reminder",
            SubjectTemplate: "Reminder: meeting “{{Title}}” on {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Reminder</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Your meeting is coming up</h2>
                <p>Hello {{RecipientName}},</p>
                <p>The meeting <strong>{{Title}}</strong> is scheduled for <strong>{{StartLocal}}</strong>. The button opens the room in one click: the code (<strong>{{AccessCode}}</strong>) is already in the link. Remember to test your microphone and camera before joining.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Join the meeting</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{RecipientName}}, reminder: the meeting “{{Title}}” takes place on {{StartLocal}}. Meeting code: {{AccessCode}}. Join: {{JoinUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — Meeting cancelled",
            SubjectTemplate: "Cancelled: meeting “{{Title}}” of {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Meeting cancelled</h2>
                <p>The meeting <strong>{{Title}}</strong> scheduled for <strong>{{StartLocal}}</strong> was cancelled by the organizer. The access link is no longer valid.</p>
                <p>If a new date is set, you will receive a new invitation.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "The meeting “{{Title}}” scheduled for {{StartLocal}} was cancelled.",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — Meeting minutes",
            SubjectTemplate: "Minutes of the meeting “{{Title}}”",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">The minutes are available</h2>
                <p>Hello {{RecipientName}},</p>
                <p>The minutes of the meeting <strong>{{Title}}</strong> are available. Please review them and report any needed correction to the organizer.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Open the minutes</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hello {{RecipientName}}, the minutes of the meeting “{{Title}}” are available: {{MinutesUrl}}",
            Language: "en",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Bienvenida",
            SubjectTemplate: "¡Bienvenido/a {{FirstName}} a TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">¡Bienvenido/a {{FirstName}}!</h1>
                <p>Su cuenta de TutorSphere está lista. Inicie sesión para acceder a su espacio personal.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir a mi espacio</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bienvenido/a {{FirstName}} a TutorSphere.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — Validación espacio padres",
            SubjectTemplate: "Valide su espacio de padres — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Active su espacio de padres</h2>
                <p>Hola {{FirstName}},</p>
                <p>Bienvenido/a a TutorSphere. Para acceder al <strong>espacio de padres</strong> y seguir el recorrido escolar de sus hijos, primero <strong>valide su correo electrónico</strong>. Sin esta validación, el acceso permanece bloqueado.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Validar mi espacio de padres</a></p>
                <p style="font-size:13px;color:#888;">Si no creó una cuenta, ignore este correo.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Valide su espacio de padres TutorSphere: {{ConfirmationUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — Confirmación de correo (escuela)",
            SubjectTemplate: "Confirme su correo electrónico — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirme su correo electrónico</h2>
                <p>Hola {{FirstName}},</p>
                <p>Haga clic en el botón de abajo para activar su cuenta de escuela.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmar mi correo</a></p>
                <p style="font-size:13px;color:#888;">Si no creó una cuenta, ignore este correo.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirme su correo: {{ConfirmationUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Informe de clase al padre",
            SubjectTemplate: "Informe de clase de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Informe de clase</h2>
                <p>Hola {{ParentFirstName}},</p>
                <p>Aquí tiene el informe de la última sesión de <strong>{{StudentName}}</strong> con <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Inicie sesión en su espacio para ver el informe completo.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver informe</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Informe de clase de {{StudentName}} con {{TutorName}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — Escuela creada (pendiente)",
            SubjectTemplate: "Su escuela {{SchoolName}} está en revisión — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Escuela registrada</h2>
                <p>Hola {{OwnerFirstName}},</p>
                <p>Su escuela <strong>{{SchoolName}}</strong> ha sido registrada y está pendiente de aprobación por el equipo de TutorSphere.</p>
                <p>Se le notificará por correo cuando se tome una decisión (plazo habitual: 1 a 2 días hábiles).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Escuela {{SchoolName}} registrada, pendiente de aprobación.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — Confirmación de correo (estándar)",
            SubjectTemplate: "Confirme su correo electrónico — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirme su correo electrónico</h2>
                <p>Hola {{FirstName}},</p>
                <p>Confirme su correo electrónico para finalizar la creación de su cuenta.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmar mi correo</a></p>
                <p style="font-size:13px;color:#888;">Si no creó una cuenta, ignore este correo.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirme su correo: {{ConfirmationUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Restablecer contraseña",
            SubjectTemplate: "Restablezca su contraseña — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Restablecer contraseña</h2>
                <p>Hola {{FirstName}},</p>
                <p>Solicitó restablecer su contraseña de TutorSphere. Haga clic abajo:</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Restablecer mi contraseña</a></p>
                <p style="font-size:13px;color:#888;">Este enlace es válido 24 horas. Si no lo solicitó, ignore este correo.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Restablezca su contraseña: {{ResetUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Contraseña cambiada",
            SubjectTemplate: "Su contraseña fue cambiada — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Contraseña cambiada</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su contraseña de TutorSphere ha sido cambiada.</p>
                <p>Si no realizó este cambio, contacte al soporte de inmediato.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sesión</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su contraseña de TutorSphere fue cambiada.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Prueba gratuita de tutor iniciada",
            SubjectTemplate: "¡Su prueba gratuita de TutorSphere ha comenzado!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">¡Su prueba gratuita ha comenzado!</h2>
                <p>Hola {{FirstName}},</p>
                <p>¡Bienvenido/a a TutorSphere! Su período de prueba gratuita ya está activo.</p>
                <p>Disfrute de todas las funciones para gestionar sus clases, alumnos y pagos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir a mi panel</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su prueba gratuita de TutorSphere ha comenzado.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Recibo de pago del tutor",
            SubjectTemplate: "Recibo de pago — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Recibo de pago</h2>
                <p>Hola {{FirstName}},</p>
                <p>Hemos recibido su pago por la suscripción a TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Importe</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi factura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recibo de pago {{Amount}}. Factura: {{InvoiceUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Recordatorio de renovación del tutor",
            SubjectTemplate: "Su suscripción a TutorSphere se renueva pronto",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Renovación próxima</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su suscripción a TutorSphere se renovará el <strong>{{RenewalDate}}</strong>.</p>
                <p>Asegúrese de que sus datos de pago estén actualizados.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gestionar mi suscripción</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Su suscripción a TutorSphere se renueva el {{RenewalDate}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Fallo de pago del tutor",
            SubjectTemplate: "Problema de pago — su suscripción a TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problema de pago</h2>
                <p>Hola {{FirstName}},</p>
                <p>No pudimos procesar su pago de la suscripción a TutorSphere.</p>
                <p>Actualice sus datos de pago para evitar la interrupción del servicio.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Actualizar mis datos</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, falló su pago de TutorSphere. Actualice sus datos.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Suscripción de tutor cancelada",
            SubjectTemplate: "Su suscripción a TutorSphere fue cancelada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Suscripción cancelada</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su suscripción a TutorSphere ha sido cancelada. Conserva el acceso hasta el final del período actual.</p>
                <p>¡Esperamos verle pronto de nuevo!</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Volver a TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su suscripción a TutorSphere fue cancelada.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Cuenta activada",
            SubjectTemplate: "Su cuenta de TutorSphere fue activada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Cuenta activada</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su cuenta de TutorSphere ha sido <strong>activada</strong>. Ya puede iniciar sesión con normalidad.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sesión</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su cuenta de TutorSphere fue activada.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Cuenta desactivada",
            SubjectTemplate: "Su cuenta de TutorSphere fue desactivada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Cuenta desactivada</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su cuenta de TutorSphere fue desactivada por la administración.</p>
                <p><strong>Motivo :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">Para cualquier pregunta, contacte al soporte de TutorSphere.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su cuenta fue desactivada. Motivo: {{Reason}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — Escuela aprobada",
            SubjectTemplate: "¡Enhorabuena! Su escuela {{SchoolName}} está aprobada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">¡Escuela aprobada!</h2>
                <p>Hola {{FirstName}},</p>
                <p>Buenas noticias: su escuela <strong>{{SchoolName}}</strong> ha sido <strong>aprobada</strong> por el equipo de TutorSphere.</p>
                <p>Ya puede iniciar sesión y gestionar sus clases y alumnos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir a mi espacio escolar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su escuela {{SchoolName}} está aprobada. Acceso: {{LoginUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Clase programada",
            SubjectTemplate: "Nueva clase programada — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Clase programada</h2>
                <p>Hola {{RecipientName}},</p>
                <p>Se ha programado una nueva clase para usted.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Materia</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi calendario</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Clase programada — {{Subject}} con {{TutorName}} el {{LessonDate}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Recordatorio de clase",
            SubjectTemplate: "Recordatorio: su clase de {{Subject}} es mañana",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Recordatorio de clase</h2>
                <p>Hola {{RecipientName}},</p>
                <p>¡No olvide su clase de mañana!</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Materia</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver detalles</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recordatorio: clase de {{Subject}} con {{TutorName}} el {{LessonDate}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Clase cancelada",
            SubjectTemplate: "Clase cancelada — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Clase cancelada</h2>
                <p>Hola {{RecipientName}},</p>
                <p>Le informamos que la siguiente clase ha sido <strong>cancelada</strong>:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Materia</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Consultar mi calendario</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Clase cancelada — {{Subject}} con {{TutorName}} prevista el {{LessonDate}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — Suplente propuesto",
            SubjectTemplate: "Se solicita su aprobación: suplente para {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Se propone un suplente</h2>
                <p>Hola {{RecipientName}},</p>
                <p><strong>{{OriginalTeacherName}}</strong> no podrá dar la sesión indicada. <strong>{{SubstituteTeacherName}}</strong>, profesor del mismo grupo, puede asumirla: <strong>se requiere su aprobación</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sesión</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Alumno</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Profesor titular</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suplente</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>Si no responde antes de la hora prevista, la sesión permanece con el profesor titular y podría posponerse.</p>
                <p><strong>Motivo de la ausencia :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Aceptar o rechazar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} no está disponible para {{LessonTitle}} el {{LessonDate}}. Suplente propuesto: {{SubstituteTeacherName}}. Su aprobación: {{ActionUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — Propuesta de suplencia",
            SubjectTemplate: "Suplencia propuesta: {{LessonCount}} sesión(es) de {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Se le propone como suplente</h2>
                <p>Hola {{RecipientName}},</p>
                <p>El grupo le propone asumir las sesiones de <strong>{{OriginalTeacherName}}</strong>, que no está disponible. Cada familia debe dar su acuerdo; las sesiones aceptadas aparecerán en su calendario.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Primera sesión</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Profesor sustituido</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Sesiones afectadas</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>Motivo de la ausencia :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi calendario</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Suplencia propuesta: {{LessonCount}} sesión(es) de {{OriginalTeacherName}}, desde el {{LessonDate}}. Calendario: {{ActionUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — Suplencia aceptada",
            SubjectTemplate: "Suplencia aceptada — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Suplencia aceptada</h2>
                <p>Hola {{RecipientName}},</p>
                <p>La familia ha <strong>aceptado</strong> la suplencia: <strong>{{SubstituteTeacherName}}</strong> dará la sesión en lugar de <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sesión</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Profesor titular</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suplente</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi calendario</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Suplencia aceptada: {{SubstituteTeacherName}} dará {{LessonTitle}} el {{LessonDate}} en lugar de {{OriginalTeacherName}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — Suplencia rechazada",
            SubjectTemplate: "Suplencia rechazada — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Suplencia rechazada</h2>
                <p>Hola {{RecipientName}},</p>
                <p>La familia ha <strong>rechazado</strong> la suplencia: la sesión permanece con <strong>{{OriginalTeacherName}}</strong>. Si se confirma la ausencia, habrá que reprogramar o cancelar la sesión.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sesión</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Suplente propuesto</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi calendario</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Suplencia rechazada: {{LessonTitle}} del {{LessonDate}} permanece con {{OriginalTeacherName}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Recibo de pago del padre",
            SubjectTemplate: "Recibo de pago de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Recibo de pago</h2>
                <p>Hola {{ParentName}},</p>
                <p>Hemos recibido su pago por las clases de <strong>{{StudentName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Alumno/a</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Importe</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi factura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recibo de pago de {{StudentName}} — {{Amount}}. Factura: {{InvoiceUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — Reembolso al padre",
            SubjectTemplate: "Reembolso de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Pago reembolsado</h2>
                <p>Hola {{ParentName}},</p>
                <p>El perfil del docente <strong>{{TutorName}}</strong> ha sido retirado. Las clases programadas quedan canceladas. Su pago por <strong>{{StudentName}}</strong> ha sido <strong>reembolsado</strong> — no se requiere ninguna acción.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Alumno/a</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Importe reembolsado</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir mi espacio</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reembolso {{Amount}} de {{StudentName}} (docente {{TutorName}}). Clases programadas canceladas.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Fallo de pago del padre",
            SubjectTemplate: "Problema de pago — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problema de pago</h2>
                <p>Hola {{ParentName}},</p>
                <p>No pudimos procesar su pago por las clases de su hijo/a.</p>
                <p>Actualice sus datos de pago para mantener el acceso a las clases.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Actualizar mis datos</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{ParentName}}, falló su pago de TutorSphere. Actualice sus datos.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Factura disponible",
            SubjectTemplate: "Su factura de TutorSphere está disponible",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Factura disponible</h2>
                <p>Hola {{ParentName}},</p>
                <p>Su nueva factura de TutorSphere está disponible para descargar.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Descargar mi factura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{ParentName}}, su factura de TutorSphere está disponible: {{InvoiceUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — Pago atrasado",
            SubjectTemplate: "Recordatorio: pago pendiente de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Pago atrasado</h2>
                <p>Hola {{ParentName}},</p>
                <p>El pago del curso <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> sigue pendiente.</p>
                <p>Regularice lo antes posible para activar o mantener el acceso a las sesiones.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Pagar ahora</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recordatorio: pago atrasado de {{StudentName}} — {{CourseTitle}}. Pagar: {{PayUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — Solicitud de inscripción a un curso",
            SubjectTemplate: "Nueva solicitud de inscripción — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Nueva solicitud de inscripción</h2>
                <p>Hola {{TutorName}},</p>
                <p><strong>{{StudentName}}</strong> desea inscribirse en el curso <strong>{{CourseTitle}}</strong>.</p>
                <p>Inicie sesión para aceptar o rechazar la solicitud.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gestionar inscripciones</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Solicitud de inscripción de {{StudentName}} al curso {{CourseTitle}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — Inscripción al curso aceptada",
            SubjectTemplate: "Inscripción aceptada — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Inscripción aceptada</h2>
                <p>Hola {{ParentName}},</p>
                <p>La inscripción de <strong>{{StudentName}}</strong> en el curso <strong>{{CourseTitle}}</strong> ha sido aceptada.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Continuar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Inscripción de {{StudentName}} en {{CourseTitle}} aceptada. {{StatusNote}} {{ActionUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — Pago recibido (curso del alumno)",
            SubjectTemplate: "Pago recibido — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Pago recibido</h2>
                <p>Hola {{TutorName}},</p>
                <p>Se recibió un pago por <strong>{{StudentName}}</strong> — curso <strong>{{CourseTitle}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Importe</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver mi espacio</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Pago recibido: {{Amount}} por {{StudentName}} — {{CourseTitle}}.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — Profesor pendiente (experto)",
            SubjectTemplate: "Nueva solicitud de profesor por revisar — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Solicitud de profesor por revisar</h2>
                <p>Hola {{ExpertFirstName}},</p>
                <p>Una escuela ha enviado una cuenta de profesor pendiente de validación.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escuela</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">País</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>Inicie sesión para revisar el expediente y aprobar o rechazar la solicitud.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Revisar solicitud</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{ExpertFirstName}}, solicitud de profesor por revisar — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — Invitación experto",
            SubjectTemplate: "Bienvenido/a {{FirstName}} — acceso experto {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Su acceso al espacio experto</h2>
                <p>Hola {{FirstName}},</p>
                <p>Ha sido invitado/a a unirse al grupo de expertos <strong>{{GroupName}}</strong> en TutorSphere. Estas son sus credenciales de acceso:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de expertos</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Correo de acceso</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Contraseña temporal</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Página de acceso experto</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Por su seguridad, <strong>cambie esta contraseña</strong> en el primer acceso al espacio experto.</p>
                <p>Pasos: 1) Abra la página de acceso experto abajo 2) Introduzca el correo y la contraseña temporal 3) Elija una nueva contraseña.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sesión en el espacio experto</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">Página de acceso experto</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Inicie sesión solo en el espacio experto:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canónica: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Ecosistema GISEBS — nuestros productos</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Este correo fue enviado por TutorSphere (GISEBS). No responda directamente.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, invitación experto {{GroupName}}. Correo: {{Email}}. Contraseña temporal: {{TemporaryPassword}}. Cambie esta contraseña en el primer acceso. Acceso experto: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — Añadido al grupo experto",
            SubjectTemplate: "{{FirstName}}, ha sido añadido/a a {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Añadido a un grupo de expertos</h2>
                <p>Hola {{FirstName}},</p>
                <p>Ha sido añadido/a al grupo de expertos <strong>{{GroupName}}</strong> en TutorSphere. Use sus credenciales existentes para iniciar sesión.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de expertos</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Cuenta</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sesión en el espacio experto</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, ha sido añadido/a al grupo {{GroupName}} (cuenta {{Email}}). Acceso: {{LoginUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — Profesor aprobado (experto)",
            SubjectTemplate: "Buenas noticias: su perfil de profesor está aprobado",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Perfil de profesor aprobado</h2>
                <p>Hola {{FirstName}},</p>
                <p>Su solicitud para <strong>{{SchoolName}}</strong> ha sido <strong>aprobada</strong> por el grupo de expertos <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escuela / perfil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de expertos</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Comentario</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Puede iniciar sesión en su espacio de profesor para continuar en TutorSphere.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir a mi espacio de profesor</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su perfil {{SchoolName}} fue aprobado por {{GroupName}}. Comentario: {{Notes}}. Acceso: {{LoginUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — Profesor rechazado (experto)",
            SubjectTemplate: "Decisión sobre su solicitud de profesor — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Solicitud de profesor no aprobada</h2>
                <p>Hola {{FirstName}},</p>
                <p>Tras la revisión, su solicitud para <strong>{{SchoolName}}</strong> no fue aprobada por el grupo de expertos <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escuela / perfil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de expertos</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Motivo / comentario</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Puede actualizar su expediente (documentos, diplomas, presentación) y volver a enviar una solicitud si lo necesita.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir mi espacio de profesor</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su solicitud {{SchoolName}} no fue aprobada por {{GroupName}}. Motivo: {{Notes}}. Acceso: {{LoginUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — Invitación candidatura profesor",
            SubjectTemplate: "{{ExpertName}} le invita a presentar su candidatura de profesor",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitación a postular</h2>
                <p>Hola {{FirstName}},</p>
                <p><strong>{{ExpertName}}</strong> (grupo de expertos <strong>{{GroupName}}</strong>) le invita a presentar su candidatura de profesor en TutorSphere para revisión.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>Cree su cuenta y envíe su expediente con el enlace de abajo. URL: {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Presentar mi candidatura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, {{ExpertName}} ({{GroupName}}) le invita a postular. {{PersonalMessage}} Enlace: {{ApplyUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — Invitación miembro experto",
            SubjectTemplate: "{{InviterName}} le invita a {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Espacio experto</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">Únase al grupo {{GroupName}}</h2>
                <p>Hola {{FirstName}},</p>
                <p>El responsable <strong>{{InviterName}}</strong> le invita a convertirse en <strong>experto</strong> del grupo <strong>{{GroupName}}</strong> en TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Responsable</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Rol propuesto</td><td style="padding:10px 14px;font-weight:600;">Experto</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Validez</td><td style="padding:10px 14px;font-weight:600;">30 días</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Mensaje</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>Próximos pasos</strong><br/>1. Abra el enlace seguro de abajo.<br/>2. Acepte o rechace la invitación.<br/>3. Según el grupo, su admisión podrá someterse a votación de los miembros.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Responder a la invitación</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, el responsable {{InviterName}} le invita a unirse al grupo de expertos {{GroupName}} en TutorSphere. {{PersonalMessage}} Responder: {{JoinUrl}} (válido 30 días).",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — Voto de admisión experto",
            SubjectTemplate: "Voto abierto: candidatura de {{CandidateName}} — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Hay un voto de admisión abierto</h2>
                <p>Hola {{FirstName}},</p>
                <p>La candidatura de <strong>{{CandidateName}}</strong> para unirse a <strong>{{GroupName}}</strong> está abierta a la votación de los miembros.</p>
                <p>Vote lo antes posible. La admisión requiere la aprobación de al menos el 75&nbsp;% de los demás miembros activos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir admisiones</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, voto abierto para {{CandidateName}} ({{GroupName}}). Enlace: {{VoteUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — Candidatura de experto no retenida",
            SubjectTemplate: "Su candidatura de experto no fue retenida — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Candidatura no retenida</h2>
                <p>Hola {{FirstName}},</p>
                <p>Tras la revisión, su candidatura para unirse a un grupo de expertos TutorSphere no fue retenida.</p>
                <p><strong>Motivo :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{FirstName}}, su candidatura de experto no fue retenida. Motivo: {{Reason}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — Invitación a reunión (miembro)",
            SubjectTemplate: "Reunión «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Reunión del grupo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Invitación a una reunión del grupo</h2>
                <p>Hola {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> le invita a una reunión de trabajo en TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Asunto</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha y hora</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Código de la reunión</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizador</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Orden del día</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>El botón abre directamente la sala en <strong>su espacio experto</strong>: el código ya está incluido en el enlace, no hay que escribir nada (solo inicie sesión en su cuenta TutorSphere si aún no lo ha hecho). Reunión privada del grupo: no reenvíe este enlace ni este código.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Unirse a la reunión</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{RecipientName}}, {{OrganizerName}} le invita a la reunión «{{Title}}» el {{StartLocal}} ({{TimeZone}}). Orden del día: {{Agenda}}. {{RecordingAndAi}} El enlace ya incluye el código de la reunión ({{AccessCode}}): un solo clic abre la sala. Unirse: {{JoinUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — Invitación a reunión (invitado externo)",
            SubjectTemplate: "Está invitado/a a la reunión «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Invitado externo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Invitación a una reunión</h2>
                <p>Hola {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> le invita a participar en una reunión en línea organizada en TutorSphere. <strong>No necesita ninguna cuenta</strong>: su enlace de acceso personal está abajo.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Asunto</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Fecha y hora</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Su código de invitación</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizador</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Orden del día</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Enlace válido hasta</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>Cómo unirse</strong><br/>1. Haga clic en el botón de abajo: su nombre y su código ya están en el enlace, la reunión se abre directamente.<br/>2. Espere en la sala de espera: el organizador le admitirá.<br/>El código de arriba solo sirve de respaldo, si el enlace se abre sin sus parámetros.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Unirse a la reunión</a></p>
                <p style="font-size:13px;color:#888;">Este enlace es personal, temporal e intransferible. Solo da acceso a esta reunión, no al resto de TutorSphere. Si no esperaba esta invitación, ignore este mensaje.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{RecipientName}}, {{OrganizerName}} le invita a la reunión «{{Title}}» el {{StartLocal}} ({{TimeZone}}). Orden del día: {{Agenda}}. {{RecordingAndAi}} Solo tiene que hacer clic en su enlace personal: su nombre y su código ({{AccessCode}}) ya están incluidos. Enlace válido hasta {{LinkValidity}}: {{JoinUrl}}. No reenvíe este enlace ni este código.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — Código de verificación de invitado",
            SubjectTemplate: "Su código de acceso a la reunión «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Invitado externo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Su código de verificación</h2>
                <p>Hola {{RecipientName}},</p>
                <p>Introduzca este código en la página de acceso para confirmar su correo y unirse a la reunión <strong>{{Title}}</strong>.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">Este código solo es válido para esta sesión. No lo comparta con nadie.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{RecipientName}}, su código de verificación para la reunión «{{Title}}» es {{Code}}. No lo comparta.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — Recordatorio de reunión",
            SubjectTemplate: "Recordatorio: reunión «{{Title}}» el {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Recordatorio</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Su reunión se acerca</h2>
                <p>Hola {{RecipientName}},</p>
                <p>La reunión <strong>{{Title}}</strong> está prevista para el <strong>{{StartLocal}}</strong>. El botón abre la sala con un clic: el código (<strong>{{AccessCode}}</strong>) ya está en el enlace. Recuerde probar su micrófono y su cámara antes de unirse.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Unirse a la reunión</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{RecipientName}}, recordatorio: la reunión «{{Title}}» es el {{StartLocal}}. Código de la reunión: {{AccessCode}}. Unirse: {{JoinUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — Reunión cancelada",
            SubjectTemplate: "Cancelada: reunión «{{Title}}» del {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Reunión cancelada</h2>
                <p>La reunión <strong>{{Title}}</strong> prevista para el <strong>{{StartLocal}}</strong> ha sido cancelada por el organizador. El enlace de acceso ya no es válido.</p>
                <p>Si se fija una nueva fecha, recibirá una nueva invitación.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "La reunión «{{Title}}» prevista para el {{StartLocal}} ha sido cancelada.",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — Acta de reunión",
            SubjectTemplate: "Acta de la reunión «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">El acta está disponible</h2>
                <p>Hola {{RecipientName}},</p>
                <p>El acta de la reunión <strong>{{Title}}</strong> está disponible. Revísela e informe al organizador de cualquier corrección necesaria.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir el acta</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hola {{RecipientName}}, el acta de la reunión «{{Title}}» está disponible: {{MinutesUrl}}",
            Language: "es",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Willkommen",
            SubjectTemplate: "Willkommen {{FirstName}} bei TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">Willkommen {{FirstName}}!</h1>
                <p>Ihr TutorSphere-Konto ist bereit. Melden Sie sich an, um auf Ihren Bereich zuzugreifen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zu meinem Bereich</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Willkommen {{FirstName}} bei TutorSphere.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — Elternbereich bestätigen",
            SubjectTemplate: "Bestätigen Sie Ihren Elternbereich — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Aktivieren Sie Ihren Elternbereich</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Willkommen bei TutorSphere. Um den <strong>Elternbereich</strong> zu nutzen und den Lernweg Ihrer Kinder zu verfolgen, bestätigen Sie bitte zuerst Ihre <strong>E-Mail-Adresse</strong>. Ohne Bestätigung bleibt die Anmeldung gesperrt.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Elternbereich bestätigen</a></p>
                <p style="font-size:13px;color:#888;">Wenn Sie kein Konto erstellt haben, ignorieren Sie diese E-Mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bestätigen Sie Ihren TutorSphere-Elternbereich: {{ConfirmationUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — E-Mail-Bestätigung (Schule)",
            SubjectTemplate: "Bestätigen Sie Ihre E-Mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Bestätigen Sie Ihre E-Mail-Adresse</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Klicken Sie auf die Schaltfläche unten, um Ihr Schulkonto zu aktivieren.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">E-Mail bestätigen</a></p>
                <p style="font-size:13px;color:#888;">Wenn Sie kein Konto erstellt haben, ignorieren Sie diese E-Mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bestätigen Sie Ihre E-Mail: {{ConfirmationUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Unterrichtsbericht an Eltern",
            SubjectTemplate: "Unterrichtsbericht für {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Unterrichtsbericht</h2>
                <p>Hallo {{ParentFirstName}},</p>
                <p>Hier ist der Bericht der letzten Sitzung von <strong>{{StudentName}}</strong> mit <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Melden Sie sich an, um den vollständigen Bericht anzuzeigen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Bericht ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Unterrichtsbericht für {{StudentName}} mit {{TutorName}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — Schule erstellt (ausstehend)",
            SubjectTemplate: "Ihre Schule {{SchoolName}} wird geprüft — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Schule registriert</h2>
                <p>Hallo {{OwnerFirstName}},</p>
                <p>Ihre Schule <strong>{{SchoolName}}</strong> wurde registriert und wartet auf die Freigabe durch das TutorSphere-Team.</p>
                <p>Sie werden per E-Mail benachrichtigt, sobald eine Entscheidung vorliegt (in der Regel 1–2 Werktage).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Schule {{SchoolName}} registriert, Freigabe ausstehend.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — E-Mail-Bestätigung (Standard)",
            SubjectTemplate: "Bestätigen Sie Ihre E-Mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Bestätigen Sie Ihre E-Mail-Adresse</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Bitte bestätigen Sie Ihre E-Mail-Adresse, um die Kontoerstellung abzuschließen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">E-Mail bestätigen</a></p>
                <p style="font-size:13px;color:#888;">Wenn Sie kein Konto erstellt haben, ignorieren Sie diese E-Mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bestätigen Sie Ihre E-Mail: {{ConfirmationUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Passwort zurücksetzen",
            SubjectTemplate: "Setzen Sie Ihr Passwort zurück — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Passwort zurücksetzen</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Sie haben das Zurücksetzen Ihres TutorSphere-Passworts angefordert. Klicken Sie unten:</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Passwort zurücksetzen</a></p>
                <p style="font-size:13px;color:#888;">Dieser Link ist 24 Stunden gültig. Wenn Sie dies nicht angefordert haben, ignorieren Sie diese E-Mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Passwort zurücksetzen: {{ResetUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Passwort geändert",
            SubjectTemplate: "Ihr Passwort wurde geändert — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Passwort geändert</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr TutorSphere-Passwort wurde geändert.</p>
                <p>Wenn Sie diese Änderung nicht vorgenommen haben, kontaktieren Sie sofort den Support.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Anmelden</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr TutorSphere-Passwort wurde geändert.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Tutor-Testversion gestartet",
            SubjectTemplate: "Ihre TutorSphere-Testversion hat begonnen!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Ihre Testversion hat begonnen!</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Willkommen bei TutorSphere! Ihre kostenlose Testphase ist jetzt aktiv.</p>
                <p>Nutzen Sie alle Funktionen zur Verwaltung von Unterricht, Schülern und Zahlungen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zum Dashboard</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihre TutorSphere-Testversion hat begonnen.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Tutor-Zahlungsbeleg",
            SubjectTemplate: "Zahlungsbeleg — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Zahlungsbeleg</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Wir haben Ihre Zahlung für Ihr TutorSphere-Abonnement erhalten.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Betrag</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rechnung ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Zahlungsbeleg {{Amount}}. Rechnung: {{InvoiceUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Tutor-Verlängerungserinnerung",
            SubjectTemplate: "Ihr TutorSphere-Abonnement wird bald verlängert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Bevorstehende Verlängerung</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr TutorSphere-Abonnement wird am <strong>{{RenewalDate}}</strong> verlängert.</p>
                <p>Stellen Sie sicher, dass Ihre Zahlungsdaten aktuell sind.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abonnement verwalten</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Ihr TutorSphere-Abonnement wird am {{RenewalDate}} verlängert.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Tutor-Zahlung fehlgeschlagen",
            SubjectTemplate: "Zahlungsproblem — Ihr TutorSphere-Abonnement",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Zahlungsproblem</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Wir konnten Ihre Zahlung für das TutorSphere-Abonnement nicht verarbeiten.</p>
                <p>Bitte aktualisieren Sie Ihre Zahlungsdaten, um eine Unterbrechung zu vermeiden.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Daten aktualisieren</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihre TutorSphere-Zahlung ist fehlgeschlagen. Bitte aktualisieren Sie Ihre Daten.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Tutor-Abonnement gekündigt",
            SubjectTemplate: "Ihr TutorSphere-Abonnement wurde gekündigt",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Abonnement gekündigt</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr TutorSphere-Abonnement wurde gekündigt. Sie behalten den Zugang bis zum Ende des aktuellen Zeitraums.</p>
                <p>Wir hoffen, Sie bald wiederzusehen!</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zurück zu TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr TutorSphere-Abonnement wurde gekündigt.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Konto aktiviert",
            SubjectTemplate: "Ihr TutorSphere-Konto wurde aktiviert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Konto aktiviert</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr TutorSphere-Konto wurde <strong>aktiviert</strong>. Sie können sich jetzt normal anmelden.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Anmelden</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr TutorSphere-Konto wurde aktiviert.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Konto deaktiviert",
            SubjectTemplate: "Ihr TutorSphere-Konto wurde deaktiviert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Konto deaktiviert</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr TutorSphere-Konto wurde von der Administration deaktiviert.</p>
                <p><strong>Grund :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">Bei Fragen wenden Sie sich an den TutorSphere-Support.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr Konto wurde deaktiviert. Grund: {{Reason}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — Schule genehmigt",
            SubjectTemplate: "Glückwunsch! Ihre Schule {{SchoolName}} ist genehmigt",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Schule genehmigt!</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Gute Nachricht: Ihre Schule <strong>{{SchoolName}}</strong> wurde vom TutorSphere-Team <strong>genehmigt</strong>.</p>
                <p>Sie können sich jetzt anmelden und Unterricht sowie Schüler verwalten.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zum Schulbereich</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihre Schule {{SchoolName}} ist genehmigt. Anmeldung: {{LoginUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Unterricht geplant",
            SubjectTemplate: "Neuer Unterricht geplant — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Unterricht geplant</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Für Sie wurde ein neuer Unterricht geplant.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Fach</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Kalender ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Unterricht geplant — {{Subject}} mit {{TutorName}} am {{LessonDate}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Unterrichtserinnerung",
            SubjectTemplate: "Erinnerung: Ihr {{Subject}}-Unterricht ist morgen",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Unterrichtserinnerung</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Vergessen Sie Ihren Unterricht morgen nicht!</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Fach</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Details ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Erinnerung: {{Subject}}-Unterricht mit {{TutorName}} am {{LessonDate}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Unterricht abgesagt",
            SubjectTemplate: "Unterricht abgesagt — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Unterricht abgesagt</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Wir informieren Sie, dass der folgende Unterricht <strong>abgesagt</strong> wurde:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Fach</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Geplantes Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Kalender öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Unterricht abgesagt — {{Subject}} mit {{TutorName}} geplant am {{LessonDate}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — Ersatzlehrkraft vorgeschlagen",
            SubjectTemplate: "Ihre Zustimmung wird benötigt: Ersatz für {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Eine Ersatzlehrkraft wird vorgeschlagen</h2>
                <p>Hallo {{RecipientName}},</p>
                <p><strong>{{OriginalTeacherName}}</strong> kann die unten genannte Sitzung nicht halten. <strong>{{SubstituteTeacherName}}</strong> aus derselben Gruppe kann sie übernehmen: <strong>Ihre Zustimmung ist erforderlich</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sitzung</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Geplantes Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Schüler</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ursprüngliche Lehrkraft</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ersatzlehrkraft</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>Ohne Ihre Antwort vor dem geplanten Termin bleibt die Sitzung bei der ursprünglichen Lehrkraft und kann verschoben werden.</p>
                <p><strong>Grund der Abwesenheit :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Annehmen oder ablehnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} ist am {{LessonDate}} für {{LessonTitle}} nicht verfügbar. Vorgeschlagener Ersatz: {{SubstituteTeacherName}}. Ihre Zustimmung: {{ActionUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — Vertretungsanfrage",
            SubjectTemplate: "Vertretung vorgeschlagen: {{LessonCount}} Sitzung(en) von {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Sie werden als Vertretung vorgeschlagen</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Die Gruppe schlägt vor, dass Sie die Sitzungen von <strong>{{OriginalTeacherName}}</strong> übernehmen, der/die nicht verfügbar ist. Jede Familie muss zustimmen; angenommene Sitzungen erscheinen danach in Ihrem Kalender.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Erste Sitzung</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Vertretene Lehrkraft</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Betroffene Sitzungen</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>Grund der Abwesenheit :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Kalender ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Vertretung vorgeschlagen: {{LessonCount}} Sitzung(en) von {{OriginalTeacherName}}, ab {{LessonDate}}. Kalender: {{ActionUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — Vertretung angenommen",
            SubjectTemplate: "Vertretung angenommen — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Vertretung angenommen</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Die Familie hat die Vertretung <strong>angenommen</strong>: <strong>{{SubstituteTeacherName}}</strong> hält die Sitzung anstelle von <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sitzung</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Geplantes Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ursprüngliche Lehrkraft</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ersatzlehrkraft</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Kalender ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Vertretung angenommen: {{SubstituteTeacherName}} hält {{LessonTitle}} am {{LessonDate}} anstelle von {{OriginalTeacherName}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — Vertretung abgelehnt",
            SubjectTemplate: "Vertretung abgelehnt — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Vertretung abgelehnt</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Die Familie hat die Vertretung <strong>abgelehnt</strong>: Die Sitzung bleibt bei <strong>{{OriginalTeacherName}}</strong>. Wird die Abwesenheit bestätigt, muss die Sitzung verlegt oder abgesagt werden.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sitzung</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Geplantes Datum</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Vorgeschlagene Vertretung</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Kalender ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Vertretung abgelehnt: {{LessonTitle}} am {{LessonDate}} bleibt bei {{OriginalTeacherName}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Eltern-Zahlungsbeleg",
            SubjectTemplate: "Zahlungsbeleg für {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Zahlungsbeleg</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Wir haben Ihre Zahlung für den Unterricht von <strong>{{StudentName}}</strong> erhalten.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Schüler/in</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Betrag</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rechnung ansehen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Zahlungsbeleg für {{StudentName}} — {{Amount}}. Rechnung: {{InvoiceUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — Eltern-Erstattung",
            SubjectTemplate: "Erstattung für {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Zahlung erstattet</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Das Lehrerprofil <strong>{{TutorName}}</strong> wurde entfernt. Geplante Unterrichtsstunden sind abgesagt. Ihre Zahlung für <strong>{{StudentName}}</strong> wurde <strong>erstattet</strong> — Sie müssen nichts tun.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Schüler/in</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Erstatteter Betrag</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Konto öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Erstattung {{Amount}} für {{StudentName}} (Lehrkraft {{TutorName}}). Geplante Stunden abgesagt.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Eltern-Zahlung fehlgeschlagen",
            SubjectTemplate: "Zahlungsproblem — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Zahlungsproblem</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Wir konnten Ihre Zahlung für den Unterricht Ihres Kindes nicht verarbeiten.</p>
                <p>Bitte aktualisieren Sie Ihre Zahlungsdaten, um den Zugang zum Unterricht zu behalten.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Daten aktualisieren</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{ParentName}}, Ihre TutorSphere-Zahlung ist fehlgeschlagen. Bitte aktualisieren Sie Ihre Daten.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Rechnung verfügbar",
            SubjectTemplate: "Ihre TutorSphere-Rechnung ist verfügbar",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Rechnung verfügbar</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Ihre neue TutorSphere-Rechnung steht zum Download bereit.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rechnung herunterladen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{ParentName}}, Ihre TutorSphere-Rechnung ist verfügbar: {{InvoiceUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — Überfällige Zahlung",
            SubjectTemplate: "Erinnerung: ausstehende Zahlung für {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Überfällige Zahlung</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Die Zahlung für den Kurs <strong>{{CourseTitle}}</strong> von <strong>{{StudentName}}</strong> steht noch aus.</p>
                <p>Bitte begleichen Sie so bald wie möglich, um den Zugang zu den Sitzungen zu aktivieren oder zu behalten.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Jetzt bezahlen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Erinnerung: überfällige Zahlung für {{StudentName}} — {{CourseTitle}}. Zahlen: {{PayUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — Kursanmeldungsanfrage",
            SubjectTemplate: "Neue Anmeldungsanfrage — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Neue Anmeldungsanfrage</h2>
                <p>Hallo {{TutorName}},</p>
                <p><strong>{{StudentName}}</strong> möchte sich für den Kurs <strong>{{CourseTitle}}</strong> anmelden.</p>
                <p>Melden Sie sich an, um die Anfrage anzunehmen oder abzulehnen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Anmeldungen verwalten</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Anmeldungsanfrage von {{StudentName}} für {{CourseTitle}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — Kursanmeldung angenommen",
            SubjectTemplate: "Anmeldung angenommen — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Anmeldung angenommen</h2>
                <p>Hallo {{ParentName}},</p>
                <p>Die Anmeldung von <strong>{{StudentName}}</strong> für den Kurs <strong>{{CourseTitle}}</strong> wurde angenommen.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Weiter</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Anmeldung von {{StudentName}} für {{CourseTitle}} angenommen. {{StatusNote}} {{ActionUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — Zahlung eingegangen (Schülerkurs)",
            SubjectTemplate: "Zahlung eingegangen — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Zahlung eingegangen</h2>
                <p>Hallo {{TutorName}},</p>
                <p>Eine Zahlung für <strong>{{StudentName}}</strong> — Kurs <strong>{{CourseTitle}}</strong> ist eingegangen.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Betrag</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Meinen Bereich öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Zahlung eingegangen: {{Amount}} für {{StudentName}} — {{CourseTitle}}.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — Lehrer ausstehend (Experte)",
            SubjectTemplate: "Neuer Lehrerantrag zur Prüfung — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Lehrerantrag zur Prüfung</h2>
                <p>Hallo {{ExpertFirstName}},</p>
                <p>Eine Schule hat ein Lehrerkonto zur Validierung eingereicht.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Schule</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Land</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>Melden Sie sich an, um die Unterlagen zu prüfen und den Antrag anzunehmen oder abzulehnen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Antrag prüfen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{ExpertFirstName}}, Lehrerantrag zur Prüfung — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — Experten-Einladung",
            SubjectTemplate: "Willkommen {{FirstName}} — Expertenzugang {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Ihr Zugang zum Expertenbereich</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Sie wurden eingeladen, der Expertengruppe <strong>{{GroupName}}</strong> auf TutorSphere beizutreten. Hier sind Ihre Anmeldedaten:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Expertengruppe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Anmelde-E-Mail</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Temporäres Passwort</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Experten-Anmeldeseite</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Aus Sicherheitsgründen <strong>ändern Sie dieses Passwort</strong> bei der ersten Anmeldung im Expertenbereich.</p>
                <p>Schritte: 1) Öffnen Sie die Experten-Anmeldeseite unten 2) Geben Sie E-Mail und temporäres Passwort ein 3) Wählen Sie ein neues Passwort.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zum Expertenbereich anmelden</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">Experten-Anmeldeseite</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Melden Sie sich nur im Expertenbereich an:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(kanonisch: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">GISEBS-Ökosystem — unsere Produkte</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Diese E-Mail wurde von TutorSphere (GISEBS) gesendet. Bitte nicht direkt antworten.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Experten-Einladung {{GroupName}}. E-Mail: {{Email}}. Temporäres Passwort: {{TemporaryPassword}}. Ändern Sie dieses Passwort bei der ersten Anmeldung. Experten-Login: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — Zur Expertengruppe hinzugefügt",
            SubjectTemplate: "{{FirstName}}, Sie wurden zu {{GroupName}} hinzugefügt",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Zu einer Expertengruppe hinzugefügt</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Sie wurden der Expertengruppe <strong>{{GroupName}}</strong> auf TutorSphere hinzugefügt. Melden Sie sich mit Ihren bestehenden Zugangsdaten an.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Expertengruppe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Konto</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zum Expertenbereich anmelden</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Sie wurden der Gruppe {{GroupName}} hinzugefügt (Konto {{Email}}). Anmeldung: {{LoginUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — Lehrer genehmigt (Experte)",
            SubjectTemplate: "Gute Nachricht: Ihr Lehrerprofil wurde genehmigt",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Lehrerprofil genehmigt</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Ihr Antrag für <strong>{{SchoolName}}</strong> wurde von der Expertengruppe <strong>{{GroupName}}</strong> <strong>genehmigt</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Schule / Profil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Expertengruppe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Kommentar</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Melden Sie sich in Ihrem Lehrerbereich an, um auf TutorSphere fortzufahren.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Zum Lehrerbereich</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr Profil {{SchoolName}} wurde von {{GroupName}} genehmigt. Kommentar: {{Notes}}. Anmeldung: {{LoginUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — Lehrer abgelehnt (Experte)",
            SubjectTemplate: "Entscheidung zu Ihrem Lehrerantrag — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Lehrerantrag nicht genehmigt</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Nach Prüfung wurde Ihr Antrag für <strong>{{SchoolName}}</strong> von der Expertengruppe <strong>{{GroupName}}</strong> nicht genehmigt.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Schule / Profil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Expertengruppe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Grund / Kommentar</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Sie können Ihre Unterlagen (Dokumente, Abschlüsse, Präsentation) aktualisieren und bei Bedarf erneut beantragen.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Lehrerbereich öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihr Antrag {{SchoolName}} wurde von {{GroupName}} nicht genehmigt. Grund: {{Notes}}. Anmeldung: {{LoginUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — Einladung Lehrerbewerbung",
            SubjectTemplate: "{{ExpertName}} lädt Sie ein, Ihre Lehrerbewerbung einzureichen",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Einladung zur Bewerbung</h2>
                <p>Hallo {{FirstName}},</p>
                <p><strong>{{ExpertName}}</strong> (Expertengruppe <strong>{{GroupName}}</strong>) lädt Sie ein, Ihre Lehrerbewerbung auf TutorSphere zur Prüfung einzureichen.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>Erstellen Sie Ihr Konto und reichen Sie Ihre Unterlagen über den Link unten ein. URL: {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Bewerbung einreichen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, {{ExpertName}} ({{GroupName}}) lädt Sie zur Bewerbung ein. {{PersonalMessage}} Link: {{ApplyUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — Einladung Expertenmitglied",
            SubjectTemplate: "{{InviterName}} lädt Sie zu {{GroupName}} ein — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Expertenbereich</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">Treten Sie der Gruppe {{GroupName}} bei</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Der Gruppenleiter <strong>{{InviterName}}</strong> lädt Sie ein, <strong>Experte</strong> der Gruppe <strong>{{GroupName}}</strong> auf TutorSphere zu werden.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Gruppe</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Gruppenleiter</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Vorgeschlagene Rolle</td><td style="padding:10px 14px;font-weight:600;">Experte</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Gültigkeit</td><td style="padding:10px 14px;font-weight:600;">30 Tage</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Nachricht</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>Nächste Schritte</strong><br/>1. Öffnen Sie den sicheren Link unten.<br/>2. Nehmen Sie die Einladung an oder lehnen Sie sie ab.<br/>3. Je nach Gruppe kann die Aufnahme danach von den Mitgliedern abgestimmt werden.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Auf die Einladung antworten</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, der Gruppenleiter {{InviterName}} lädt Sie in die Expertengruppe {{GroupName}} auf TutorSphere ein. {{PersonalMessage}} Antworten: {{JoinUrl}} (30 Tage gültig).",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — Expertenaufnahme-Abstimmung",
            SubjectTemplate: "Abstimmung offen: Bewerbung von {{CandidateName}} — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Eine Aufnahmeabstimmung ist geöffnet</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Die Bewerbung von <strong>{{CandidateName}}</strong> für <strong>{{GroupName}}</strong> steht zur Abstimmung der Mitglieder.</p>
                <p>Bitte stimmen Sie möglichst bald ab. Die Aufnahme erfordert die Zustimmung von mindestens 75&nbsp;% der anderen aktiven Mitglieder.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Aufnahmen öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Abstimmung offen für {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — Expertenbewerbung nicht angenommen",
            SubjectTemplate: "Ihre Expertenbewerbung wurde nicht angenommen — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Bewerbung nicht angenommen</h2>
                <p>Hallo {{FirstName}},</p>
                <p>Nach Prüfung wurde Ihre Bewerbung für eine TutorSphere-Expertengruppe nicht angenommen.</p>
                <p><strong>Grund :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{FirstName}}, Ihre Expertenbewerbung wurde nicht angenommen. Grund: {{Reason}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — Besprechungseinladung (Mitglied)",
            SubjectTemplate: "Besprechung „{{Title}}“ — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Gruppenbesprechung</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Einladung zu einer Gruppenbesprechung</h2>
                <p>Hallo {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> lädt Sie zu einer Arbeitsbesprechung auf TutorSphere ein.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Thema</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Datum und Uhrzeit</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Besprechungscode</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organisator</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tagesordnung</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>Die Schaltfläche öffnet den Raum direkt in <strong>Ihrem Expertenbereich</strong>: Der Code ist bereits im Link enthalten, Sie müssen nichts eingeben (melden Sie sich nur bei Ihrem TutorSphere-Konto an, falls noch nicht geschehen). Private Gruppenbesprechung — bitte leiten Sie weder Link noch Code weiter.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">An der Besprechung teilnehmen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{RecipientName}}, {{OrganizerName}} lädt Sie zur Besprechung „{{Title}}“ am {{StartLocal}} ({{TimeZone}}) ein. Tagesordnung: {{Agenda}}. {{RecordingAndAi}} Der Link enthält den Besprechungscode ({{AccessCode}}) bereits: ein Klick öffnet den Raum. Teilnehmen: {{JoinUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — Besprechungseinladung (externer Gast)",
            SubjectTemplate: "Sie sind zur Besprechung „{{Title}}“ eingeladen — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Externer Gast</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Einladung zu einer Besprechung</h2>
                <p>Hallo {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> lädt Sie zu einer Online-Besprechung auf TutorSphere ein. <strong>Kein Konto erforderlich</strong>: Ihr persönlicher Zugangslink steht unten.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Thema</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Datum und Uhrzeit</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ihr Einladungscode</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organisator</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tagesordnung</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Link gültig bis</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>So nehmen Sie teil</strong><br/>1. Klicken Sie auf die Schaltfläche unten: Name und Code sind bereits im Link enthalten, die Besprechung öffnet sich direkt.<br/>2. Warten Sie im Warteraum: Der Organisator lässt Sie ein.<br/>Der Code oben dient nur als Reserve, falls der Link ohne Parameter geöffnet wird.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">An der Besprechung teilnehmen</a></p>
                <p style="font-size:13px;color:#888;">Dieser Link ist persönlich, zeitlich begrenzt und nicht übertragbar. Er gewährt nur Zugang zu dieser Besprechung, nicht zum übrigen TutorSphere. Falls Sie diese Einladung nicht erwartet haben, ignorieren Sie diese Nachricht.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{RecipientName}}, {{OrganizerName}} lädt Sie zur Besprechung „{{Title}}“ am {{StartLocal}} ({{TimeZone}}) ein. Tagesordnung: {{Agenda}}. {{RecordingAndAi}} Klicken Sie einfach auf Ihren persönlichen Link: Name und Code ({{AccessCode}}) sind bereits enthalten. Link gültig bis {{LinkValidity}}: {{JoinUrl}}. Bitte weder Link noch Code weiterleiten.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — Gast-Bestätigungscode",
            SubjectTemplate: "Ihr Zugangscode für die Besprechung „{{Title}}“",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Externer Gast</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Ihr Bestätigungscode</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Geben Sie diesen Code auf der Zugangsseite ein, um Ihre E-Mail-Adresse zu bestätigen und an der Besprechung <strong>{{Title}}</strong> teilzunehmen.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">Dieser Code gilt nur für diese Sitzung. Geben Sie ihn nicht weiter.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{RecipientName}}, Ihr Bestätigungscode für die Besprechung „{{Title}}“ lautet {{Code}}. Nicht weitergeben.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — Besprechungserinnerung",
            SubjectTemplate: "Erinnerung: Besprechung „{{Title}}“ am {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Erinnerung</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Ihre Besprechung steht bevor</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Die Besprechung <strong>{{Title}}</strong> ist für <strong>{{StartLocal}}</strong> geplant. Die Schaltfläche öffnet den Raum mit einem Klick: Der Code (<strong>{{AccessCode}}</strong>) ist bereits im Link enthalten. Testen Sie vorher Mikrofon und Kamera.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">An der Besprechung teilnehmen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{RecipientName}}, Erinnerung: Die Besprechung „{{Title}}“ findet am {{StartLocal}} statt. Besprechungscode: {{AccessCode}}. Teilnehmen: {{JoinUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — Besprechung abgesagt",
            SubjectTemplate: "Abgesagt: Besprechung „{{Title}}“ vom {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Besprechung abgesagt</h2>
                <p>Die für <strong>{{StartLocal}}</strong> geplante Besprechung <strong>{{Title}}</strong> wurde vom Organisator abgesagt. Der Zugangslink ist nicht mehr gültig.</p>
                <p>Wird ein neuer Termin festgelegt, erhalten Sie eine neue Einladung.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Die Besprechung „{{Title}}“ am {{StartLocal}} wurde abgesagt.",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — Besprechungsprotokoll",
            SubjectTemplate: "Protokoll der Besprechung „{{Title}}“",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Das Protokoll ist verfügbar</h2>
                <p>Hallo {{RecipientName}},</p>
                <p>Das Protokoll der Besprechung <strong>{{Title}}</strong> ist verfügbar. Bitte prüfen Sie es und melden Sie Korrekturen dem Organisator.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Protokoll öffnen</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Hallo {{RecipientName}}, das Protokoll der Besprechung „{{Title}}“ ist verfügbar: {{MinutesUrl}}",
            Language: "de",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — Boas-vindas",
            SubjectTemplate: "Bem-vindo(a) {{FirstName}} ao TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">Bem-vindo(a) {{FirstName}}!</h1>
                <p>A sua conta TutorSphere está pronta. Inicie sessão para aceder ao seu espaço pessoal.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Aceder ao meu espaço</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Bem-vindo(a) {{FirstName}} ao TutorSphere.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — Validação espaço responsável",
            SubjectTemplate: "Valide o seu espaço de responsável — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Ative o seu espaço de responsável</h2>
                <p>Olá {{FirstName}},</p>
                <p>Bem-vindo(a) ao TutorSphere. Para aceder ao <strong>espaço de responsável</strong> e acompanhar o percurso escolar dos seus filhos, <strong>valide primeiro o seu e-mail</strong>. Sem esta validação, o acesso permanece bloqueado.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Validar o meu espaço de responsável</a></p>
                <p style="font-size:13px;color:#888;">Se não criou uma conta, ignore este e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Valide o seu espaço de responsável TutorSphere: {{ConfirmationUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — Confirmação de e-mail (escola)",
            SubjectTemplate: "Confirme o seu e-mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirme o seu endereço de e-mail</h2>
                <p>Olá {{FirstName}},</p>
                <p>Clique no botão abaixo para ativar a sua conta de escola.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmar o meu e-mail</a></p>
                <p style="font-size:13px;color:#888;">Se não criou uma conta, ignore este e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirme o seu e-mail: {{ConfirmationUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — Relatório de aula ao responsável",
            SubjectTemplate: "Relatório de aula de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Relatório de aula</h2>
                <p>Olá {{ParentFirstName}},</p>
                <p>Segue o relatório da última sessão de <strong>{{StudentName}}</strong> com <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Inicie sessão no seu espaço para ver o relatório completo.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver relatório</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Relatório de aula de {{StudentName}} com {{TutorName}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — Escola criada (pendente)",
            SubjectTemplate: "A sua escola {{SchoolName}} está em análise — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Escola registada</h2>
                <p>Olá {{OwnerFirstName}},</p>
                <p>A sua escola <strong>{{SchoolName}}</strong> foi registada e aguarda aprovação da equipa TutorSphere.</p>
                <p>Será notificado por e-mail assim que houver uma decisão (prazo habitual: 1 a 2 dias úteis).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Escola {{SchoolName}} registada, aguarda aprovação.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — Confirmação de e-mail (padrão)",
            SubjectTemplate: "Confirme o seu e-mail — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Confirme o seu endereço de e-mail</h2>
                <p>Olá {{FirstName}},</p>
                <p>Confirme o seu e-mail para concluir a criação da sua conta.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Confirmar o meu e-mail</a></p>
                <p style="font-size:13px;color:#888;">Se não criou uma conta, ignore este e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Confirme o seu e-mail: {{ConfirmationUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — Redefinição de palavra-passe",
            SubjectTemplate: "Redefina a sua palavra-passe — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Redefinição de palavra-passe</h2>
                <p>Olá {{FirstName}},</p>
                <p>Pediu para redefinir a sua palavra-passe TutorSphere. Clique abaixo:</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Redefinir a minha palavra-passe</a></p>
                <p style="font-size:13px;color:#888;">Este link é válido por 24 horas. Se não fez este pedido, ignore este e-mail.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Redefina a sua palavra-passe: {{ResetUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — Palavra-passe alterada",
            SubjectTemplate: "A sua palavra-passe foi alterada — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Palavra-passe alterada</h2>
                <p>Olá {{FirstName}},</p>
                <p>A sua palavra-passe TutorSphere foi alterada.</p>
                <p>Se não fez esta alteração, contacte o suporte imediatamente.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sessão</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua palavra-passe TutorSphere foi alterada.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — Avaliação gratuita do tutor iniciada",
            SubjectTemplate: "A sua avaliação gratuita TutorSphere começou!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">A sua avaliação gratuita começou!</h2>
                <p>Olá {{FirstName}},</p>
                <p>Bem-vindo(a) ao TutorSphere! O seu período de avaliação gratuita está ativo.</p>
                <p>Aproveite todas as funcionalidades para gerir aulas, alunos e pagamentos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir ao meu painel</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua avaliação gratuita TutorSphere começou.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — Recibo de pagamento do tutor",
            SubjectTemplate: "Recibo de pagamento — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Recibo de pagamento</h2>
                <p>Olá {{FirstName}},</p>
                <p>Recebemos o seu pagamento da subscrição TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Montante</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver a minha fatura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recibo de pagamento {{Amount}}. Fatura: {{InvoiceUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — Lembrete de renovação do tutor",
            SubjectTemplate: "A sua subscrição TutorSphere renova em breve",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Renovação próxima</h2>
                <p>Olá {{FirstName}},</p>
                <p>A sua subscrição TutorSphere será renovada em <strong>{{RenewalDate}}</strong>.</p>
                <p>Certifique-se de que os seus dados de pagamento estão atualizados.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gerir a minha subscrição</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "A sua subscrição TutorSphere renova em {{RenewalDate}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — Falha no pagamento do tutor",
            SubjectTemplate: "Problema de pagamento — a sua subscrição TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problema de pagamento</h2>
                <p>Olá {{FirstName}},</p>
                <p>Não foi possível processar o pagamento da sua subscrição TutorSphere.</p>
                <p>Atualize os seus dados de pagamento para evitar a interrupção do serviço.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Atualizar os meus dados</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, o pagamento TutorSphere falhou. Atualize os seus dados.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — Subscrição do tutor cancelada",
            SubjectTemplate: "A sua subscrição TutorSphere foi cancelada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Subscrição cancelada</h2>
                <p>Olá {{FirstName}},</p>
                <p>A sua subscrição TutorSphere foi cancelada. Mantém o acesso até ao fim do período atual.</p>
                <p>Esperamos vê-lo(a) em breve!</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Voltar ao TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua subscrição TutorSphere foi cancelada.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — Conta ativada",
            SubjectTemplate: "A sua conta TutorSphere foi ativada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Conta ativada</h2>
                <p>Olá {{FirstName}},</p>
                <p>A sua conta TutorSphere foi <strong>ativada</strong>. Já pode iniciar sessão normalmente.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sessão</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua conta TutorSphere foi ativada.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — Conta desativada",
            SubjectTemplate: "A sua conta TutorSphere foi desativada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Conta desativada</h2>
                <p>Olá {{FirstName}},</p>
                <p>A sua conta TutorSphere foi desativada pela administração.</p>
                <p><strong>Motivo :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">Para qualquer questão, contacte o suporte TutorSphere.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua conta foi desativada. Motivo: {{Reason}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — Escola aprovada",
            SubjectTemplate: "Parabéns! A sua escola {{SchoolName}} foi aprovada",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Escola aprovada!</h2>
                <p>Olá {{FirstName}},</p>
                <p>Boas notícias: a sua escola <strong>{{SchoolName}}</strong> foi <strong>aprovada</strong> pela equipa TutorSphere.</p>
                <p>Já pode iniciar sessão e gerir as suas aulas e alunos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Aceder ao espaço da escola</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua escola {{SchoolName}} foi aprovada. Acesso: {{LoginUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — Aula agendada",
            SubjectTemplate: "Nova aula agendada — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Aula agendada</h2>
                <p>Olá {{RecipientName}},</p>
                <p>Foi agendada uma nova aula para si.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Disciplina</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver o meu calendário</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Aula agendada — {{Subject}} com {{TutorName}} em {{LessonDate}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — Lembrete de aula",
            SubjectTemplate: "Lembrete: a sua aula de {{Subject}} é amanhã",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Lembrete de aula</h2>
                <p>Olá {{RecipientName}},</p>
                <p>Não se esqueça da sua aula de amanhã!</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Disciplina</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver detalhes</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Lembrete: aula de {{Subject}} com {{TutorName}} em {{LessonDate}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — Aula cancelada",
            SubjectTemplate: "Aula cancelada — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Aula cancelada</h2>
                <p>Olá {{RecipientName}},</p>
                <p>Informamos que a seguinte aula foi <strong>cancelada</strong>:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Disciplina</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Tutor</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Consultar o meu calendário</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Aula cancelada — {{Subject}} com {{TutorName}} prevista para {{LessonDate}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — Substituto proposto",
            SubjectTemplate: "É necessária a sua aprovação: substituto para {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Foi proposto um substituto</h2>
                <p>Olá {{RecipientName}},</p>
                <p><strong>{{OriginalTeacherName}}</strong> não poderá dar a sessão abaixo. <strong>{{SubstituteTeacherName}}</strong>, professor do mesmo grupo, pode assumi-la: <strong>é necessária a sua aprovação</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sessão</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Aluno</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Professor titular</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Substituto</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>Sem a sua resposta antes da hora prevista, a sessão mantém-se com o professor titular e poderá ser adiada.</p>
                <p><strong>Motivo da ausência :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Aceitar ou recusar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} não está disponível para {{LessonTitle}} em {{LessonDate}}. Substituto proposto: {{SubstituteTeacherName}}. A sua aprovação: {{ActionUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — Proposta de substituição",
            SubjectTemplate: "Substituição proposta: {{LessonCount}} sessão(ões) de {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Foi proposto como substituto</h2>
                <p>Olá {{RecipientName}},</p>
                <p>O grupo propõe que assuma as sessões de <strong>{{OriginalTeacherName}}</strong>, que está indisponível. Cada família deve concordar; as sessões aceites passam a constar no seu calendário.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Primeira sessão</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Professor substituído</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Sessões envolvidas</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>Motivo da ausência :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver o meu calendário</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substituição proposta: {{LessonCount}} sessão(ões) de {{OriginalTeacherName}}, a partir de {{LessonDate}}. Calendário: {{ActionUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — Substituição aceite",
            SubjectTemplate: "Substituição aceite — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Substituição aceite</h2>
                <p>Olá {{RecipientName}},</p>
                <p>A família <strong>aceitou</strong> a substituição: <strong>{{SubstituteTeacherName}}</strong> dará a sessão em vez de <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sessão</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Professor titular</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Substituto</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver o meu calendário</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substituição aceite: {{SubstituteTeacherName}} dará {{LessonTitle}} em {{LessonDate}} em vez de {{OriginalTeacherName}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — Substituição recusada",
            SubjectTemplate: "Substituição recusada — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Substituição recusada</h2>
                <p>Olá {{RecipientName}},</p>
                <p>A família <strong>recusou</strong> a substituição: a sessão mantém-se com <strong>{{OriginalTeacherName}}</strong>. Se a ausência se confirmar, a sessão terá de ser reagendada ou cancelada.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Sessão</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data prevista</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Substituto proposto</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver o meu calendário</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Substituição recusada: {{LessonTitle}} de {{LessonDate}} mantém-se com {{OriginalTeacherName}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — Recibo de pagamento do responsável",
            SubjectTemplate: "Recibo de pagamento de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Recibo de pagamento</h2>
                <p>Olá {{ParentName}},</p>
                <p>Recebemos o seu pagamento pelas aulas de <strong>{{StudentName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Aluno/a</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Montante</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver a minha fatura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Recibo de pagamento de {{StudentName}} — {{Amount}}. Fatura: {{InvoiceUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — Reembolso ao responsável",
            SubjectTemplate: "Reembolso de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Pagamento reembolsado</h2>
                <p>Olá {{ParentName}},</p>
                <p>O perfil do professor <strong>{{TutorName}}</strong> foi removido. As aulas programadas foram canceladas. O seu pagamento para <strong>{{StudentName}}</strong> foi <strong>reembolsado</strong> — não é necessária qualquer ação.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Aluno/a</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">Montante reembolsado</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir o meu espaço</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Reembolso {{Amount}} de {{StudentName}} (professor {{TutorName}}). Aulas programadas canceladas.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — Falha no pagamento do responsável",
            SubjectTemplate: "Problema de pagamento — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Problema de pagamento</h2>
                <p>Olá {{ParentName}},</p>
                <p>Não foi possível processar o pagamento das aulas do seu filho/a.</p>
                <p>Atualize os seus dados de pagamento para manter o acesso às aulas.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Atualizar os meus dados</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{ParentName}}, o pagamento TutorSphere falhou. Atualize os seus dados.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — Fatura disponível",
            SubjectTemplate: "A sua fatura TutorSphere está disponível",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Fatura disponível</h2>
                <p>Olá {{ParentName}},</p>
                <p>A sua nova fatura TutorSphere está disponível para descarregar.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Descarregar a minha fatura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{ParentName}}, a sua fatura TutorSphere está disponível: {{InvoiceUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — Pagamento em atraso",
            SubjectTemplate: "Lembrete: pagamento pendente de {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Pagamento em atraso</h2>
                <p>Olá {{ParentName}},</p>
                <p>O pagamento do curso <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> ainda está pendente.</p>
                <p>Regularize o mais cedo possível para ativar ou manter o acesso às sessões.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Pagar agora</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Lembrete: pagamento em atraso de {{StudentName}} — {{CourseTitle}}. Pagar: {{PayUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — Pedido de inscrição num curso",
            SubjectTemplate: "Novo pedido de inscrição — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Novo pedido de inscrição</h2>
                <p>Olá {{TutorName}},</p>
                <p><strong>{{StudentName}}</strong> deseja inscrever-se no curso <strong>{{CourseTitle}}</strong>.</p>
                <p>Inicie sessão para aceitar ou recusar o pedido.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Gerir inscrições</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Pedido de inscrição de {{StudentName}} no curso {{CourseTitle}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — Inscrição no curso aceite",
            SubjectTemplate: "Inscrição aceite — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Inscrição aceite</h2>
                <p>Olá {{ParentName}},</p>
                <p>A inscrição de <strong>{{StudentName}}</strong> no curso <strong>{{CourseTitle}}</strong> foi aceite.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Continuar</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Inscrição de {{StudentName}} em {{CourseTitle}} aceite. {{StatusNote}} {{ActionUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — Pagamento recebido (curso do aluno)",
            SubjectTemplate: "Pagamento recebido — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Pagamento recebido</h2>
                <p>Olá {{TutorName}},</p>
                <p>Foi recebido um pagamento por <strong>{{StudentName}}</strong> — curso <strong>{{CourseTitle}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">Montante</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ver o meu espaço</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Pagamento recebido: {{Amount}} por {{StudentName}} — {{CourseTitle}}.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — Professor pendente (especialista)",
            SubjectTemplate: "Novo pedido de professor para rever — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Pedido de professor para rever</h2>
                <p>Olá {{ExpertFirstName}},</p>
                <p>Uma escola submeteu uma conta de professor pendente de validação.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escola</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">País</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>Inicie sessão para rever o processo e aprovar ou recusar o pedido.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Rever pedido</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{ExpertFirstName}}, pedido de professor para rever — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — Convite especialista",
            SubjectTemplate: "Bem-vindo(a) {{FirstName}} — acesso especialista {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">O seu acesso ao espaço de especialista</h2>
                <p>Olá {{FirstName}},</p>
                <p>Foi convidado(a) a juntar-se ao grupo de especialistas <strong>{{GroupName}}</strong> no TutorSphere. Eis as suas credenciais de acesso:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de especialistas</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">E-mail de acesso</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Palavra-passe temporária</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Página de acesso especialista</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">Por segurança, <strong>altere esta palavra-passe</strong> no primeiro acesso ao espaço de especialista.</p>
                <p>Passos: 1) Abra a página de acesso especialista abaixo 2) Introduza o e-mail e a palavra-passe temporária 3) Escolha uma nova palavra-passe.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sessão no espaço de especialista</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">Página de acesso especialista</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Inicie sessão apenas no espaço de especialista:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canónico: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Ecossistema GISEBS — os nossos produtos</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Este e-mail foi enviado pelo TutorSphere (GISEBS). Não responda diretamente.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, convite especialista {{GroupName}}. E-mail: {{Email}}. Palavra-passe temporária: {{TemporaryPassword}}. Altere esta palavra-passe no primeiro acesso. Acesso especialista: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — Adicionado ao grupo de especialistas",
            SubjectTemplate: "{{FirstName}}, foi adicionado(a) a {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Adicionado a um grupo de especialistas</h2>
                <p>Olá {{FirstName}},</p>
                <p>Foi adicionado(a) ao grupo de especialistas <strong>{{GroupName}}</strong> no TutorSphere. Utilize as suas credenciais existentes para iniciar sessão.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de especialistas</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Conta</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Iniciar sessão no espaço de especialista</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, foi adicionado(a) ao grupo {{GroupName}} (conta {{Email}}). Acesso: {{LoginUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — Professor aprovado (especialista)",
            SubjectTemplate: "Boa notícia: o seu perfil de professor foi aprovado",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">Perfil de professor aprovado</h2>
                <p>Olá {{FirstName}},</p>
                <p>O seu pedido para <strong>{{SchoolName}}</strong> foi <strong>aprovado</strong> pelo grupo de especialistas <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escola / perfil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de especialistas</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Comentário</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Pode iniciar sessão no seu espaço de professor para continuar no TutorSphere.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Ir para o meu espaço de professor</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, o seu perfil {{SchoolName}} foi aprovado por {{GroupName}}. Comentário: {{Notes}}. Acesso: {{LoginUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — Professor recusado (especialista)",
            SubjectTemplate: "Decisão sobre o seu pedido de professor — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Pedido de professor não aprovado</h2>
                <p>Olá {{FirstName}},</p>
                <p>Após análise, o seu pedido para <strong>{{SchoolName}}</strong> não foi aprovado pelo grupo de especialistas <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Escola / perfil</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Grupo de especialistas</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Motivo / comentário</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>Pode atualizar o seu processo (documentos, diplomas, apresentação) e voltar a submeter um pedido se necessário.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir o meu espaço de professor</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, o seu pedido {{SchoolName}} não foi aprovado por {{GroupName}}. Motivo: {{Notes}}. Acesso: {{LoginUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — Convite candidatura professor",
            SubjectTemplate: "{{ExpertName}} convida-o a submeter a sua candidatura de professor",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Convite para candidatar-se</h2>
                <p>Olá {{FirstName}},</p>
                <p><strong>{{ExpertName}}</strong> (grupo de especialistas <strong>{{GroupName}}</strong>) convida-o a submeter a sua candidatura de professor no TutorSphere para análise.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>Crie a sua conta e submeta o seu processo através do link abaixo. URL: {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Submeter a minha candidatura</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, {{ExpertName}} ({{GroupName}}) convida-o a candidatar-se. {{PersonalMessage}} Link: {{ApplyUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — Convite membro especialista",
            SubjectTemplate: "{{InviterName}} convida-o para {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Espaço especialista</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">Junte-se ao grupo {{GroupName}}</h2>
                <p>Olá {{FirstName}},</p>
                <p>O responsável <strong>{{InviterName}}</strong> convida-o a tornar-se <strong>especialista</strong> do grupo <strong>{{GroupName}}</strong> no TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Grupo</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Responsável</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Função proposta</td><td style="padding:10px 14px;font-weight:600;">Especialista</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Validade</td><td style="padding:10px 14px;font-weight:600;">30 dias</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Mensagem</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>Próximos passos</strong><br/>1. Abra o link seguro abaixo.<br/>2. Aceite ou recuse o convite.<br/>3. Consoante o grupo, a sua admissão pode depois ser submetida a votação.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Responder ao convite</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, o responsável {{InviterName}} convida-o a juntar-se ao grupo {{GroupName}} no TutorSphere. {{PersonalMessage}} Responder: {{JoinUrl}} (válido 30 dias).",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — Votação de admissão especialista",
            SubjectTemplate: "Votação aberta: candidatura de {{CandidateName}} — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Uma votação de admissão está aberta</h2>
                <p>Olá {{FirstName}},</p>
                <p>A candidatura de <strong>{{CandidateName}}</strong> para juntar-se a <strong>{{GroupName}}</strong> está aberta à votação dos membros.</p>
                <p>Vote o mais cedo possível. A admissão exige a aprovação de pelo menos 75&nbsp;% dos outros membros ativos.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir admissões</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, votação aberta para {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — Candidatura de especialista não retida",
            SubjectTemplate: "A sua candidatura de especialista não foi retida — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Candidatura não retida</h2>
                <p>Olá {{FirstName}},</p>
                <p>Após análise, a sua candidatura para juntar-se a um grupo de especialistas TutorSphere não foi retida.</p>
                <p><strong>Motivo :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{FirstName}}, a sua candidatura de especialista não foi retida. Motivo: {{Reason}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — Convite para reunião (membro)",
            SubjectTemplate: "Reunião «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Reunião do grupo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">Convite para uma reunião do grupo</h2>
                <p>Olá {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> convida-o para uma reunião de trabalho no TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Assunto</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data e hora</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Código da reunião</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizador</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ordem de trabalhos</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>O botão abre diretamente a sala no <strong>seu espaço de especialista</strong>: o código já está incluído no link, não precisa de escrever nada (basta iniciar sessão na sua conta TutorSphere, se ainda não o fez). Reunião privada do grupo — não reencaminhe este link nem este código.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Entrar na reunião</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{RecipientName}}, {{OrganizerName}} convida-o para a reunião «{{Title}}» em {{StartLocal}} ({{TimeZone}}). Ordem de trabalhos: {{Agenda}}. {{RecordingAndAi}} O link já inclui o código da reunião ({{AccessCode}}): um único clique abre a sala. Entrar: {{JoinUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — Convite para reunião (convidado externo)",
            SubjectTemplate: "Está convidado(a) para a reunião «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Convidado externo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">Convite para uma reunião</h2>
                <p>Olá {{RecipientName}},</p>
                <p><strong>{{OrganizerName}}</strong> convida-o a participar numa reunião online no TutorSphere. <strong>Não é necessária qualquer conta</strong>: o seu link de acesso pessoal está abaixo.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">Assunto</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Data e hora</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">O seu código de convite</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Organizador</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Ordem de trabalhos</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">Link válido até</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>Como entrar</strong><br/>1. Clique no botão abaixo: o seu nome e o seu código já estão no link, a reunião abre diretamente.<br/>2. Aguarde na sala de espera: o organizador irá admiti-lo.<br/>O código acima serve apenas de reserva, caso o link seja aberto sem os parâmetros.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Entrar na reunião</a></p>
                <p style="font-size:13px;color:#888;">Este link é pessoal, temporário e não transferível. Dá acesso apenas a esta reunião, não ao resto do TutorSphere. Se não esperava este convite, ignore esta mensagem.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{RecipientName}}, {{OrganizerName}} convida-o para a reunião «{{Title}}» em {{StartLocal}} ({{TimeZone}}). Ordem de trabalhos: {{Agenda}}. {{RecordingAndAi}} Basta clicar no seu link pessoal: o seu nome e o seu código ({{AccessCode}}) já estão incluídos. Link válido até {{LinkValidity}}: {{JoinUrl}}. Não reencaminhe este link nem este código.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — Código de verificação de convidado",
            SubjectTemplate: "O seu código de acesso à reunião «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Convidado externo</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">O seu código de verificação</h2>
                <p>Olá {{RecipientName}},</p>
                <p>Introduza este código na página de acesso para confirmar o seu e-mail e entrar na reunião <strong>{{Title}}</strong>.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">Este código é válido apenas para esta sessão. Não o partilhe com ninguém.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{RecipientName}}, o seu código de verificação para a reunião «{{Title}}» é {{Code}}. Não o partilhe.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — Lembrete de reunião",
            SubjectTemplate: "Lembrete: reunião «{{Title}}» em {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">Lembrete</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">A sua reunião aproxima-se</h2>
                <p>Olá {{RecipientName}},</p>
                <p>A reunião <strong>{{Title}}</strong> está prevista para <strong>{{StartLocal}}</strong>. O botão abre a sala com um clique: o código (<strong>{{AccessCode}}</strong>) já está no link. Não se esqueça de testar o microfone e a câmara antes de entrar.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Entrar na reunião</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{RecipientName}}, lembrete: a reunião «{{Title}}» é em {{StartLocal}}. Código da reunião: {{AccessCode}}. Entrar: {{JoinUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — Reunião cancelada",
            SubjectTemplate: "Cancelada: reunião «{{Title}}» de {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">Reunião cancelada</h2>
                <p>A reunião <strong>{{Title}}</strong> prevista para <strong>{{StartLocal}}</strong> foi cancelada pelo organizador. O link de acesso já não é válido.</p>
                <p>Se for definida uma nova data, receberá um novo convite.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "A reunião «{{Title}}» prevista para {{StartLocal}} foi cancelada.",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — Ata da reunião",
            SubjectTemplate: "Ata da reunião «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">A ata está disponível</h2>
                <p>Olá {{RecipientName}},</p>
                <p>A ata da reunião <strong>{{Title}}</strong> está disponível. Reveja-a e comunique ao organizador qualquer correção necessária.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">Abrir a ata</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "Olá {{RecipientName}}, a ata da reunião «{{Title}}» está disponível: {{MinutesUrl}}",
            Language: "pt",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — 欢迎",
            SubjectTemplate: "欢迎 {{FirstName}} 加入 TutorSphere！",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">欢迎，{{FirstName}}！</h1>
                <p>您的 TutorSphere 帐户已准备就绪。请登录以访问您的个人空间。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">进入我的空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "欢迎 {{FirstName}} 加入 TutorSphere。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — 家长空间验证",
            SubjectTemplate: "验证您的家长空间 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">激活您的家长空间</h2>
                <p>{{FirstName}}，您好，</p>
                <p>欢迎使用 TutorSphere。要访问<strong>家长空间</strong>并跟进孩子的学习，请先<strong>验证您的电子邮件</strong>。未验证前无法登录。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">验证我的家长空间</a></p>
                <p style="font-size:13px;color:#888;">如果您未创建帐户，请忽略此邮件。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "验证您的 TutorSphere 家长空间：{{ConfirmationUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — 确认电子邮件（学校）",
            SubjectTemplate: "确认您的电子邮件 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">确认您的电子邮件地址</h2>
                <p>{{FirstName}}，您好，</p>
                <p>点击下方按钮以激活您的学校帐户。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">确认我的电子邮件</a></p>
                <p style="font-size:13px;color:#888;">如果您未创建帐户，请忽略此邮件。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "确认您的电子邮件：{{ConfirmationUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — 课程报告（家长）",
            SubjectTemplate: "{{StudentName}} 的课程报告 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">课程报告</h2>
                <p>{{ParentFirstName}}，您好，</p>
                <p>以下是 <strong>{{StudentName}}</strong> 与 <strong>{{TutorName}}</strong> 最近一次课程的报告。</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">登录您的空间以查看完整报告。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看报告</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{StudentName}} 与 {{TutorName}} 的课程报告。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — 学校已创建（待审）",
            SubjectTemplate: "您的学校 {{SchoolName}} 正在审核 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">学校已登记</h2>
                <p>{{OwnerFirstName}}，您好，</p>
                <p>您的学校 <strong>{{SchoolName}}</strong> 已登记，正在等待 TutorSphere 团队审核。</p>
                <p>作出决定后将通过电子邮件通知您（通常为 1–2 个工作日）。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "学校 {{SchoolName}} 已登记，等待审核。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — 确认电子邮件（标准）",
            SubjectTemplate: "确认您的电子邮件 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">确认您的电子邮件地址</h2>
                <p>{{FirstName}}，您好，</p>
                <p>请确认您的电子邮件地址以完成帐户创建。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">确认我的电子邮件</a></p>
                <p style="font-size:13px;color:#888;">如果您未创建帐户，请忽略此邮件。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "确认您的电子邮件：{{ConfirmationUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — 重置密码",
            SubjectTemplate: "重置您的密码 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">重置密码</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您请求重置 TutorSphere 密码。请点击下方：</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">重置我的密码</a></p>
                <p style="font-size:13px;color:#888;">此链接 24 小时内有效。如非您本人操作，请忽略此邮件。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "重置密码：{{ResetUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — 密码已更改",
            SubjectTemplate: "您的密码已更改 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">密码已更改</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您的 TutorSphere 密码已更改。</p>
                <p>如非您本人操作，请立即联系支持。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">登录</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的 TutorSphere 密码已更改。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — 导师免费试用已开始",
            SubjectTemplate: "您的 TutorSphere 免费试用已开始！",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">您的免费试用已开始！</h2>
                <p>{{FirstName}}，您好，</p>
                <p>欢迎使用 TutorSphere！您的免费试用期现已激活。</p>
                <p>畅享全部功能，管理课程、学生和付款。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">前往我的仪表板</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的 TutorSphere 免费试用已开始。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — 导师付款收据",
            SubjectTemplate: "付款收据 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">付款收据</h2>
                <p>{{FirstName}}，您好，</p>
                <p>我们已收到您的 TutorSphere 订阅付款。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">金额</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的发票</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "付款收据 {{Amount}}。发票：{{InvoiceUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — 导师续订提醒",
            SubjectTemplate: "您的 TutorSphere 订阅即将续订",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">即将续订</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您的 TutorSphere 订阅将于 <strong>{{RenewalDate}}</strong> 续订。</p>
                <p>请确保您的付款信息是最新的。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">管理我的订阅</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "您的 TutorSphere 订阅将于 {{RenewalDate}} 续订。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — 导师付款失败",
            SubjectTemplate: "付款问题 — 您的 TutorSphere 订阅",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">付款问题</h2>
                <p>{{FirstName}}，您好，</p>
                <p>我们无法处理您的 TutorSphere 订阅付款。</p>
                <p>请更新付款信息，以免服务中断。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">更新我的信息</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的 TutorSphere 付款失败。请更新信息。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — 导师订阅已取消",
            SubjectTemplate: "您的 TutorSphere 订阅已取消",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">订阅已取消</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您的 TutorSphere 订阅已取消。在当前周期结束前您仍可访问。</p>
                <p>期待很快再次见到您！</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">返回 TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的 TutorSphere 订阅已取消。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — 帐户已激活",
            SubjectTemplate: "您的 TutorSphere 帐户已激活",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">帐户已激活</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您的 TutorSphere 帐户已<strong>激活</strong>。您现在可以正常登录。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">登录</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的 TutorSphere 帐户已激活。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — 帐户已停用",
            SubjectTemplate: "您的 TutorSphere 帐户已停用",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">帐户已停用</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您的 TutorSphere 帐户已被管理员停用。</p>
                <p><strong>原因 :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">如有疑问，请联系 TutorSphere 支持。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的帐户已停用。原因：{{Reason}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — 学校已批准",
            SubjectTemplate: "恭喜！您的学校 {{SchoolName}} 已获批准",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">学校已批准！</h2>
                <p>{{FirstName}}，您好，</p>
                <p>好消息：您的学校 <strong>{{SchoolName}}</strong> 已获 TutorSphere 团队<strong>批准</strong>。</p>
                <p>您现在可以登录并开始管理课程和学生。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">进入我的学校空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的学校 {{SchoolName}} 已获批准。登录：{{LoginUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — 课程已安排",
            SubjectTemplate: "新课程已安排 — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">课程已安排</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>已为您安排了一节新课程。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">科目</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">导师</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">日期</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的日历</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "课程已安排 — {{Subject}}，导师 {{TutorName}}，时间 {{LessonDate}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — 课程提醒",
            SubjectTemplate: "提醒：您的 {{Subject}} 课程在明天",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">课程提醒</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>别忘了明天的课程！</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">科目</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">导师</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">日期</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看详情</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "提醒：{{Subject}} 课程，导师 {{TutorName}}，时间 {{LessonDate}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — 课程已取消",
            SubjectTemplate: "课程已取消 — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">课程已取消</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>以下课程已被<strong>取消</strong>：</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">科目</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">导师</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">原定日期</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的日历</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "课程已取消 — {{Subject}}，导师 {{TutorName}}，原定 {{LessonDate}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — 已提议代课教师",
            SubjectTemplate: "需要您的同意：{{LessonTitle}} 的代课教师",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">已为您提议代课教师</h2>
                <p>{{RecipientName}}，您好，</p>
                <p><strong>{{OriginalTeacherName}}</strong> 无法讲授下列课程。同组教师 <strong>{{SubstituteTeacherName}}</strong> 可以代课：<strong>需要您的同意</strong>。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">课程</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">预定时间</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">学生</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">原任教师</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">代课教师</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>若您在预定时间前未作答复，该课程仍归原任教师，并可能延期。</p>
                <p><strong>缺席原因 :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">接受或拒绝</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} 在 {{LessonDate}} 无法讲授 {{LessonTitle}}。建议代课教师：{{SubstituteTeacherName}}。请确认：{{ActionUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — 代课邀请",
            SubjectTemplate: "代课提议：{{OriginalTeacherName}} 的 {{LessonCount}} 节课",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">您被提议担任代课教师</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>小组提议由您接替暂时无法授课的 <strong>{{OriginalTeacherName}}</strong>。每个家庭须先同意，获同意的课程随后会出现在您的日历中。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">首节课程</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">被代课教师</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">涉及课程数</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>缺席原因 :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的日历</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "代课提议：{{OriginalTeacherName}} 的 {{LessonCount}} 节课，自 {{LessonDate}} 起。日历：{{ActionUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — 代课已接受",
            SubjectTemplate: "代课已接受 — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">代课已接受</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>家庭已<strong>接受</strong>代课安排：将由 <strong>{{SubstituteTeacherName}}</strong> 代替 <strong>{{OriginalTeacherName}}</strong> 授课。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">课程</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">预定时间</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">原任教师</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">代课教师</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的日历</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "代课已接受：{{SubstituteTeacherName}} 将于 {{LessonDate}} 代替 {{OriginalTeacherName}} 讲授 {{LessonTitle}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — 代课被拒绝",
            SubjectTemplate: "代课被拒绝 — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">代课被拒绝</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>家庭<strong>拒绝</strong>了代课安排：课程仍归 <strong>{{OriginalTeacherName}}</strong>。若确认缺席，该课程需改期或取消。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">课程</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">预定时间</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">建议代课教师</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的日历</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "代课被拒绝：{{LessonDate}} 的 {{LessonTitle}} 仍归 {{OriginalTeacherName}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — 家长付款收据",
            SubjectTemplate: "{{StudentName}} 的付款收据 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">付款收据</h2>
                <p>{{ParentName}}，您好，</p>
                <p>我们已收到您为 <strong>{{StudentName}}</strong> 课程支付的款项。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">学生</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">金额</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的发票</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{StudentName}} 的付款收据 — {{Amount}}。发票：{{InvoiceUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — 家长退款",
            SubjectTemplate: "{{StudentName}} 的退款 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">付款已退还</h2>
                <p>{{ParentName}}，您好，</p>
                <p>教师资料 <strong>{{TutorName}}</strong> 已移除。已安排的课程均已取消。您为 <strong>{{StudentName}}</strong> 支付的款项已<strong>退还</strong>——您无需采取任何操作。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">学生</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">退款金额</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">打开我的账户</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "退款 {{Amount}}（学生 {{StudentName}}，教师 {{TutorName}}）。已安排课程已取消。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — 家长付款失败",
            SubjectTemplate: "付款问题 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">付款问题</h2>
                <p>{{ParentName}}，您好，</p>
                <p>我们无法处理您为孩子课程支付的款项。</p>
                <p>请更新付款信息以保持课程访问权限。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">更新我的信息</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{ParentName}}，您好，您的 TutorSphere 付款失败。请更新信息。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — 发票已就绪",
            SubjectTemplate: "您的 TutorSphere 发票已就绪",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">发票已就绪</h2>
                <p>{{ParentName}}，您好，</p>
                <p>您的新 TutorSphere 发票可供下载。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">下载我的发票</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{ParentName}}，您好，您的 TutorSphere 发票已就绪：{{InvoiceUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — 逾期付款",
            SubjectTemplate: "提醒：{{StudentName}} 的付款待处理 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">逾期付款</h2>
                <p>{{ParentName}}，您好，</p>
                <p><strong>{{StudentName}}</strong> 的课程 <strong>{{CourseTitle}}</strong> 付款仍待处理。</p>
                <p>请尽快完成付款以激活或保持课程访问权限。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">立即付款</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "提醒：{{StudentName}} — {{CourseTitle}} 逾期付款。付款：{{PayUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — 课程报名请求",
            SubjectTemplate: "新的报名请求 — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">新的报名请求</h2>
                <p>{{TutorName}}，您好，</p>
                <p><strong>{{StudentName}}</strong> 希望报名课程 <strong>{{CourseTitle}}</strong>。</p>
                <p>登录以接受或拒绝该请求。</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">管理报名</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{StudentName}} 报名课程 {{CourseTitle}} 的请求。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — 课程报名已接受",
            SubjectTemplate: "报名已接受 — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">报名已接受</h2>
                <p>{{ParentName}}，您好，</p>
                <p><strong>{{StudentName}}</strong> 报名课程 <strong>{{CourseTitle}}</strong> 已获接受。</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">继续</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{StudentName}} 报名 {{CourseTitle}} 已接受。{{StatusNote}} {{ActionUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — 已收到付款（学生课程）",
            SubjectTemplate: "已收到付款 — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">已收到付款</h2>
                <p>{{TutorName}}，您好，</p>
                <p>已收到 <strong>{{StudentName}}</strong> — 课程 <strong>{{CourseTitle}}</strong> 的付款。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">金额</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看我的空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "已收到付款：{{Amount}}，{{StudentName}} — {{CourseTitle}}。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — 待审教师（专家）",
            SubjectTemplate: "待审教师申请 — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">待审教师申请</h2>
                <p>{{ExpertFirstName}}，您好，</p>
                <p>一所学校已提交待审教师帐户。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">学校</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">国家</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>请登录以审核材料并批准或拒绝该申请。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">审核申请</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{ExpertFirstName}}，您好，待审教师申请 — {{SchoolName}}（{{Country}}）。{{ReviewUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — 专家邀请",
            SubjectTemplate: "欢迎 {{FirstName}} — 专家访问 {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">您的专家空间访问权限</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您已受邀加入 TutorSphere 专家组 <strong>{{GroupName}}</strong>。以下是您的登录凭据：</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">专家组</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">登录电子邮件</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">临时密码</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">专家登录页</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">为安全起见，请在首次登录专家空间时<strong>更改此密码</strong>。</p>
                <p>步骤：1）打开下方专家登录页 2）输入电子邮件和临时密码 3）设置新密码。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">登录专家空间</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">专家登录页</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          请仅通过专家空间登录：<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">（标准地址：<a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>）</span>
<br/><br/>
<strong style="color:#333;">GISEBS 生态系统 — 我们的产品</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
此邮件由 TutorSphere（GISEBS）发送。请勿直接回复。<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，专家邀请 {{GroupName}}。电子邮件：{{Email}}。临时密码：{{TemporaryPassword}}。请在首次登录时更改密码。专家登录：{{LoginUrl}}（https://tutorsphere.gisebs.com/login/expert）。GISEBS：https://gisebs.com",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — 已加入专家组",
            SubjectTemplate: "{{FirstName}}，您已加入 {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">已加入专家组</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您已加入 TutorSphere 专家组 <strong>{{GroupName}}</strong>。请使用现有凭据登录。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">专家组</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">帐户</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">登录专家空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您已加入小组 {{GroupName}}（帐户 {{Email}}）。登录：{{LoginUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — 教师已批准（专家）",
            SubjectTemplate: "好消息：您的教师资料已获批准",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">教师资料已批准</h2>
                <p>{{FirstName}}，您好，</p>
                <p>您针对 <strong>{{SchoolName}}</strong> 的申请已由专家组 <strong>{{GroupName}}</strong> <strong>批准</strong>。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">学校 / 资料</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">专家组</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">备注</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>您可以登录教师空间继续使用 TutorSphere。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">进入我的教师空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的资料 {{SchoolName}} 已由 {{GroupName}} 批准。备注：{{Notes}}。登录：{{LoginUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — 教师已拒绝（专家）",
            SubjectTemplate: "关于您教师申请的决定 — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">教师申请未获批准</h2>
                <p>{{FirstName}}，您好，</p>
                <p>经审核，专家组 <strong>{{GroupName}}</strong> 未批准您针对 <strong>{{SchoolName}}</strong> 的申请。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">学校 / 资料</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">专家组</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">原因 / 备注</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>您可以更新材料（文件、学历、介绍），如有需要可重新提交申请。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">打开我的教师空间</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的申请 {{SchoolName}} 未获 {{GroupName}} 批准。原因：{{Notes}}。登录：{{LoginUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — 教师申请邀请",
            SubjectTemplate: "{{ExpertName}} 邀请您提交教师申请",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">申请邀请</h2>
                <p>{{FirstName}}，您好，</p>
                <p><strong>{{ExpertName}}</strong>（专家组 <strong>{{GroupName}}</strong>）邀请您在 TutorSphere 提交教师申请以供审核。</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>请通过下方链接创建账户并提交材料。URL：{{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">提交我的申请</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，{{ExpertName}}（{{GroupName}}）邀请您申请。{{PersonalMessage}} 链接：{{ApplyUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — 专家成员邀请",
            SubjectTemplate: "{{InviterName}} 邀请您加入 {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">专家空间</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">加入 {{GroupName}} 专家组</h2>
                <p>{{FirstName}}，您好，</p>
                <p>负责人 <strong>{{InviterName}}</strong> 邀请您成为 TutorSphere 专家组 <strong>{{GroupName}}</strong> 的<strong>专家</strong>。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">小组</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">负责人</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">拟任角色</td><td style="padding:10px 14px;font-weight:600;">专家</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">有效期</td><td style="padding:10px 14px;font-weight:600;">30 天</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">留言</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>下一步</strong><br/>1. 打开下方安全链接。<br/>2. 接受或拒绝邀请。<br/>3. 视小组规则，入组可能还需成员投票。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">回复邀请</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，负责人 {{InviterName}} 邀请您加入 TutorSphere 专家组 {{GroupName}}。{{PersonalMessage}} 回复：{{JoinUrl}}（30 天有效）。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — 专家入组投票",
            SubjectTemplate: "投票已开启：{{CandidateName}} 的申请 — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">入组投票已开启</h2>
                <p>{{FirstName}}，您好，</p>
                <p><strong>{{CandidateName}}</strong> 申请加入 <strong>{{GroupName}}</strong>，现已开放成员投票。</p>
                <p>请尽快投票。入组需获得至少 75% 其他活跃成员的同意。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">打开录取页</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，{{CandidateName}}（{{GroupName}}）的投票已开启。链接：{{VoteUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — 专家申请未通过",
            SubjectTemplate: "您的专家申请未获通过 — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">申请未通过</h2>
                <p>{{FirstName}}，您好，</p>
                <p>经审核，您加入 TutorSphere 专家组的申请未获通过。</p>
                <p><strong>原因 :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{FirstName}}，您好，您的专家申请未获通过。原因：{{Reason}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — 会议邀请（成员）",
            SubjectTemplate: "会议《{{Title}}》— {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">小组会议</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">小组会议邀请</h2>
                <p>{{RecipientName}}，您好，</p>
                <p><strong>{{OrganizerName}}</strong> 邀请您参加 TutorSphere 上的工作会议。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">主题</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">日期和时间</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">会议密码</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">组织者</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">议程</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>该按钮将直接在<strong>您的专家空间</strong>中打开会议室：密码已包含在链接中，无需输入（如尚未登录，请先登录 TutorSphere 账户）。这是小组内部会议，请勿转发此链接或密码。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">加入会议</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{RecipientName}}，您好，{{OrganizerName}} 邀请您参加会议《{{Title}}》，时间为 {{StartLocal}}（{{TimeZone}}）。议程：{{Agenda}}。{{RecordingAndAi}} 链接已包含入会密码（{{AccessCode}}），点击即可进入会议室。加入：{{JoinUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — 会议邀请（外部嘉宾）",
            SubjectTemplate: "邀请您参加会议《{{Title}}》— {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">外部嘉宾</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">会议邀请</h2>
                <p>{{RecipientName}}，您好，</p>
                <p><strong>{{OrganizerName}}</strong> 邀请您参加在 TutorSphere 上举办的线上会议。<strong>无需注册账户</strong>：您的个人访问链接见下方。</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">主题</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">日期和时间</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">您的邀请码</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">组织者</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">议程</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">链接有效期至</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>如何加入</strong><br/>1. 点击下方按钮：姓名和邀请码已包含在链接中，会议将直接打开。<br/>2. 在等候室稍候，组织者将允许您进入。<br/>上方的邀请码仅作备用，以防链接缺少参数时使用。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">加入会议</a></p>
                <p style="font-size:13px;color:#888;">此链接为个人专用、临时且不可转让，仅可进入本次会议，不能访问 TutorSphere 的其他功能。如果您并未预期收到此邀请，请忽略本邮件。</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{RecipientName}}，您好，{{OrganizerName}} 邀请您参加会议《{{Title}}》，时间为 {{StartLocal}}（{{TimeZone}}）。议程：{{Agenda}}。{{RecordingAndAi}} 只需点击您的个人链接：姓名和邀请码（{{AccessCode}}）已包含在内。链接有效期至 {{LinkValidity}}：{{JoinUrl}}。请勿转发此链接或邀请码。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — 嘉宾验证码",
            SubjectTemplate: "您参加会议《{{Title}}》的验证码",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">外部嘉宾</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">您的验证码</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>请在访问页面输入此验证码，以确认您的邮箱并加入会议<strong>{{Title}}</strong>。</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">此验证码仅对本次会话有效，请勿转告他人。</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{RecipientName}}，您好，会议《{{Title}}》的验证码为 {{Code}}，请勿告知他人。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — 会议提醒",
            SubjectTemplate: "提醒：会议《{{Title}}》将于 {{StartLocal}} 举行",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">提醒</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">您的会议即将开始</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>会议<strong>{{Title}}</strong>将于 <strong>{{StartLocal}}</strong> 举行。点击按钮即可进入会议室：密码（<strong>{{AccessCode}}</strong>）已包含在链接中。加入前请先测试麦克风与摄像头。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">加入会议</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{RecipientName}}，您好，提醒您：会议《{{Title}}》将于 {{StartLocal}} 举行。会议密码：{{AccessCode}}。加入：{{JoinUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — 会议已取消",
            SubjectTemplate: "已取消：{{StartLocal}} 的会议《{{Title}}》",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">会议已取消</h2>
                <p>原定于 <strong>{{StartLocal}}</strong> 的会议<strong>{{Title}}</strong>已被组织者取消，访问链接失效。</p>
                <p>如另行安排时间，您将收到新的邀请。</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "原定于 {{StartLocal}} 的会议《{{Title}}》已取消。",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — 会议记录",
            SubjectTemplate: "会议《{{Title}}》的会议记录",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">会议记录已生成</h2>
                <p>{{RecipientName}}，您好，</p>
                <p>会议<strong>{{Title}}</strong>的会议记录已生成。请查阅，如需更正请告知组织者。</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">查看会议记录</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{RecipientName}}，您好，会议《{{Title}}》的会议记录已生成：{{MinutesUrl}}",
            Language: "zh-Hans",
            SeedRevision: 13),

        new(
            TemplateCode: "WELCOME",
            Name: "TutorSphere — مرحبًا",
            SubjectTemplate: "مرحبًا {{FirstName}} في TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h1 style="color:#5831E0;margin:0 0 12px;font-size:24px;">مرحبًا {{FirstName}}!</h1>
                <p>حساب TutorSphere جاهز. سجّل الدخول للوصول إلى مساحتك الشخصية.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانتقال إلى مساحتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}} في TutorSphere.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_CONFIRM_ACCESS",
            Name: "TutorSphere — تأكيد مساحة ولي الأمر",
            SubjectTemplate: "أكد مساحة ولي الأمر — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">فعّل مساحة ولي الأمر</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>مرحبًا بك في TutorSphere. للوصول إلى <strong>مساحة ولي الأمر</strong> ومتابعة مسار أبنائك الدراسي، يرجى <strong>تأكيد بريدك الإلكتروني</strong> أولًا. بدون هذا التأكيد يبقى تسجيل الدخول محظورًا.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تأكيد مساحة ولي الأمر</a></p>
                <p style="font-size:13px;color:#888;">إذا لم تنشئ حسابًا، فتجاهل هذا البريد.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "أكد مساحة ولي الأمر في TutorSphere: {{ConfirmationUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL",
            Name: "TutorSphere — تأكيد البريد (مدرسة)",
            SubjectTemplate: "أكد عنوان بريدك — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">أكد عنوان بريدك الإلكتروني</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>انقر على الزر أدناه لتفعيل حساب مدرستك.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تأكيد بريدي</a></p>
                <p style="font-size:13px;color:#888;">إذا لم تنشئ حسابًا، فتجاهل هذا البريد.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "أكد بريدك: {{ConfirmationUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REPORT",
            Name: "TutorSphere — تقرير الحصة لولي الأمر",
            SubjectTemplate: "تقرير الحصة لـ {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تقرير الحصة</h2>
                <p>مرحبًا {{ParentFirstName}}،</p>
                <p>إليك تقرير آخر حصة لـ <strong>{{StudentName}}</strong> مع <strong>{{TutorName}}</strong>.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">سجّل الدخول إلى مساحتك لعرض التقرير الكامل.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض التقرير</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تقرير الحصة لـ {{StudentName}} مع {{TutorName}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_CREATED",
            Name: "TutorSphere — تم إنشاء المدرسة (قيد الانتظار)",
            SubjectTemplate: "مدرستك {{SchoolName}} قيد المراجعة — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم تسجيل المدرسة</h2>
                <p>مرحبًا {{OwnerFirstName}}،</p>
                <p>تم تسجيل مدرستك <strong>{{SchoolName}}</strong> وهي بانتظار موافقة فريق TutorSphere.</p>
                <p>سيتم إعلامك بالبريد عند اتخاذ قرار (عادة خلال يوم إلى يومي عمل).</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم تسجيل المدرسة {{SchoolName}} وبانتظار الموافقة.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "CONFIRM_EMAIL_SIMPLE",
            Name: "TutorSphere — تأكيد البريد (قياسي)",
            SubjectTemplate: "أكد عنوان بريدك — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">أكد عنوان بريدك الإلكتروني</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>يرجى تأكيد بريدك الإلكتروني لإكمال إنشاء حسابك.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ConfirmationUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تأكيد بريدي</a></p>
                <p style="font-size:13px;color:#888;">إذا لم تنشئ حسابًا، فتجاهل هذا البريد.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "أكد بريدك: {{ConfirmationUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "TutorSphere — إعادة تعيين كلمة المرور",
            SubjectTemplate: "أعد تعيين كلمة المرور — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">إعادة تعيين كلمة المرور</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>طلبت إعادة تعيين كلمة مرور TutorSphere. انقر أدناه:</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ResetUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">إعادة تعيين كلمة المرور</a></p>
                <p style="font-size:13px;color:#888;">هذا الرابط صالح لمدة 24 ساعة. إذا لم تطلب ذلك، فتجاهل هذا البريد.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "أعد تعيين كلمة المرور: {{ResetUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PASSWORD_CHANGED",
            Name: "TutorSphere — تم تغيير كلمة المرور",
            SubjectTemplate: "تم تغيير كلمة مرورك — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم تغيير كلمة المرور</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تم تغيير كلمة مرور TutorSphere الخاصة بك.</p>
                <p>إذا لم تقم بهذا التغيير، فاتصل بالدعم فورًا.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تسجيل الدخول</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تم تغيير كلمة مرور TutorSphere.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_TRIAL_STARTED",
            Name: "TutorSphere — بدأت الفترة التجريبية للمعلم",
            SubjectTemplate: "بدأت فترتك التجريبية في TutorSphere!",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">بدأت فترتك التجريبية!</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>مرحبًا بك في TutorSphere! فترتك التجريبية المجانية نشطة الآن.</p>
                <p>استفد من جميع الميزات لإدارة دروسك وطلابك ومدفوعاتك.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/dashboard" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانتقال إلى لوحة التحكم</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، بدأت فترتك التجريبية في TutorSphere.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_RECEIPT",
            Name: "TutorSphere — إيصال دفع المعلم",
            SubjectTemplate: "إيصال الدفع — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">إيصال الدفع</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>استلمنا دفعتك لاشتراك TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">المبلغ</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض فاتورتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "إيصال دفع {{Amount}}. الفاتورة: {{InvoiceUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_RENEWAL_REMINDER",
            Name: "TutorSphere — تذكير بتجديد المعلم",
            SubjectTemplate: "سيُجدَّد اشتراكك في TutorSphere قريبًا",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تجديد قادم</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>سيُجدَّد اشتراكك في TutorSphere في <strong>{{RenewalDate}}</strong>.</p>
                <p>تأكد من أن بيانات الدفع محدثة.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">إدارة اشتراكي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "سيُجدَّد اشتراكك في TutorSphere في {{RenewalDate}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_PAYMENT_FAILED",
            Name: "TutorSphere — فشل دفع المعلم",
            SubjectTemplate: "مشكلة في الدفع — اشتراك TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">مشكلة في الدفع</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تعذّر معالجة دفعتك لاشتراك TutorSphere.</p>
                <p>يرجى تحديث بيانات الدفع لتجنب انقطاع الخدمة.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تحديث بياناتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، فشل دفع TutorSphere. حدّث بياناتك.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_SUB_CANCELLED",
            Name: "TutorSphere — تم إلغاء اشتراك المعلم",
            SubjectTemplate: "تم إلغاء اشتراكك في TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم إلغاء الاشتراك</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تم إلغاء اشتراكك في TutorSphere. تحتفظ بالوصول حتى نهاية الفترة الحالية.</p>
                <p>نأمل أن نراك قريبًا مجددًا!</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">العودة إلى TutorSphere</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تم إلغاء اشتراكك في TutorSphere.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_ACTIVATED",
            Name: "TutorSphere — تم تفعيل الحساب",
            SubjectTemplate: "تم تفعيل حسابك في TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تم تفعيل الحساب</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تم <strong>تفعيل</strong> حساب TutorSphere. يمكنك الآن تسجيل الدخول كالمعتاد.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تسجيل الدخول</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تم تفعيل حسابك في TutorSphere.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "ACCOUNT_DEACTIVATED",
            Name: "TutorSphere — تم تعطيل الحساب",
            SubjectTemplate: "تم تعطيل حسابك في TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">تم تعطيل الحساب</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تم تعطيل حساب TutorSphere من قبل الإدارة.</p>
                <p><strong>السبب :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#888;">لأي استفسار، تواصل مع دعم TutorSphere.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تم تعطيل حسابك. السبب: {{Reason}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "SCHOOL_APPROVED",
            Name: "TutorSphere — تمت الموافقة على المدرسة",
            SubjectTemplate: "تهانينا! تمت الموافقة على مدرستك {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تمت الموافقة على المدرسة!</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>خبر سار: تمت <strong>الموافقة</strong> على مدرستك <strong>{{SchoolName}}</strong> من فريق TutorSphere.</p>
                <p>يمكنك الآن تسجيل الدخول وبدء إدارة دروسك وطلابك.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانتقال إلى مساحة المدرسة</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تمت الموافقة على مدرستك {{SchoolName}}. الدخول: {{LoginUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_SCHEDULED",
            Name: "TutorSphere — تمت جدولة الحصة",
            SubjectTemplate: "حصة جديدة مجدولة — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">حصة مجدولة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>تمت جدولة حصة جديدة لك.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المادة</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض تقويمي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "حصة مجدولة — {{Subject}} مع {{TutorName}} في {{LessonDate}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_REMINDER",
            Name: "TutorSphere — تذكير بالحصة",
            SubjectTemplate: "تذكير: حصتك في {{Subject}} غدًا",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تذكير بالحصة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>لا تنسَ حصتك غدًا!</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المادة</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض التفاصيل</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تذكير: حصة {{Subject}} مع {{TutorName}} في {{LessonDate}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_CANCELLED",
            Name: "TutorSphere — تم إلغاء الحصة",
            SubjectTemplate: "تم إلغاء الحصة — {{Subject}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">تم إلغاء الحصة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>نعلمك أن الحصة التالية قد تم <strong>إلغاؤها</strong>:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المادة</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ المقرر</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض تقويمي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم إلغاء الحصة — {{Subject}} مع {{TutorName}} المقررة في {{LessonDate}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_PROPOSED",
            Name: "TutorSphere — تم اقتراح معلم بديل",
            SubjectTemplate: "مطلوب موافقتك: معلم بديل لـ {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم اقتراح معلم بديل</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>لن يتمكن <strong>{{OriginalTeacherName}}</strong> من تقديم الحصة التالية. يمكن للمعلم <strong>{{SubstituteTeacherName}}</strong> من المجموعة نفسها تولّيها: <strong>موافقتك مطلوبة</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الحصة</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ المقرر</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الطالب</td><td style="padding:10px 14px;font-weight:600;">{{StudentName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم الأصلي</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم البديل</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p>في حال عدم ردّك قبل الموعد المقرر، تبقى الحصة باسم المعلم الأصلي وقد تُؤجَّل.</p>
                <p><strong>سبب الغياب :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الموافقة أو الرفض</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "{{OriginalTeacherName}} غير متاح لحصة {{LessonTitle}} في {{LessonDate}}. البديل المقترح: {{SubstituteTeacherName}}. موافقتك: {{ActionUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_SUBSTITUTE",
            Name: "TutorSphere — طلب نيابة",
            SubjectTemplate: "نيابة مقترحة: {{LessonCount}} حصة عن {{OriginalTeacherName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم اقتراحك معلمًا بديلًا</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>تقترح المجموعة أن تتولّى حصص <strong>{{OriginalTeacherName}}</strong> غير المتاح. على كل أسرة الموافقة أولًا، ثم تظهر الحصص المقبولة في تقويمك.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الحصة الأولى</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم المستبدل</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الحصص المعنية</td><td style="padding:10px 14px;font-weight:600;">{{LessonCount}}</td></tr>
                </table>
                <p><strong>سبب الغياب :</strong> {{Reason}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض تقويمي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "نيابة مقترحة: {{LessonCount}} حصة عن {{OriginalTeacherName}} بدءًا من {{LessonDate}}. التقويم: {{ActionUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_APPROVED",
            Name: "TutorSphere — تم قبول النيابة",
            SubjectTemplate: "تم قبول النيابة — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تم قبول النيابة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>وافقت الأسرة على النيابة: سيتولّى <strong>{{SubstituteTeacherName}}</strong> الحصة بدلًا من <strong>{{OriginalTeacherName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdf4;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الحصة</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ المقرر</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم الأصلي</td><td style="padding:10px 14px;font-weight:600;">{{OriginalTeacherName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المعلم البديل</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض تقويمي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم قبول النيابة: سيقدّم {{SubstituteTeacherName}} حصة {{LessonTitle}} في {{LessonDate}} بدلًا من {{OriginalTeacherName}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "LESSON_COVERAGE_REJECTED",
            Name: "TutorSphere — تم رفض النيابة",
            SubjectTemplate: "تم رفض النيابة — {{LessonTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">تم رفض النيابة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>رفضت الأسرة النيابة: تبقى الحصة باسم <strong>{{OriginalTeacherName}}</strong>. وإذا تأكّد الغياب، فيجب تأجيل الحصة أو إلغاؤها.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#fff5f5;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الحصة</td><td style="padding:10px 14px;font-weight:600;">{{LessonTitle}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ المقرر</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">البديل المقترح</td><td style="padding:10px 14px;font-weight:600;">{{SubstituteTeacherName}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض تقويمي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم رفض النيابة: تبقى حصة {{LessonTitle}} في {{LessonDate}} باسم {{OriginalTeacherName}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_RECEIPT",
            Name: "TutorSphere — إيصال دفع ولي الأمر",
            SubjectTemplate: "إيصال دفع لـ {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">إيصال الدفع</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>استلمنا دفعتك لحصص <strong>{{StudentName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">الطالب</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">المبلغ</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض فاتورتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "إيصال دفع لـ {{StudentName}} — {{Amount}}. الفاتورة: {{InvoiceUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_REFUNDED",
            Name: "TutorSphere — استرداد ولي الأمر",
            SubjectTemplate: "استرداد لـ {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تم استرداد الدفعة</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>تمت إزالة ملف المعلم <strong>{{TutorName}}</strong>. الحصص المبرمجة أُلغيت. دفعتك لـ <strong>{{StudentName}}</strong> تم <strong>استردادها</strong> — لا يلزم أي إجراء منك.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">الطالب</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">المبلغ المسترد</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">فتح مساحتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "استرداد {{Amount}} لـ {{StudentName}} (المعلم {{TutorName}}). الحصص المبرمجة أُلغيت.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_FAILED",
            Name: "TutorSphere — فشل دفع ولي الأمر",
            SubjectTemplate: "مشكلة في الدفع — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">مشكلة في الدفع</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>تعذّر معالجة دفعتك لحصص طفلك.</p>
                <p>يرجى تحديث بيانات الدفع للحفاظ على الوصول إلى الحصص.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/settings/billing" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تحديث بياناتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{ParentName}}، فشل دفع TutorSphere. حدّث بياناتك.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "INVOICE_READY",
            Name: "TutorSphere — الفاتورة جاهزة",
            SubjectTemplate: "فاتورة TutorSphere جاهزة",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">الفاتورة جاهزة</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>فاتورتك الجديدة من TutorSphere جاهزة للتنزيل.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{InvoiceUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تنزيل فاتورتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{ParentName}}، فاتورة TutorSphere جاهزة: {{InvoiceUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "PARENT_PAYMENT_OVERDUE",
            Name: "TutorSphere — دفعة متأخرة",
            SubjectTemplate: "تذكير: دفعة معلّقة لـ {{StudentName}} — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">دفعة متأخرة</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>لا تزال دفعة دورة <strong>{{CourseTitle}}</strong> لـ <strong>{{StudentName}}</strong> معلّقة.</p>
                <p>يرجى التسوية في أقرب وقت لتفعيل أو الحفاظ على الوصول إلى الحصص.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{PayUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">ادفع الآن</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تذكير: دفعة متأخرة لـ {{StudentName}} — {{CourseTitle}}. ادفع: {{PayUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_REQUEST",
            Name: "TutorSphere — طلب تسجيل في دورة",
            SubjectTemplate: "طلب تسجيل جديد — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">طلب تسجيل جديد</h2>
                <p>مرحبًا {{TutorName}}،</p>
                <p>يرغب <strong>{{StudentName}}</strong> في التسجيل في دورة <strong>{{CourseTitle}}</strong>.</p>
                <p>سجّل الدخول لقبول الطلب أو رفضه.</p>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">إدارة التسجيلات</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "طلب تسجيل من {{StudentName}} في دورة {{CourseTitle}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "COURSE_ENROLLMENT_ACCEPTED",
            Name: "TutorSphere — تم قبول التسجيل في الدورة",
            SubjectTemplate: "تم قبول التسجيل — {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تم قبول التسجيل</h2>
                <p>مرحبًا {{ParentName}}،</p>
                <p>تم قبول تسجيل <strong>{{StudentName}}</strong> في دورة <strong>{{CourseTitle}}</strong>.</p>
                <p>{{StatusNote}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ActionUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">متابعة</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم قبول تسجيل {{StudentName}} في {{CourseTitle}}. {{StatusNote}} {{ActionUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "TUTOR_STUDENT_PAYMENT_RECEIVED",
            Name: "TutorSphere — تم استلام الدفع (دورة الطالب)",
            SubjectTemplate: "تم استلام الدفع — {{StudentName}} / {{CourseTitle}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تم استلام الدفع</h2>
                <p>مرحبًا {{TutorName}}،</p>
                <p>تم استلام دفعة لـ <strong>{{StudentName}}</strong> — دورة <strong>{{CourseTitle}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">المبلغ</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="https://tutorsphere.gisebs.com/login" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">عرض مساحتي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم استلام الدفع: {{Amount}} لـ {{StudentName}} — {{CourseTitle}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_PENDING",
            Name: "TutorSphere — معلم قيد الانتظار (خبير)",
            SubjectTemplate: "طلب معلم جديد للمراجعة — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">طلب معلم للمراجعة</h2>
                <p>مرحبًا {{ExpertFirstName}}،</p>
                <p>قدّمت مدرسة حساب معلم بانتظار التحقق.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المدرسة</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">البلد</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>
                <p>سجّل الدخول لمراجعة الملف والموافقة على الطلب أو رفضه.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ReviewUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">مراجعة الطلب</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{ExpertFirstName}}، طلب معلم للمراجعة — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_INVITE",
            Name: "TutorSphere — دعوة خبير",
            SubjectTemplate: "مرحبًا {{FirstName}} — وصول خبير {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">وصولك إلى مساحة الخبير</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تمت دعوتك للانضمام إلى مجموعة الخبراء <strong>{{GroupName}}</strong> على TutorSphere. إليك بيانات تسجيل الدخول:</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">مجموعة الخبراء</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">بريد الدخول</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">كلمة المرور المؤقتة</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">صفحة دخول الخبير</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">لأمانك، <strong>غيّر كلمة المرور هذه</strong> عند أول دخول إلى مساحة الخبير.</p>
                <p>الخطوات: 1) افتح صفحة دخول الخبير أدناه 2) أدخل البريد وكلمة المرور المؤقتة 3) اختر كلمة مرور جديدة.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تسجيل الدخول إلى مساحة الخبير</a></p>
                <p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">صفحة دخول الخبير</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          سجّل الدخول فقط عبر مساحة الخبير:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(العنوان الرسمي: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">منظومة GISEBS — منتجاتنا</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
تم إرسال هذا البريد بواسطة TutorSphere (GISEBS). يُرجى عدم الرد مباشرة.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، دعوة خبير {{GroupName}}. البريد: {{Email}}. كلمة المرور المؤقتة: {{TemporaryPassword}}. غيّر كلمة المرور عند أول دخول. دخول الخبير: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_ADDED_TO_GROUP",
            Name: "TutorSphere — أُضيفت إلى مجموعة الخبراء",
            SubjectTemplate: "{{FirstName}}، تمت إضافتك إلى {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">أُضيفت إلى مجموعة خبراء</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تمت إضافتك إلى مجموعة الخبراء <strong>{{GroupName}}</strong> على TutorSphere. استخدم بيانات اعتمادك الحالية لتسجيل الدخول.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">مجموعة الخبراء</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الحساب</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تسجيل الدخول إلى مساحة الخبير</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تمت إضافتك إلى المجموعة {{GroupName}} (الحساب {{Email}}). الدخول: {{LoginUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPROVED",
            Name: "TutorSphere — تمت الموافقة على المعلم (خبير)",
            SubjectTemplate: "خبر سار: تمت الموافقة على ملفك كمعلم",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#16a34a;margin:0 0 12px;">تمت الموافقة على ملف المعلم</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>تمت <strong>الموافقة</strong> على طلبك لـ <strong>{{SchoolName}}</strong> من مجموعة الخبراء <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المدرسة / الملف</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">مجموعة الخبراء</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">تعليق</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>يمكنك تسجيل الدخول إلى مساحة المعلم لمتابعة نشاطك على TutorSphere.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#16a34a;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانتقال إلى مساحة المعلم</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، تمت الموافقة على ملفك {{SchoolName}} من {{GroupName}}. التعليق: {{Notes}}. الدخول: {{LoginUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_REJECTED",
            Name: "TutorSphere — رُفض المعلم (خبير)",
            SubjectTemplate: "قرار بشأن طلبك كمعلم — {{SchoolName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">لم تتم الموافقة على طلب المعلم</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>بعد المراجعة، لم تتم الموافقة على طلبك لـ <strong>{{SchoolName}}</strong> من مجموعة الخبراء <strong>{{GroupName}}</strong>.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المدرسة / الملف</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">مجموعة الخبراء</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">السبب / التعليق</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>
                <p>يمكنك تحديث ملفك (المستندات، الشهادات، العرض) ثم إعادة تقديم الطلب عند الحاجة.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{LoginUrl}}" style="background:#dc2626;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">فتح مساحة المعلم</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، لم تتم الموافقة على طلبك {{SchoolName}} من {{GroupName}}. السبب: {{Notes}}. الدخول: {{LoginUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_TEACHER_APPLY_INVITE",
            Name: "TutorSphere — دعوة تقديم طلب معلم",
            SubjectTemplate: "{{ExpertName}} يدعوك لتقديم طلبك كمعلم",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">دعوة للتقديم</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p><strong>{{ExpertName}}</strong> (مجموعة الخبراء <strong>{{GroupName}}</strong>) يدعوك لتقديم طلبك كمعلم على TutorSphere للمراجعة.</p>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{PersonalMessage}}</p>
                <p>أنشئ حسابك وقدّم ملفك عبر الرابط أدناه. الرابط: {{ApplyUrl}}</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{ApplyUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">تقديم طلبي</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، {{ExpertName}} ({{GroupName}}) يدعوك للتقديم. {{PersonalMessage}} الرابط: {{ApplyUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_INVITE",
            Name: "TutorSphere — دعوة عضوية خبير",
            SubjectTemplate: "{{InviterName}} يدعوك إلى {{GroupName}} — TutorSphere Expert",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#eff6ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(37,99,235,0.12);">
            <div style="background:#2563EB;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">مساحة الخبير</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#2563EB;margin:0 0 12px;">انضم إلى مجموعة {{GroupName}}</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>يدعوك المسؤول <strong>{{InviterName}}</strong> لتصبح <strong>خبيرًا</strong> في مجموعة <strong>{{GroupName}}</strong> على TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#eff6ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">المجموعة</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المسؤول</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الدور المقترح</td><td style="padding:10px 14px;font-weight:600;">خبير</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الصلاحية</td><td style="padding:10px 14px;font-weight:600;">30 يومًا</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">رسالة</td><td style="padding:10px 14px;font-weight:600;">{{PersonalMessage}}</td></tr>
                </table>
                <p><strong>الخطوات التالية</strong><br/>1. افتح الرابط الآمن أدناه.<br/>2. اقبل الدعوة أو ارفضها.<br/>3. حسب المجموعة، قد تُعرض عضويتك على تصويت الأعضاء.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#2563EB;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الرد على الدعوة</a></p>
              <hr style="border:none;border-top:1px solid #dbeafe;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، يدعوك المسؤول {{InviterName}} للانضمام إلى مجموعة الخبراء {{GroupName}} على TutorSphere. {{PersonalMessage}} الرد: {{JoinUrl}} (صالحة 30 يومًا).",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_VOTE_OPENED",
            Name: "TutorSphere — تصويت قبول خبير",
            SubjectTemplate: "التصويت مفتوح: ترشيح {{CandidateName}} — {{GroupName}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">تصويت القبول مفتوح</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>ترشيح <strong>{{CandidateName}}</strong> للانضمام إلى <strong>{{GroupName}}</strong> مفتوح لتصويت الأعضاء.</p>
                <p>يُرجى التصويت في أقرب وقت. يتطلب القبول موافقة 75٪ على الأقل من الأعضاء النشطين الآخرين.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{VoteUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">فتح القبولات</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، التصويت مفتوح لـ {{CandidateName}} ({{GroupName}}). الرابط: {{VoteUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "EXPERT_MEMBERSHIP_REJECTED",
            Name: "TutorSphere — لم تُقبل ترشيح الخبير",
            SubjectTemplate: "لم تُقبل ترشيحك كخبير — TutorSphere",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">لم تُقبل الترشيح</h2>
                <p>مرحبًا {{FirstName}}،</p>
                <p>بعد المراجعة، لم تُقبل ترشيحك للانضمام إلى مجموعة خبراء TutorSphere.</p>
                <p><strong>السبب :</strong> {{Reason}}</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{FirstName}}، لم تُقبل ترشيحك كخبير. السبب: {{Reason}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION",
            Name: "TutorSphere — دعوة اجتماع (عضو)",
            SubjectTemplate: "اجتماع «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">اجتماع المجموعة</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">دعوة إلى اجتماع المجموعة</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>يدعوك <strong>{{OrganizerName}}</strong> إلى اجتماع عمل على TutorSphere.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f5f3ff;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الموضوع</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ والوقت</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">رمز الاجتماع</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#5831E0;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المنظّم</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">جدول الأعمال</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                </table>
                <p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p>يفتح الزر الغرفة مباشرة في <strong>مساحة الخبير الخاصة بك</strong>: الرمز مُضمَّن في الرابط، فلا حاجة إلى إدخال أي شيء (يكفي تسجيل الدخول إلى حسابك على TutorSphere إن لم تكن مسجّلاً). اجتماع خاص بالمجموعة — يُرجى عدم تحويل هذا الرابط أو الرمز.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانضمام إلى الاجتماع</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{RecipientName}}، يدعوك {{OrganizerName}} إلى اجتماع «{{Title}}» في {{StartLocal}} ({{TimeZone}}). جدول الأعمال: {{Agenda}}. {{RecordingAndAi}} يحتوي الرابط على رمز الاجتماع ({{AccessCode}}) مسبقًا: نقرة واحدة تفتح الغرفة. الانضمام: {{JoinUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_INVITATION_GUEST",
            Name: "TutorSphere — دعوة اجتماع (ضيف خارجي)",
            SubjectTemplate: "أنت مدعو إلى اجتماع «{{Title}}» — {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">ضيف خارجي</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">دعوة إلى اجتماع</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>يدعوك <strong>{{OrganizerName}}</strong> للمشاركة في اجتماع عبر الإنترنت على TutorSphere. <strong>لا حاجة إلى أي حساب</strong>: رابط الدخول الخاص بك أدناه.</p>
                <table style="width:100%;border-collapse:collapse;margin:16px 0;background:#f0fdfa;border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">الموضوع</td><td style="padding:10px 14px;font-weight:600;">{{Title}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">التاريخ والوقت</td><td style="padding:10px 14px;font-weight:600;">{{StartLocal}} ({{TimeZone}})</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">رمز دعوتك</td><td style="padding:10px 14px;"><span style="font-family:monospace;font-size:20px;font-weight:700;letter-spacing:4px;color:#0D9488;">{{AccessCode}}</span></td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">المنظّم</td><td style="padding:10px 14px;font-weight:600;">{{OrganizerName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">جدول الأعمال</td><td style="padding:10px 14px;font-weight:600;">{{Agenda}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">الرابط صالح حتى</td><td style="padding:10px 14px;font-weight:600;">{{LinkValidity}}</td></tr>
                </table>
                <p style="background:#f0fdfa;border-left:4px solid #0D9488;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">{{RecordingAndAi}}</p>
                <p><strong>كيفية الانضمام</strong><br/>1. اضغط الزر أدناه: اسمك ورمزك مُضمَّنان في الرابط، وسيُفتح الاجتماع مباشرة.<br/>2. انتظر في غرفة الانتظار: سيسمح لك المنظّم بالدخول.<br/>الرمز أعلاه للاحتياط فقط، إذا فُتح الرابط بدون معاملاته.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#0D9488;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانضمام إلى الاجتماع</a></p>
                <p style="font-size:13px;color:#888;">هذا الرابط شخصي ومؤقت وغير قابل للتحويل. يمنح الوصول إلى هذا الاجتماع فقط وليس إلى بقية TutorSphere. إذا لم تكن تتوقع هذه الدعوة، فتجاهل هذه الرسالة.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{RecipientName}}، يدعوك {{OrganizerName}} إلى اجتماع «{{Title}}» في {{StartLocal}} ({{TimeZone}}). جدول الأعمال: {{Agenda}}. {{RecordingAndAi}} يكفي أن تنقر على رابطك الشخصي: اسمك ورمزك ({{AccessCode}}) مُضمَّنان فيه. الرابط صالح حتى {{LinkValidity}}: {{JoinUrl}}. لا تُحوّل هذا الرابط أو الرمز.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_GUEST_CODE",
            Name: "TutorSphere — رمز تحقق الضيف",
            SubjectTemplate: "رمز دخولك إلى اجتماع «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f0fdfa;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(13,148,136,0.12);">
            <div style="background:#0D9488;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">ضيف خارجي</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#0D9488;margin:0 0 12px;">رمز التحقق الخاص بك</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>أدخل هذا الرمز في صفحة الدخول لتأكيد بريدك والانضمام إلى اجتماع <strong>{{Title}}</strong>.</p>
                <p style="text-align:center;margin:24px 0;">
                  <span style="display:inline-block;padding:14px 28px;border:1px dashed #0D9488;border-radius:8px;font-family:monospace;font-size:26px;font-weight:700;letter-spacing:6px;color:#0D9488;">{{Code}}</span>
                </p>
                <p style="font-size:13px;color:#888;">هذا الرمز صالح لهذه الجلسة فقط. لا تشاركه مع أي شخص.</p>
              <hr style="border:none;border-top:1px solid #ccfbf1;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{RecipientName}}، رمز التحقق لاجتماع «{{Title}}» هو {{Code}}. لا تشاركه.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_REMINDER",
            Name: "TutorSphere — تذكير بالاجتماع",
            SubjectTemplate: "تذكير: اجتماع «{{Title}}» في {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere<span style="display:inline-block;margin-left:10px;padding:4px 10px;border-radius:999px;font-size:10px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;background:rgba(255,255,255,.22);color:#ffffff;vertical-align:middle;">تذكير</span></p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">اجتماعك يقترب</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>اجتماع <strong>{{Title}}</strong> مقرر في <strong>{{StartLocal}}</strong>. يفتح الزر الغرفة بنقرة واحدة: الرمز (<strong>{{AccessCode}}</strong>) مُضمَّن في الرابط. تذكّر اختبار الميكروفون والكاميرا قبل الانضمام.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{JoinUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">الانضمام إلى الاجتماع</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{RecipientName}}، تذكير: اجتماع «{{Title}}» في {{StartLocal}}. رمز الاجتماع: {{AccessCode}}. الانضمام: {{JoinUrl}}",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_CANCELLED",
            Name: "TutorSphere — تم إلغاء الاجتماع",
            SubjectTemplate: "إلغاء: اجتماع «{{Title}}» بتاريخ {{StartLocal}}",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#dc2626;margin:0 0 12px;">تم إلغاء الاجتماع</h2>
                <p>تم إلغاء اجتماع <strong>{{Title}}</strong> المقرر في <strong>{{StartLocal}}</strong> من قِبل المنظّم. لم يعد رابط الدخول صالحًا.</p>
                <p>إذا تم تحديد موعد جديد، فستتلقى دعوة جديدة.</p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "تم إلغاء اجتماع «{{Title}}» المقرر في {{StartLocal}}.",
            Language: "ar",
            SeedRevision: 13),

        new(
            TemplateCode: "MEETING_MINUTES",
            Name: "TutorSphere — محضر الاجتماع",
            SubjectTemplate: "محضر اجتماع «{{Title}}»",
            HtmlBody: """
<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              <h2 style="color:#5831E0;margin:0 0 12px;">المحضر متاح الآن</h2>
                <p>مرحبًا {{RecipientName}}،</p>
                <p>محضر اجتماع <strong>{{Title}}</strong> متاح. يُرجى مراجعته وإبلاغ المنظّم بأي تصحيح لازم.</p>
                <p style="text-align:center;margin:28px 0;"><a href="{{MinutesUrl}}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;display:inline-block;">فتح المحضر</a></p>
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">tutorsphere.gisebs.com</a>
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:13 -->
""",
            TextBody: "مرحبًا {{RecipientName}}، محضر اجتماع «{{Title}}» متاح: {{MinutesUrl}}",
            Language: "ar",
            SeedRevision: 13)
    ];
}
