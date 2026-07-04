using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
    IHtmlSanitizerService htmlSanitizerService,
    ITemplatePreviewService templatePreviewService,
    ITemplateAiService templateAiService,
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
        var unknownCreateVariables = htmlSanitizerService.GetUnknownVariables(model.SubjectTemplate, model.HtmlBody, model.TextBody);
        if (unknownCreateVariables.Count > 0)
        {
            ModelState.AddModelError(string.Empty, $"Variables non autorisees detectees: {string.Join(", ", unknownCreateVariables)}");
        }

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
        var unknownEditVariables = htmlSanitizerService.GetUnknownVariables(model.SubjectTemplate, model.HtmlBody, model.TextBody);
        if (unknownEditVariables.Count > 0)
        {
            ModelState.AddModelError(string.Empty, $"Variables non autorisees detectees: {string.Join(", ", unknownEditVariables)}");
        }

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
        var preview = templatePreviewService.BuildPreview(request);
        if (preview.UnknownVariables.Count > 0)
        {
            return BadRequest(new
            {
                message = "Variables non autorisees detectees.",
                unknownVariables = preview.UnknownVariables
            });
        }

        return Json(new { subject = preview.Subject, html = preview.Html, text = preview.Text });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> GenerateWithAi([FromBody] TemplateAiGenerateRequest request, CancellationToken ct)
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

        var aiResult = await templateAiService.GenerateAsync(new TemplateAiGenerationRequest
        {
            Objective = request.Objective.Trim(),
            BrandOrCompany = request.BrandOrCompany?.Trim(),
            Tone = request.Tone?.Trim(),
            Language = request.Language?.Trim(),
            EmailType = request.EmailType?.Trim(),
            Cta = request.Cta?.Trim(),
            OptionalVariables = request.OptionalVariables?.Trim(),
            AllowedVariables = htmlSanitizerService.AllowedVariables
        }, ct);

        if (!aiResult.Success)
        {
            return BadRequest(new
            {
                message = aiResult.UserMessage,
                warnings = aiResult.Warnings
            });
        }

        var warnings = aiResult.Warnings.ToList();
        var allowedSet = new HashSet<string>(htmlSanitizerService.AllowedVariables, StringComparer.OrdinalIgnoreCase);

        var subjectTemplate = NormalizeTemplateVariables(aiResult.SubjectTemplate, allowedSet, warnings);
        var normalizedHtml = NormalizeTemplateVariables(aiResult.HtmlBody, allowedSet, warnings);
        var textBody = NormalizeTemplateVariables(aiResult.TextBody, allowedSet, warnings);
        var htmlBody = htmlSanitizerService.Sanitize(normalizedHtml);
        if (!string.Equals(normalizedHtml, htmlBody, StringComparison.Ordinal))
        {
            warnings.Add("Le HTML généré a été assaini pour la sécurité.");
        }

        var recommendedSamples = NormalizeRecommendedVariables(aiResult.Variables, allowedSet, warnings);
        var extractedVariables = templateRenderer.ExtractVariables(subjectTemplate, htmlBody, textBody);

        var variableNames = extractedVariables
            .Concat(recommendedSamples.Keys)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(v => v)
            .ToList();

        var sampleData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var variableName in variableNames)
        {
            if (recommendedSamples.TryGetValue(variableName, out var sampleValue))
            {
                sampleData[variableName] = sampleValue;
            }
            else
            {
                sampleData[variableName] = CreateFallbackSampleValue(variableName);
            }
        }

        var variables = variableNames
            .Select(v => new TemplateAiVariableViewModel
            {
                Name = v,
                Token = $"{{{{{v}}}}}",
                SampleValue = sampleData[v]
            })
            .ToList();

        return Json(new
        {
            subjectTemplate,
            htmlBody,
            textBody,
            variables,
            sampleData,
            warnings = warnings.Distinct().ToList()
        });
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

    private static Dictionary<string, string> NormalizeRecommendedVariables(
        IReadOnlyList<TemplateAiVariableSuggestion> aiVariables,
        HashSet<string> allowedSet,
        List<string> warnings)
    {
        var samples = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var variable in aiVariables)
        {
            var normalizedName = NormalizeVariableName(variable.Name);
            if (normalizedName is null) continue;

            if (!allowedSet.Contains(normalizedName))
            {
                warnings.Add($"Variable IA ignorée (non autorisée): {normalizedName}");
                continue;
            }

            samples[normalizedName] = string.IsNullOrWhiteSpace(variable.SampleValue)
                ? CreateFallbackSampleValue(normalizedName)
                : variable.SampleValue.Trim();
        }

        return samples;
    }

    private static string NormalizeTemplateVariables(string input, HashSet<string> allowedSet, List<string> warnings)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        return Regex.Replace(input, @"\{\{\s*([A-Za-z][A-Za-z0-9_]*)\s*\}\}", match =>
        {
            var rawName = match.Groups[1].Value;
            var normalizedName = NormalizeVariableName(rawName);
            if (normalizedName is null) return string.Empty;

            if (!allowedSet.Contains(normalizedName))
            {
                warnings.Add($"Variable IA retirée du template (non autorisée): {normalizedName}");
                return normalizedName;
            }

            return $"{{{{{normalizedName}}}}}";
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
