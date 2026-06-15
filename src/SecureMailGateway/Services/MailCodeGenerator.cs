using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;

namespace SecureMailGateway.Services;

public interface IMailCodeGenerator
{
    Task<string> GenerateAsync(CancellationToken ct = default);
}

public class MailCodeGenerator(ApplicationDbContext db) : IMailCodeGenerator
{
    public async Task<string> GenerateAsync(CancellationToken ct = default)
    {
        var year = DateTime.UtcNow.Year;

        await using var tx = await db.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, ct);

        var seq = await db.MailCodeSequences.FirstOrDefaultAsync(s => s.Year == year, ct);

        if (seq is null)
        {
            seq = new MailCodeSequence { Year = year, LastNumber = 0 };
            db.MailCodeSequences.Add(seq);
        }

        seq.LastNumber++;
        await db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);

        return $"MAIL-{year}-{seq.LastNumber:D6}";
    }
}
