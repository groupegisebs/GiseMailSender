using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SecureMailGateway.Services;

public interface ITokenHashService
{
    string GenerateToken();
    string HashToken(string token);
    bool VerifyToken(string token, string hash);
    string GetPrefix(string token);
}

public class TokenHashService : ITokenHashService
{
    private readonly IPasswordHasher<object> _hasher = new PasswordHasher<object>();
    private static readonly object Dummy = new();

    public string GenerateToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(bytes).Replace("+", "").Replace("/", "").TrimEnd('=');
    }

    public string HashToken(string token) => _hasher.HashPassword(Dummy, token);

    public bool VerifyToken(string token, string hash)
    {
        var result = _hasher.VerifyHashedPassword(Dummy, hash, token);
        return result is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }

    public string GetPrefix(string token) => token.Length >= 8 ? token[..8] : token;
}
