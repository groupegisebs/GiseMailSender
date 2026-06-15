using Hangfire;

namespace SecureMailGateway.Services;

public interface IBackgroundJobScheduler
{
    void EnqueueSend(Guid emailMessageId);
}

public class HangfireJobScheduler : IBackgroundJobScheduler
{
    public void EnqueueSend(Guid emailMessageId)
    {
        BackgroundJob.Enqueue<IEmailSenderService>(s => s.SendAsync(emailMessageId, CancellationToken.None));
    }
}
