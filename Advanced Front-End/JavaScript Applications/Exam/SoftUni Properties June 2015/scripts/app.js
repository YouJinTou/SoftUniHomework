var app = app || {};

app = (function () {
    var appId = 'e6Us142aC68mk8CaQonBcxhHNsM97uvpBlpKCv0S';
    var restKey = 'AXjLCtDolXmah3QeAf7j5RaGo2KVbtsXOdKem2iz';

    var headers = app.headers.load(appId, restKey);
    var requester = app.requester.load();

    var userModel = app.userModel.load(headers, requester);

    var userViews = app.userViews.load();

    var userController = app.userController.load(userModel, userViews);

    //userController.register('test2', 'test2');
    //userController.login('admin', 'admin');
    //userController.logout();
    userController.loadWelcomeGuestScreen('#main');
})();