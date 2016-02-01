function isChecked(id, checkbox) {
    var element = document.getElementById(id);

    if (checkbox.checked) {
        element.style.display = 'block';
    } else {
        element.style.display = 'none';
    }
}