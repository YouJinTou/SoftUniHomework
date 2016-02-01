(function () {
    var ID = '015xFSViLC5j645dGBU73mPMsT8mrB7v6pbLj7Tj';
    var REST_API_KEY = 'x67RJoZDxFIAne4BBYFvtfEZgChl7CAUhbOA70uq';
    var COUNTRY_URL = 'https://api.parse.com/1/classes/Country/';

    var currentlySelectedCountry;

    $('#add-country').on('click', function () {
        var countryName = $('#add-country-field').val();

        addCountry(countryName);
        $('#add-country-field').val('');
    })

    $('#countries').on('change', function () {
        currentlySelectedCountry = $(this).val();
    })

    $('#edit-country').on('click', function () {
        var newCountryName = $('#new-country-field').val();
        editCountry(currentlySelectedCountry, newCountryName);
        $('#new-country-field').val('');
    })

    $('#delete-country').on('click', function () {
        deleteCountry(currentlySelectedCountry);
    });

    function getObjectId(obj) {
        if (obj['country'] === currentlySelectedCountry[0]) {
            return true;
        }
    };

    function addCountry(countryName) {
        $.ajax({
            method: 'POST',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY,
                'Content-Type': 'application/json'
            },
            url: COUNTRY_URL,
            data: JSON.stringify({
                'countryName': countryName
            })
        })
    }

    function editCountry(oldCountryName, newCountryName) {
        var country = countryObjectIds.filter(getObjectId); // Accessing global var
        var objectId = country[0].objectId;

        $.ajax({
            method: 'PUT',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY,
                'Content-Type': 'application/json'
            },
            url: COUNTRY_URL + objectId,
            data: JSON.stringify({
                'countryName': newCountryName
            })
        })
    }

    function deleteCountry(selectedCountry) {
        var country = countryObjectIds.filter(getObjectId);
        var objectId = country[0].objectId;

        $.ajax({
            method: 'DELETE',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            url: COUNTRY_URL + objectId
        })
    }
})();