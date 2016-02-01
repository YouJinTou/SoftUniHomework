var app = app || {};

app.userModel = (function () {
    var baseUrl = 'https://api.parse.com/1/';

    function UserModel(headers, requester) {
        this.headers = headers;
        this.requester = requester;
    }

    UserModel.prototype.register = function (username, password) {
        var url = baseUrl + 'users/';
        var data = {
            username: username,
            password: password
        }

        return this.requester.post(this.headers.getHeaders(), url, data);
    };

    UserModel.prototype.login = function (username, password) {
        var url = baseUrl + 'login?' + 'username=' + username + '&password=' + password;

        return this.requester.get(this.headers.getHeaders(), url);
    };

    UserModel.prototype.logout = function () {
        var url = baseUrl + 'logout';        

        return this.requester.post(this.headers.getHeaders(true), url);
    };    

    return {
        load: function (headers, requester) {
            return new UserModel(headers, requester);
        }
    }
})();