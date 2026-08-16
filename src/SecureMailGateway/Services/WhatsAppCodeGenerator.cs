using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

public interface IWhatsAppCodeGenerator
{
    Task<string> GenerateAsync(CancellationToken ct = default);
}

public class WhatsAppCodeGenerator(ApplicationDbContext db) : IWhatsAppCodeGenerator
{
    public async Task<string> GenerateAsync(CancellationToken ct = default)
    {
        var year = DateTime.UtcNow.Year;

        await using var tx = await db.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, ct);

        var seq = await db.WhatsAppCodeSequences.FirstOrDefaultAsync(s => s.Year == year, ct);
        if (seq is null)
        {
            seq = new WhatsAppCodeSequence { Year = year, LastNumber = 0 };
            db.WhatsAppCodeSequences.Add(seq);
        }

        seq.LastNumber++;
        await db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);

        return $"WHAP-{year}-{seq.LastNumber:D6}";
    }
}
