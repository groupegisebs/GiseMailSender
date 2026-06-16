# SecureMail Gateway

Passerelle sécurisée d'envoi d'e-mails transactionnels pour applications SaaS.

## Stack technique

- ASP.NET Core 10 MVC + API REST (.NET 10 — SDK installé ; compatible conceptuellement avec .NET 9)
- PostgreSQL + Entity Framework Core
- Hangfire (file d'attente d'envoi)
- Serilog (logs)
- Bootstrap 5 + Summernote (éditeur visuel gratuit, sans clé API)
- Identity (rôles Admin / Developer / Viewer)
- API Key / Bearer Token
- Prometheus (`/metrics`) + Health (`/health`)
- Rate limiting (AspNetCoreRateLimit)

## Structure du projet

```
src/SecureMailGateway/
├── Controllers/          # MVC administration
├── Controllers/Api/      # API REST sécurisée
├── Data/                 # DbContext, migrations, seed
├── Middleware/           # Auth API Key, logging appels
├── Models/Entities/      # Entités EF Core
├── Services/             # Logique métier
├── Views/                # Interface Razor
└── wwwroot/              # Assets statiques
```

## Démarrage local

### Prérequis

- .NET 10 SDK
- PostgreSQL 14+

### Configuration

Copiez `appsettings.Development.json` ou définissez la variable d'environnement :

```bash
export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=SecureMailGateway;Username=postgres;Password=postgres"
export Seed__AdminPassword="VotreMotDePasseFort!"
```

### Mettre à jour la base avec EF Core

La base et le schéma sont gérés **uniquement par les migrations EF Core** (pas de script SQL manuel).

```powershell
cd src/SecureMailGateway

# Définir la connexion (mot de passe réel requis)
$env:ConnectionStrings__DefaultConnection = "Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=VOTRE_MOT_DE_PASSE"

# Crée la base si elle n'existe pas + applique toutes les migrations
dotnet ef database update
```

Commandes utiles :

```powershell
# Créer une nouvelle migration après modification des entités
dotnet ef migrations add NomDeLaMigration --output-dir Data/Migrations

# Voir l'état des migrations
dotnet ef migrations list
```

### Lancer l'application

```powershell
dotnet run --no-launch-profile
```

Interface : `https://localhost:5001`  
Compte admin par défaut : `admin@securemail.local` / `ChangeMe!SecureMail2026` (à changer immédiatement)

## API — Envoi d'e-mail

### Endpoint

`POST /api/mail/send`

### Authentification

```http
Authorization: Bearer VOTRE_API_KEY
```

ou

```http
X-Api-Key: VOTRE_API_KEY
```

### Exemple curl

```bash
curl -X POST "https://votre-serveur/api/mail/send" \
  -H "Authorization: Bearer VOTRE_API_KEY" \
  -H "Content-Type: application/json" \
  -d '{
    "clientCode": "DEMO",
    "templateCode": "WELCOME",
    "to": ["client@example.com"],
    "cc": [],
    "bcc": [],
    "subjectData": { "FirstName": "Jean", "CompanyName": "Acme" },
    "bodyData": { "FirstName": "Jean", "CompanyName": "Acme" },
    "priority": 1,
    "callbackUrl": "https://votre-app.com/webhooks/mail"
  }'
```

### Réponse

```json
{
  "success": true,
  "mailCode": "MAIL-2026-000001",
  "trackingId": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
  "status": "Queued"
}
```

## Code unique MAIL-YYYY-NNNNNN

Chaque e-mail reçoit un identifiant lisible `MAIL-2026-000145`, enregistré en base, logs, audit, callbacks et interface admin.

## Sécurité

| Mesure | Implémentation |
|--------|----------------|
| HTTPS | Obligatoire en production (HSTS) |
| API keys | Hashées (PasswordHasher), jamais en clair en BDD |
| Rotation tokens | Interface admin + audit |
| Rate limiting | 60 req/min sur `/api/*` |
| Restriction IP | Par application cliente (optionnel) |
| Validation | DataAnnotations + sanitization HTML (HtmlSanitizer) |
| Audit | Toutes actions sensibles journalisées |
| Rôles | Admin, Developer, Viewer |
| Verrouillage | 5 tentatives → 15 min (Identity) |
| Secrets SMTP | Chiffrés via Data Protection API |
| MFA | Champ `MfaEnabled` sur utilisateur (extensible TOTP) |

**Ne jamais committer** de mots de passe réels. Utilisez des variables d'environnement ou un gestionnaire de secrets.

## Déploiement (GitHub Actions sur `main`)

Chaque **push sur `main`** déploie automatiquement vers `51.79.53.197`.

Voir **[`deploy/README.md`](deploy/README.md)** et **[`deploy/servers/ubuntu1.md`](deploy/servers/ubuntu1.md)** pour configurer les secrets GitHub.

```text
git push origin main   →  Actions: Deploy Production  →  securemail-gateway sur :5060
```

### Première fois (BD + serveur)

```powershell
# Migrations EF (une fois, depuis votre poste)
$env:ConnectionStrings__DefaultConnection = "Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=..."
cd src/SecureMailGateway
dotnet ef database update
```

Sur le serveur :

```bash
ssh ubuntu@51.79.53.197
sudo mkdir -p /opt/apps/securemail-gateway && sudo chown ubuntu:ubuntu /opt/apps/securemail-gateway
```

Puis configurez les secrets repo (`UBUNTU1_*`) et poussez sur `main`.

### Docker (optionnel)

```bash
docker build -t securemail-gateway .
docker run -d -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="Host=...;Password=..." \
  securemail-gateway
```

## Monitoring

| Endpoint | Description |
|----------|-------------|
| `GET /health` | Santé application + PostgreSQL |
| `GET /metrics` | Métriques Prometheus |
| `/hangfire` | Dashboard file d'attente (Admin) |

Métriques exposées : e-mails envoyés, échecs, durée d'envoi, appels API par client.

## Pages d'administration

- Dashboard
- Applications clientes + quotas + domaines
- Tokens API (génération, rotation, révocation)
- Templates (éditeur WYSIWYG, aperçu, test, versions)
- Historique e-mails + détails
- Configuration SMTP
- Journal d'audit
- Utilisateurs et rôles

## Licence

Usage interne — GiseDoc
