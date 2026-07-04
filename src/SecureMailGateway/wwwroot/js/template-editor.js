(function () {
    'use strict';

    const htmlBodyEl = document.getElementById('htmlBody');
    const variableListEl = document.getElementById('variableList');
    const formEl = document.getElementById('templateForm');
    if (!htmlBodyEl || !variableListEl) return;

    const previewUrl = htmlBodyEl.dataset.previewUrl;
    const defaultVariables = (htmlBodyEl.dataset.variables || 'FirstName,CompanyName,Title,Message')
        .split(',').map(v => v.trim()).filter(Boolean);

    const presets = {
        welcome: {
            subject: 'Bienvenue {{FirstName}} chez {{CompanyName}}',
            text: 'Bienvenue {{FirstName}} chez {{CompanyName}}. Votre compte est actif.',
            html: `<div style="font-family:Arial,sans-serif;max-width:600px;margin:0 auto;padding:32px;background:#ffffff;">
  <h1 style="color:#1e40af;margin:0 0 16px;">Bienvenue {{FirstName}} !</h1>
  <p style="color:#334155;line-height:1.6;margin:0 0 12px;">Nous sommes ravis de vous accueillir chez <strong>{{CompanyName}}</strong>.</p>
  <p style="color:#334155;line-height:1.6;margin:0;">Votre compte est maintenant actif.</p>
  <p style="color:#94a3b8;font-size:12px;margin-top:32px;border-top:1px solid #e2e8f0;padding-top:16px;">{{CompanyName}}</p>
</div>`
        },
        notification: {
            subject: '{{Title}} — {{CompanyName}}',
            text: 'Bonjour {{FirstName}}, {{Message}}',
            html: `<div style="font-family:Arial,sans-serif;max-width:600px;margin:0 auto;padding:32px;background:#f8fafc;border:1px solid #e2e8f0;border-radius:8px;">
  <h2 style="color:#1e40af;margin:0 0 16px;">{{Title}}</h2>
  <p style="color:#334155;line-height:1.6;margin:0 0 12px;">Bonjour {{FirstName}},</p>
  <p style="color:#334155;line-height:1.6;margin:0;">{{Message}}</p>
  <p style="color:#64748b;font-size:12px;margin-top:32px;">{{CompanyName}}</p>
</div>`
        },
        alert: {
            subject: 'Action requise — {{CompanyName}}',
            text: 'Bonjour {{FirstName}}, {{Message}}',
            html: `<div style="font-family:Arial,sans-serif;max-width:600px;margin:0 auto;padding:32px;background:#fef2f2;border-left:4px solid #dc2626;">
  <h2 style="color:#dc2626;margin:0 0 16px;">Action requise</h2>
  <p style="color:#334155;line-height:1.6;margin:0 0 12px;">Bonjour {{FirstName}},</p>
  <p style="color:#334155;line-height:1.6;margin:0;">{{Message}}</p>
  <p style="color:#64748b;font-size:12px;margin-top:32px;">{{CompanyName}}</p>
</div>`
        },
        action: {
            subject: '{{Title}} — {{CompanyName}}',
            text: 'Bonjour {{FirstName}}, {{Message}}',
            html: `<div style="font-family:Arial,sans-serif;max-width:600px;margin:0 auto;padding:32px;">
  <h1 style="color:#1e40af;margin:0 0 16px;">{{Title}}</h1>
  <p style="color:#334155;line-height:1.6;margin:0 0 12px;">Bonjour {{FirstName}},</p>
  <p style="color:#334155;line-height:1.6;margin:0 0 24px;">{{Message}}</p>
  <p style="text-align:center;margin:32px 0;">
    <a href="https://example.com" style="background:#2563eb;color:#ffffff;padding:14px 28px;text-decoration:none;border-radius:6px;font-weight:bold;display:inline-block;">Accéder à mon compte</a>
  </p>
  <p style="color:#94a3b8;font-size:12px;margin-top:32px;">{{CompanyName}}</p>
</div>`
        }
    };

    const knownVariables = new Set();
    function tinyEditor() {
        return window.tinymce?.get('htmlBody') ?? null;
    }

    function normalizeVariableName(name) {
        return name.trim().replace(/\s+/g, '');
    }

    function isValidVariableName(name) {
        return /^[A-Za-z][A-Za-z0-9_]*$/.test(name);
    }

    function variableToken(name) {
        return '{{' + name + '}}';
    }

    function renderVariableBadge(name) {
        const badge = document.createElement('span');
        badge.className = 'badge bg-primary variable-badge me-1 mb-1';
        badge.dataset.var = variableToken(name);
        badge.dataset.name = name;
        badge.textContent = variableToken(name);
        badge.title = 'Cliquer pour insérer dans le message';
        badge.addEventListener('click', () => insertVariable(name));
        return badge;
    }

    function refreshVariableSelect() {
        const select = document.getElementById('variableInsertSelect');
        if (!select) return;
        const current = select.value;
        select.innerHTML = '<option value="">— Choisir —</option>';
        [...knownVariables].sort().forEach(name => {
            const opt = document.createElement('option');
            opt.value = name;
            opt.textContent = variableToken(name);
            select.appendChild(opt);
        });
        if (current && knownVariables.has(current)) select.value = current;
    }

    function addVariable(name, silent) {
        const normalized = normalizeVariableName(name);
        if (!normalized) return false;
        if (!isValidVariableName(normalized)) {
            if (!silent) alert('Nom invalide. Utilisez des lettres, chiffres et _ (ex. FirstName, OrderId).');
            return false;
        }
        if (knownVariables.has(normalized)) return true;

        knownVariables.add(normalized);
        variableListEl.appendChild(renderVariableBadge(normalized));
        refreshVariableSelect();
        return true;
    }

    function bindExistingVariableBadges() {
        variableListEl.querySelectorAll('.variable-badge').forEach(badge => {
            const name = badge.dataset.name;
            if (!name) return;
            knownVariables.add(name);
            if (badge.dataset.bound) return;
            badge.dataset.bound = '1';
            badge.title = 'Cliquer pour insérer dans le message';
            badge.addEventListener('click', () => insertVariable(name));
        });
    }

    function getHtmlBody() {
        const editor = tinyEditor();
        if (editor) return editor.getContent();
        return htmlBodyEl.value;
    }

    function setHtmlBody(html) {
        const editor = tinyEditor();
        htmlBodyEl.value = html;
        if (editor) editor.setContent(html || '');
    }

    function insertVariable(name) {
        const token = variableToken(name);
        const editor = tinyEditor();
        if (editor) {
            editor.focus();
            editor.insertContent(token);
            htmlBodyEl.value = editor.getContent();
        } else {
            const start = htmlBodyEl.selectionStart ?? htmlBodyEl.value.length;
            const end = htmlBodyEl.selectionEnd ?? htmlBodyEl.value.length;
            htmlBodyEl.value = htmlBodyEl.value.slice(0, start) + token + htmlBodyEl.value.slice(end);
            htmlBodyEl.focus();
            htmlBodyEl.selectionStart = htmlBodyEl.selectionEnd = start + token.length;
        }
        extractVariablesFromContent();
        updatePreview();
    }

    function getSampleData() {
        const data = {};
        document.querySelectorAll('.sample-field').forEach(el => {
            data[el.dataset.key] = el.value;
        });
        return data;
    }

    function syncSampleFieldsFromVariables() {
        const container = document.getElementById('sampleDataFields');
        if (!container) return;

        [...knownVariables].forEach(name => {
            if (container.querySelector(`[data-key="${name}"]`)) return;
            const col = document.createElement('div');
            col.className = 'col-6';
            col.innerHTML = `<input class="form-control form-control-sm sample-field" data-key="${name}" placeholder="${name}" value="" />`;
            container.appendChild(col);
            col.querySelector('input').addEventListener('input', updatePreview);
        });
    }

    async function updatePreview() {
        if (!previewUrl) return;
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
        const res = await fetch(previewUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'RequestVerificationToken': token },
            body: JSON.stringify({
                subjectTemplate: document.getElementById('subjectTemplate').value,
                htmlBody: getHtmlBody(),
                textBody: document.getElementById('textBody').value,
                sampleData: getSampleData()
            })
        });
        const data = await res.json();
        document.getElementById('previewPane').innerHTML = '<h5>' + data.subject + '</h5>' + data.html;
    }

    function applyPreset(key) {
        const preset = presets[key];
        if (!preset) return;

        const hasContent = getHtmlBody().replace(/<[^>]*>/g, '').trim().length > 0;
        if (hasContent && !confirm('Remplacer le contenu actuel par ce modèle ?')) return;

        if (!document.getElementById('subjectTemplate').value.trim())
            document.getElementById('subjectTemplate').value = preset.subject;
        if (!document.getElementById('textBody').value.trim())
            document.getElementById('textBody').value = preset.text;

        setHtmlBody(preset.html);
        extractVariablesFromContent();
        updatePreview();
    }

    function extractVariablesFromContent() {
        const content = [
            document.getElementById('subjectTemplate').value,
            getHtmlBody(),
            document.getElementById('textBody').value
        ].join(' ');
        const matches = content.matchAll(/\{\{([A-Za-z][A-Za-z0-9_]*)\}\}/g);
        for (const match of matches) addVariable(match[1], true);
        syncSampleFieldsFromVariables();
    }

    bindExistingVariableBadges();
    defaultVariables.forEach(v => addVariable(v, true));
    syncSampleFieldsFromVariables();
    refreshVariableSelect();

    htmlBodyEl.addEventListener('input', () => {
        extractVariablesFromContent();
        updatePreview();
    });

    document.getElementById('btnApplyPreset')?.addEventListener('click', () => {
        const key = document.getElementById('presetSelect').value;
        if (!key) return;
        applyPreset(key);
        document.getElementById('presetSelect').value = '';
    });

    document.getElementById('btnAddVariable')?.addEventListener('click', () => {
        const input = document.getElementById('newVariableName');
        if (addVariable(input.value)) {
            input.value = '';
            input.focus();
            syncSampleFieldsFromVariables();
        }
    });

    document.getElementById('newVariableName')?.addEventListener('keydown', e => {
        if (e.key === 'Enter') {
            e.preventDefault();
            document.getElementById('btnAddVariable')?.click();
        }
    });

    document.getElementById('btnInsertVariable')?.addEventListener('click', () => {
        const name = document.getElementById('variableInsertSelect').value;
        if (name) insertVariable(name);
    });

    document.getElementById('btnPreview')?.addEventListener('click', updatePreview);
    document.getElementById('subjectTemplate')?.addEventListener('input', () => {
        extractVariablesFromContent();
        updatePreview();
    });
    document.getElementById('textBody')?.addEventListener('input', () => {
        extractVariablesFromContent();
        updatePreview();
    });
    document.querySelectorAll('.sample-field').forEach(el => el.addEventListener('input', updatePreview));

    formEl?.addEventListener('submit', () => {
        window.tinymce?.triggerSave();
    });

    document.getElementById('testModal')?.addEventListener('show.bs.modal', function () {
        window.tinymce?.triggerSave();
        document.getElementById('testSubject').value = document.getElementById('subjectTemplate').value;
        document.getElementById('testHtml').value = getHtmlBody();
        document.getElementById('testText').value = document.getElementById('textBody').value;
        const container = document.getElementById('testSampleData');
        container.innerHTML = '';
        Object.entries(getSampleData()).forEach(([k, v]) => {
            container.innerHTML += `<input type="hidden" name="SampleData[${k}]" value="${v.replace(/"/g, '&quot;')}" />`;
        });
    });

    if (window.tinymce && typeof window.tinymce.init === 'function') {
        window.tinymce.init({
            selector: '#htmlBody',
            menubar: false,
            height: 420,
            plugins: 'link lists code table autoresize',
            toolbar: 'undo redo | blocks | bold italic underline | forecolor backcolor | alignleft aligncenter alignright | bullist numlist | link table | code',
            branding: false,
            setup(editor) {
                editor.on('init', () => {
                    htmlBodyEl.value = editor.getContent();
                    extractVariablesFromContent();
                    updatePreview();
                });
                editor.on('change input keyup undo redo setcontent', () => {
                    htmlBodyEl.value = editor.getContent();
                    extractVariablesFromContent();
                    updatePreview();
                });
            }
        });
    } else {
        extractVariablesFromContent();
        updatePreview();
    }
})();
