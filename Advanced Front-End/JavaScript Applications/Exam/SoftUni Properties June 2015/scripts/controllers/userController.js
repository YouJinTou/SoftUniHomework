var app = app || {};

app.userController = (function () {
    function UserController(userModel, userViews) {
        this.userModel = userModel;
        this.userViews = userViews;
    }

    UserController.prototype.loadWelcomeGuestScreen = function (selector) {
        this.userViews.loadWelcomeGuestScreen(selector);
    }

    UserController.prototype.register = function (username, password) {
        return this.userModel.register(username, password)
            .then(function (regData) {                
                setSessionStorage(regData);
            }, function (error) {
                console.log(error);
            })
    }

    UserController.prototype.login = function (username, password) {
        return this.userModel.login(username, password)
            .then(function (data) {
                setSessionStorage(data);
            }, function (error) {
                console.log(error);
            })
    };

    // Doesn't work
    UserController.prototype.logout = function () {
        return this.userModel.logout()
            .then(function (data) {
                clearSessionStorage(data);
            }, function (error) {
                console.log(error);
            })
    };

    function setSessionStorage(data) {
        sessionStorage.setItem('userId', data.objectId);
        sessionStorage.setItem('sessionToken', data.sessionToken);
    }

    function clearSessionStorage(data) {
        delete sessionStorage[data.sessionToken];
        delete sessionStorage[data.objectId];
    }

    return {
        load: function (userModel, userViews) {
            return new UserController(userModel, userViews);
        }
    }
})();