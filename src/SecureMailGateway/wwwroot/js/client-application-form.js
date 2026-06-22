(function () {
    const checkbox = document.getElementById('allowAllDomains');
    const wrap = document.getElementById('allowedDomainsWrap');
    const input = document.getElementById('allowedDomainsInput');

    if (!checkbox || !wrap) return;

    function sync() {
        const allowAll = checkbox.checked;
        wrap.style.display = allowAll ? 'none' : '';
        input.disabled = allowAll;
        if (allowAll) input.value = '';
    }

    checkbox.addEventListener('change', sync);
    sync();
})();
