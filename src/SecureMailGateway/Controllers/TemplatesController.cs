using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
public class TemplatesController(
    ApplicationDbContext db,
    ITemplateRenderer templateRenderer,
    IAuditService auditService,
    IEmailSenderService emailSender,
    IMailCodeGenerator mailCodeGenerator) : Controller
{
    public async Task<IActionResult> Index(string? clientCode, string? q, int page = 1, CancellationToken ct = default)
    {
        const int pageSize = 20;
        page = Math.Max(1, page);

        var clientApplications = await db.ClientApplications
            .OrderBy(c => c.Name)
            .Select(c => new { c.ClientCode, c.Name })
            .ToListAsync(ct);

        var selectedClientCode = string.IsNullOrWhiteSpace(clientCode) ? null : clientCode.Trim().ToUpperInvariant();
        var searchTerm = string.IsNullOrWhiteSpace(q) ? null : q.Trim();

        var query = db.EmailTemplates.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(t => EF.Functions.ILike(t.TemplateCode, $"%{searchTerm}%") || EF.Functions.ILike(t.Name, $"%{searchTerm}%"));

        if (!string.IsNullOrWhiteSpace(selectedClientCode))
        {
            query = selectedClientCode switch
            {
                "BOUTIQUEGISE" => query.Where(t =>
                    EF.Functions.ILike(t.TemplateCode, $"%{selectedClientCode}%") ||
                    EF.Functions.ILike(t.Name, $"%{selectedClientCode}%") ||
                    EF.Functions.ILike(t.Name, "%Agentia%") ||
                    EF.Functions.ILike(t.Name, "%Market%")),
                "TUTORSPHERE" => query.Where(t =>
                    EF.Functions.ILike(t.TemplateCode, $"%{selectedClientCode}%") ||
                    EF.Functions.ILike(t.Name, $"%{selectedClientCode}%")),
                "HOLOTUTO" => query.Where(t =>
                    EF.Functions.ILike(t.TemplateCode, $"%{selectedClientCode}%") ||
                    EF.Functions.ILike(t.Name, $"%{selectedClientCode}%")),
                _ => query.Where(t =>
                    EF.Functions.ILike(t.TemplateCode, $"%{selectedClientCode}%") ||
                    EF.Functions.ILike(t.Name, $"%{selectedClientCode}%"))
            };
        }

        var totalItems = await query.CountAsync(ct);

        var templates = await query
            .OrderBy(t => t.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        var vm = new TemplatesIndexViewModel
        {
            Templates = templates,
            ApplicationFilters = clientApplications
                .Select(c => new TemplateApplicationFilterOption
                {
                    ClientCode = c.ClientCode,
                    DisplayName = $"{c.Name} ({c.ClientCode})"
                })
                .ToList(),
            SelectedClientCode = selectedClientCode,
            SearchTerm = searchTerm,
            CurrentPage = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };

        return View(vm);
    }

    public IActionResult Create() => View(new EmailTemplateViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmailTemplateViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(model);

        if (await db.EmailTemplates.AnyAsync(t => t.TemplateCode == model.TemplateCode, ct))
        {
            ModelState.AddModelError(nameof(model.TemplateCode), "Ce code template existe déjà.");
            return View(model);
        }

        var entity = MapToEntity(model);
        entity.Version = 1;
        entity.HtmlBody = templateRenderer.SanitizeHtml(entity.HtmlBody);

        db.EmailTemplates.Add(entity);
        db.EmailTemplateVersions.Add(new EmailTemplateVersion
        {
            EmailTemplateId = entity.Id,
            Version = 1,
            SubjectTemplate = entity.SubjectTemplate,
            HtmlBody = entity.HtmlBody,
            TextBody = entity.TextBody,
            CreatedBy = User.Identity?.Name
        });

        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.TemplateCreated, User.Identity?.Name,
            entityType: nameof(EmailTemplate), entityId: entity.Id.ToString());

        return RedirectToAction(nameof(Edit), new { id = entity.Id });
    }

    public async Task<IActionResult> Edit(Guid id, CancellationToken ct)
    {
        var entity = await db.EmailTemplates
            .Include(t => t.Versions.OrderByDescending(v => v.Version))
            .FirstOrDefaultAsync(t => t.Id == id, ct);

        if (entity is null) return NotFound();

        var vm = MapToViewModel(entity);
        vm.Variables = templateRenderer.ExtractVariables(entity.SubjectTemplate, entity.HtmlBody, entity.TextBody);
        return View(vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, EmailTemplateViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(model);

        var entity = await db.EmailTemplates.FindAsync([id], ct);
        if (entity is null) return NotFound();

        entity.Name = model.Name;
        entity.SubjectTemplate = model.SubjectTemplate;
        entity.HtmlBody = templateRenderer.SanitizeHtml(model.HtmlBody);
        entity.TextBody = model.TextBody;
        entity.Language = model.Language;
        entity.IsActive = model.IsActive;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.Version++;

        db.EmailTemplateVersions.Add(new EmailTemplateVersion
        {
            EmailTemplateId = entity.Id,
            Version = entity.Version,
            SubjectTemplate = entity.SubjectTemplate,
            HtmlBody = entity.HtmlBody,
            TextBody = entity.TextBody,
            CreatedBy = User.Identity?.Name
        });

        await db.SaveChangesAsync(ct);
        await auditService.LogAsync(AuditAction.TemplateUpdated, User.Identity?.Name,
            entityType: nameof(EmailTemplate), entityId: entity.Id.ToString());

        return RedirectToAction(nameof(Edit), new { id });
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public IActionResult Preview([FromBody] TemplatePreviewRequest request)
    {
        var subject = templateRenderer.Render(request.SubjectTemplate, request.SampleData);
        var html = templateRenderer.Render(request.HtmlBody, request.SampleData);
        var text = request.TextBody is not null ? templateRenderer.Render(request.TextBody, request.SampleData) : null;
        return Json(new { subject, html, text });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Duplicate(Guid id, CancellationToken ct)
    {
        var source = await db.EmailTemplates.FindAsync([id], ct);
        if (source is null) return NotFound();

        var copy = new EmailTemplate
        {
            TemplateCode = source.TemplateCode + "_COPY_" + DateTime.UtcNow.Ticks % 10000,
            Name = source.Name + " (copie)",
            SubjectTemplate = source.SubjectTemplate,
            HtmlBody = source.HtmlBody,
            TextBody = source.TextBody,
            Language = source.Language,
            Version = 1,
            IsActive = false
        };

        db.EmailTemplates.Add(copy);
        await db.SaveChangesAsync(ct);
        return RedirectToAction(nameof(Edit), new { id = copy.Id });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SendTest(TemplateTestRequest request, CancellationToken ct)
    {
        string subjectTpl, htmlTpl;
        string? textTpl;

        if (request.TemplateId.HasValue)
        {
            var t = await db.EmailTemplates.FindAsync([request.TemplateId.Value], ct);
            if (t is null) return BadRequest();
            subjectTpl = t.SubjectTemplate;
            htmlTpl = t.HtmlBody;
            textTpl = t.TextBody;
        }
        else
        {
            subjectTpl = request.SubjectTemplate ?? "";
            htmlTpl = request.HtmlBody ?? "";
            textTpl = request.TextBody;
        }

        var subject = templateRenderer.Render(subjectTpl, request.SampleData);
        var html = templateRenderer.SanitizeHtml(templateRenderer.Render(htmlTpl, request.SampleData));
        var text = textTpl is not null ? templateRenderer.Render(textTpl, request.SampleData) : null;

        var testClient = await db.ClientApplications.FirstOrDefaultAsync(ct);
        if (testClient is null) return BadRequest("Aucune application cliente configurée.");

        var mailCode = await mailCodeGenerator.GenerateAsync(ct);
        var msg = new EmailMessage
        {
            MailCode = mailCode,
            ClientApplicationId = testClient.Id,
            TemplateCode = "TEST",
            ToAddresses = System.Text.Json.JsonSerializer.Serialize(new[] { request.TestEmail }),
            Subject = "[TEST] " + subject,
            HtmlBody = html,
            TextBody = text,
            Status = EmailStatus.Queued,
            Priority = Models.Enums.EmailPriority.High
        };

        db.EmailMessages.Add(msg);
        await db.SaveChangesAsync(ct);
        await emailSender.SendAsync(msg.Id, ct);

        TempData["TestResult"] = $"E-mail test envoyé ({mailCode}) vers {request.TestEmail}";
        return request.TemplateId.HasValue
            ? RedirectToAction(nameof(Edit), new { id = request.TemplateId })
            : RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Versions(Guid id, CancellationToken ct)
    {
        var versions = await db.EmailTemplateVersions
            .Where(v => v.EmailTemplateId == id)
            .OrderByDescending(v => v.Version)
            .ToListAsync(ct);
        ViewBag.TemplateId = id;
        return View(versions);
    }

    private static EmailTemplate MapToEntity(EmailTemplateViewModel m) => new()
    {
        TemplateCode = m.TemplateCode.ToUpperInvariant(),
        Name = m.Name,
        SubjectTemplate = m.SubjectTemplate,
        HtmlBody = m.HtmlBody,
        TextBody = m.TextBody,
        Language = m.Language,
        IsActive = m.IsActive
    };

    private static EmailTemplateViewModel MapToViewModel(EmailTemplate e) => new()
    {
        Id = e.Id,
        TemplateCode = e.TemplateCode,
        Name = e.Name,
        SubjectTemplate = e.SubjectTemplate,
        HtmlBody = e.HtmlBody,
        TextBody = e.TextBody,
        Language = e.Language,
        IsActive = e.IsActive
    };

}
