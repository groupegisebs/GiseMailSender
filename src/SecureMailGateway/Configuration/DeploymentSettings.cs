namespace SecureMailGateway.Configuration;

/// <summary>
/// Paramètres de déploiement UBUNTU1 (secrets GitHub Actions / variables systemd app.env).
/// </summary>
public class DeploymentSettings
{
    public const string SectionName = "Deployment";

    public string AppName { get; set; } = "SecureMail Gateway";
    public string ServiceName { get; set; } = "securemail-gateway";
    public string AppRoot { get; set; } = "/opt/apps/securemail-gateway";
    public int ListenPort { get; set; } = 5060;
    public string? ConnectionString { get; set; }
}
