$('[type="submit"]').on('click', function () {
    var classField = $('[name="input-field"]').val();
    var colorField = $('[name="color-picker"]').val();
    var liClass = $('.' + classField);

    liClass.css('background-color', colorField);
})