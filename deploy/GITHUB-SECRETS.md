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

## Upload d'images (optionnel)

Pour héberger sur le serveur les images insérées dans les templates :

| Nom | Type | Contenu |
|-----|------|---------|
| `UPLOADS_PUBLIC_BASE_URL` | Variable/Secret | URL publique absolue du service (ex. `https://mail.gisebs.com`). Utilisée pour construire les liens d'images dans les emails. Si vide, l'URL est dérivée de la requête (déconseillé derrière un proxy). |
| `UPLOADS_PATH` | Variable | Dossier persistant des uploads sur le serveur (défaut `<APP_ROOT>/uploads`). |

> Le dossier d'uploads est créé **hors** du dossier applicatif synchronisé (`rsync --delete`), donc les images survivent aux déploiements. Renseignez `UPLOADS_PUBLIC_BASE_URL` avec votre domaine public pour que les images s'affichent dans les emails envoyés.

---

## Canal WhatsApp (optionnel)

Canal additionnel : l'envoi de courriels ne dépend d'aucune de ces valeurs.

| Nom | Type | Contenu |
|-----|------|---------|
| `WHATSAPP_PHONE_NUMBER_ID` | Secret/Variable | *Phone number ID* du numéro expéditeur (console Meta → WhatsApp → API Setup) |
| `WHATSAPP_ACCESS_TOKEN` | Secret | Jeton d'accès. Le jeton de test expire en 24 h : utiliser un jeton d'utilisateur système permanent en production |
| `WHATSAPP_APP_SECRET` | Secret | *App secret* de l'application Meta. Sans lui, la signature des webhooks n'est pas vérifiée |
| `WHATSAPP_VERIFY_TOKEN` | Secret | Chaîne libre, à saisir à l'identique dans la console Meta lors de l'abonnement au webhook |
| `WHATSAPP_BUSINESS_ACCOUNT_ID` | Secret/Variable | *WhatsApp Business Account ID* (optionnel) |
| `WHATSAPP_DISPLAY_PHONE_NUMBER` | Variable | Numéro affiché aux destinataires (informatif) |
| `WHATSAPP_DEFAULT_COUNTRY_CODE` | Variable | Indicatif appliqué aux numéros saisis sans indicatif (ex. `237`) |
| `WHATSAPP_API_VERSION` | Variable | Version de l'API Graph (défaut `v21.0`) |

> `app.env` est régénéré à chaque déploiement : une valeur ajoutée manuellement sur le serveur
> disparaît au déploiement suivant. Ces secrets sont la seule façon durable de configurer le canal
> par variables d'environnement. Alternative : renseigner la configuration en base via l'écran
> d'administration, qui a priorité sur l'environnement.
>
> Vérification : `GET /api/whatsapp/diagnostics` renvoie la source retenue (`configuration` ou
> `database`) sans exposer les secrets. Webhook à déclarer chez Meta :
> `https://gisemailsender.gisebs.com/api/whatsapp/webhook`.

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
