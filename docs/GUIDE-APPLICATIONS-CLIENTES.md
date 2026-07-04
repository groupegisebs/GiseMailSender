# Guide d'utilisation - Applications clientes

Ce guide est destiné aux équipes qui intègrent leur application avec **SecureMail Gateway** pour envoyer des e-mails transactionnels.

Pour la référence technique complète, voir `docs/API-CONSOMMATION.md`.

---

## 1) Ce que votre équipe doit recevoir

Avant de commencer, votre équipe doit obtenir ces 4 informations :

- `baseUrl` (ex: `https://gisemailsender.gisebs.com`)
- `clientCode` (ex: `DEMO`, `BOUTIQUEGISE`)
- `templateCode` à utiliser
- `apiToken` (Bearer ou X-Api-Key)

Sans ces 4 éléments, l'appel API ne peut pas fonctionner.

---

## 2) Flux standard d'envoi

1. Votre application déclenche un événement métier (inscription, commande, alerte).
2. Elle appelle `POST /api/mail/send`.
3. SecureMail valide le token, le client, le template et les destinataires.
4. Le message est mis en file (`status = Queued`).
5. Le service SMTP envoie l'e-mail.
6. Optionnel : un callback webhook est envoyé à votre système.

---

## 3) Appel minimal (copier-coller)

```bash
curl -X POST "https://gisemailsender.gisebs.com/api/mail/send" \
  -H "Authorization: Bearer VOTRE_TOKEN_API" \
  -H "Content-Type: application/json" \
  -d '{
    "clientCode": "DEMO",
    "templateCode": "WELCOME",
    "to": ["client@example.com"],
    "subjectData": { "FirstName": "Jean" },
    "bodyData": { "FirstName": "Jean" }
  }'
```

Réponse attendue :

```json
{
  "success": true,
  "mailCode": "MAIL-2026-000145",
  "trackingId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "status": "Queued"
}
```

Exigence importante :

- Les variables présentes dans le template (`{{NomVariable}}`) doivent etre fournies avec une valeur non vide dans `subjectData` et/ou `bodyData`.
- `subjectData` et `bodyData` sont fusionnes. En cas de meme cle, `bodyData` ecrase `subjectData`.

Si le `templateCode` n'existe pas encore, le service crée automatiquement un template brouillon actif, puis l'envoi continue. Un administrateur peut ensuite l'éditer dans *Templates*.

---

## 3bis) Variables disponibles dans les templates

Les templates proposent un catalogue riche de variables **recommandées** couvrant les cas
d'usage transactionnels courants (inscription, mot de passe oublié, abonnement, commande,
livraison, facture, etc.). Insérez-les avec la syntaxe `{{NomVariable}}` puis fournissez
la valeur dans `subjectData` / `bodyData` lors de l'appel API.

| Catégorie | Variables |
|-----------|-----------|
| Identité / Compte | `FirstName`, `LastName`, `FullName`, `UserName`, `Email`, `PhoneNumber`, `AccountId`, `CompanyName` |
| Authentification / Sécurité | `ResetLink`, `ConfirmLink`, `VerificationCode`, `LoginLink`, `ExpiryTime`, `IpAddress`, `DeviceInfo`, `SupportEmail` |
| Abonnement | `SubscriptionName`, `PlanName`, `TrialEndDate`, `RenewalDate`, `SubscriptionStatus`, `BillingCycle`, `ManageSubscriptionLink`, `CancelLink` |
| Commandes (e-commerce) | `OrderId`, `OrderNumber`, `OrderDate`, `OrderStatus`, `OrderLink`, `OrderTotal`, `Currency`, `Subtotal`, `ShippingCost`, `TaxAmount`, `DiscountAmount`, `PromoCode` |
| Produits / Article | `ProductName`, `ProductLink`, `Quantity` |
| Livraison | `TrackingNumber`, `TrackingLink`, `Carrier`, `EstimatedDelivery`, `ShippingAddress`, `DeliveryDate` |
| Facturation / Facture | `InvoiceId`, `InvoiceNumber`, `InvoiceDate`, `InvoiceLink`, `Amount`, `DueDate`, `PaymentMethod`, `PaymentStatus`, `ReceiptLink` |
| Boutique / Marque / Générique | `StoreName`, `StoreLink`, `WebsiteUrl`, `LogoUrl`, `UnsubscribeLink`, `PrivacyPolicyLink`, `Year`, `Message`, `Title`, `CtaLink`, `CtaLabel` |

Points importants :

- Ce catalogue est un **ensemble recommandé**, pas une liste exclusive : vous (ou la génération IA) pouvez aussi utiliser des **variables personnalisées** `{{NomVariable}}` hors catalogue quand le cas d'usage l'exige.
- Une variable personnalisée doit être un identifiant valide (lettres, chiffres, underscore, en PascalCase, commençant par une lettre) et n'est jamais supprimée si elle est bien formée.
- Toute variable réellement utilisée (catalogue ou personnalisée) reste **obligatoire** à l'envoi : fournissez-lui une valeur non vide dans `subjectData` / `bodyData`.
- Il n'existe **pas** de syntaxe de boucle/liste. Pour lister plusieurs articles, composez le HTML directement dans le template ou envoyez des valeurs déjà formatées.
- Les noms existants (`FirstName`, `LastName`, `CompanyName`, `Email`, `ResetLink`, `OrderId`, `Amount`, `InvoiceDate`, `Message`) restent valides : les anciens templates continuent de fonctionner.

---

## 4) Checklist d'onboarding (équipe cliente)

## Etape A - Authentification

- [ ] Stocker le token en variable d'environnement
- [ ] Ne jamais exposer le token côté front-end public
- [ ] Envoyer `Authorization: Bearer <token>`

## Etape B - Mapping template

- [ ] Documenter les variables attendues pour chaque `templateCode`
- [ ] Vérifier que toutes les variables sont bien fournies (`{{FirstName}}`, etc.)
- [ ] Versionner les changements de payload côté application cliente

## Etape C - Fiabilité

- [ ] Logger `mailCode` et `trackingId` dans votre application
- [ ] Gérer les erreurs HTTP (`400/401/429`)
- [ ] Mettre en place retry avec backoff en cas de `429` ou erreurs réseau

---

## 5) Rotation de token (sans interruption)

Procédure recommandée :

1. Générer un nouveau token dans SecureMail.
2. Mettre à jour la variable d'environnement dans toutes les apps clientes.
3. Redéployer/restart les apps.
4. Tester un envoi.
5. Révoquer l'ancien token.

---

## 6) Erreurs fréquentes et actions

| Erreur | Cause probable | Action |
|---|---|---|
| `401 Invalid or expired API key.` | Token absent/invalide/expiré | Vérifier le token et sa révocation |
| `400 Client code mismatch.` | `clientCode` différent de celui du token | Aligner le `clientCode` |
| `400 Template 'XXX' not found or inactive.` | Template absent/inactif | Vérifier le code template et son statut |
| `400 Missing required template variables...` | Variables du template absentes ou vides dans `subjectData`/`bodyData` | Fournir toutes les variables requises avec une valeur non vide |
| `400 Quota exceeded.` | Quota journalier/mensuel atteint | Ajuster quotas ou attendre reset |
| `429` | Trop de requêtes | Réduire cadence + retry backoff |

Exemple d'erreur :

```json
{
  "success": false,
  "error": "Missing required template variables. Required: [CompanyName, FirstName]. Missing or empty: [CompanyName]. Provide values in subjectData/bodyData."
}
```

---

## 7) Bonnes pratiques de production

- Utiliser des timeouts HTTP explicites (ex: 30s).
- Implémenter idempotence côté métier si nécessaire.
- Centraliser les logs d'échec d'envoi.
- Surveiller les taux d'erreurs et la latence.
- Tester chaque nouveau template avant release.

---

## 8) Contrat d'intégration recommandé

Pour chaque application cliente, maintenir un mini-document :

- `clientCode`
- liste des `templateCode` utilisés
- variables requises par template
- propriétaire technique
- contact opérationnel

---

## 9) Support opérationnel

En cas de problème, fournir systématiquement :

- timestamp de l'appel
- `clientCode`
- `templateCode`
- `mailCode` et `trackingId` (si disponibles)
- payload sans données sensibles

Ces éléments réduisent fortement le temps de diagnostic.
