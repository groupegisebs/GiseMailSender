using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using SecureMailGateway.Authorization;
using SecureMailGateway.Data;
using SecureMailGateway.Models.Dtos;
using SecureMailGateway.Models.Entities;
using SecureMailGateway.Models.Enums;
using SecureMailGateway.Services;
using SecureMailGateway.ViewModels;

namespace SecureMailGateway.Controllers;

[Authorize(Roles = $"{AppRoles.Admin},{AppRoles.Developer}")]
public class TemplatesController(
    ApplicationDbContext db,
    ITemplateRenderer templateRenderer,
    IHtmlSanitizerService htmlSanitizerService,
    ITemplatePreviewService templatePreviewService,
    OpenAiTemplateService openAiTemplateService,
    IImageUploadService imageUploadService,
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
        // Custom {{Variable}} placeholders are allowed (per-template variable set); the catalog is a
        // recommended default, not an exclusive whitelist. Well-formed tokens survive sanitization.
        if (!ModelState.IsValid)
        {
            model.Variables = templateRenderer.ExtractVariables(model.SubjectTemplate, model.HtmlBody, model.TextBody);
            return View(model);
        }

        if (await db.EmailTemplates.AnyAsync(t => t.TemplateCode == model.TemplateCode, ct))
        {
            ModelState.AddModelError(nameof(model.TemplateCode), "Ce code template existe déjà.");
            return View(model);
        }

        var entity = MapToEntity(model);
        entity.Version = 1;
        entity.HtmlBody = htmlSanitizerService.Sanitize(entity.HtmlBody);

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
        // Custom {{Variable}} placeholders are allowed (per-template variable set); the catalog is a
        // recommended default, not an exclusive whitelist. Well-formed tokens survive sanitization.
        if (!ModelState.IsValid)
        {
            model.Variables = templateRenderer.ExtractVariables(model.SubjectTemplate, model.HtmlBody, model.TextBody);
            return View(model);
        }

        var entity = await db.EmailTemplates.FindAsync([id], ct);
        if (entity is null) return NotFound();

        entity.Name = model.Name;
        entity.SubjectTemplate = model.SubjectTemplate;
        entity.HtmlBody = htmlSanitizerService.Sanitize(model.HtmlBody);
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
        // Custom variables are allowed, so the preview always renders (any {{Variable}} without a
        // sample value simply falls back to its catalog default or stays as the literal token).
        var preview = templatePreviewService.BuildPreview(request);
        return Json(new { subject = preview.Subject, html = preview.Html, text = preview.Text });
    }

    [HttpPost("templates/ai/generate"), ValidateAntiForgeryToken]
    public async Task<IActionResult> GenerateWithAi([FromBody] AiTemplateGenerateRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .ToArray();
            return BadRequest(new { message = "Paramètres invalides pour la génération IA.", errors });
        }

        AiTemplateGenerateResponse aiResult;
        try
        {
            aiResult = await openAiTemplateService.GenerateEmailTemplateAsync(request, ct);
        }
        catch (AiTemplateGenerationException ex)
        {
            // The message is always safe to surface (never contains the API key).
            return BadRequest(new
            {
                message = ex.Message,
                warnings = ex.Detail is { Length: > 0 } detail ? new[] { detail } : []
            });
        }

        var warnings = aiResult.Warnings.ToList();

        // Keep every well-formed {{Variable}} the AI used (catalog or custom); only normalize the
        // token formatting. Nothing is stripped based on the catalog.
        var subject = NormalizeTemplateVariables(aiResult.Subject);
        var normalizedHtml = NormalizeTemplateVariables(aiResult.BodyHtml);
        var bodyText = NormalizeTemplateVariables(aiResult.BodyText);
        var bodyHtml = htmlSanitizerService.Sanitize(normalizedHtml);
        if (!string.Equals(normalizedHtml, bodyHtml, StringComparison.Ordinal))
        {
            warnings.Add("Le HTML généré a été assaini pour la sécurité.");
        }

        var recommendedSamples = NormalizeRecommendedVariables(aiResult);
        var extractedVariables = templateRenderer.ExtractVariables(subject, bodyHtml, bodyText);

        var variableNames = extractedVariables
            .Concat(recommendedSamples.Keys)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(v => v)
            .ToList();

        var testData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var variableName in variableNames)
        {
            testData[variableName] = recommendedSamples.TryGetValue(variableName, out var sampleValue)
                ? sampleValue
                : CreateFallbackSampleValue(variableName);
        }

        var variables = variableNames
            .Select(v => new AiTemplateVariable
            {
                Name = v,
                Token = $"{{{{{v}}}}}",
                SampleValue = testData[v]
            })
            .ToList();

        return Json(new AiTemplateGenerateResponse
        {
            Subject = subject,
            BodyHtml = bodyHtml,
            BodyText = bodyText,
            TestData = testData,
            Variables = variables,
            Warnings = warnings.Distinct().ToList()
        });
    }

    [HttpPost("templates/images/upload"), ValidateAntiForgeryToken]
    [RequestSizeLimit(8 * 1024 * 1024)]
    public async Task<IActionResult> UploadImage(IFormFile? file, CancellationToken ct)
    {
        var result = await imageUploadService.SaveAsync(file, Request, ct);
        if (!result.Success)
            return BadRequest(new { message = result.Error });

        return Json(new { url = result.Url, fileName = result.FileName });
    }

    [HttpGet("templates/images")]
    public IActionResult ListImages()
    {
        var items = imageUploadService.List(Request)
            .Select(i => new { url = i.Url, fileName = i.FileName, size = i.Size });
        return Json(items);
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
        var html = htmlSanitizerService.Sanitize(templateRenderer.Render(htmlTpl, request.SampleData));
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

    private static Dictionary<string, string> NormalizeRecommendedVariables(AiTemplateGenerateResponse aiResult)
    {
        // Accept every AI-suggested variable with a valid identifier name (catalog or custom),
        // attaching the AI-provided sample value (or a sensible fallback) so previews render.
        // Sources: the variables[] list (with Token/SampleValue) and the testData{} map.
        var samples = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var variable in aiResult.Variables)
        {
            var normalizedName = NormalizeVariableName(variable.Name);
            if (normalizedName is null) continue;

            samples[normalizedName] = string.IsNullOrWhiteSpace(variable.SampleValue)
                ? CreateFallbackSampleValue(normalizedName)
                : variable.SampleValue.Trim();
        }

        foreach (var (name, value) in aiResult.TestData)
        {
            var normalizedName = NormalizeVariableName(name);
            if (normalizedName is null || samples.ContainsKey(normalizedName)) continue;

            samples[normalizedName] = string.IsNullOrWhiteSpace(value)
                ? CreateFallbackSampleValue(normalizedName)
                : value.Trim();
        }

        return samples;
    }

    private static string NormalizeTemplateVariables(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        // Preserve every well-formed placeholder (catalog or custom); only tidy the token formatting.
        return Regex.Replace(input, @"\{\{\s*([A-Za-z][A-Za-z0-9_]*)\s*\}\}", match =>
        {
            var normalizedName = NormalizeVariableName(match.Groups[1].Value);
            return normalizedName is null ? string.Empty : $"{{{{{normalizedName}}}}}";
        }, RegexOptions.CultureInvariant);
    }

    private static string? NormalizeVariableName(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;

        var cleaned = Regex.Replace(value, @"[^A-Za-z0-9_]", string.Empty, RegexOptions.CultureInvariant).Trim();
        if (string.IsNullOrWhiteSpace(cleaned)) return null;

        if (!char.IsLetter(cleaned[0]))
        {
            cleaned = $"Var{cleaned}";
        }

        return cleaned;
    }

    private static string CreateFallbackSampleValue(string variableName) =>
        TemplateVariableCatalog.GetSampleValue(variableName);

}
