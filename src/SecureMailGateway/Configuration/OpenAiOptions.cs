namespace SecureMailGateway.Configuration;

public sealed class OpenAiOptions
{
    public const string SectionName = "OpenAI";

    public string? ApiKey { get; set; }
    public string Model { get; set; } = "gpt-4o-mini";
    public string? BaseUrl { get; set; }
    public int TimeoutSeconds { get; set; } = 45;
}
