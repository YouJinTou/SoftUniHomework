(function toLocalStorage() {
    $('#username-save').on('click', function () {
        localStorage['username'] = $('#username').val();

        if (!sessionStorage['sessionVisits']) {
            sessionStorage['sessionVisits'] = 0;
        }
        
        if (!localStorage['totalVisits']) {
            localStorage['totalVisits'] = 0;
        }
    });    

    if (localStorage['username']) {
        var $greeting = 'Hello, ' + localStorage.username + '!';
        var $count = $('<div id="count">').text('Total visits: '
            + localStorage.totalVisits + ' / Session visits: '
            + sessionStorage.sessionVisits);

        $('#log-in-form').hide();

        sessionStorage['sessionVisits']++;
        localStorage['totalVisits']++;

       
        $('#logged-in-info').text($greeting);
        $count.appendTo('body');
    }
})();