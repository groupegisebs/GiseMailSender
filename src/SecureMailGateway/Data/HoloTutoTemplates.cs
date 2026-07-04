namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail HoloTuteur. Client code : HOLOTUTO.
/// SeedRevision dans le HTML permet la mise à jour au démarrage du gateway.
/// </summary>
public static class HoloTutoTemplates
{
    private const string BrandHeader = """
        <div style="background:#1a1a2e;padding:24px 32px;text-align:center;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#fff;letter-spacing:0.04em;">HoloTuto</p>
          <p style="margin:6px 0 0;font-size:12px;color:#93c5fd;">L'assistant pédagogique intelligent</p>
        </div>
        """;

    private static string BrandFooter(int seedRevision) => $"""
        <div style="background:#1a1a2e;padding:18px 32px;text-align:center;">
          <p style="margin:0;font-size:12px;color:#aaa;">
            HoloTuto — <a href="https://holotuto.com" style="color:#6c63ff;text-decoration:none;">holotuto.com</a>
          </p>
          <p style="margin:8px 0 0;font-size:11px;color:#666;">© {{{{Year}}}} GISEBS Inc. Tous droits réservés.</p>
        </div>
        <!-- holotuto-seed:{seedRevision} -->
        """;

    private static string Wrap(string body, int seedRevision = 2) => $"""
        <div style="font-family:Segoe UI,Arial,sans-serif;line-height:1.55;color:#1e293b;max-width:600px;margin:0 auto;background:#f4f4f4;padding:16px;">
          <div style="background:#ffffff;border-radius:10px;overflow:hidden;box-shadow:0 2px 10px rgba(0,0,0,0.08);">
            {BrandHeader}
            <div style="padding:28px 32px;">{body}</div>
            {BrandFooter(seedRevision)}
          </div>
        </div>
        """;

    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        new(
            TemplateCode: "RAW",
            Name: "HoloTuto — HTML brut (passe-plat)",
            SubjectTemplate: "{{Subject}}",
            HtmlBody: "{{Body}}<!-- holotuto-seed:2 -->",
            TextBody: "{{Body}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "INTERNAL_ALERT",
            Name: "HoloTuto — Alerte interne",
            SubjectTemplate: "{{Subject}}",
            HtmlBody: Wrap("<h2 style=\"margin:0 0 12px;color:#1a1a2e;\">{{Subject}}</h2><div>{{Body}}</div>"),
            TextBody: "{{Subject}} — {{Body}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "WELCOME",
            Name: "HoloTuto — Bienvenue parent",
            SubjectTemplate: "Bienvenue sur HoloTuto, {{FirstName}} !",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:22px;color:#1a1a2e;">Bienvenue {{FirstName}} !</h1>
                <p style="margin:0 0 16px;">Votre compte parent HoloTuto est prêt. Ajoutez le profil de votre enfant, choisissez une formule et lancez la première session.</p>
                <p style="margin:0 0 8px;font-weight:bold;">Prochaines étapes :</p>
                <ol style="margin:0 0 20px;padding-left:20px;color:#475569;">
                  <li>Ajoutez le profil de votre enfant</li>
                  <li>Choisissez une formule (à l'heure, pack ou abonnement)</li>
                  <li>Créez votre premier agenda d'étude</li>
                </ol>
                <p style="text-align:center;margin:24px 0;">
                  <a href="{{LoginUrl}}" style="background:#6c63ff;color:#fff;padding:12px 24px;text-decoration:none;border-radius:8px;font-weight:bold;display:inline-block;">Accéder à mon espace</a>
                </p>
                """),
            TextBody: "Bienvenue {{FirstName}} sur HoloTuto. Connectez-vous : {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "HoloTuto — Mot de passe temporaire",
            SubjectTemplate: "Réinitialisation de votre mot de passe HoloTuto",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#1a1a2e;">Mot de passe temporaire</h1>
                <p style="margin:0 0 12px;">Bonjour <strong>{{ParentName}}</strong>,</p>
                <p style="margin:0 0 16px;">Vous avez demandé la réinitialisation de votre mot de passe. Voici votre mot de passe temporaire :</p>
                <div style="background:#f8fafc;border:2px dashed #e74c3c;border-radius:8px;padding:18px;text-align:center;margin:0 0 16px;">
                  <span style="font-size:26px;font-weight:bold;letter-spacing:3px;font-family:monospace;color:#1a1a2e;">{{TempPassword}}</span>
                </div>
                <p style="margin:0 0 12px;color:#e74c3c;font-size:14px;">Ce mot de passe expire dans <strong>24 heures</strong>.</p>
                <p style="margin:0 0 8px;font-size:14px;color:#475569;"><strong>Comment procéder :</strong></p>
                <ol style="margin:0 0 16px;padding-left:20px;color:#475569;font-size:14px;">
                  <li>Connectez-vous avec ce mot de passe temporaire</li>
                  <li>Choisissez immédiatement un nouveau mot de passe</li>
                  <li>Il doit être différent de vos 3 derniers mots de passe</li>
                </ol>
                <p style="text-align:center;margin:20px 0;">
                  <a href="{{LoginUrl}}" style="background:#6c63ff;color:#fff;padding:12px 24px;text-decoration:none;border-radius:8px;font-weight:bold;display:inline-block;">Se connecter</a>
                </p>
                <p style="margin:0;font-size:13px;color:#94a3b8;">Si vous n'êtes pas à l'origine de cette demande, ignorez cet e-mail.</p>
                """),
            TextBody: "Bonjour {{ParentName}}, mot de passe temporaire : {{TempPassword}} (expire en 24h). {{LoginUrl}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "PAYMENT_CONFIRMATION",
            Name: "HoloTuto — Confirmation de paiement",
            SubjectTemplate: "Paiement confirmé — {{PlanLabel}}",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#065f46;">Paiement confirmé</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{ParentName}}</strong>,</p>
                <p style="margin:0 0 16px;">Nous avons bien reçu votre paiement. Voici le récapitulatif :</p>
                <table style="width:100%;border-collapse:collapse;font-size:14px;margin:0 0 16px;">
                  <tr><td style="padding:8px 0;color:#64748b;">Montant</td><td style="padding:8px 0;font-weight:bold;text-align:right;">{{Amount}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Date</td><td style="padding:8px 0;text-align:right;">{{Date}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Formule</td><td style="padding:8px 0;text-align:right;">{{PlanLabel}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Élève(s)</td><td style="padding:8px 0;text-align:right;">{{Students}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Heures / accès</td><td style="padding:8px 0;text-align:right;">{{HoursLine}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Référence</td><td style="padding:8px 0;text-align:right;font-family:monospace;font-size:12px;">{{PaymentRef}}</td></tr>
                </table>
                <p style="margin:0;font-size:14px;color:#475569;">Merci de votre confiance. Vous pouvez suivre vos factures dans l'espace parent.</p>
                """),
            TextBody: "Paiement confirmé {{Amount}} — {{PlanLabel}} pour {{Students}}. Réf. {{PaymentRef}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "SUBSCRIPTION_RENEWED",
            Name: "HoloTuto — Renouvellement abonnement",
            SubjectTemplate: "Votre abonnement HoloTuto a été renouvelé",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#1e3a8a;">Abonnement renouvelé</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{ParentName}}</strong>,</p>
                <p style="margin:0 0 16px;">Votre abonnement mensuel a été renouvelé avec succès.</p>
                <table style="width:100%;border-collapse:collapse;font-size:14px;margin:0 0 16px;">
                  <tr><td style="padding:8px 0;color:#64748b;">Élève(s)</td><td style="padding:8px 0;text-align:right;">{{Students}}</td></tr>
                  <tr><td style="padding:8px 0;color:#64748b;">Période</td><td style="padding:8px 0;text-align:right;">{{PeriodStart}} → {{PeriodEnd}}</td></tr>
                </table>
                <p style="margin:0;font-size:14px;color:#475569;">L'accès illimité reste actif pour la période indiquée.</p>
                """),
            TextBody: "Abonnement renouvelé pour {{Students}} du {{PeriodStart}} au {{PeriodEnd}}.",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "BALANCE_EXHAUSTED",
            Name: "HoloTuto — Solde d'heures épuisé",
            SubjectTemplate: "Session terminée pour {{StudentName}} — solde épuisé",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#92400e;">Solde d'heures épuisé</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{ParentName}}</strong>,</p>
                <p style="margin:0 0 16px;">La session d'étude de <strong>{{StudentName}}</strong> s'est terminée car la banque de temps est vide.</p>
                <p style="margin:0 0 16px;"><strong>Heures consommées cette session :</strong> {{HoursDebited}}h</p>
                <p style="text-align:center;margin:24px 0;">
                  <a href="{{BillingUrl}}" style="background:#6c63ff;color:#fff;padding:12px 24px;text-decoration:none;border-radius:8px;font-weight:bold;display:inline-block;">Recharger ou s'abonner</a>
                </p>
                """),
            TextBody: "Session terminée pour {{StudentName}} — solde épuisé ({{HoursDebited}}h). {{BillingUrl}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "TEACHER_INVITE",
            Name: "HoloTuto — Invitation enseignant",
            SubjectTemplate: "Invitation HoloTuto — suivi de {{StudentName}}",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#1a1a2e;">Invitation enseignant</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{TeacherName}}</strong>,</p>
                <p style="margin:0 0 16px;"><strong>{{ParentName}}</strong> vous invite à suivre les progrès de <strong>{{StudentName}}</strong> sur HoloTuto.</p>
                <p style="text-align:center;margin:24px 0;">
                  <a href="{{InviteUrl}}" style="background:#6c63ff;color:#fff;padding:12px 24px;text-decoration:none;border-radius:8px;font-weight:bold;display:inline-block;">Accepter l'invitation</a>
                </p>
                """),
            TextBody: "{{ParentName}} vous invite à suivre {{StudentName}}. {{InviteUrl}}",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "TEACHER_ACCEPTED",
            Name: "HoloTuto — Invitation acceptée",
            SubjectTemplate: "{{TeacherName}} a accepté votre invitation pour {{StudentName}}",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#065f46;">Invitation acceptée</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{ParentName}}</strong>,</p>
                <p style="margin:0 0 16px;">L'enseignant <strong>{{TeacherName}}</strong> ({{TeacherEmail}}) a accepté votre invitation et peut consulter les progrès de <strong>{{StudentName}}</strong>.</p>
                <p style="margin:0;font-size:14px;color:#475569;">Gérez les accès depuis l'onglet « Enseignants » de votre portail.</p>
                """),
            TextBody: "{{TeacherName}} a accepté l'invitation pour {{StudentName}}.",
            Language: "fr",
            SeedRevision: 2),

        new(
            TemplateCode: "TEACHER_REVOKED",
            Name: "HoloTuto — Accès enseignant révoqué",
            SubjectTemplate: "Accès révoqué pour le profil de {{StudentName}}",
            HtmlBody: Wrap("""
                <h1 style="margin:0 0 12px;font-size:20px;color:#991b1b;">Accès révoqué</h1>
                <p style="margin:0 0 16px;">Bonjour <strong>{{TeacherName}}</strong>,</p>
                <p style="margin:0 0 16px;">Votre accès au profil de <strong>{{StudentName}}</strong> a été révoqué par le parent.</p>
                <p style="margin:0;font-size:14px;color:#475569;">Si vous pensez qu'il s'agit d'une erreur, contactez le parent directement.</p>
                """),
            TextBody: "Votre accès au profil de {{StudentName}} a été révoqué.",
            Language: "fr",
            SeedRevision: 2),
    ];
}
