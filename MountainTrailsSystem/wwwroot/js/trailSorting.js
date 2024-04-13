document.addEventListener('DOMContentLoaded', function () {
    const sortOrderSelect = document.getElementById('sortCriteria');

    sortOrderSelect.addEventListener('change', function () {
        const selectedOption = sortOrderSelect.options[sortOrderSelect.selectedIndex];
        const selectedValue = selectedOption.value;

        const currentUrl = new URL(window.location.href);
        const baseUrl = currentUrl.origin + currentUrl.pathname;

        const queryParams = new URLSearchParams(currentUrl.search);
        queryParams.set('sortCriteria', selectedValue);

        const newUrl = baseUrl + '?' + queryParams.toString();
        window.location.href = newUrl;
    });
});