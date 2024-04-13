document.addEventListener('DOMContentLoaded', function () {
    const elevationRange = document.getElementById('elevationRange');
    const elevationInput = document.getElementById('elevationInput');

    elevationRange.addEventListener('input', function () {
        const value = parseInt(elevationRange.value);
        document.getElementById('elevationValue').textContent = value + ' m';

        elevationInput.value = value;
    });

    const form = document.getElementById('elevationRange');
    form.addEventListener('submit', function () {

        elevationInput.value = elevationRange.value;
    });
});