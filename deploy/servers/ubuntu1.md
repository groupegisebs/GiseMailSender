# Serveur UBUNTU1 — configuration GitHub (SecureMail Gateway)

Convention : **`SSH_*_UBUNTU1`** à l’organisation, **`UBUNTU1_*`** au dépôt.

| Serveur | ID | IP |
|---------|-----|-----|
| Ubuntu principal | `ubuntu1` | `51.79.53.197` |

---

## Organisation (secrets partagés)

| Secret | Valeur |
|--------|--------|
| `SSH_PRIVATE_KEY_UBUNTU1` | Clé privée `cognidoc_deploy` |
| `SSH_HOST_UBUNTU1` | `51.79.53.197` |
| `SSH_USER_UBUNTU1` | `ubuntu` |
| `SSH_PORT_UBUNTU1` | `22` |

---

## Dépôt GiseMailSender

| Secret | Valeur |
|--------|--------|
| `UBUNTU1_CONNECTION_STRING` | `Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=...` |
| `UBUNTU1_APP_ROOT` | `/opt/apps/securemail-gateway` |
| `UBUNTU1_SERVICE_NAME` | `securemail-gateway` |
| `UBUNTU1_LISTEN_PORT` | `5060` |
| `UBUNTU1_APP_NAME` | `SecureMail Gateway` |

### Nginx Proxy Manager

| Champ | Valeur |
|-------|--------|
| Scheme | **`http`** |
| Forward Host | `172.17.0.1` |
| Forward Port | `5060` |

---

## Première installation sur le serveur

```bash
ssh ubuntu@51.79.53.197
sudo mkdir -p /opt/apps/securemail-gateway
sudo chown ubuntu:ubuntu /opt/apps/securemail-gateway
dotnet --list-runtimes   # Microsoft.AspNetCore.App 10.x
```

### Mise à jour BD (EF Core)

Avant le premier démarrage, depuis votre poste de dev :

```powershell
$env:ConnectionStrings__DefaultConnection = "Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=..."
cd src/SecureMailGateway
dotnet ef database update
```

Les déploiements suivants appliquent les migrations au démarrage (`MigrateAsync`).

---

## Lancer le déploiement

### Automatique (recommandé)

**Push sur la branche `main`** → le workflow **Deploy Production** s'exécute automatiquement.

### Manuel

**Actions → Deploy Production → Run workflow → ubuntu1**
