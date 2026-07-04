using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;
using SecureMailGateway.Models.Dtos;

namespace SecureMailGateway.Services;

/// <summary>
/// Thrown when template generation fails for a reason we want to surface to the user (missing key,
/// upstream HTTP error, empty/unparseable response, timeout...). The message is always safe to show:
/// it NEVER contains the API key.
/// </summary>
public sealed class AiTemplateGenerationException(string userMessage, string? detail = null)
    : Exception(userMessage)
{
    /// <summary>Optional short technical detail (upstream body excerpt, exception message) — never the API key.</summary>
    public string? Detail { get; } = detail;
}

/// <summary>
/// Generates transactional email templates via the OpenAI <b>Responses API</b>
/// (<c>POST {BaseUrl}/responses</c>). The API key is read from server-side configuration and never
/// leaves the server. Returns the parsed model output; HTML sanitization is applied downstream by the
/// controller through <see cref="IHtmlSanitizerService"/>.
/// </summary>
public sealed class OpenAiTemplateService(
    HttpClient httpClient,
    IOptions<OpenAiOptions> options,
    ILogger<OpenAiTemplateService> logger)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<AiTemplateGenerateResponse> GenerateEmailTemplateAsync(
        AiTemplateGenerateRequest request,
        CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);

        var config = options.Value;
        var apiKey = config.ApiKey?.Trim();
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new AiTemplateGenerationException(
                "La clé OpenAI n'est pas configurée. Définissez OpenAI__ApiKey (ou OPENAI_API_KEY) pour activer la génération IA.");
        }

        var model = string.IsNullOrWhiteSpace(config.Model) ? "gpt-4.1-mini" : config.Model.Trim();
        var requestUri = BuildResponsesUri(config.BaseUrl);

        httpClient.Timeout = TimeSpan.FromSeconds(Math.Clamp(config.TimeoutSeconds, 10, 180));

        // The Responses API replaces Chat Completions' "response_format" with "text.format".
        var payload = new
        {
            model,
            temperature = 0.7,
            input = new object[]
            {
                new { role = "system", content = SystemPrompt },
                new { role = "user", content = BuildUserPrompt(request) }
            },
            text = new { format = new { type = "json_object" } }
        };

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json")
        };
        // Auth header set per-request so the (potentially shared) HttpClient never stores the key.
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        try
        {
            using var response = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, ct);
            var responseBody = await response.Content.ReadAsStringAsync(ct);

            if (!response.IsSuccessStatusCode)
            {
                var effectiveUrl = requestUri.GetLeftPart(UriPartial.Path);
                // Log without the API key (only the endpoint + status + a short body excerpt).
                logger.LogError(
                    "OpenAI Responses API returned {StatusCode} for {Endpoint}. Body: {Body}",
                    (int)response.StatusCode, effectiveUrl, Truncate(responseBody, 500));

                throw new AiTemplateGenerationException(
                    $"OpenAI a retourné {(int)response.StatusCode} pour {effectiveUrl}. Vérifiez le modèle, la clé API, l'URL de base (OpenAI:BaseUrl) et les quotas.",
                    Truncate(responseBody, 350));
            }

            var content = ExtractResponsesOutputText(responseBody);
            if (string.IsNullOrWhiteSpace(content))
            {
                logger.LogWarning("OpenAI Responses API returned an empty output payload.");
                throw new AiTemplateGenerationException(
                    "Réponse IA vide. Réessayez avec une description plus précise.");
            }

            var parsed = ParseResult(content);
            if (parsed is null)
            {
                logger.LogWarning("OpenAI output could not be parsed as JSON. Raw excerpt: {Raw}", Truncate(content, 400));
                throw new AiTemplateGenerationException(
                    "La réponse IA n'a pas pu être interprétée. Réessayez avec un objectif plus précis.");
            }

            return MapToResponse(parsed);
        }
        catch (OperationCanceledException) when (!ct.IsCancellationRequested)
        {
            logger.LogWarning("OpenAI Responses API call timed out after {Seconds}s.", config.TimeoutSeconds);
            throw new AiTemplateGenerationException(
                "Délai dépassé lors de l'appel OpenAI. Réessayez dans quelques secondes.");
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Network error calling the OpenAI Responses API.");
            throw new AiTemplateGenerationException(
                "Impossible de joindre OpenAI. Vérifiez OpenAI:BaseUrl et la connectivité réseau.", ex.Message);
        }
    }

    /// <summary>
    /// Builds the absolute <c>/responses</c> endpoint from the configured base URL while keeping the
    /// "/v1" segment idempotent. Handles: unset (defaults to api.openai.com/v1), a base ending in
    /// "/v1" or "/v1/", a bare host, or a base already ending in "/responses". Returned as an
    /// absolute URI so it fully controls the request target.
    /// </summary>
    internal static Uri BuildResponsesUri(string? configuredBaseUrl)
    {
        var baseUrl = string.IsNullOrWhiteSpace(configuredBaseUrl)
            ? "https://api.openai.com/v1"
            : configuredBaseUrl.Trim();

        baseUrl = baseUrl.TrimEnd('/');

        // Already the full endpoint -> use as-is.
        if (baseUrl.EndsWith("/responses", StringComparison.OrdinalIgnoreCase))
        {
            return new Uri(baseUrl);
        }

        // Base already contains a "/v1" version segment -> append only "responses" (no doubling).
        var hasVersionSegment = baseUrl.EndsWith("/v1", StringComparison.OrdinalIgnoreCase)
            || baseUrl.Contains("/v1/", StringComparison.OrdinalIgnoreCase);
        if (hasVersionSegment)
        {
            return new Uri($"{baseUrl}/responses");
        }

        // Bare host / no version segment -> append the full "v1/responses".
        return new Uri($"{baseUrl}/v1/responses");
    }

    private const string SystemPrompt =
        "Tu es un designer/intégrateur email senior, expert en emails transactionnels HTML compatibles avec tous les " +
        "clients de messagerie (Outlook, Gmail, Apple Mail, mobile).\n" +
        "Tu réponds STRICTEMENT en JSON valide (aucun texte hors JSON, aucun bloc markdown, aucune prose) avec EXACTEMENT ces clés :\n" +
        "  - subject (string) : objet d'email concis et accrocheur.\n" +
        "  - bodyHtml (string) : le code HTML complet du corps de l'email.\n" +
        "  - bodyText (string) : version texte brut équivalente et cohérente.\n" +
        "  - testData (objet) : mappe CHAQUE variable utilisée vers un exemple réaliste, ex. {\"FirstName\":\"Jean\"}.\n" +
        "  - variables (array de strings) : la liste des noms de variables réellement utilisées.\n" +
        "  - warnings (array de strings) : avertissements éventuels (peut être vide []).\n" +
        "\n" +
        "EXIGENCES HTML (impératif — un email pauvre/vide est un échec) :\n" +
        "  - Mise en page 100% en TABLES imbriquées (<table>/<tr>/<td>), JAMAIS de flexbox/grid.\n" +
        "  - UNIQUEMENT des styles INLINE via l'attribut style=\"...\". Interdit : <style>, CSS externe, <script>, <iframe>, classes CSS.\n" +
        "  - Conteneur centré de largeur principale 600px (table role=\"presentation\" width=\"600\" align=\"center\", cellpadding=\"0\" cellspacing=\"0\").\n" +
        "  - Polices web sûres (Arial, Helvetica, 'Segoe UI', sans-serif). Bon espacement (padding généreux dans les <td>).\n" +
        "  - Un EN-TÊTE de marque (bandeau coloré, nom/logo de la marque bien visible).\n" +
        "  - Un TITRE clair, puis le corps du message rédigé.\n" +
        "  - Un BOUTON CTA proéminent UNIQUEMENT si un texte de CTA est fourni : un <a> stylé « bulletproof » " +
        "(background-color, color:#ffffff, padding:14px 28px, border-radius, font-weight:bold, text-decoration:none, display:inline-block).\n" +
        "  - Utilise la couleur principale fournie (le cas échéant) pour l'en-tête et le bouton CTA.\n" +
        "  - Un PIED DE PAGE professionnel (mentions, désabonnement/contact, année/marque).\n" +
        "\n" +
        "VARIABLES :\n" +
        "  - Privilégie les variables du catalogue recommandé fourni lorsqu'elles conviennent, au format {{NomVariable}} (doubles accolades).\n" +
        "  - Tu PEUX introduire des variables personnalisées supplémentaires quand le cas d'usage l'exige.\n" +
        "  - Toute variable DOIT être un identifiant valide : lettres, chiffres et underscore, en PascalCase, commençant par une lettre (ex. {{GiftCardCode}}).\n" +
        "  - Conserve les placeholders {{VariableName}} tels quels (ne les échappe pas) dans subject, bodyHtml et bodyText.\n" +
        "  - Pour le href du bouton CTA, utilise une variable de lien (ex. {{ResetLink}}, {{CtaLink}} ou une variable de lien personnalisée).\n" +
        "  - Renseigne testData ET variables pour CHAQUE variable utilisée.\n" +
        "  - Rédige tout le contenu dans la langue demandée (français par défaut).";

    private static string BuildUserPrompt(AiTemplateGenerateRequest request)
    {
        var allowedVariables = string.Join(", ", TemplateVariableCatalog.Names.Select(v => $"{{{{{v}}}}}"));

        return
            "Génère un template d'email transactionnel professionnel, riche et STYLÉ (en-tête de marque, titre, texte, " +
            "bouton CTA si pertinent, pied de page) à partir de ce brief :\n" +
            $"- Objectif / cas d'usage : {Fallback(request.Objective, "email transactionnel générique")}\n" +
            $"- Marque / entreprise : {Fallback(request.BrandName, "SecureMail")}\n" +
            $"- Type d'email : {Fallback(request.EmailType, "transactionnel")}\n" +
            $"- Ton souhaité : {Fallback(request.Tone, "professionnel et chaleureux")}\n" +
            $"- Langue : {Fallback(request.Language, "fr")}\n" +
            $"- Appel à l'action (CTA) : {Fallback(request.CtaText, "(aucun CTA explicite — n'ajoute un bouton que si cela a du sens)")}\n" +
            $"- Couleur principale : {Fallback(request.PrimaryColor, "(au choix, cohérente avec la marque)")}\n" +
            $"- Variables souhaitées par l'utilisateur : {Fallback(request.DesiredVariables, "au choix parmi le catalogue ou des variables personnalisées pertinentes")}\n" +
            $"- Instructions supplémentaires : {Fallback(request.AdditionalInstructions, "(aucune)")}\n" +
            $"- Catalogue de variables RECOMMANDÉES (à privilégier ; tu peux en ajouter d'autres) : {allowedVariables}\n" +
            "\n" +
            "Rappels : HTML en tables imbriquées + styles inline uniquement, largeur principale 600px centrée, bouton CTA " +
            "« bulletproof » uniquement si un CTA est fourni, en-tête et pied de page soignés. Réponds uniquement en JSON valide.";
    }

    private static string Fallback(string? value, string fallback) =>
        string.IsNullOrWhiteSpace(value) ? fallback : value.Trim();

    private static AiTemplateGenerateResponse MapToResponse(OpenAiTemplatePayload parsed)
    {
        var response = new AiTemplateGenerateResponse
        {
            Subject = parsed.Subject ?? string.Empty,
            BodyHtml = parsed.BodyHtml ?? string.Empty,
            BodyText = parsed.BodyText ?? string.Empty,
            Warnings = parsed.Warnings?.Where(w => !string.IsNullOrWhiteSpace(w)).ToList() ?? []
        };

        if (parsed.TestData is not null)
        {
            foreach (var (key, value) in parsed.TestData)
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    response.TestData[key.Trim()] = value ?? string.Empty;
                }
            }
        }

        if (parsed.Variables is not null)
        {
            foreach (var name in parsed.Variables.Where(n => !string.IsNullOrWhiteSpace(n)))
            {
                var trimmed = name.Trim();
                response.TestData.TryGetValue(trimmed, out var sample);
                response.Variables.Add(new AiTemplateVariable
                {
                    Name = trimmed,
                    Token = $"{{{{{trimmed}}}}}",
                    SampleValue = sample ?? string.Empty
                });
            }
        }

        return response;
    }

    private static OpenAiTemplatePayload? ParseResult(string content)
    {
        var normalized = TryExtractJsonObject(content);
        if (string.IsNullOrWhiteSpace(normalized)) return null;

        try
        {
            return JsonSerializer.Deserialize<OpenAiTemplatePayload>(normalized, JsonOptions);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Extracts the assistant text from a Responses API body. The raw HTTP response exposes the text
    /// under <c>output[].content[].text</c> for items whose type is <c>output_text</c> (NOT
    /// <c>choices[0].message</c> like Chat Completions). We also honor a top-level <c>output_text</c>
    /// string if present, and skip non-message items (e.g. reasoning) defensively.
    /// </summary>
    internal static string ExtractResponsesOutputText(string responseBody)
    {
        using var doc = JsonDocument.Parse(responseBody);
        var root = doc.RootElement;

        // Convenience field some SDK-style payloads include.
        if (root.TryGetProperty("output_text", out var outputText) &&
            outputText.ValueKind == JsonValueKind.String)
        {
            var value = outputText.GetString();
            if (!string.IsNullOrWhiteSpace(value)) return value;
        }

        if (!root.TryGetProperty("output", out var output) || output.ValueKind != JsonValueKind.Array)
        {
            return string.Empty;
        }

        var builder = new StringBuilder();
        foreach (var item in output.EnumerateArray())
        {
            // Only assistant "message" items carry the answer; skip reasoning/tool items.
            if (item.TryGetProperty("type", out var itemType) &&
                itemType.ValueKind == JsonValueKind.String &&
                !string.Equals(itemType.GetString(), "message", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (!item.TryGetProperty("content", out var contentArray) ||
                contentArray.ValueKind != JsonValueKind.Array)
            {
                continue;
            }

            foreach (var part in contentArray.EnumerateArray())
            {
                if (part.TryGetProperty("type", out var partType) &&
                    partType.ValueKind == JsonValueKind.String &&
                    !string.Equals(partType.GetString(), "output_text", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (part.TryGetProperty("text", out var textElement) &&
                    textElement.ValueKind == JsonValueKind.String)
                {
                    builder.Append(textElement.GetString());
                }
            }
        }

        return builder.ToString();
    }

    private static string? TryExtractJsonObject(string value)
    {
        var start = value.IndexOf('{');
        var end = value.LastIndexOf('}');
        if (start < 0 || end <= start) return null;
        return value[start..(end + 1)];
    }

    private static string Truncate(string value, int maxLen) =>
        value.Length <= maxLen ? value : $"{value[..maxLen]}...";

    private sealed class OpenAiTemplatePayload
    {
        public string? Subject { get; set; }
        public string? BodyHtml { get; set; }
        public string? BodyText { get; set; }
        public Dictionary<string, string?>? TestData { get; set; }
        public List<string>? Variables { get; set; }
        public List<string>? Warnings { get; set; }
    }
}
