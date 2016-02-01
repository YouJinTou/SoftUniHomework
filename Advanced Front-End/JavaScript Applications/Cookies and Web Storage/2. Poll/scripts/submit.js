// If the form hasn't been filled out yet
if (!(localStorage.answer0 && localStorage.answer1
    && localStorage.answer2)) {
    $('#save').on('click', function (event) {
        var radios = $('input:radio:checked');

        if (radios.length === 3) {
            displayResults();
        } else {
            alert('All questions must be answered.')
        }
    })
} else {
    $('#save').hide();
    $('#timer-holder').remove();
    displayResults();
}

function displayResults() {
    var answers = [];

    $('input:radio:checked').each(function (i) {
        localStorage['answer' + i] = $(this).val();
        answers[i] = $(this).val();
    })

    for (var i in answers) {
        var answer = parseInt(answers[i]);
        if (answers[i] !== '2'
            || answers[i] !== '5'
            || answers[i] !== '11') {
            $('input:radio').eq(answer).next().css('background-color', 'red');
        }
    }
    $('input:radio').eq(2).next().css('background-color', 'green');
    $('input:radio').eq(5).next().css('background-color', 'green');
    $('input:radio').eq(11).next().css('background-color', 'green');
}