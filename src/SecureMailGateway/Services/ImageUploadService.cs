using Microsoft.Extensions.Options;
using SecureMailGateway.Configuration;

namespace SecureMailGateway.Services;

public interface IImageUploadService
{
    Task<ImageUploadResult> SaveAsync(IFormFile? file, HttpRequest request, CancellationToken ct);

    IReadOnlyList<ImageUploadItem> List(HttpRequest request);
}

public sealed record ImageUploadResult(bool Success, string? Url = null, string? FileName = null, string? Error = null)
{
    public static ImageUploadResult Ok(string url, string fileName) => new(true, url, fileName);
    public static ImageUploadResult Fail(string error) => new(false, Error: error);
}

public sealed record ImageUploadItem(string Url, string FileName, long Size, DateTimeOffset ModifiedUtc);

public sealed class ImageUploadService(
    IOptions<UploadsOptions> options,
    IWebHostEnvironment environment) : IImageUploadService
{
    private readonly UploadsOptions _options = options.Value;

    private string ResolveDirectory()
    {
        var path = string.IsNullOrWhiteSpace(_options.Path) ? "uploads" : _options.Path;
        return Path.IsPathRooted(path) ? path : Path.Combine(environment.ContentRootPath, path);
    }

    public async Task<ImageUploadResult> SaveAsync(IFormFile? file, HttpRequest request, CancellationToken ct)
    {
        if (file is null || file.Length == 0)
            return ImageUploadResult.Fail("Aucun fichier fourni.");

        if (file.Length > _options.MaxBytes)
        {
            var maxMb = Math.Round(_options.MaxBytes / (1024d * 1024d), 1);
            return ImageUploadResult.Fail($"Fichier trop volumineux (max {maxMb} Mo).");
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(extension) || !_options.AllowedExtensions.Contains(extension))
        {
            var allowed = string.Join(", ", _options.AllowedExtensions);
            return ImageUploadResult.Fail($"Format non autorisé. Formats acceptés : {allowed}.");
        }

        await using var stream = file.OpenReadStream();
        if (!await IsSupportedImageAsync(stream, extension, ct))
            return ImageUploadResult.Fail("Le fichier n'est pas une image valide.");
        stream.Position = 0;

        var directory = ResolveDirectory();
        Directory.CreateDirectory(directory);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(directory, fileName);

        await using (var target = File.Create(fullPath))
        {
            await stream.CopyToAsync(target, ct);
        }

        return ImageUploadResult.Ok(BuildUrl(request, fileName), fileName);
    }

    public IReadOnlyList<ImageUploadItem> List(HttpRequest request)
    {
        var directory = ResolveDirectory();
        if (!Directory.Exists(directory)) return [];

        return new DirectoryInfo(directory)
            .EnumerateFiles()
            .Where(f => _options.AllowedExtensions.Contains(f.Extension.ToLowerInvariant()))
            .OrderByDescending(f => f.LastWriteTimeUtc)
            .Select(f => new ImageUploadItem(
                BuildUrl(request, f.Name),
                f.Name,
                f.Length,
                new DateTimeOffset(f.LastWriteTimeUtc, TimeSpan.Zero)))
            .ToList();
    }

    private string BuildUrl(HttpRequest request, string fileName)
    {
        var baseUrl = string.IsNullOrWhiteSpace(_options.PublicBaseUrl)
            ? $"{request.Scheme}://{request.Host}"
            : _options.PublicBaseUrl!.TrimEnd('/');

        var requestPath = (_options.RequestPath ?? "/uploads").Trim('/');
        return $"{baseUrl}/{requestPath}/{fileName}";
    }

    /// <summary>Validates the file content by its magic bytes so a renamed non-image is rejected.</summary>
    private static async Task<bool> IsSupportedImageAsync(Stream stream, string extension, CancellationToken ct)
    {
        var header = new byte[12];
        var read = await stream.ReadAsync(header.AsMemory(0, header.Length), ct);
        if (read < 4) return false;

        // PNG
        if (header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47)
            return extension is ".png";

        // JPEG
        if (header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF)
            return extension is ".jpg" or ".jpeg";

        // GIF ("GIF87a" / "GIF89a")
        if (header[0] == 0x47 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x38)
            return extension is ".gif";

        // WEBP ("RIFF"...."WEBP")
        if (read >= 12 &&
            header[0] == 0x52 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x46 &&
            header[8] == 0x57 && header[9] == 0x45 && header[10] == 0x42 && header[11] == 0x50)
            return extension is ".webp";

        return false;
    }
}
