// Global
var countryObjectIds = [];
var townObjectIds = [];

(function () {
    var ID = '015xFSViLC5j645dGBU73mPMsT8mrB7v6pbLj7Tj';
    var REST_API_KEY = 'x67RJoZDxFIAne4BBYFvtfEZgChl7CAUhbOA70uq';
    var COUNTRY_URL = 'https://api.parse.com/1/classes/Country/';

    $('#update-countries-button').on('click', function () {
        $('#countries').empty();
        updateCountries();
    })

    function updateCountries() {
        var line,
        tokens,
        option,
        countries;

        $.ajax({
            method: 'GET',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            url: COUNTRY_URL
        }).success(function (data) {
            for (var obj in data.results) {
                tokens = [];
                line = data.results[obj];
                option = $('<option class="country" id="' + obj + '">');
                countries = $('#countries');
                for (var entry in line) {
                    tokens.push(line[entry]);
                    option.text(tokens[0]);
                    option.appendTo(countries);
                }
                countryObjectIds.push({
                    country: tokens[0],
                    objectId: tokens[2]
                });
            }
        })
    }
})();

