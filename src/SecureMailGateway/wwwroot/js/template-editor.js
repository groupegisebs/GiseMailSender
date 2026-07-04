(function () {
    'use strict';

    const config = window.secureMailTemplateEditorConfig || {};
    const initialAllowedVariables = Array.isArray(config.allowedVariables) ? config.allowedVariables : [];
    const testDataDefaults = config.testDataDefaults && typeof config.testDataDefaults === 'object'
        ? config.testDataDefaults
        : {};
    const form = document.getElementById('templateForm');
    const editorRoot = document.getElementById('SecureMailTemplateEditor');
    const visualEditor = document.getElementById('visualEditor');
    const htmlSourceEditor = document.getElementById('htmlSourceEditor');
    const previewPane = document.getElementById('previewPane');
    const previewSubject = document.getElementById('previewSubject');
    const previewSurface = document.getElementById('previewSurface');
    const subjectTemplate = document.getElementById('subjectTemplate');
    const htmlBodyHidden = document.getElementById('HtmlBodyHidden');
    const textBodyHidden = document.getElementById('TextBodyHidden');
    const bodyHtmlHidden = document.getElementById('BodyHtml');
    const bodyTextHidden = document.getElementById('BodyText');
    const subjectHidden = document.getElementById('Subject');
    const codeTemplateHidden = document.getElementById('CodeTemplate');
    const activeHidden = document.getElementById('Active');
    const templateCodeInput = document.getElementById('TemplateCode');
    const isActiveInput = document.getElementById('IsActive');
    const variablePalette = document.getElementById('variablePalette');
    const sampleDataFields = document.getElementById('sampleDataFields');

    if (!form || !visualEditor || !htmlSourceEditor || !previewPane || !subjectTemplate) {
        return;
    }

    let htmlMode = false;
    let previewAbortController = null;
    let previewDebounce = null;
    let unknownPromptDebounce = null;
    let unknownPromptInProgress = false;
    let lastUnknownPromptSignature = '';
    const allowedVariables = [];

    const quickBlocks = {
        'header-logo': '<div style="padding:16px;background:#6D5DF6;color:#ffffff;font-weight:700;border-radius:12px;">SecureMail</div><p><br></p>',
        'welcome-message': '<h2 style="margin:0 0 8px 0;">Bienvenue {{FirstName}},</h2><p>Nous sommes heureux de vous compter parmi {{CompanyName}}.</p>',
        'verification-code': '<div style="border:1px solid #E5E7EB;padding:16px;border-radius:12px;text-align:center;"><p style="margin-bottom:8px;">Code de verification</p><p style="font-size:26px;letter-spacing:4px;font-weight:700;">123456</p></div>',
        'primary-button': '<p style="margin:16px 0;"><a href="{{ResetLink}}" style="display:inline-block;background:#2563EB;color:#ffffff;text-decoration:none;padding:12px 18px;border-radius:10px;font-weight:600;">Confirmer</a></p>',
        'invoice-block': '<table style="width:100%;border:1px solid #E5E7EB;border-radius:12px;"><tr><td style="padding:10px;font-weight:600;">Commande</td><td style="padding:10px;">{{OrderId}}</td></tr><tr><td style="padding:10px;font-weight:600;">Montant</td><td style="padding:10px;">{{Amount}}</td></tr><tr><td style="padding:10px;font-weight:600;">Date</td><td style="padding:10px;">{{InvoiceDate}}</td></tr></table>',
        'security-alert': '<div style="border-left:4px solid #DC2626;background:#FEE2E2;padding:14px;border-radius:10px;"><h3 style="color:#991B1B;margin:0 0 8px 0;">Alerte de securite</h3><p style="margin:0;">{{Message}}</p></div>',
        'legal-footer': '<hr><p style="font-size:12px;color:#6B7280;">Vous recevez cet e-mail car vous utilisez SecureMail. Ce message est confidentiel.</p>',
        'team-signature': '<p>Cordialement,<br><strong>L\'equipe SecureMail</strong></p>'
    };

    function normalizeVariableName(value) {
        if (!value || typeof value !== 'string') return '';
        let cleaned = value.trim().replace(/[^A-Za-z0-9_]/g, '');
        if (!cleaned) return '';
        if (!/^[A-Za-z]/.test(cleaned)) {
            cleaned = 'Var' + cleaned;
        }
        return cleaned;
    }

    function isVariableAlreadyAllowed(variableName) {
        return allowedVariables.some(function (existing) {
            return existing.toLowerCase() === variableName.toLowerCase();
        });
    }

    function bindVariableButton(button) {
        if (!button || button.dataset.bound === 'true') return;
        button.dataset.bound = 'true';
        button.addEventListener('click', function () {
            insertVariable(button.dataset.variable);
        });
    }

    function bindSampleFieldInput(input) {
        if (!input || input.dataset.bound === 'true') return;
        input.dataset.bound = 'true';
        input.addEventListener('input', schedulePreview);
    }

    const PALETTE_STATE_KEY = 'secureMailVariableGroups';
    const CUSTOM_GROUP_KEY = 'Personnalisées';

    function readPaletteState() {
        try {
            const raw = window.localStorage.getItem(PALETTE_STATE_KEY);
            const parsed = raw ? JSON.parse(raw) : {};
            return parsed && typeof parsed === 'object' ? parsed : {};
        } catch (error) {
            return {};
        }
    }

    function writePaletteState(state) {
        try {
            window.localStorage.setItem(PALETTE_STATE_KEY, JSON.stringify(state));
        } catch (error) {
            /* localStorage unavailable (private mode / quota) - persistence is best-effort */
        }
    }

    const paletteGroupState = readPaletteState();

    function setGroupExpanded(toggle, expanded, persist) {
        if (!toggle) return;
        const chipsId = toggle.getAttribute('aria-controls');
        const chips = chipsId ? document.getElementById(chipsId) : null;
        toggle.setAttribute('aria-expanded', expanded ? 'true' : 'false');
        if (chips) {
            if (expanded) {
                chips.removeAttribute('hidden');
            } else {
                chips.setAttribute('hidden', 'hidden');
            }
        }
        if (persist) {
            const key = toggle.dataset.groupKey || '';
            if (key) {
                paletteGroupState[key] = expanded;
                writePaletteState(paletteGroupState);
            }
        }
    }

    function bindGroupToggle(toggle) {
        if (!toggle || toggle.dataset.bound === 'true') return;
        toggle.dataset.bound = 'true';

        const key = toggle.dataset.groupKey || '';
        if (key && Object.prototype.hasOwnProperty.call(paletteGroupState, key)) {
            setGroupExpanded(toggle, paletteGroupState[key] === true, false);
        }

        toggle.addEventListener('click', function () {
            const isExpanded = toggle.getAttribute('aria-expanded') === 'true';
            setGroupExpanded(toggle, !isExpanded, true);
        });
    }

    function initVariableGroups() {
        document.querySelectorAll('#variablePalette [data-group-toggle]').forEach(bindGroupToggle);
    }

    // Dynamically-registered variables (custom / AI-generated) live in their own collapsible
    // "Personnalisées" group so they still benefit from the accordion behaviour.
    function ensureCustomGroupChips() {
        if (!variablePalette) return null;

        let group = variablePalette.querySelector('[data-custom-group]');
        if (!group) {
            group = document.createElement('div');
            group.className = 'securemail-variable-group';
            group.setAttribute('data-custom-group', 'true');
            group.setAttribute('data-group', CUSTOM_GROUP_KEY);

            const chipsId = 'varGroupChipsCustom';

            const toggle = document.createElement('button');
            toggle.type = 'button';
            toggle.className = 'securemail-variable-group-label';
            toggle.setAttribute('data-group-toggle', '');
            toggle.dataset.groupKey = CUSTOM_GROUP_KEY;
            toggle.setAttribute('aria-controls', chipsId);
            toggle.setAttribute('aria-expanded', 'true');

            const caret = document.createElement('span');
            caret.className = 'securemail-variable-group-caret';
            caret.setAttribute('aria-hidden', 'true');
            caret.textContent = '▸';

            const label = document.createElement('span');
            label.className = 'securemail-variable-group-text';
            label.textContent = CUSTOM_GROUP_KEY;

            toggle.appendChild(caret);
            toggle.appendChild(label);

            const chips = document.createElement('div');
            chips.className = 'securemail-variable-group-chips';
            chips.id = chipsId;

            group.appendChild(toggle);
            group.appendChild(chips);
            variablePalette.appendChild(group);

            bindGroupToggle(toggle);
        }

        return group.querySelector('.securemail-variable-group-chips');
    }

    function addVariableToPalette(variableName) {
        const container = ensureCustomGroupChips();
        if (!container) return;
        const button = document.createElement('button');
        button.type = 'button';
        button.className = 'securemail-pill-btn';
        button.dataset.variable = variableName;
        button.textContent = '{{' + variableName + '}}';
        bindVariableButton(button);
        container.appendChild(button);

        // Expand the custom group so the freshly added variable is immediately visible.
        const toggle = variablePalette
            ? variablePalette.querySelector('[data-custom-group] [data-group-toggle]')
            : null;
        if (toggle && toggle.getAttribute('aria-expanded') !== 'true') {
            setGroupExpanded(toggle, true, true);
        }
    }

    function addSampleField(variableName) {
        if (!sampleDataFields) return;
        const wrapper = document.createElement('div');
        wrapper.className = 'securemail-field';

        const label = document.createElement('label');
        label.setAttribute('for', 'sample_' + variableName);
        label.textContent = variableName;

        const input = document.createElement('input');
        input.id = 'sample_' + variableName;
        input.className = 'form-control sample-field';
        input.dataset.key = variableName;
        input.value = testDataDefaults[variableName] || '';

        wrapper.appendChild(label);
        wrapper.appendChild(input);
        sampleDataFields.appendChild(wrapper);
        bindSampleFieldInput(input);
    }

    function addAllowedVariable(variableName) {
        const normalizedName = normalizeVariableName(variableName);
        if (!normalizedName || isVariableAlreadyAllowed(normalizedName)) return false;
        allowedVariables.push(normalizedName);
        addVariableToPalette(normalizedName);
        addSampleField(normalizedName);
        return true;
    }

    // Registers a variable (catalog or custom, e.g. one returned by the AI) into the template's
    // per-template variable set: adds it to the palette + test-data panel and, when provided,
    // fills its sample value so the preview renders.
    function registerVariable(variableName, sampleValue) {
        const normalizedName = normalizeVariableName(variableName);
        if (!normalizedName) return;
        if (!isVariableAlreadyAllowed(normalizedName)) {
            allowedVariables.push(normalizedName);
            addVariableToPalette(normalizedName);
            addSampleField(normalizedName);
        }
        if (typeof sampleValue === 'string' && sampleValue.length > 0) {
            const field = document.getElementById('sample_' + normalizedName);
            if (field) {
                field.value = sampleValue;
            }
        }
    }

    function initializeAllowedVariables() {
        initialAllowedVariables.forEach(function (variableName) {
            const normalizedName = normalizeVariableName(variableName);
            if (normalizedName && !isVariableAlreadyAllowed(normalizedName)) {
                allowedVariables.push(normalizedName);
            }
        });

        document.querySelectorAll('.securemail-pill-btn[data-variable]').forEach(function (button) {
            bindVariableButton(button);
        });
        document.querySelectorAll('.sample-field').forEach(function (input) {
            bindSampleFieldInput(input);
        });
        initVariableGroups();
    }

    function findUnknownVariables() {
        const fullText = [subjectTemplate.value, getEditorHtml()].join(' ');
        const matches = fullText.match(/\{\{\s*([A-Za-z][A-Za-z0-9_]*)\s*\}\}/g) || [];
        const unknown = [];

        matches.forEach(function (token) {
            const rawName = token.replace(/\{\{|\}\}/g, '').trim();
            const varName = normalizeVariableName(rawName);
            if (!varName) return;
            if (!isVariableAlreadyAllowed(varName) && unknown.indexOf(varName) === -1) {
                unknown.push(varName);
            }
        });

        return unknown;
    }

    function escapeRegExp(value) {
        return value.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    }

    function removeUnknownVariablesFromContent(variablesToRemove) {
        if (!Array.isArray(variablesToRemove) || variablesToRemove.length === 0) return;
        const pattern = variablesToRemove.map(escapeRegExp).join('|');
        const tokenRegex = new RegExp('\\{\\{\\s*(' + pattern + ')\\s*\\}\\}', 'g');

        subjectTemplate.value = (subjectTemplate.value || '').replace(tokenRegex, '');
        const cleanedHtml = getEditorHtml().replace(tokenRegex, '');
        setEditorHtml(cleanedHtml);
    }

    function promptUnknownVariables(unknownVariables) {
        if (!Array.isArray(unknownVariables) || unknownVariables.length === 0) return true;

        const signature = unknownVariables.join('|');
        if (unknownPromptInProgress || signature === lastUnknownPromptSignature) return false;

        unknownPromptInProgress = true;
        lastUnknownPromptSignature = signature;

        const message = [
            'Variables inconnues detectees: ' + unknownVariables.join(', '),
            '',
            'OK: ajouter ces variables au template (palette + donnees de test).',
            'Annuler: supprimer ces tokens du sujet et du contenu.'
        ].join('\n');

        const shouldAdd = window.confirm(message);
        if (shouldAdd) {
            unknownVariables.forEach(function (variableName) {
                addAllowedVariable(variableName);
            });
        } else {
            removeUnknownVariablesFromContent(unknownVariables);
        }

        unknownPromptInProgress = false;
        schedulePreview();
        return true;
    }

    function scheduleUnknownPrompt(forceImmediate) {
        if (unknownPromptDebounce) {
            clearTimeout(unknownPromptDebounce);
            unknownPromptDebounce = null;
        }

        const run = function () {
            const unknown = findUnknownVariables();
            if (unknown.length === 0) {
                lastUnknownPromptSignature = '';
                return;
            }
            promptUnknownVariables(unknown);
        };

        if (forceImmediate) {
            run();
            return;
        }

        unknownPromptDebounce = setTimeout(function () {
            unknownPromptDebounce = null;
            run();
        }, 450);
    }

    function getEditorHtml() {
        return htmlMode ? htmlSourceEditor.value : visualEditor.innerHTML;
    }

    function setEditorHtml(html) {
        visualEditor.innerHTML = html || '<p><br></p>';
        htmlSourceEditor.value = visualEditor.innerHTML;
    }

    function restoreEditorFocus() {
        visualEditor.focus();
        const selection = window.getSelection();
        if (!selection || selection.rangeCount > 0) return;
        const range = document.createRange();
        range.selectNodeContents(visualEditor);
        range.collapse(false);
        selection.removeAllRanges();
        selection.addRange(range);
    }

    function insertHtmlAtCursor(html) {
        if (htmlMode) {
            const start = htmlSourceEditor.selectionStart || 0;
            const end = htmlSourceEditor.selectionEnd || 0;
            const current = htmlSourceEditor.value;
            htmlSourceEditor.value = current.slice(0, start) + html + current.slice(end);
            htmlSourceEditor.focus();
            htmlSourceEditor.selectionStart = htmlSourceEditor.selectionEnd = start + html.length;
            return;
        }

        restoreEditorFocus();
        document.execCommand('insertHTML', false, html);
    }

    function execCommand(action) {
        if (!action) return;
        restoreEditorFocus();

        if (action.startsWith('formatBlock:')) {
            const tag = action.split(':')[1];
            document.execCommand('formatBlock', false, tag);
        } else {
            document.execCommand(action, false, null);
        }

        syncSourceFromVisual();
        schedulePreview();
    }

    function insertVariable(variableName) {
        insertHtmlAtCursor('{{' + variableName + '}}');
        syncSourceFromVisual();
        schedulePreview();
    }

    function insertQuickBlock(blockType) {
        const blockHtml = quickBlocks[blockType];
        if (!blockHtml) return;
        insertHtmlAtCursor(blockHtml + '<p><br></p>');
        syncSourceFromVisual();
        schedulePreview();
    }

    function insertButton() {
        insertHtmlAtCursor('<a href="https://example.com" style="display:inline-block;background:#6D5DF6;color:#ffffff;text-decoration:none;padding:12px 18px;border-radius:10px;font-weight:600;">Call to action</a>');
        syncSourceFromVisual();
        schedulePreview();
    }

    function insertImage() {
        const imageUrl = window.prompt('URL de l\'image');
        if (!imageUrl) return;
        insertHtmlAtCursor('<img src="' + imageUrl + '" alt="Image" style="max-width:100%;height:auto;border-radius:12px;" />');
        syncSourceFromVisual();
        schedulePreview();
    }

    function insertLink() {
        const url = window.prompt('URL du lien');
        if (!url) return;
        const label = window.prompt('Texte du lien', 'Cliquez ici') || 'Cliquez ici';
        insertHtmlAtCursor('<a href="' + url + '" target="_blank" rel="noopener noreferrer">' + label + '</a>');
        syncSourceFromVisual();
        schedulePreview();
    }

    function toggleHtmlMode() {
        htmlMode = !htmlMode;
        if (htmlMode) {
            htmlSourceEditor.value = visualEditor.innerHTML;
            visualEditor.classList.add('d-none');
            htmlSourceEditor.classList.remove('d-none');
            htmlSourceEditor.focus();
        } else {
            visualEditor.innerHTML = htmlSourceEditor.value;
            htmlSourceEditor.classList.add('d-none');
            visualEditor.classList.remove('d-none');
            restoreEditorFocus();
        }

        schedulePreview();
    }

    function toggleFullscreen() {
        editorRoot.classList.toggle('is-fullscreen');
        fitPreview();
    }

    function syncSourceFromVisual() {
        if (!htmlMode) {
            htmlSourceEditor.value = visualEditor.innerHTML;
        }
    }

    function getSampleData() {
        const sampleData = {};
        document.querySelectorAll('.sample-field').forEach(function (field) {
            sampleData[field.dataset.key] = field.value || '';
        });
        return sampleData;
    }

    function generatePlainText() {
        const html = getEditorHtml();
        const temp = document.createElement('div');
        temp.innerHTML = html;
        return (temp.textContent || temp.innerText || '').replace(/\s+\n/g, '\n').trim();
    }

    function validateVariables(showSuccessMessage) {
        const unknown = findUnknownVariables();

        if (unknown.length > 0) {
            promptUnknownVariables(unknown);
            const remainingUnknown = findUnknownVariables();
            if (remainingUnknown.length > 0) {
                window.alert('Variables non autorisees: ' + remainingUnknown.join(', '));
                return false;
            }
        }

        if (showSuccessMessage) {
            window.alert('Variables valides.');
        }

        return true;
    }

    function saveEditorContent() {
        const html = getEditorHtml();
        const plainText = generatePlainText();

        if (htmlBodyHidden) htmlBodyHidden.value = html;
        if (textBodyHidden) textBodyHidden.value = plainText;
        if (bodyHtmlHidden) bodyHtmlHidden.value = html;
        if (bodyTextHidden) bodyTextHidden.value = plainText;
        if (subjectHidden) subjectHidden.value = subjectTemplate.value || '';
        if (codeTemplateHidden && templateCodeInput) codeTemplateHidden.value = templateCodeInput.value || '';
        if (activeHidden && isActiveInput) activeHidden.value = isActiveInput.checked ? 'true' : 'false';
    }

    async function updatePreview() {
        if (!config.previewUrl) return;

        if (previewAbortController) {
            previewAbortController.abort();
        }
        previewAbortController = new AbortController();

        const token = document.querySelector('input[name="__RequestVerificationToken"]');
        const headers = {
            'Content-Type': 'application/json',
            Accept: 'application/json'
        };
        if (token) {
            headers.RequestVerificationToken = token.value;
        }

        try {
            const response = await fetch(config.previewUrl, {
                method: 'POST',
                headers: headers,
                body: JSON.stringify({
                    subjectTemplate: subjectTemplate.value || '',
                    htmlBody: getEditorHtml(),
                    textBody: generatePlainText(),
                    sampleData: getSampleData()
                }),
                signal: previewAbortController.signal
            });

            const payload = await response.json();
            if (!response.ok) {
                const unknown = payload.unknownVariables || [];
                const message = unknown.length > 0
                    ? 'Variables non autorisees: ' + unknown.join(', ')
                    : (payload.message || 'Impossible de generer l\'apercu.');
                previewPane.innerHTML = '<div class="text-danger small">' + message + '</div>';
                return;
            }

            previewSubject.textContent = payload.subject || '';
            previewPane.innerHTML = payload.html || '';
            fitPreview();
        } catch (error) {
            if (error && error.name === 'AbortError') return;
            previewPane.innerHTML = '<div class="text-danger small">Erreur lors du chargement de l\'apercu.</div>';
            fitPreview();
        }
    }

    // Scales the fixed-width email preview (600px desktop / 375px mobile) down so
    // the whole email is always visible within the preview column, never clipped.
    function fitPreview() {
        if (!previewPane || !previewSurface) return;
        const viewport = document.getElementById('previewViewport');
        if (!viewport) return;

        const contentWidth = previewSurface.classList.contains('is-mobile') ? 375 : 600;

        previewPane.style.transform = 'none';
        previewPane.style.width = contentWidth + 'px';
        viewport.style.height = 'auto';

        const available = viewport.clientWidth;
        const scale = available > 0 ? Math.min(1, available / contentWidth) : 1;
        const naturalHeight = previewPane.offsetHeight;

        previewPane.style.transform = 'scale(' + scale + ')';
        viewport.style.height = Math.ceil(naturalHeight * scale) + 'px';
    }

    function schedulePreview() {
        if (previewDebounce) clearTimeout(previewDebounce);
        previewDebounce = setTimeout(function () {
            previewDebounce = null;
            updatePreview();
        }, 180);
    }

    document.querySelectorAll('.securemail-tool-btn[data-action]').forEach(function (button) {
        button.addEventListener('click', function () {
            execCommand(button.dataset.action);
        });
    });

    document.querySelectorAll('.securemail-quick-block-btn[data-block]').forEach(function (button) {
        button.addEventListener('click', function () {
            insertQuickBlock(button.dataset.block);
        });
    });

    document.querySelectorAll('.securemail-tool-btn[data-role]').forEach(function (button) {
        button.addEventListener('click', function () {
            const role = button.dataset.role;
            if (role === 'insertButton') insertButton();
            if (role === 'insertImage') insertImage();
            if (role === 'insertLink') insertLink();
            if (role === 'toggleHtmlMode') toggleHtmlMode();
            if (role === 'toggleFullscreen') toggleFullscreen();
            if (role === 'insertSeparator') insertHtmlAtCursor('<hr>');
            if (role === 'insertFrame') insertHtmlAtCursor('<div style="border:1px solid #E5E7EB;border-radius:12px;padding:16px;">Contenu encadre</div><p><br></p>');
            if (role === 'insertTable') insertHtmlAtCursor('<table style="width:100%;border:1px solid #E5E7EB;"><tr><td style="padding:8px;border:1px solid #E5E7EB;">Colonne 1</td><td style="padding:8px;border:1px solid #E5E7EB;">Colonne 2</td></tr></table><p><br></p>');
            syncSourceFromVisual();
            schedulePreview();
        });
    });

    const foreColorPicker = document.getElementById('foreColorPicker');
    const backColorPicker = document.getElementById('backColorPicker');
    if (foreColorPicker) {
        foreColorPicker.addEventListener('input', function () {
            restoreEditorFocus();
            document.execCommand('foreColor', false, foreColorPicker.value);
            syncSourceFromVisual();
            schedulePreview();
        });
    }
    if (backColorPicker) {
        backColorPicker.addEventListener('input', function () {
            restoreEditorFocus();
            document.execCommand('hiliteColor', false, backColorPicker.value);
            syncSourceFromVisual();
            schedulePreview();
        });
    }

    document.querySelectorAll('.securemail-device-btn').forEach(function (button) {
        button.addEventListener('click', function () {
            document.querySelectorAll('.securemail-device-btn').forEach(function (candidate) {
                candidate.classList.remove('is-active');
            });
            button.classList.add('is-active');
            if (button.dataset.device === 'mobile') {
                previewSurface.classList.remove('is-desktop');
                previewSurface.classList.add('is-mobile');
            } else {
                previewSurface.classList.remove('is-mobile');
                previewSurface.classList.add('is-desktop');
            }
            fitPreview();
        });
    });

    let resizeDebounce = null;
    window.addEventListener('resize', function () {
        if (resizeDebounce) clearTimeout(resizeDebounce);
        resizeDebounce = setTimeout(fitPreview, 120);
    });

    subjectTemplate.addEventListener('input', schedulePreview);
    subjectTemplate.addEventListener('input', function () {
        scheduleUnknownPrompt(false);
    });
    visualEditor.addEventListener('input', function () {
        syncSourceFromVisual();
        schedulePreview();
        scheduleUnknownPrompt(false);
    });
    htmlSourceEditor.addEventListener('input', function () {
        schedulePreview();
        scheduleUnknownPrompt(false);
    });

    const validateButton = document.getElementById('btnValidateVariables');
    if (validateButton) {
        validateButton.addEventListener('click', function () {
            validateVariables(true);
        });
    }

    form.addEventListener('submit', function (event) {
        if (!validateVariables(false)) {
            event.preventDefault();
            return;
        }
        saveEditorContent();
    });

    initializeAllowedVariables();
    setEditorHtml(htmlBodyHidden ? htmlBodyHidden.value : visualEditor.innerHTML);
    schedulePreview();
    scheduleUnknownPrompt(true);

    window.secureMailTemplateEditor = {
        registerVariable: registerVariable,
        addAllowedVariable: addAllowedVariable
    };
    window.execCommand = execCommand;
    window.insertVariable = insertVariable;
    window.insertQuickBlock = insertQuickBlock;
    window.insertButton = insertButton;
    window.insertImage = insertImage;
    window.insertLink = insertLink;
    window.toggleHtmlMode = toggleHtmlMode;
    window.updatePreview = updatePreview;
    window.generatePlainText = generatePlainText;
    window.validateVariables = validateVariables;
    window.saveEditorContent = saveEditorContent;
})();
