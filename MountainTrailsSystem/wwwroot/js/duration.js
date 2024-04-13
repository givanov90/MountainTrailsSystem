document.addEventListener('DOMContentLoaded', function () {
    const durationRange = document.getElementById('durationRange');
    const durationInput = document.getElementById('durationInput');

    durationRange.addEventListener('input', function () {
        const value = parseFloat(durationRange.value);
        const hours = Math.floor(value);
        const minutes = Math.round((value - hours) * 60);
        const formattedValue = hours + ":" + (minutes < 10 ? "0" : "") + minutes;
        document.getElementById('rangeValue').textContent = formattedValue;

        durationInput.value = value;
    });

    const form = document.getElementById('durationRange');
    form.addEventListener('submit', function () {

        durationInput.value = durationRange.value;
    });
});