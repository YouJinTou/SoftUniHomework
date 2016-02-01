'use strict';

app.controller('UserDeleteAdController', function ($scope, $rootScope, $location,
    $routeParams, townsService, categoriesService, userService, notifyService) {
    $rootScope.pageTitle = 'Delete Ad';

    $scope.adData = {};

    function getAdId(id) {
        userService.getAdById(
            id,
            function success(data) {
                $scope.adData = data;
            },
            function error(err) {
                notifyService.showError('User ad load failed', err);
            });
    }

    getAdId($routeParams.id);

    $scope.deleteAd = function (adData) {
        userService.deleteAd(adData.id,
            function success() {
                notifyService.showInfo('Ad deleted successfully');
                $location.path('/user/ads');
            },
            function error(err) {
                notifyService.showError('Ad deletion failed', err);
            });
    };
});