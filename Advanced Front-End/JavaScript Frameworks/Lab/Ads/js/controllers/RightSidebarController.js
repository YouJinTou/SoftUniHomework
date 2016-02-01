'use strict';

app.controller('RightSidebarController',
    function ($scope, $rootScope, $location, userService, categoriesService, townsService,
        notifyService) {
        $scope.categories = categoriesService.getCategories();
        $scope.towns = townsService.getTowns();

        $scope.categoryClicked = function (clickedCategoryId) {
            $scope.selectedCategoryId = clickedCategoryId;
            $rootScope.$broadcast('categorySelectionChanged', clickedCategoryId)
        }

        $scope.townClicked = function (clickedTownId) {
            $scope.selectedTownId = clickedTownId;
            $rootScope.$broadcast('townSelectionChanged', clickedTownId)
        }

        $scope.statusClicked = function (clickedStatus) {
            $scope.selectedStatus = clickedStatus;
            $rootScope.$broadcast('statusSelectionChanged', clickedStatus);
        }
    });