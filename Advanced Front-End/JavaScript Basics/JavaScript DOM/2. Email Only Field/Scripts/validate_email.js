function validateEmail(textArea, validator) {
    var text = document.getElementById(textArea).value;
    var validatorField = document.getElementById(validator);

    validatorField.innerHTML = text;

    var pattern = /(.*)@(.{2,})\.(\w{2,})/;
    if (text.match(pattern)) {
        validatorField.style.backgroundColor = 'lightgreen';
    } else {
        validatorField.style.backgroundColor = 'red';
    }
}