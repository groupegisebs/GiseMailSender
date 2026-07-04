(function () {
    'use strict';

    const config = window.secureMailAiConfig || {};
    const generateUrl = config.generateUrl;
    const runButton = document.getElementById('btnRunAiGenerate');
    const form = document.getElementById('templateForm');

    if (!generateUrl || !runButton || !form) {
        return;
    }

    const modalElement = document.getElementById('aiGenerateModal');
    const statusNode = document.getElementById('aiGenerateStatus');
    const warningsNode = document.getElementById('aiGenerateWarnings');
    const variablesNode = document.getElementById('aiGenerateVariables');

    const subjectInput = document.getElementById('subjectTemplate');
    const htmlTextarea = document.getElementById('htmlBody');
    const textTextarea = document.getElementById('textBody');
    const visualEditor = document.getElementById('visualEditor');
    const htmlSourceEditor = document.getElementById('htmlSourceEditor');
    const htmlHidden = document.getElementById('HtmlBodyHidden');
    const textHidden = document.getElementById('TextBodyHidden');
    const antiForgeryToken = document.querySelector('input[name="__RequestVerificationToken"]');

    const runButtonDefaultLabel = runButton.textContent;

    function valueOf(id) {
        const node = document.getElementById(id);
        return node ? (node.value || '').trim() : '';
    }

    function setStatus(message, isError) {
        if (!statusNode) return;
        statusNode.className = isError ? 'small mt-3 text-danger' : 'small mt-3 text-success';
        statusNode.textContent = message || '';
    }

    function renderWarnings(warnings) {
        if (!warningsNode) return;
        warningsNode.innerHTML = '';
        (warnings || []).forEach(function (warning) {
            const li = document.createElement('li');
            li.textContent = warning;
            warningsNode.appendChild(li);
        });
    }

    function renderDetectedVariables(variables) {
        if (!variablesNode) return;
        variablesNode.innerHTML = '';
        if (!Array.isArray(variables) || variables.length === 0) return;

        const label = document.createElement('span');
        label.className = 'text-muted me-1';
        label.textContent = 'Variables détectées :';
        variablesNode.appendChild(label);

        variables.forEach(function (variable) {
            if (!variable || !variable.name) return;
            const badge = document.createElement('span');
            badge.className = 'badge bg-secondary me-1 mb-1';
            badge.textContent = '{{' + variable.name + '}}';
            variablesNode.appendChild(badge);
        });
    }

    function openAiGenerateModal() {
        if (modalElement && window.bootstrap && window.bootstrap.Modal) {
            window.bootstrap.Modal.getOrCreateInstance(modalElement).show();
        }
    }

    function closeAiGenerateModal() {
        if (modalElement && window.bootstrap && window.bootstrap.Modal) {
            const instance = window.bootstrap.Modal.getInstance(modalElement);
            if (instance) instance.hide();
        }
    }

    function setAiGenerationLoading(isLoading) {
        runButton.disabled = isLoading;
        runButton.textContent = isLoading ? 'Génération en cours...' : runButtonDefaultLabel;
    }

    function showAiGenerationError(message) {
        setStatus(message || 'La génération IA a échoué.', true);
    }

    function collectAiGenerateRequest() {
        return {
            objective: valueOf('aiObjective'),
            brandName: valueOf('aiBrand'),
            emailType: valueOf('aiEmailType'),
            tone: valueOf('aiTone'),
            language: valueOf('aiLanguage') || 'fr',
            ctaText: valueOf('aiCta'),
            desiredVariables: valueOf('aiDesiredVariables'),
            primaryColor: valueOf('aiPrimaryColor'),
            additionalInstructions: valueOf('aiAdditionalInstructions')
        };
    }

    function setHtmlContent(html) {
        if (typeof html !== 'string') return;

        if (visualEditor) {
            visualEditor.innerHTML = html;
        }
        if (htmlSourceEditor) {
            htmlSourceEditor.value = html;
        }
        if (htmlHidden) {
            htmlHidden.value = html;
        }
        if (htmlTextarea) {
            htmlTextarea.value = html;
        }

        if (window.tinymce && htmlTextarea) {
            const editor = window.tinymce.get(htmlTextarea.id);
            if (editor) {
                editor.setContent(html);
            }
        }
    }

    function setTextContent(text) {
        if (typeof text !== 'string') return;
        if (textTextarea) {
            textTextarea.value = text;
        }
        if (textHidden) {
            textHidden.value = text;
        }
    }

    // Ensure every variable the AI used (catalog OR custom) exists in the editor's palette and
    // test-data panel, seeded with the AI-provided sample value so the preview renders. Reuses the
    // editor's registerVariable API so custom variables land in the collapsible "Personnalisées" group.
    function registerGeneratedVariables(variables) {
        const editorApi = window.secureMailTemplateEditor;
        if (!editorApi || typeof editorApi.registerVariable !== 'function' || !Array.isArray(variables)) {
            return;
        }
        variables.forEach(function (variable) {
            if (variable && variable.name) {
                editorApi.registerVariable(variable.name, variable.sampleValue);
            }
        });
    }

    function applySampleData(testData) {
        if (!testData || typeof testData !== 'object') return;

        const sampleFields = document.querySelectorAll('.sample-field');
        if (!sampleFields || sampleFields.length === 0) return;

        sampleFields.forEach(function (field) {
            const key = field.dataset.key;
            if (!key || !(key in testData)) return;
            field.value = testData[key] || '';
            field.dispatchEvent(new Event('input', { bubbles: true }));
        });
    }

    // Applies the server response to the editor. Never auto-saves: the user must click "Enregistrer".
    function applyAiTemplateResponse(response) {
        if (!response || typeof response !== 'object') return;

        if (subjectInput) {
            subjectInput.value = response.subject || '';
            subjectInput.dispatchEvent(new Event('input', { bubbles: true }));
        }

        setHtmlContent(response.bodyHtml || '');
        setTextContent(response.bodyText || '');
        registerGeneratedVariables(response.variables);
        applySampleData(response.testData || {});
        renderDetectedVariables(response.variables);
        renderWarnings(response.warnings || []);
        setStatus('Template généré. Vérifiez puis cliquez sur Enregistrer si le résultat vous convient.', false);

        if (typeof window.updatePreview === 'function') {
            window.updatePreview();
        }
    }

    async function generateTemplateWithAi() {
        const payload = collectAiGenerateRequest();
        if (!payload.objective) {
            showAiGenerationError('Le champ "Objectif / use-case" est requis.');
            return;
        }

        setStatus('Génération IA en cours...', false);
        renderWarnings([]);
        renderDetectedVariables([]);
        setAiGenerationLoading(true);

        try {
            const headers = {
                'Content-Type': 'application/json',
                Accept: 'application/json'
            };
            if (antiForgeryToken) {
                headers.RequestVerificationToken = antiForgeryToken.value;
            }

            const response = await fetch(generateUrl, {
                method: 'POST',
                headers: headers,
                body: JSON.stringify(payload)
            });

            const result = await response.json();
            if (!response.ok) {
                showAiGenerationError(result.message || 'La génération IA a échoué.');
                renderWarnings(result.warnings || result.errors || []);
                return;
            }

            applyAiTemplateResponse(result);
        } catch (error) {
            showAiGenerationError('Erreur réseau pendant la génération IA.');
        } finally {
            setAiGenerationLoading(false);
        }
    }

    runButton.addEventListener('click', generateTemplateWithAi);

    window.secureMailAiGenerator = {
        openAiGenerateModal: openAiGenerateModal,
        closeAiGenerateModal: closeAiGenerateModal,
        collectAiGenerateRequest: collectAiGenerateRequest,
        generateTemplateWithAi: generateTemplateWithAi,
        applyAiTemplateResponse: applyAiTemplateResponse,
        showAiGenerationError: showAiGenerationError,
        setAiGenerationLoading: setAiGenerationLoading
    };
})();
