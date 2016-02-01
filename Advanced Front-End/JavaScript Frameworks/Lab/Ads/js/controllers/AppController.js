'use strict';

app.controller('AppController', function ($scope, $location, authService, notifyService) {
    $scope.authService = authService;

    $scope.logout = function () {
        authService.logout();
        $location.path('/');
        notifyService.showInfo('Logout successful');
    }
})