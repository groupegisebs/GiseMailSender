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

Si le `templateCode` n'existe pas encore, le service crée automatiquement un template brouillon actif, puis l'envoi continue. Un administrateur peut ensuite l'éditer dans *Templates*.

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
| `400 Quota exceeded.` | Quota journalier/mensuel atteint | Ajuster quotas ou attendre reset |
| `429` | Trop de requêtes | Réduire cadence + retry backoff |

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
