'use strict';

app.controller('UserAdsController',
    function ($scope, $rootScope, userService, notifyService, pageSize) {
        $rootScope.pageTitle = 'My Ads';
        $scope.adsParams = {
            startPage: 1,
            pageSize: pageSize
        }

        $scope.reloadUserAds = function () {
            userService.getUserAds(
            $scope.adsParams,
            function success(data) {
                $scope.userAds = data;
            },
            function error(err) {
                notifyService.showError('My ads failed to load', err);
            }
        );
        };

        $scope.reloadUserAds();

        $scope.deactivateAd = function (ad) {
            userService.deactivateAd(
                ad.id,
                function success() {
                    notifyService.showInfo('Ad deactivated successfully');
                    ad.status = 'Inactive';
                },
                function error(err) {
                    notifyService.showError('Ad deactivation failed', err);
                }
                );
        };

        $scope.republishAd = function (ad) {
            userService.publishAdAgain(
                ad.id,
                function success() {
                    notifyService.showInfo('Ad rebulished successfully');
                    ad.status = 'WaitingApproval';
                },
                function error(err) {
                    notifyService.showError('Failed to republishad', err);
                }
                );
        };

        $scope.$on('statusSelectionChanged', function (event, selectedStatus) {
            $scope.adsParams.status = selectedStatus;
            $scope.adsParams.startPage = 1;
            $scope.reloadUserAds();
        });
    }
);