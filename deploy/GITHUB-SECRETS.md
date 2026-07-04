# Secrets GitHub — GiseMailSender (minimum requis)

**https://github.com/groupegisebs/GiseMailSender/settings/secrets/actions**

Cliquez **New repository secret** pour chacun :

---

## ✅ 2 secrets obligatoires seulement

| Nom (choisir un des deux noms) | Contenu |
|--------------------------------|---------|
| **`GISEMAIL_SSH_PRIVATE_KEY`** *(recommandé)* | Clé privée SSH complète (multiligne) |
| *ou* `SSH_PRIVATE_KEY_UBUNTU1` | même contenu |

| Nom | Contenu |
|-----|---------|
| **`GISEMAIL_CONNECTION_STRING`** *(recommandé)* | `Host=51.79.53.197;Port=5432;Database=GiseMailSenderService;Username=gisedocuser;Password=VOTRE_MDP` |
| *ou* `UBUNTU1_CONNECTION_STRING` | même contenu |

---

## OpenAI (optionnel)

Si vous activez les fonctionnalités IA, configurez :

| Nom | Type | Contenu |
|-----|------|---------|
| **`GISEMAIL_OPENAI_API_KEY`** *(recommandé)* | Secret | Clé API OpenAI |
| *ou* `OPENAI_API_KEY` | Secret/Variable | même contenu |
| `OPENAI_MODEL` | Variable/Secret | ex. `gpt-4o-mini` (défaut si absent) |
| `OPENAI_BASE_URL` | Variable/Secret | URL custom compatible OpenAI (optionnel) |
| `OPENAI_TIMEOUT_SECONDS` | Variable/Secret | timeout HTTP en secondes (défaut `45`) |

> Le workflow n'écrit `OpenAI__ApiKey` que si la clé est renseignée, pour éviter d'écraser une valeur existante par vide.

---

## Host / User — pas besoin de secrets

Le workflow utilise par défaut :
- Host : `51.79.53.197`
- User : `ubuntu`
- Port : `22`

Vous pouvez surcharger avec des secrets/variables si besoin.

---

## Format clé SSH

```
-----BEGIN OPENSSH PRIVATE KEY-----
b3BlbnNzaC1rZX...
-----END OPENSSH PRIVATE KEY-----
```

⚠️ Copier **tout** le fichier. Pas une seule ligne.

---

## Vérification

Après ajout des 2 secrets, **Actions → Deploy Production → Re-run jobs**.

L’étape **Diagnose secrets** doit afficher `OK` pour la clé et la connection string.

---

## Checklist rapide

- [ ] `GISEMAIL_SSH_PRIVATE_KEY` créé au **dépôt** (pas seulement org)
- [ ] `GISEMAIL_CONNECTION_STRING` créé au **dépôt**
- [ ] Push sur `main` ou re-run workflow
- [ ] Serveur : `sudo mkdir -p /opt/apps/securemail-gateway && sudo chown ubuntu:ubuntu /opt/apps/securemail-gateway`
- [ ] BD : créée automatiquement au déploiement, ou manuellement :
  ```bash
  ssh ubuntu@51.79.53.197
  sudo -u postgres psql -c 'CREATE DATABASE "GiseMailSenderService" OWNER gisedocuser;'
  ```
