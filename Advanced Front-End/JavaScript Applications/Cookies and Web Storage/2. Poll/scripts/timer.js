(function Timer() {
    var timeRemaining = 300;    

    var ticker = setInterval(function () {
        countDown()
    }, 1000);

    function countDown() {
        var timer = $('#timer');
        timer.text(timeRemaining);
        timeRemaining--;

        if (timeRemaining < 0) {
            clearTimeout(ticker);
            $('#poll').hide();
            $('<div>')
                .text('You have failed to submit the form in time.')
                .appendTo('body');
        }
    };

    $('#save').on('click', function (event) {
        clearTimeout(ticker);
    });
   
})();

