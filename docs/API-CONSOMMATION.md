# Consommer l'API SecureMail depuis une application externe

Ce document résume comment une application (SaaS, batch, microservice, etc.) envoie des e-mails via **SecureMail Gateway**.

---

## 1. Prérequis (côté administrateur)

Avant d'appeler l'API depuis votre code, un administrateur SecureMail doit :

1. **Créer une application cliente** (menu *Applications*)
   - Noter le **code client** (ex. `DEMO`, `MONAPP`)
   - Configurer les **quotas** (journalier / mensuel)
   - Optionnel : restreindre les **domaines** autorisés (`example.com, monentreprise.fr`)
   - Optionnel : restreindre les **adresses IP** autorisées

2. **Générer un token API** (menu *Tokens API*)
   - Associer le token à l'application cliente
   - **Copier le token immédiatement** : il n'est affiché qu'une seule fois
   - Le conserver dans un gestionnaire de secrets (variables d'environnement, Azure Key Vault, etc.)

3. **Créer un template actif** (menu *Templates*)
   - Noter le **code template** (ex. `WELCOME`, `RESET_PASSWORD`)
   - Le template contient des variables `{{NomVariable}}` remplacées à l'envoi

4. **Configurer le SMTP** (menu *SMTP*, admin uniquement)

---

## 2. URL de base

| Environnement | URL |
|---------------|-----|
| **Production** | **`https://gisemailsender.gisebs.com`** |
| Développement local | `https://localhost:5001` |

Toutes les routes API sont préfixées par `/api`.

**Vérifier que le service répond :**

```http
GET https://gisemailsender.gisebs.com/api/health
```

Réponse exemple :

```json
{
  "status": "Healthy",
  "timestamp": "2026-06-15T12:00:00Z",
  "service": "securemail-gateway",
  "listenPort": 5060
}
```

> `/api/health` est **public** (pas de token requis).

---

## 3. Authentification

Chaque requête sur `/api/*` (sauf `/api/health`) doit inclure le token API.

**Méthode 1 — en-tête Bearer (recommandé)**

```http
Authorization: Bearer VOTRE_TOKEN_API
```

**Méthode 2 — en-tête dédié**

```http
X-Api-Key: VOTRE_TOKEN_API
```

### Erreurs d'authentification

| Code HTTP | Signification |
|-----------|---------------|
| `401` | Token absent, invalide, expiré ou révoqué |
| `429` | Trop de requêtes (rate limit) |

Exemple de réponse `401` :

```json
{
  "error": "Invalid or expired API key."
}
```

---

## 4. Envoyer un e-mail

### Endpoint

```http
POST https://gisemailsender.gisebs.com/api/mail/send
Content-Type: application/json
Authorization: Bearer VOTRE_TOKEN_API
```

### Corps de la requête

| Champ | Obligatoire | Description |
|-------|-------------|-------------|
| `clientCode` | Oui | Code de l'application cliente (doit correspondre au token) |
| `templateCode` | Oui | Code du template actif |
| `to` | Oui | Liste des destinataires (au moins 1) |
| `cc` | Non | Copie |
| `bcc` | Non | Copie cachée |
| `subjectData` | Non | Variables pour le **sujet** du template |
| `bodyData` | Non | Variables pour le **corps** du template |
| `attachments` | Non | Pièces jointes (base64, max 10 Mo chacune) |
| `priority` | Non | `0` = Low, `1` = Normal (défaut), `2` = High |
| `callbackUrl` | Non | URL appelée quand l'e-mail est envoyé ou en échec |

### Variables des templates

Les templates utilisent la syntaxe `{{NomVariable}}`.

Exemple de template `WELCOME` :

- Sujet : `Bienvenue {{FirstName}} chez {{CompanyName}}`
- Corps HTML : `<p>Bonjour {{FirstName}}, votre compte est prêt.</p>`

À l'appel API, passez les valeurs :

```json
{
  "subjectData": { "FirstName": "Jean", "CompanyName": "Acme" },
  "bodyData": { "FirstName": "Jean", "CompanyName": "Acme" }
}
```

> `subjectData` et `bodyData` sont fusionnés. En cas de clé identique, `bodyData` l'emporte.
> Toutes les variables utilisees dans le template (sujet + html + texte) sont obligatoires avec une valeur non vide. Sinon l'API retourne `400`.

### Exemple complet (curl)

```bash
curl -X POST "https://gisemailsender.gisebs.com/api/mail/send" \
  -H "Authorization: Bearer VOTRE_TOKEN_API" \
  -H "Content-Type: application/json" \
  -d '{
    "clientCode": "DEMO",
    "templateCode": "WELCOME",
    "to": ["client@example.com"],
    "cc": [],
    "bcc": [],
    "subjectData": {
      "FirstName": "Jean",
      "CompanyName": "Acme"
    },
    "bodyData": {
      "FirstName": "Jean",
      "CompanyName": "Acme"
    },
    "priority": 1,
    "callbackUrl": "https://votre-app.com/webhooks/mail"
  }'
```

### Réponse succès (`200 OK`)

```json
{
  "success": true,
  "mailCode": "MAIL-2026-000145",
  "trackingId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "status": "Queued"
}
```

| Champ | Description |
|-------|-------------|
| `mailCode` | Identifiant lisible unique (`MAIL-AAAA-NNNNNN`) |
| `trackingId` | GUID interne pour le suivi |
| `status` | `Queued` = mis en file d'attente (envoi asynchrone) |

### Comportement si le template n'existe pas

Si `templateCode` n'existe pas encore, SecureMail crée automatiquement un template actif avec un contenu brouillon, puis traite l'envoi.

Le template auto-créé doit ensuite être édité dans l'interface d'administration (*Templates*).

### Réponse erreur (`400 Bad Request`)

```json
{
  "success": false,
  "error": "Template 'WELCOME' not found or inactive."
}
```

Exemple d'erreur si des variables de template sont absentes ou vides :

```json
{
  "success": false,
  "error": "Missing required template variables. Required: [CompanyName, FirstName]. Missing or empty: [CompanyName]. Provide values in subjectData/bodyData."
}
```

Erreurs fréquentes :

| Message | Cause |
|---------|-------|
| `Client code mismatch.` | Le `clientCode` ne correspond pas à l'application du token |
| `Client application is disabled.` | Application désactivée dans l'admin |
| `Quota exceeded.` | Quota journalier ou mensuel dépassé |
| `Invalid or unauthorized recipient domain.` | E-mail invalide ou domaine non autorisé |
| `Template 'XXX' is inactive.` | Template existant mais inactif |
| `Missing required template variables...` | Une ou plusieurs variables du template sont absentes ou ont une valeur vide |
| `Attachment exceeds 10 MB limit.` | Pièce jointe trop volumineuse |

---

## 5. Pièces jointes

```json
{
  "attachments": [
    {
      "fileName": "facture.pdf",
      "contentType": "application/pdf",
      "base64Content": "JVBERi0xLjQK..."
    }
  ]
}
```

- Contenu encodé en **Base64**
- Taille max : **10 Mo** par fichier

---

## 6. Callback (webhook)

Si `callbackUrl` est fourni, SecureMail envoie un **POST JSON** à cette URL lorsque l'e-mail est **envoyé** ou en **échec**.

```json
{
  "mailCode": "MAIL-2026-000145",
  "trackingId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "status": "Sent",
  "sentAt": "2026-06-15T12:05:00Z",
  "failedAt": null,
  "errorMessage": null
}
```

Valeurs possibles de `status` : `Sent`, `Failed`, etc.

> Votre endpoint doit répondre rapidement. Le callback est best-effort (pas de retry automatique documenté).

---

## 7. Exemples par langage

### C# (.NET)

```csharp
using System.Net.Http.Json;

var client = new HttpClient();
client.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("SECUREMAIL_API_TOKEN"));

var request = new
{
    clientCode = "DEMO",
    templateCode = "WELCOME",
    to = new[] { "client@example.com" },
    subjectData = new Dictionary<string, string>
    {
        ["FirstName"] = "Jean",
        ["CompanyName"] = "Acme"
    },
    bodyData = new Dictionary<string, string>
    {
        ["FirstName"] = "Jean",
        ["CompanyName"] = "Acme"
    }
};

var response = await client.PostAsJsonAsync(
    "https://gisemailsender.gisebs.com/api/mail/send", request);

response.EnsureSuccessStatusCode();
var result = await response.Content.ReadFromJsonAsync<SendMailResponse>();
Console.WriteLine($"E-mail en file : {result.MailCode}");
```

### Python

```python
import os
import requests

response = requests.post(
    "https://gisemailsender.gisebs.com/api/mail/send",
    headers={
        "Authorization": f"Bearer {os.environ['SECUREMAIL_API_TOKEN']}",
        "Content-Type": "application/json",
    },
    json={
        "clientCode": "DEMO",
        "templateCode": "WELCOME",
        "to": ["client@example.com"],
        "subjectData": {"FirstName": "Jean", "CompanyName": "Acme"},
        "bodyData": {"FirstName": "Jean", "CompanyName": "Acme"},
    },
    timeout=30,
)
response.raise_for_status()
print(response.json())
```

### JavaScript (Node.js / fetch)

```javascript
const response = await fetch("https://gisemailsender.gisebs.com/api/mail/send", {
  method: "POST",
  headers: {
    Authorization: `Bearer ${process.env.SECUREMAIL_API_TOKEN}`,
    "Content-Type": "application/json",
  },
  body: JSON.stringify({
    clientCode: "DEMO",
    templateCode: "WELCOME",
    to: ["client@example.com"],
    subjectData: { FirstName: "Jean", CompanyName: "Acme" },
    bodyData: { FirstName: "Jean", CompanyName: "Acme" },
  }),
});

if (!response.ok) throw new Error(await response.text());
const result = await response.json();
console.log("Mail en file :", result.mailCode);
```

---

## 8. Limites et bonnes pratiques

| Règle | Valeur |
|-------|--------|
| Rate limit API | **60 requêtes / minute** par IP sur `/api/*` |
| Quotas | Par application (config admin) |
| Envoi | **Asynchrone** : `Queued` ≠ `Sent` immédiatement |
| Token | Ne jamais l'exposer côté navigateur (front-end public) |
| Secrets | Variables d'environnement, jamais dans le code source |
| Rotation | En cas de fuite, révoquer et regénérer le token (menu *Tokens API*) |

### Flux recommandé dans votre application

```
1. Événement métier (inscription, commande, alerte…)
2. POST /api/mail/send avec template + variables
3. Stocker mailCode + trackingId en base (optionnel)
4. Recevoir le callback sur callbackUrl (optionnel)
5. Consulter l'historique dans SecureMail (menu E-mails) si besoin
```

---

## 9. Récapitulatif rapide

```text
Token API     →  menu SecureMail : Tokens API
clientCode    →  menu SecureMail : Applications
templateCode  →  menu SecureMail : Templates
Endpoint      →  POST https://gisemailsender.gisebs.com/api/mail/send
Auth          →  Authorization: Bearer <token>
Variables     →  {{Nom}} dans le template, valeurs dans subjectData / bodyData
Suivi         →  mailCode (MAIL-2026-000145) ou trackingId (GUID)
```

---

## 10. Support / dépannage

| Problème | Action |
|----------|--------|
| `401` | Vérifier le token, qu'il n'est pas révoqué |
| `400 Client code mismatch` | Aligner `clientCode` avec l'application du token |
| `400 Quota exceeded` | Augmenter le quota ou attendre le lendemain / mois suivant |
| E-mail en file mais non reçu | Vérifier SMTP (admin) et l'historique (*E-mails*) |
| `429` | Réduire la cadence ou implémenter un retry avec backoff |

Logs et audit disponibles dans l'interface SecureMail (*Audit*, *E-mails*).

---

## 11. Intégrations clientes documentées

| Application | Document |
|-------------|----------|
| BoutiqueGise (Agentia Market) | [`INTEGRATION-BOUTIQUEGISE.md`](INTEGRATION-BOUTIQUEGISE.md) |

