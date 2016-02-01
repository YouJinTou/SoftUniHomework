// TODO
(function () {
    var ID = '015xFSViLC5j645dGBU73mPMsT8mrB7v6pbLj7Tj';
    var REST_API_KEY = 'x67RJoZDxFIAne4BBYFvtfEZgChl7CAUhbOA70uq';
    var TOWN_URL = 'https://api.parse.com/1/classes/Town/';

    $('#countries').on('change', function () {
        $('#towns').empty();
        updateTowns();
    })

    function updateTowns() {
        var line,
        tokens,
        option,
        towns;

        $.ajax({
            method: 'GET',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            url: TOWN_URL
        }).success(function (data) {
            for (var obj in data.results) {
                tokens = [];
                line = data.results[obj];
                option = $('<option class="town" id="' + obj + '">');
                towns = $('#towns');
                for (var entry in line) {
                    tokens.push(line[entry]);
                    option.text(tokens[0]);
                    option.appendTo(towns);
                }
                townObjectIds.push({
                    country: tokens[0],
                    objectId: tokens[2]
                });
            }
        })
    }
})();