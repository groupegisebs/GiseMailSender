using Microsoft.AspNetCore.Mvc;
using SecureMailGateway.Data;
using SecureMailGateway.Middleware;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Services;

namespace SecureMailGateway.Controllers.Api;

[ApiController]
[Route("api/mail")]
public class MailController(IEmailQueueService emailQueueService) : ControllerBase
{
    [HttpPost("send")]
    public async Task<ActionResult<SendMailResponse>> Send([FromBody] SendMailRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new SendMailResponse { Success = false, Error = "Invalid request." });

        if (!HttpContext.Items.TryGetValue(ApiClientContext.ItemKey, out var obj) || obj is not ClientApplication client)
            return Unauthorized(new SendMailResponse { Success = false, Error = "Unauthorized." });

        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        var result = await emailQueueService.QueueEmailAsync(request, client.Id, ip, ct);

        MetricsRegistry.ApiCalls.WithLabels(client.ClientCode, result.Success ? "success" : "error").Inc();

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}

[ApiController]
[Route("api/health")]
public class HealthController(ApplicationDbContext db) : ControllerBase
{
    private readonly ApplicationDbContext _db = db;

    [HttpGet("")]
    [Route("/health")]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        try
        {
            await _db.Database.CanConnectAsync(ct);
            return Ok(new { status = "Healthy", timestamp = DateTimeOffset.UtcNow });
        }
        catch
        {
            return StatusCode(503, new { status = "Unhealthy", timestamp = DateTimeOffset.UtcNow });
        }
    }
}
