(function () {
    const customKey = 'custom';
    const select = document.getElementById('providerSelect');
    const customWrap = document.getElementById('customProviderWrap');
    const providerNameInput = document.getElementById('providerNameInput');
    const hostInput = document.getElementById('hostInput');
    const portInput = document.getElementById('portInput');
    const useSslInput = document.getElementById('useSslInput');

    if (!select) return;

    function isCustom() {
        return select.value === customKey;
    }

    function selectedOption() {
        return select.options[select.selectedIndex];
    }

    function syncCustomVisibility() {
        const custom = isCustom();
        customWrap.style.display = custom ? '' : 'none';
        providerNameInput.readOnly = !custom;
        if (!custom) {
            const opt = selectedOption();
            providerNameInput.value = opt.dataset.name || '';
        }
    }

    function applyPreset() {
        if (isCustom()) {
            syncCustomVisibility();
            return;
        }

        const opt = selectedOption();
        providerNameInput.value = opt.dataset.name || '';
        hostInput.value = opt.dataset.host || '';
        portInput.value = opt.dataset.port || '587';
        useSslInput.checked = opt.dataset.ssl === 'true';
        syncCustomVisibility();
    }

    select.addEventListener('change', applyPreset);
    applyPreset();
})();
