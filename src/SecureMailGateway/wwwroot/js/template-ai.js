(function () {
    'use strict';

    const config = window.secureMailAiConfig || {};
    const generateUrl = config.generateUrl;
    const runButton = document.getElementById('btnRunAiGenerate');
    const form = document.getElementById('templateForm');

    if (!generateUrl || !runButton || !form) {
        return;
    }

    const statusNode = document.getElementById('aiGenerateStatus');
    const warningsNode = document.getElementById('aiGenerateWarnings');
    const subjectInput = document.getElementById('subjectTemplate');
    const htmlTextarea = document.getElementById('htmlBody');
    const textTextarea = document.getElementById('textBody');
    const visualEditor = document.getElementById('visualEditor');
    const htmlSourceEditor = document.getElementById('htmlSourceEditor');
    const htmlHidden = document.getElementById('HtmlBodyHidden');
    const textHidden = document.getElementById('TextBodyHidden');
    const antiForgeryToken = document.querySelector('input[name="__RequestVerificationToken"]');

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
    // test-data panel, seeded with the AI-provided sample value so the preview renders.
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

    function applySampleData(sampleData) {
        if (!sampleData || typeof sampleData !== 'object') return;

        const sampleFields = document.querySelectorAll('.sample-field');
        if (!sampleFields || sampleFields.length === 0) return;

        sampleFields.forEach(function (field) {
            const key = field.dataset.key;
            if (!key || !(key in sampleData)) return;
            field.value = sampleData[key] || '';
            field.dispatchEvent(new Event('input', { bubbles: true }));
        });
    }

    async function generateTemplate() {
        const objective = valueOf('aiObjective');
        if (!objective) {
            setStatus('Le champ "Objectif / use-case" est requis.', true);
            return;
        }

        setStatus('Génération IA en cours...', false);
        renderWarnings([]);
        runButton.disabled = true;

        try {
            const payload = {
                objective: objective,
                brandOrCompany: valueOf('aiBrand'),
                tone: valueOf('aiTone'),
                language: valueOf('aiLanguage') || 'fr',
                emailType: valueOf('aiEmailType'),
                cta: valueOf('aiCta'),
                optionalVariables: valueOf('aiOptionalVariables')
            };

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
                setStatus(result.message || 'La génération IA a échoué.', true);
                renderWarnings(result.warnings || result.errors || []);
                return;
            }

            if (subjectInput) {
                subjectInput.value = result.subjectTemplate || '';
                subjectInput.dispatchEvent(new Event('input', { bubbles: true }));
            }

            setHtmlContent(result.htmlBody || '');
            setTextContent(result.textBody || '');
            registerGeneratedVariables(result.variables);
            applySampleData(result.sampleData || {});
            renderWarnings(result.warnings || []);
            setStatus('Template généré. Vérifiez puis cliquez sur Enregistrer si le résultat vous convient.', false);

            if (typeof window.updatePreview === 'function') {
                window.updatePreview();
            }
        } catch (error) {
            setStatus('Erreur réseau pendant la génération IA.', true);
        } finally {
            runButton.disabled = false;
        }
    }

    runButton.addEventListener('click', generateTemplate);
})();
