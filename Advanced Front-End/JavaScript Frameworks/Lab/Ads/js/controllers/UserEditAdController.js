'use strict';

app.controller('UserEditAdController', function ($scope, $rootScope, $location,
    $routeParams, townsService, categoriesService, userService, notifyService) {
    $rootScope.pageTitle = 'Edit Ad';

    $scope.adData = { townId: null, categoryId: null };
    $scope.categories = categoriesService.getCategories();
    $scope.towns = townsService.getTowns();

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

    $scope.editAd = function (adData) {
        userService.editAd(adData.id,
            adData,
            function success() {
                $scope.adData = adData
                notifyService.showInfo('Ad edited successfully');
                $location.path('/user/ads');
            },
            function error(err) {
                notifyService.showError('Ad edit failed', err);
            });
    };

    $scope.fileSelected = function (fileInputField) {
        delete $scope.adData.imageDataUrl;
        var file = fileInputField.files[0];
        if (file.type.match(/image\/.*/)) {
            var reader = new FileReader();
            reader.onload = function () {
                $scope.adData.imageDataUrl = reader.result;
                $('.image-box').html("<img src='" + reader.result + "'>");
            }
            reader.readAsDataURL(file);
        } else {
            $('.image-box').html("<p>File not in the correct format!</p>");
        }
    }
});