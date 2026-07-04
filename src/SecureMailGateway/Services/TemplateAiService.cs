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

        var baseUrl = string.IsNullOrWhiteSpace(config.BaseUrl) ? "https://api.openai.com/" : config.BaseUrl!;
        var model = string.IsNullOrWhiteSpace(config.Model) ? "gpt-4o-mini" : config.Model.Trim();

        var client = httpClientFactory.CreateClient(nameof(OpenAiTemplateAiService));
        client.Timeout = TimeSpan.FromSeconds(Math.Clamp(config.TimeoutSeconds, 10, 120));
        client.BaseAddress = new Uri(baseUrl.EndsWith('/') ? baseUrl : $"{baseUrl}/");
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
                    content =
                        "Tu es un expert en email marketing B2B/B2C. Réponds uniquement en JSON valide avec les champs: " +
                        "subjectTemplate (string), htmlBody (string), textBody (string), variables (array d'objets {name, sampleValue}). " +
                        "Utilise uniquement des variables de la liste autorisée au format {{VarName}}."
                },
                new
                {
                    role = "user",
                    content = BuildUserPrompt(request)
                }
            }
        };

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "v1/chat/completions")
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
                return TemplateAiGenerationResult.Fail(
                    $"OpenAI a retourné {(int)response.StatusCode}. Vérifiez le modèle, la clé API et les quotas.",
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

    private static string BuildUserPrompt(TemplateAiGenerationRequest request)
    {
        var allowedVariables = request.AllowedVariables.Count == 0
            ? "(aucune)"
            : string.Join(", ", request.AllowedVariables.Select(v => $"{{{{{v}}}}}"));

        return
            "Génère un template email professionnel à fort impact avec ces paramètres:\n" +
            $"- Objectif: {request.Objective}\n" +
            $"- Marque/Entreprise: {request.BrandOrCompany ?? "N/A"}\n" +
            $"- Ton: {request.Tone ?? "professionnel"}\n" +
            $"- Langue: {request.Language ?? "fr"}\n" +
            $"- Type d'email: {request.EmailType ?? "transactionnel"}\n" +
            $"- CTA: {request.Cta ?? "N/A"}\n" +
            $"- Variables optionnelles demandées: {request.OptionalVariables ?? "N/A"}\n" +
            $"- Variables autorisées UNIQUEMENT: {allowedVariables}\n" +
            "Le HTML doit être compatible email (table/div simple, inline styles), clair et réutilisable.";
    }

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
