using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Data;

/// <summary>
/// Données immuables d'un template à insérer en base (sans identité EF).
/// </summary>
public sealed record EmailTemplateSeed(
    string TemplateCode,
    string Name,
    string SubjectTemplate,
    string HtmlBody,
    string? TextBody,
    string Language = "fr",
    bool IsActive = true)
{
    public EmailTemplate ToEntity() => new()
    {
        TemplateCode = TemplateCode,
        Name = Name,
        SubjectTemplate = SubjectTemplate,
        HtmlBody = HtmlBody,
        TextBody = TextBody,
        Language = Language,
        Version = 1,
        IsActive = IsActive
    };
}

/// <summary>
/// Templates e-mail pour l'intégration BoutiqueGise / Agentia Market.
/// Insérés au démarrage s'ils n'existent pas encore (par TemplateCode).
/// </summary>
public static class BoutiqueGiseTemplates
{
    private const string BrandHeader = """
        <p style="margin:0 0 24px;font-size:18px;font-weight:bold;color:#1e40af;">Agentia Market</p>
        """;

    private const string BrandFooter = """
        <hr style="border:none;border-top:1px solid #eee;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#666;margin:0;">
          Cet e-mail a été envoyé par Agentia Market. Ne répondez pas directement à ce message.
        </p>
        """;

    private static string Wrap(string body) => $"""
        <div style="font-family:Arial,sans-serif;line-height:1.5;color:#222;max-width:600px;margin:0 auto;padding:24px;">
          {BrandHeader}
          {body}
          {BrandFooter}
        </div>
        """;

    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
        new(
            TemplateCode: "TRANSACTIONAL",
            Name: "Agentia — Transactionnel générique",
            SubjectTemplate: "{{Subject}}",
            HtmlBody: Wrap("{{HtmlBody}}"),
            TextBody: "{{Subject}}"),
        new(
            TemplateCode: "WELCOME",
            Name: "Agentia — Bienvenue acheteur",
            SubjectTemplate: "Bienvenue {{FirstName}} — Agentia Market",
            HtmlBody: Wrap("""
                <h1 style="color:#1e40af;margin:0 0 16px;">Bienvenue {{FirstName}} !</h1>
                <p>Votre compte Agentia Market est prêt. Découvrez des milliers de produits locaux.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{DashboardLink}}" style="background:#2563eb;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Accéder à mon compte</a>
                </p>
                """),
            TextBody: "Bienvenue {{FirstName}} sur Agentia Market. {{DashboardLink}}"),
        new(
            TemplateCode: "RESET_PASSWORD",
            Name: "Agentia — Réinitialisation mot de passe",
            SubjectTemplate: "Réinitialisation de votre mot de passe — Agentia Market",
            HtmlBody: Wrap("""
                <h2 style="color:#1e40af;margin:0 0 16px;">Réinitialisation du mot de passe</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez demandé à réinitialiser votre mot de passe. Cliquez sur le bouton ci-dessous :</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ResetLink}}" style="background:#2563eb;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Réinitialiser mon mot de passe</a>
                </p>
                <p style="font-size:13px;color:#64748b;">Si vous n'êtes pas à l'origine de cette demande, ignorez cet e-mail.</p>
                """),
            TextBody: "Bonjour {{FirstName}}, réinitialisez votre mot de passe : {{ResetLink}}"),
        new(
            TemplateCode: "SELLER_CONFIRM_EMAIL",
            Name: "Agentia — Confirmation e-mail vendeur",
            SubjectTemplate: "Confirmez votre e-mail vendeur — Agentia Market",
            HtmlBody: Wrap("""
                <h2 style="color:#1e40af;margin:0 0 16px;">Confirmation de votre compte vendeur</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Confirmez votre adresse e-mail pour poursuivre votre inscription vendeur :</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ConfirmLink}}" style="background:#2563eb;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Confirmer mon e-mail</a>
                </p>
                """),
            TextBody: "Confirmez votre e-mail vendeur : {{ConfirmLink}}"),
        new(
            TemplateCode: "SELLER_APPLICATION_RECEIVED",
            Name: "Agentia — Candidature vendeur reçue",
            SubjectTemplate: "Candidature vendeur reçue — {{ShopName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#1e40af;margin:0 0 16px;">Candidature enregistrée</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Nous avons bien reçu votre candidature pour la boutique <strong>{{ShopName}}</strong>.</p>
                <p>Notre équipe l'examinera sous 2 à 5 jours ouvrables. Vous recevrez un e-mail dès qu'une décision sera prise.</p>
                """),
            TextBody: "Candidature reçue pour {{ShopName}}. Examen sous 2 à 5 jours."),
        new(
            TemplateCode: "SELLER_APPROVED",
            Name: "Agentia — Candidature vendeur approuvée",
            SubjectTemplate: "Félicitations ! Votre boutique {{ShopName}} est approuvée",
            HtmlBody: Wrap("""
                <h2 style="color:#16a34a;margin:0 0 16px;">Boutique approuvée</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre candidature pour <strong>{{ShopName}}</strong> a été <strong>approuvée</strong>. Vous pouvez maintenant publier vos produits.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{DashboardLink}}" style="background:#16a34a;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Accéder à mon espace vendeur</a>
                </p>
                """),
            TextBody: "Boutique {{ShopName}} approuvée. Espace vendeur : {{DashboardLink}}"),
        new(
            TemplateCode: "SELLER_REJECTED",
            Name: "Agentia — Candidature vendeur refusée",
            SubjectTemplate: "Décision concernant votre candidature — {{ShopName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 16px;">Candidature non retenue</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Après examen, votre candidature pour <strong>{{ShopName}}</strong> n'a pas été retenue.</p>
                <p><strong>Motif :</strong> {{Reason}}</p>
                <p style="font-size:13px;color:#64748b;">Pour toute question, contactez le support Agentia Market.</p>
                """),
            TextBody: "Candidature {{ShopName}} refusée. Motif : {{Reason}}"),
        new(
            TemplateCode: "PRODUCT_SUBMITTED",
            Name: "Agentia — Produit soumis à modération",
            SubjectTemplate: "Produit soumis — {{ProductName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#1e40af;margin:0 0 16px;">Produit en modération</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre produit <strong>{{ProductName}}</strong> a été soumis et est en cours de modération.</p>
                <p>Vous serez notifié dès qu'il sera approuvé ou si des modifications sont nécessaires.</p>
                """),
            TextBody: "Produit {{ProductName}} soumis à modération."),
        new(
            TemplateCode: "PRODUCT_APPROVED",
            Name: "Agentia — Produit approuvé",
            SubjectTemplate: "Produit approuvé — {{ProductName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#16a34a;margin:0 0 16px;">Produit publié</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre produit <strong>{{ProductName}}</strong> a été <strong>approuvé</strong> et est visible sur la marketplace.</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ProductLink}}" style="background:#2563eb;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Voir le produit</a>
                </p>
                """),
            TextBody: "Produit {{ProductName}} approuvé : {{ProductLink}}"),
        new(
            TemplateCode: "PRODUCT_REJECTED",
            Name: "Agentia — Produit refusé",
            SubjectTemplate: "Produit refusé — {{ProductName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#dc2626;margin:0 0 16px;">Produit non publié</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre produit <strong>{{ProductName}}</strong> n'a pas été approuvé.</p>
                <p><strong>Motif :</strong> {{Reason}}</p>
                <p>Modifiez votre fiche produit et soumettez-la à nouveau.</p>
                """),
            TextBody: "Produit {{ProductName}} refusé. Motif : {{Reason}}"),
        new(
            TemplateCode: "ORDER_CONFIRMATION",
            Name: "Agentia — Confirmation de commande",
            SubjectTemplate: "Commande {{OrderNumber}} confirmée — Agentia Market",
            HtmlBody: Wrap("""
                <h2 style="color:#1e40af;margin:0 0 16px;">Merci pour votre commande</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Votre commande <strong>{{OrderNumber}}</strong> a été confirmée.</p>
                <p><strong>Montant total :</strong> {{OrderTotal}}</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{OrderLink}}" style="background:#2563eb;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Suivre ma commande</a>
                </p>
                """),
            TextBody: "Commande {{OrderNumber}} confirmée. Total : {{OrderTotal}}. {{OrderLink}}"),
        new(
            TemplateCode: "SELLER_SALE_NOTIFICATION",
            Name: "Agentia — Nouvelle vente vendeur",
            SubjectTemplate: "Nouvelle vente — commande {{OrderNumber}}",
            HtmlBody: Wrap("""
                <h2 style="color:#16a34a;margin:0 0 16px;">Nouvelle vente</h2>
                <p>Bonjour {{FirstName}},</p>
                <p>Vous avez vendu <strong>{{ProductName}}</strong> (commande {{OrderNumber}}).</p>
                <p><strong>Commission plateforme :</strong> {{CommissionAmount}}</p>
                """),
            TextBody: "Vente {{ProductName}} — commande {{OrderNumber}}. Commission : {{CommissionAmount}}"),
        new(
            TemplateCode: "ADMIN_SELLER_PENDING",
            Name: "Agentia — Alerte admin candidature vendeur",
            SubjectTemplate: "Nouvelle candidature vendeur — {{ShopName}}",
            HtmlBody: Wrap("""
                <h2 style="color:#b45309;margin:0 0 16px;">Candidature vendeur en attente</h2>
                <p>Une nouvelle candidature vendeur nécessite votre attention.</p>
                <p><strong>Vendeur :</strong> {{SellerName}}<br /><strong>Boutique :</strong> {{ShopName}}</p>
                <p style="text-align:center;margin:28px 0;">
                  <a href="{{ReviewLink}}" style="background:#b45309;color:#fff;padding:12px 24px;text-decoration:none;border-radius:6px;font-weight:bold;">Examiner la candidature</a>
                </p>
                """),
            TextBody: "Candidature vendeur {{SellerName}} / {{ShopName}} — {{ReviewLink}}")
    ];
}
