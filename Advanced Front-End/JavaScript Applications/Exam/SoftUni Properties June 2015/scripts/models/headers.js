var app = app || {};

app.headers = (function () {
    function Headers(appId, restKey) {
        this.appId = appId;
        this.restKey = restKey;
    }

    Headers.prototype.getHeaders = function (useSessionToken) {
        var headers = {
            'X-Parse-Application-Id': this.appId,
            'X-Parse-REST-API-Key': this.restKey,
            'Content-Type': 'application/json'
        }

        if (sessionStorage['sessionToken'] && useSessionToken) {
            headers['X-Parse-Session-Token'] = sessionStorage['sessionToken'];
        }

        return headers;
    };

    return {
        load: function (appId, restKey) {
            return new Headers(appId, restKey)
        }
    }
})();