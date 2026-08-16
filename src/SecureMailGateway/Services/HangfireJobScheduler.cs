using Hangfire;

namespace SecureMailGateway.Services;

public interface IBackgroundJobScheduler
{
    void EnqueueSend(Guid emailMessageId);

    void EnqueueWhatsAppSend(Guid whatsAppMessageId);

    /// <summary>Nouvelle tentative différée après une erreur passagère de l'opérateur.</summary>
    void ScheduleWhatsAppRetry(Guid whatsAppMessageId, TimeSpan delay);
}

public class HangfireJobScheduler : IBackgroundJobScheduler
{
    public void EnqueueSend(Guid emailMessageId)
    {
        BackgroundJob.Enqueue<IEmailSenderService>(s => s.SendAsync(emailMessageId, CancellationToken.None));
    }

    public void EnqueueWhatsAppSend(Guid whatsAppMessageId)
    {
        BackgroundJob.Enqueue<IWhatsAppSenderService>(s => s.SendAsync(whatsAppMessageId, CancellationToken.None));
    }

    public void ScheduleWhatsAppRetry(Guid whatsAppMessageId, TimeSpan delay)
    {
        BackgroundJob.Schedule<IWhatsAppSenderService>(s => s.SendAsync(whatsAppMessageId, CancellationToken.None), delay);
    }
}
