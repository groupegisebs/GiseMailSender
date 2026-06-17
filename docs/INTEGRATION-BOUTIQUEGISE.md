# Intégration SecureMail — BoutiqueGise (Agentia Market)

Ce document recense **tous les points d'envoi d'e-mails** dans l'application BoutiqueGise, la **configuration SecureMail** à préparer côté administrateur, et la **configuration BoutiqueGise** (appsettings / secrets / déploiement).

Voir aussi : [`API-CONSOMMATION.md`](API-CONSOMMATION.md) (référence API générique SecureMail).

---

## 1. Architecture actuelle

```
Événement métier (Identity, futur marketplace…)
        ↓
IEmailSender.SendEmailAsync(to, subject, htmlMessage)
        ↓
EmailSender (Services/Email/EmailSender.cs)
        ├─ 1. MailGateway configuré ? → POST /api/mail/send (SecureMail)
        ├─ 2. SendGridKey configuré ?  → SendGrid API
        └─ 3. Sinon                    → log warning [EMAIL SKIPPED]
```

**Priorité** : SecureMail (MailGateway) > SendGrid > aucun envoi (log uniquement).

**Point d'entrée unique** : `BoutiqueGise.Services.Email.EmailSender` implémente `Microsoft.AspNetCore.Identity.UI.Services.IEmailSender`.

---

## 2. Appels API SecureMail effectués par l'application

### Endpoint utilisé

| Propriété | Valeur |
|-----------|--------|
| URL production | `https://gisemailsender.gisebs.com` |
| Route | `POST /api/mail/send` |
| Authentification | `Authorization: Bearer {ApiKey}` |
| Client HTTP | `IHttpClientFactory` — nom `"MailGateway"` |

### Payload JSON envoyé

L'application utilise **un seul template générique** (`TransactionalTemplateCode`) et injecte le sujet + le corps HTML dynamiquement :

```json
{
  "clientCode": "BOUTIQUEGISE",
  "templateCode": "TRANSACTIONAL",
  "to": ["destinataire@example.com"],
  "subjectData": {
    "Subject": "Confirmez votre email — Agentia Market"
  },
  "bodyData": {
    "Subject": "Confirmez votre email — Agentia Market",
    "HtmlBody": "<p>Confirmez votre compte en cliquant <a href='https://...'>ici</a>.</p>"
  }
}
```

**Variables attendues dans le template SecureMail** :

| Variable | Source | Usage |
|----------|--------|--------|
| `{{Subject}}` | `subjectData` / `bodyData` | Sujet de l'e-mail |
| `{{HtmlBody}}` | `bodyData` | Corps HTML complet (liens, mise en forme) |

> En cas de clé identique, SecureMail fusionne `subjectData` et `bodyData` — `bodyData` l'emporte.

> **SecureMail** : syntaxe **`{{NomVariable}}` uniquement** (double accolades). Pas de triple accolades. Le HTML passé dans `HtmlBody` est inséré tel quel puis le document final est assaini (balises `<a>`, `<p>`, `<div>`, etc. autorisées).

### Fichiers code concernés (dépôt BoutiqueGise)

| Fichier | Rôle |
|---------|------|
| `Services/Email/EmailSender.cs` | Envoi MailGateway / SendGrid / fallback log |
| `Services/Email/MailGatewaySendModels.cs` | DTO requête / réponse API |
| `Configuration/MailGatewayOptions.cs` | Options `Email:MailGateway:*` |
| `Extensions/ServiceCollectionExtensions.cs` | HttpClient + enregistrement `IEmailSender` |

---

## 3. Inventaire des envois d'e-mails

### 3.1 En production aujourd'hui (code actif)

| # | Scénario | Déclencheur | Fichier | Destinataire | Sujet (ex. FR) | Corps |
|---|----------|-------------|---------|--------------|----------------|-------|
| 1 | **Confirmation de compte acheteur** | Inscription `/Identity/Account/Register` + `Security:RequireConfirmedEmail=true` + passerelle configurée | `Areas/Identity/Pages/Account/Register.cshtml.cs` | E-mail saisi à l'inscription | `Auth.Register.ConfirmEmailSubject` → *« Confirmez votre email — Agentia Market »* | `Auth.Register.ConfirmEmailBody` → lien HTML vers `/Identity/Account/ConfirmEmail` |

**Conditions d'envoi (inscription acheteur)** :

- `Security:AllowPublicRegistration` = `true`
- `Security:RequireConfirmedEmail` = `true` **et** au moins un provider e-mail configuré (MailGateway ou SendGrid)
- Si l'envoi échoue : l'application **confirme l'e-mail automatiquement** (fallback) et connecte l'utilisateur

**Clés de localisation** (toutes les langues dans `Localization/Defaults/*.yaml`) :

```yaml
Auth.Register.ConfirmEmailSubject: Confirmez votre email — Agentia Market
Auth.Register.ConfirmEmailBody: "Confirmez votre compte en cliquant <a href='{0}'>ici</a>."
```

---

### 3.2 Comportements liés à l'e-mail (sans envoi SecureMail)

| Scénario | Comportement actuel | Fichier |
|----------|---------------------|---------|
| **Inscription vendeur** (`/Vendor/Register` étape 1) | Si confirmation requise : **auto-confirmation** locale (pas d'e-mail envoyé) | `Services/SellerRegistrationService.cs` |
| **Mot de passe oublié** | Lien UI présent (`Login.cshtml` → `./ForgotPassword`) mais **page non implémentée** | — |
| **Réinitialisation mot de passe** | Non implémentée | — |
| **Préférence « Notifications par email »** | Stockée en profil (`UserProfile.EmailNotifications`) — **aucun envoi branché** | `Controllers/ProfileController.cs` |
| **Paiement / commande** | PayGateway gère le paiement ; **pas d'e-mail de confirmation commande** | `Services/PayGatewayPaymentService.cs` |
| **Approbation vendeur** | Audit log uniquement | `Services/SellerApprovalService.cs` |
| **Modération produit** | Audit log uniquement | `Services/ProductModerationService.cs` |
| **Abonnement vendeur 5 $/mois** | Acknowledgment UI ; pas d'e-mail | `VendorRegister` étape 4 |

---

### 3.3 Envois recommandés (non implémentés — à prévoir)

D'après le cahier des charges, les pages légales et les flux marketplace, voici les e-mails **à brancher** sur `IEmailSender` (ou des templates dédiés) :

| Priorité | Scénario | Destinataire | Template SecureMail suggéré |
|----------|----------|--------------|----------------------------|
| Haute | Mot de passe oublié / reset | Utilisateur | `RESET_PASSWORD` |
| Haute | Confirmation compte vendeur (inscription 5 étapes) | Candidat vendeur | `SELLER_CONFIRM_EMAIL` |
| Haute | Candidature vendeur soumise | Candidat | `SELLER_APPLICATION_RECEIVED` |
| Haute | Candidature approuvée / refusée | Candidat | `SELLER_APPROVED` / `SELLER_REJECTED` |
| Haute | Produit soumis / approuvé / refusé | Vendeur | `PRODUCT_SUBMITTED` / `PRODUCT_APPROVED` / `PRODUCT_REJECTED` |
| Moyenne | Confirmation de commande payée | Acheteur | `ORDER_CONFIRMATION` |
| Moyenne | Nouvelle vente (commission calculée) | Vendeur | `SELLER_SALE_NOTIFICATION` |
| Basse | Bienvenue post-inscription | Acheteur | `WELCOME` |
| Basse | Alerte admin (nouvelle candidature vendeur) | Super admin | `ADMIN_SELLER_PENDING` |

Pour l'instant, **un seul template** (`TRANSACTIONAL`) suffit pour le code existant. Les scénarios futurs peuvent soit réutiliser `TRANSACTIONAL`, soit ajouter des codes template dédiés dans `MailGatewayOptions` (évolution à prévoir dans le code BoutiqueGise).

---

## 4. Configuration SecureMail (administrateur)

Interface : [https://gisemailsender.gisebs.com](https://gisemailsender.gisebs.com)

### 4.1 Checklist admin SecureMail

| Étape | Menu SecureMail | Valeur recommandée |
|-------|-----------------|-------------------|
| 1 | **Applications** | Application `BOUTIQUEGISE` (créée automatiquement au démarrage) |
| | Code client | `BOUTIQUEGISE` |
| | Quotas | 2000/jour, 50000/mois (ajuster si besoin) |
| | Domaines autorisés | `agentiamarket.com`, `gmail.com`, etc. |
| | IP autorisées | IP sortante du serveur VPS BoutiqueGise (optionnel) |
| 2 | **Tokens API** | Générer un token lié à `BOUTIQUEGISE` — **copier immédiatement** |
| 3 | **Templates** | Vérifier les templates (créés automatiquement au démarrage, voir § 4.2) |
| | Code principal | `TRANSACTIONAL` (utilisé aujourd'hui par BoutiqueGise) |
| | Statut | **Actif** |
| 4 | **SMTP** | Configurer le relais SMTP (obligatoire pour l'envoi effectif) |

> Les templates listés ci-dessous sont **insérés automatiquement** au démarrage de SecureMail s'ils n'existent pas encore. Après déploiement, vérifiez-les dans le menu *Templates* et générez le token API.

### 4.2 Catalogue des templates (Agentia Market)

Créés par le seeder (`Data/BoutiqueGiseTemplates.cs`) — branding **Agentia Market** :

| Code | Nom | Variables | Usage BoutiqueGise |
|------|-----|-----------|-------------------|
| `TRANSACTIONAL` | Transactionnel générique | `Subject`, `HtmlBody` | **Actif** — confirmation e-mail acheteur |
| `WELCOME` | Bienvenue acheteur | `FirstName`, `DashboardLink` | Post-inscription (à brancher) |
| `RESET_PASSWORD` | Réinitialisation mot de passe | `FirstName`, `ResetLink` | ForgotPassword (à brancher) |
| `SELLER_CONFIRM_EMAIL` | Confirmation e-mail vendeur | `FirstName`, `ConfirmLink` | Inscription vendeur |
| `SELLER_APPLICATION_RECEIVED` | Candidature reçue | `FirstName`, `ShopName` | Après soumission candidature |
| `SELLER_APPROVED` | Candidature approuvée | `FirstName`, `ShopName`, `DashboardLink` | Approbation vendeur |
| `SELLER_REJECTED` | Candidature refusée | `FirstName`, `ShopName`, `Reason` | Refus vendeur |
| `PRODUCT_SUBMITTED` | Produit soumis | `FirstName`, `ProductName` | Modération produit |
| `PRODUCT_APPROVED` | Produit approuvé | `FirstName`, `ProductName`, `ProductLink` | Produit publié |
| `PRODUCT_REJECTED` | Produit refusé | `FirstName`, `ProductName`, `Reason` | Produit refusé |
| `ORDER_CONFIRMATION` | Confirmation commande | `FirstName`, `OrderNumber`, `OrderTotal`, `OrderLink` | Après paiement |
| `SELLER_SALE_NOTIFICATION` | Nouvelle vente | `FirstName`, `ProductName`, `OrderNumber`, `CommissionAmount` | Notification vendeur |
| `ADMIN_SELLER_PENDING` | Alerte admin | `SellerName`, `ShopName`, `ReviewLink` | Nouvelle candidature vendeur |

Exemple d'appel avec un template dédié (futur code BoutiqueGise) :

```json
{
  "clientCode": "BOUTIQUEGISE",
  "templateCode": "RESET_PASSWORD",
  "to": ["user@example.com"],
  "bodyData": {
    "FirstName": "Jean",
    "ResetLink": "https://agentiamarket.com/Identity/Account/ResetPassword?code=..."
  }
}
```

### 4.3 Modèle de template `TRANSACTIONAL`

**Code** : `TRANSACTIONAL`

**Sujet** :

```text
{{Subject}}
```

**Corps HTML** (exemple) :

```html
<div style="font-family: Arial, sans-serif; line-height: 1.5; color: #222; max-width: 600px; margin: 0 auto; padding: 24px;">
  <p style="margin-bottom: 24px;">
    <strong>Agentia Market</strong>
  </p>
  {{HtmlBody}}
  <hr style="border: none; border-top: 1px solid #eee; margin: 32px 0 16px;" />
  <p style="font-size: 12px; color: #666;">
    Cet e-mail a été envoyé par Agentia Market. Ne répondez pas directement à ce message.
  </p>
</div>
```

**Variables du template** :

| Variable | Exemple |
|----------|---------|
| `Subject` | Confirmez votre email — Agentia Market |
| `HtmlBody` | `<p>Confirmez… <a href="…">ici</a>.</p>` |

> Utiliser **`{{HtmlBody}}`** (double accolades). Le HTML injecté par BoutiqueGise (liens de confirmation, etc.) est rendu correctement dans le corps final.

### 4.4 Vérification

```bash
# Santé API (sans token)
curl -s https://gisemailsender.gisebs.com/api/health

# Test d'envoi
curl -X POST "https://gisemailsender.gisebs.com/api/mail/send" \
  -H "Authorization: Bearer VOTRE_TOKEN_API" \
  -H "Content-Type: application/json" \
  -d '{
    "clientCode": "BOUTIQUEGISE",
    "templateCode": "TRANSACTIONAL",
    "to": ["votre-email@example.com"],
    "subjectData": { "Subject": "Test Agentia Market" },
    "bodyData": {
      "Subject": "Test Agentia Market",
      "HtmlBody": "<p>Ceci est un test depuis BoutiqueGise.</p>"
    }
  }'
```

Réponse attendue : `200 OK` avec `"status": "Queued"`.

---

## 5. Configuration BoutiqueGise

### 5.1 appsettings.json (développement — structure)

```json
{
  "Security": {
    "RequireConfirmedEmail": true,
    "AllowPublicRegistration": true
  },
  "Email": {
    "SendGridKey": "",
    "FromEmail": "noreply@agentiamarket.com",
    "FromName": "Agentia Market",
    "MailGateway": {
      "BaseUrl": "https://gisemailsender.gisebs.com",
      "ApiKey": "",
      "ClientCode": "BOUTIQUEGISE",
      "TransactionalTemplateCode": "TRANSACTIONAL",
      "RequestTimeoutSeconds": 30
    }
  }
}
```

| Clé | Obligatoire | Description |
|-----|-------------|-------------|
| `Email:MailGateway:BaseUrl` | Oui | URL SecureMail |
| `Email:MailGateway:ApiKey` | Oui | Token API Bearer |
| `Email:MailGateway:ClientCode` | Oui | Doit correspondre au token (`BOUTIQUEGISE`) |
| `Email:MailGateway:TransactionalTemplateCode` | Oui | Code template actif (`TRANSACTIONAL`) |
| `Email:MailGateway:RequestTimeoutSeconds` | Non | Défaut 30 s |
| `Email:SendGridKey` | Non | Fallback si MailGateway absent |
| `Email:FromEmail` / `FromName` | Non* | Utilisés par SendGrid uniquement |

\* SecureMail utilise l'expéditeur configuré dans SMTP SecureMail, pas `FromEmail` BoutiqueGise.

### 5.2 Production

**`appsettings.Production.json`** (déployé — **sans secrets**) :

```json
"Email": {
  "MailGateway": {
    "BaseUrl": "https://gisemailsender.gisebs.com",
    "ClientCode": "BOUTIQUEGISE",
    "TransactionalTemplateCode": "TRANSACTIONAL"
  }
}
```

**Secrets à injecter** (ne jamais committer) :

| Méthode | Variable |
|---------|----------|
| User secrets (dev) | `Email:MailGateway:ApiKey` |
| systemd / fichier env (deploy) | `Email__MailGateway__ApiKey` |
| GitHub Actions (`deploy-gha.sh`) | `MAILGATEWAY_API_KEY` |

Exemple user secrets :

```powershell
dotnet user-secrets set "Email:MailGateway:ApiKey" "VOTRE_TOKEN" --project src/BoutiqueGise/BoutiqueGise.csproj
```

Exemple variables systemd :

```bash
Email__MailGateway__BaseUrl=https://gisemailsender.gisebs.com
Email__MailGateway__ApiKey=VOTRE_TOKEN
Email__MailGateway__ClientCode=BOUTIQUEGISE
Email__MailGateway__TransactionalTemplateCode=TRANSACTIONAL
```

### 5.3 Impact sur Identity

Si `Email:MailGateway:ApiKey` **n'est pas** renseigné :

- `IsEmailProviderConfigured()` retourne `false`
- `RequireConfirmedAccount` est **désactivé** automatiquement à l'inscription
- Les comptes sont confirmés sans e-mail

Si la clé **est** renseignée :

- L'inscription acheteur envoie l'e-mail de confirmation via SecureMail
- L'utilisateur doit cliquer le lien avant connexion (sauf échec d'envoi → auto-confirm fallback)

---

## 6. Flux détaillé — confirmation d'inscription acheteur

```
1. POST /Identity/Account/Register
2. UserManager.CreateAsync
3. Si RequireConfirmedAccount :
   a. GenerateEmailConfirmationTokenAsync
   b. URL callback → /Identity/Account/ConfirmEmail?userId=…&code=…
   c. IEmailSender.SendEmailAsync(email, subject, htmlBody)
   d. EmailSender → POST SecureMail /api/mail/send (template TRANSACTIONAL)
   e. Redirect → RegisterConfirmation
4. Utilisateur clique le lien → ConfirmEmail → EmailConfirmed = true
```

**Logs applicatifs en cas de succès** :

```text
Email mis en file via MailGateway pour {Email} — {MailCode} ({Status})
```

**Erreurs fréquentes SecureMail** :

| Erreur API | Cause probable |
|------------|----------------|
| `401 Invalid or expired API key` | Token absent, expiré ou mal injecté en prod |
| `Client code mismatch` | `ClientCode` ≠ application du token |
| `Template 'TRANSACTIONAL' not found or inactive` | Template manquant ou désactivé |
| `Quota exceeded` | Quota journalier/mensuel dépassé |
| `Invalid or unauthorized recipient domain` | Domaine destinataire non autorisé |
| E-mail `Queued` mais non reçu | SMTP non configuré côté SecureMail |

---

## 7. Récapitulatif rapide

```text
Application SecureMail  →  code BOUTIQUEGISE
Token API               →  Email:MailGateway:ApiKey (secret)
Template actif          →  TRANSACTIONAL (variables Subject, HtmlBody)
Endpoint                →  POST https://gisemailsender.gisebs.com/api/mail/send
Envoi actif dans l'app  →  Confirmation e-mail inscription acheteur uniquement
Fallback                →  SendGrid si MailGateway absent ; sinon log + skip
Pages Identity manquantes → ForgotPassword, ResetPassword (liens UI sans implémentation)
```

---

## 8. Prochaines étapes recommandées

1. **SecureMail** : vérifier application `BOUTIQUEGISE`, templates (auto-seed), token API, SMTP.
2. **Production** : injecter `Email__MailGateway__ApiKey` dans systemd / secrets CI.
3. **Test** : inscription d'un compte test sur `/Identity/Account/Register` → vérifier réception + lien de confirmation.
4. **Évolution code BoutiqueGise** (optionnel) :
   - Implémenter `ForgotPassword` / `ResetPassword` (Identity)
   - E-mails vendeur (soumission, approbation, refus)
   - E-mails commande / vente
   - Templates SecureMail dédiés par scénario

---

*Document d'intégration BoutiqueGise ↔ SecureMail Gateway — analyse des services `EmailSender`, Identity Register, configuration `Email:MailGateway`.*
