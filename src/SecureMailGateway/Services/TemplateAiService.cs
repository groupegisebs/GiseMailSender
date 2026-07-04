using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;

namespace SecureMailGateway.Services;

public interface ITemplateAiService
{
    Task<TemplateAiGenerationResult> GenerateAsync(TemplateAiGenerationRequest request, CancellationToken ct);
}

public sealed class TemplateAiGenerationRequest
{
    public string Objective { get; set; } = string.Empty;
    public string? BrandOrCompany { get; set; }
    public string? Tone { get; set; }
    public string? Language { get; set; }
    public string? EmailType { get; set; }
    public string? Cta { get; set; }
    public string? OptionalVariables { get; set; }
    public IReadOnlyCollection<string> AllowedVariables { get; set; } = [];
}

public sealed class TemplateAiVariableSuggestion
{
    public string Name { get; set; } = string.Empty;
    public string? SampleValue { get; set; }
}

public sealed class TemplateAiGenerationResult
{
    public bool Success { get; init; }
    public string UserMessage { get; init; } = string.Empty;
    public string SubjectTemplate { get; init; } = string.Empty;
    public string HtmlBody { get; init; } = string.Empty;
    public string TextBody { get; init; } = string.Empty;
    public IReadOnlyList<TemplateAiVariableSuggestion> Variables { get; init; } = [];
    public IReadOnlyList<string> Warnings { get; init; } = [];

    public static TemplateAiGenerationResult Fail(string message, params string[] warnings) => new()
    {
        Success = false,
        UserMessage = message,
        Warnings = warnings
    };

    public static TemplateAiGenerationResult Ok(
        string subjectTemplate,
        string htmlBody,
        string textBody,
        IReadOnlyList<TemplateAiVariableSuggestion> variables,
        IReadOnlyList<string>? warnings = null) => new()
        {
            Success = true,
            UserMessage = "Template généré avec succès.",
            SubjectTemplate = subjectTemplate,
            HtmlBody = htmlBody,
            TextBody = textBody,
            Variables = variables,
            Warnings = warnings ?? []
        };
}

public sealed class OpenAiTemplateAiService(
    IHttpClientFactory httpClientFactory,
    IOptions<OpenAiOptions> options) : ITemplateAiService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<TemplateAiGenerationResult> GenerateAsync(TemplateAiGenerationRequest request, CancellationToken ct)
    {
        var config = options.Value;
        if (string.IsNullOrWhiteSpace(config.ApiKey))
        {
            return TemplateAiGenerationResult.Fail(
                "La clé OpenAI n'est pas configurée. Définissez OpenAI:ApiKey pour activer la génération IA.");
        }

        var model = string.IsNullOrWhiteSpace(config.Model) ? "gpt-4o-mini" : config.Model.Trim();
        var requestUri = BuildChatCompletionsUri(config.BaseUrl);

        var client = httpClientFactory.CreateClient(nameof(OpenAiTemplateAiService));
        client.Timeout = TimeSpan.FromSeconds(Math.Clamp(config.TimeoutSeconds, 10, 120));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ApiKey);

        var payload = new
        {
            model,
            temperature = 0.7,
            response_format = new { type = "json_object" },
            messages = new object[]
            {
                new
                {
                    role = "system",
                    content = SystemPrompt
                },
                new
                {
                    role = "user",
                    content = BuildUserPrompt(request)
                }
            }
        };

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json")
        };

        try
        {
            using var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, ct);
            var responseBody = await response.Content.ReadAsStringAsync(ct);
            if (!response.IsSuccessStatusCode)
            {
                var shortError = Truncate(responseBody, 350);
                // Include the effective endpoint (scheme+host+path, never the API key) to ease diagnosis
                // of common misconfigurations such as a doubled "/v1" path.
                var effectiveUrl = requestUri.GetLeftPart(UriPartial.Path);
                return TemplateAiGenerationResult.Fail(
                    $"OpenAI a retourné {(int)response.StatusCode} pour {effectiveUrl}. Vérifiez le modèle, la clé API, l'URL de base (OpenAI:BaseUrl) et les quotas.",
                    shortError);
            }

            var content = ExtractAssistantContent(responseBody);
            if (string.IsNullOrWhiteSpace(content))
            {
                return TemplateAiGenerationResult.Fail("Réponse IA vide. Réessayez avec une description plus précise.");
            }

            var parsed = ParseResult(content);
            if (parsed is null)
            {
                return TemplateAiGenerationResult.Fail(
                    "La réponse IA n'a pas pu être interprétée. Réessayez avec un objectif plus précis.");
            }

            return TemplateAiGenerationResult.Ok(
                parsed.SubjectTemplate ?? string.Empty,
                parsed.HtmlBody ?? string.Empty,
                parsed.TextBody ?? string.Empty,
                parsed.Variables?
                    .Where(v => !string.IsNullOrWhiteSpace(v.Name))
                    .Select(v => new TemplateAiVariableSuggestion
                    {
                        Name = v.Name!.Trim(),
                        SampleValue = v.SampleValue?.Trim()
                    })
                    .ToList() ?? []);
        }
        catch (OperationCanceledException) when (!ct.IsCancellationRequested)
        {
            return TemplateAiGenerationResult.Fail("Délai dépassé lors de l'appel OpenAI. Réessayez dans quelques secondes.");
        }
        catch (HttpRequestException ex)
        {
            return TemplateAiGenerationResult.Fail(
                "Impossible de joindre OpenAI. Vérifiez OpenAI:BaseUrl et la connectivité réseau.",
                ex.Message);
        }
        catch (Exception ex)
        {
            return TemplateAiGenerationResult.Fail("Erreur inattendue durant la génération IA.", ex.Message);
        }
    }

    /// <summary>
    /// Builds the absolute chat/completions endpoint from a configured base URL while making the
    /// "/v1" segment idempotent. Handles: unset (defaults to api.openai.com), a base ending in
    /// "/v1" or "/v1/", a bare host, or a base that already includes the full
    /// "/v1/chat/completions" path. Returned as an absolute URI so it overrides any client BaseAddress.
    /// </summary>
    internal static Uri BuildChatCompletionsUri(string? configuredBaseUrl)
    {
        var baseUrl = string.IsNullOrWhiteSpace(configuredBaseUrl)
            ? "https://api.openai.com"
            : configuredBaseUrl.Trim();

        baseUrl = baseUrl.TrimEnd('/');

        // Already the full endpoint (with or without a trailing slash) -> use as-is.
        if (baseUrl.EndsWith("/chat/completions", StringComparison.OrdinalIgnoreCase))
        {
            return new Uri(baseUrl);
        }

        // Base already contains a "/v1" version segment -> append only "chat/completions".
        var hasVersionSegment = baseUrl.EndsWith("/v1", StringComparison.OrdinalIgnoreCase)
            || baseUrl.Contains("/v1/", StringComparison.OrdinalIgnoreCase);
        if (hasVersionSegment)
        {
            return new Uri($"{baseUrl}/chat/completions");
        }

        // Bare host / no version segment -> append the full "v1/chat/completions".
        return new Uri($"{baseUrl}/v1/chat/completions");
    }

    private const string SystemPrompt =
        "Tu es un designer/intégrateur email senior, expert en emails transactionnels HTML compatibles avec tous les " +
        "clients de messagerie (Outlook, Gmail, Apple Mail, mobile).\n" +
        "Tu réponds STRICTEMENT en JSON valide (aucun texte hors JSON, aucun bloc markdown) avec EXACTEMENT ces champs :\n" +
        "  - subjectTemplate (string) : objet d'email concis et accrocheur.\n" +
        "  - htmlBody (string) : le code HTML complet du corps de l'email.\n" +
        "  - textBody (string) : version texte brut équivalente.\n" +
        "  - variables (array d'objets {name, sampleValue}) : la liste des variables réellement utilisées avec un exemple.\n" +
        "\n" +
        "EXIGENCES HTML (impératif — un email pauvre/vide est un échec) :\n" +
        "  - Mise en page 100% en TABLES imbriquées (<table>/<tr>/<td>), JAMAIS de flexbox/grid.\n" +
        "  - UNIQUEMENT des styles INLINE via l'attribut style=\"...\". Interdit : <style>, CSS externe, <script>, classes CSS.\n" +
        "  - Conteneur centré de largeur max ~600px (table role=\"presentation\" width=\"600\" align=\"center\", cellpadding=\"0\" cellspacing=\"0\").\n" +
        "  - Polices web sûres (Arial, Helvetica, 'Segoe UI', sans-serif). Bon espacement (padding généreux dans les <td>).\n" +
        "  - Un EN-TÊTE de marque (bandeau coloré avec la couleur de marque, nom/logo de la marque bien visible).\n" +
        "  - Un TITRE clair, puis le corps du message rédigé.\n" +
        "  - Au moins un BOUTON CTA proéminent : un <a> stylé « bulletproof » (background-color, color:#ffffff, padding:14px 28px, " +
        "border-radius, font-weight:bold, text-decoration:none, display:inline-block) et non un simple lien texte.\n" +
        "  - Un EMPLACEMENT IMAGE avec <img src=\"...\" alt=\"...\" width=\"...\" style=\"display:block;max-width:100%;\"> lorsque pertinent.\n" +
        "  - Un PIED DE PAGE (mentions, désabonnement/contact, année/marque).\n" +
        "  - Utilise des couleurs cohérentes avec la marque et un rendu soigné, digne d'une vraie campagne.\n" +
        "\n" +
        "VARIABLES :\n" +
        "  - Privilégie les variables du catalogue recommandé fourni lorsqu'elles conviennent, au format {{NomVariable}} (doubles accolades).\n" +
        "  - Tu PEUX aussi introduire des variables personnalisées supplémentaires quand le cas d'usage l'exige (ex. jeton spécifique e-commerce/abonnement absent du catalogue).\n" +
        "  - Toute variable (catalogue OU personnalisée) DOIT être un identifiant valide : uniquement lettres, chiffres et underscore, en PascalCase, commençant par une lettre (ex. {{GiftCardCode}}, {{LoyaltyPoints}}).\n" +
        "  - Tu DOIS lister dans variables[] CHAQUE variable réellement utilisée (catalogue comme personnalisée) avec un sampleValue réaliste.\n" +
        "  - Pour le lien du bouton CTA, utilise une variable de lien (ex. {{ResetLink}}, {{CtaLink}} ou une variable de lien personnalisée) dans href.\n" +
        "  - textBody doit reprendre les mêmes {{Variables}} et rester lisible sans HTML.\n" +
        "  - Rédige tout le contenu dans la langue demandée (français par défaut).\n" +
        "  - N'échappe pas les accolades : garde {{Variable}} tel quel.";

    private static string BuildUserPrompt(TemplateAiGenerationRequest request)
    {
        var allowedVariables = request.AllowedVariables.Count == 0
            ? "(catalogue vide — crée des variables personnalisées pertinentes au format {{NomVariable}})"
            : string.Join(", ", request.AllowedVariables.Select(v => $"{{{{{v}}}}}"));

        return
            "Génère un template d'email transactionnel professionnel, riche et STYLÉ (en-tête de marque, titre, texte, " +
            "bouton CTA, image, pied de page) à partir de ce brief :\n" +
            $"- Objectif / cas d'usage : {Fallback(request.Objective, "email transactionnel générique")}\n" +
            $"- Marque / entreprise : {Fallback(request.BrandOrCompany, "SecureMail")}\n" +
            $"- Ton souhaité : {Fallback(request.Tone, "professionnel et chaleureux")}\n" +
            $"- Langue : {Fallback(request.Language, "fr")}\n" +
            $"- Type d'email : {Fallback(request.EmailType, "transactionnel")}\n" +
            $"- Appel à l'action (CTA) : {Fallback(request.Cta, "un bouton d'action pertinent avec la variable de lien autorisée")}\n" +
            $"- Variables souhaitées par l'utilisateur : {Fallback(request.OptionalVariables, "au choix parmi le catalogue ou des variables personnalisées pertinentes")}\n" +
            $"- Catalogue de variables RECOMMANDÉES (à privilégier, au format double-accolade ; tu peux en ajouter d'autres si besoin) : {allowedVariables}\n" +
            "\n" +
            "Rappels : HTML en tables imbriquées + styles inline uniquement, largeur ~600px centrée, bouton CTA « bulletproof » " +
            "bien visible, un <img> placeholder si pertinent, en-tête et pied de page soignés. Réponds uniquement en JSON valide.";
    }

    private static string Fallback(string? value, string fallback) =>
        string.IsNullOrWhiteSpace(value) ? fallback : value.Trim();

    private static OpenAiTemplateResponse? ParseResult(string content)
    {
        var normalized = TryExtractJsonObject(content);
        if (string.IsNullOrWhiteSpace(normalized)) return null;

        try
        {
            return JsonSerializer.Deserialize<OpenAiTemplateResponse>(normalized, JsonOptions);
        }
        catch
        {
            return null;
        }
    }

    private static string ExtractAssistantContent(string responseBody)
    {
        using var doc = JsonDocument.Parse(responseBody);
        if (!doc.RootElement.TryGetProperty("choices", out var choices) || choices.GetArrayLength() == 0)
            return string.Empty;

        var message = choices[0].GetProperty("message");
        return message.TryGetProperty("content", out var contentElement) ? contentElement.GetString() ?? string.Empty : string.Empty;
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

    private sealed class OpenAiTemplateResponse
    {
        public string? SubjectTemplate { get; set; }
        public string? HtmlBody { get; set; }
        public string? TextBody { get; set; }
        public List<OpenAiVariableResponse>? Variables { get; set; }
    }

    private sealed class OpenAiVariableResponse
    {
        public string? Name { get; set; }
        public string? SampleValue { get; set; }
    }
}
