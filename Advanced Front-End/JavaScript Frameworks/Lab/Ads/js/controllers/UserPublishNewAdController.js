﻿'use strict';

app.controller('UserPublishNewAdController', function ($scope, $rootScope, $location,
    townsService, categoriesService, userService, notifyService) {
    $rootScope.pageTitle = 'Publish New Ad';
    $scope.adData = { townId: null, categoryId: null };
    $scope.categories = categoriesService.getCategories();
    $scope.towns = townsService.getTowns();

    $scope.publishAd = function (adData) {
        userService.createNewAd(adData,
            function success() {
                notifyService.showInfo('Ad posted successfully');
                $locaiton.path('/user/ads');
            },
            function error(err) {
                notifyService.showError('Failed to post ad successfully', err);
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