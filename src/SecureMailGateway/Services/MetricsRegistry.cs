using Prometheus;

namespace SecureMailGateway.Services;

public static class MetricsRegistry
{
    public static readonly Counter EmailsSent = Metrics.CreateCounter(
        "securemail_emails_sent_total", "Total emails sent successfully");

    public static readonly Counter EmailsFailed = Metrics.CreateCounter(
        "securemail_emails_failed_total", "Total emails failed");

    public static readonly Gauge EmailsQueued = Metrics.CreateGauge(
        "securemail_emails_queued", "Emails currently in queue");

    public static readonly Histogram SendDuration = Metrics.CreateHistogram(
        "securemail_send_duration_seconds", "Email send duration");

    public static readonly Counter WhatsAppSent = Metrics.CreateCounter(
        "securemail_whatsapp_sent_total", "Total WhatsApp messages accepted by the provider");

    public static readonly Counter WhatsAppFailed = Metrics.CreateCounter(
        "securemail_whatsapp_failed_total", "Total WhatsApp messages failed");

    public static readonly Counter WhatsAppInbound = Metrics.CreateCounter(
        "securemail_whatsapp_inbound_total", "Total inbound WhatsApp messages received");

    public static readonly Histogram WhatsAppSendDuration = Metrics.CreateHistogram(
        "securemail_whatsapp_send_duration_seconds", "WhatsApp send duration");

    public static readonly Counter ApiCalls = Metrics.CreateCounter(
        "securemail_api_calls_total", "API calls", new CounterConfiguration
        {
            LabelNames = ["client_code", "status"]
        });
}
