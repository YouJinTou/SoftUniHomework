'use strict';

app.controller('UserEditProfileController', function ($scope, $rootScope, $location,
    $routeParams, townsService, categoriesService, userService, notifyService) {
    $rootScope.pageTitle = 'Edit Profile';

    $scope.userData = {};
    $scope.categories = categoriesService.getCategories();
    $scope.towns = townsService.getTowns();

    function getUserData() {
        userService.getUserData(
            function success(data) {
                $scope.userData = data;
            },
            function error(err) {
                notifyService.showError('User data load failed', err);
            });
    }

    getUserData();
    

    $scope.updateProfile = function (userData) {
        userService.updateProfile(
            userData,
            function success() {                
                notifyService.showInfo('User data updated successfully', err);
                $location.path('/');
            },
            function error(err) {
                notifyService.showError('Failed to update user data', err);
            });
    }

    $scope.changePassword = function (passData) {
        userService.changePassword(
            passData,
            function success() {
                notifyService.showInfo('Password changed successfully', err);
                $location.path('/');
            },
            function error(err) {
                notifyService.showError('Failed to change password', err);
            });
    }
});