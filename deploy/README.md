# Déploiement SecureMail Gateway

Scripts réutilisables sur le modèle **ComptaDoc-PME** — configuration via fichiers JSON locaux (non commités).

## Configuration par projet

| Fichier | Rôle | Commité ? |
|---------|------|-----------|
| `deploy/project.config.example.json` | Modèle applicatif | ✅ |
| `deploy/project.config.json` | **Votre** config (service, port, DLL) | ❌ |
| `deploy/deploy-all.config.example.json` | Modèle serveur SSH | ✅ |
| `deploy/deploy-all.config.json` | **Votre** serveur (IP, user) | ❌ |

### Première configuration

```powershell
copy deploy\project.config.example.json deploy\project.config.json
copy deploy\deploy-all.config.example.json deploy\deploy-all.config.json
```

Valeurs par défaut SecureMail Gateway :

| Clé | Valeur |
|-----|--------|
| `serviceName` | `securemail-gateway` |
| `appRoot` | `/opt/apps/securemail-gateway` |
| `listenPort` | `5060` |
| `healthCheckUrl` | `http://localhost:5060/health` |
| `dllName` | `SecureMailGateway.dll` |

## Base de données (EF Core)

**Avant le premier déploiement**, créez le schéma avec EF :

```powershell
$env:ConnectionStrings__DefaultConnection = "Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=..."
cd src/SecureMailGateway
dotnet ef database update
```

Au démarrage, l'application réapplique les migrations en attente (`MigrateAsync`).

## Déploiement via GitHub Actions (recommandé)

**Chaque push sur `main` déclenche automatiquement le déploiement** vers UBUNTU1 (`51.79.53.197`).

Workflow : [`.github/workflows/deploy-production.yml`](../.github/workflows/deploy-production.yml)

| Où | Secret / Variable | Valeur |
|----|-------------------|--------|
| Organisation | `SSH_PRIVATE_KEY_UBUNTU1` | Clé `cognidoc_deploy` |
| Organisation | `SSH_HOST_UBUNTU1` | `51.79.53.197` |
| Organisation | `SSH_USER_UBUNTU1` | `ubuntu` |
| Dépôt (secret) | `UBUNTU1_CONNECTION_STRING` | Chaîne PostgreSQL |
| Dépôt | `UBUNTU1_APP_ROOT` | `/opt/apps/securemail-gateway` |
| Dépôt | `UBUNTU1_SERVICE_NAME` | `securemail-gateway` |
| Dépôt | `UBUNTU1_LISTEN_PORT` | `5060` |

OpenAI (optionnel, pour les fonctionnalités IA de l'application) :
- Secret recommandé : `GISEMAIL_OPENAI_API_KEY` (fallback supporté : `OPENAI_API_KEY`, secret ou variable).
- Variables/secrets optionnels :
  - `OPENAI_MODEL` (défaut: `gpt-4o-mini`)
  - `OPENAI_BASE_URL`
  - `OPENAI_TIMEOUT_SECONDS` (défaut: `45`)

Guide : [`deploy/servers/ubuntu1.md`](servers/ubuntu1.md)  
Environnement optionnel : **`deploy-ubuntu1`** (approbation manuelle).

Pipeline : publish → SCP → systemd → healthcheck `/health` → migrations EF au boot.

Déclenchement manuel : **Actions → Deploy Production → Run workflow**.

---

## Déploiement manuel (secours)

### Windows → Ubuntu

```bat
deploy\deploy.bat -ServerHost "51.79.53.197"
```

Ou avec `deploy/deploy-all.config.json` configuré :

```bat
deploy\deploy.bat
```

Le script :
1. Publie `src/SecureMailGateway/SecureMailGateway.csproj`
2. Transfère via SCP
3. Sauvegarde l'ancienne version
4. Installe le service systemd `securemail-gateway`
5. Vérifie `GET /health`

| Option | Description |
|--------|-------------|
| `-SkipPublish` | Réutilise `./publish` existant |
| `-ConnectionString` | Surcharge la chaîne depuis `appsettings.json` |

### Prérequis SSH (une fois)

```powershell
ssh-keygen -t ed25519 -C "securemail-deploy" -f $env:USERPROFILE\.ssh\cognidoc_deploy
type $env:USERPROFILE\.ssh\cognidoc_deploy.pub | ssh ubuntu@51.79.53.197 "mkdir -p ~/.ssh && cat >> ~/.ssh/authorized_keys"
```

Mot de passe BD : préférez **user-secrets** en local :

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=...;Password=..." --project src/SecureMailGateway
```

## Déploiement sur le serveur (manuel)

```bash
git pull
chmod +x deploy/deploy.sh
./deploy/deploy.sh
```

## Structure sur le serveur

```
/opt/apps/securemail-gateway/
├── app/                  # Application publiée
│   ├── app.env           # ConnectionStrings (chmod 600)
│   ├── keys/             # Data Protection
│   └── logs/
├── backups/
└── staging/
```

## Première installation serveur

```bash
sudo mkdir -p /opt/apps/securemail-gateway
sudo chown ubuntu:ubuntu /opt/apps/securemail-gateway

sudo mkdir -p /opt/apps/securemail-gateway/app
sudo cp deploy/appsettings.Production.json.example /opt/apps/securemail-gateway/app/appsettings.Production.json
sudo nano /opt/apps/securemail-gateway/app/appsettings.Production.json
```

`deploy.sh` **ne remplace jamais** `appsettings.Production.json` s'il existe déjà.

## Service systemd

```bash
sudo systemctl status securemail-gateway
sudo journalctl -u securemail-gateway -f
```

Template : `deploy/systemd.service.template`

## Nginx Proxy Manager

Proxy Host → `http://172.17.0.1:5060` + SSL Let's Encrypt (scheme **http**, pas https).

## Dépannage

```bash
curl -v http://localhost:5060/health
curl -v http://localhost:5060/metrics
sudo journalctl -u securemail-gateway -e --no-pager
```

## Fichiers deploy/

| Fichier | Rôle |
|---------|------|
| `project.config.example.json` | Config projet |
| `deploy-all.ps1` / `deploy.bat` | Déploiement Windows → Ubuntu |
| `deploy.sh` | Déploiement sur le serveur Linux |
| `deploy-gha.sh` | Déploiement GitHub Actions |
| `systemd.service.template` | Unit systemd |
| `appsettings.Production.json.example` | Config production |
