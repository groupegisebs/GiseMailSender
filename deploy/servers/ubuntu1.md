# Serveur UBUNTU1 — configuration GitHub (`groupegisebs/GiseMailSender`)

Convention : **`SSH_*_UBUNTU1`** à l’**organisation**, **`UBUNTU1_*`** au **dépôt**.

| Serveur | ID | IP |
|---------|-----|-----|
| Ubuntu principal | `ubuntu1` | `51.79.53.197` |

---

## ⚠️ Erreur « secret manquant » alors qu’il existe à l’org ?

Les secrets **organisation** ne sont pas automatiquement visibles par tous les dépôts.

**À faire une fois** pour chaque secret org (`SSH_PRIVATE_KEY_UBUNTU1`, `SSH_HOST_UBUNTU1`, etc.) :

1. Ouvrir : **https://github.com/organizations/groupegisebs/settings/secrets/actions**
2. Cliquer sur le secret (ex. `SSH_PRIVATE_KEY_UBUNTU1`)
3. Section **Repository access** → **Selected repositories**
4. **Ajouter `GiseMailSender`**

Même procédure pour les **variables** org :  
**https://github.com/organizations/groupegisebs/settings/variables/actions**

Le workflow affiche une étape **Diagnose secret availability** : les lignes `--` indiquent ce qui n’est pas accessible au dépôt.

---

## Organisation `groupegisebs`

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
