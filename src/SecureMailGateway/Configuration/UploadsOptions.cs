namespace SecureMailGateway.Configuration;

public sealed class UploadsOptions
{
    public const string SectionName = "Uploads";

    /// <summary>Absolute or content-root-relative directory where uploaded images are stored.
    /// In production this must point OUTSIDE the published app folder so it survives deploys
    /// (the deploy script rsync --delete only touches the app directory).</summary>
    public string Path { get; set; } = "uploads";

    /// <summary>Public absolute base URL used to build image links embedded in e-mails
    /// (e.g. "https://mail.example.com"). When empty, the request's own base URL is used.</summary>
    public string? PublicBaseUrl { get; set; }

    /// <summary>URL path prefix under which uploaded files are served.</summary>
    public string RequestPath { get; set; } = "/uploads";

    /// <summary>Maximum accepted file size in bytes (default 2 MB).</summary>
    public long MaxBytes { get; set; } = 2 * 1024 * 1024;

    /// <summary>Allowed file extensions (lowercase, with leading dot).</summary>
    public string[] AllowedExtensions { get; set; } = [".png", ".jpg", ".jpeg", ".gif", ".webp"];
}
