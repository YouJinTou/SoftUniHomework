﻿'use strict';

app.factory('userService',
    function ($http, baseServiceUrl, authService) {
        return {

            createNewAd: function (adData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/user/ads',
                    headers: authService.getAuthHeaders(),
                    data: adData
                };
                $http(request).success(success).error(error);
            },

            getUserAds: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/user/ads',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            },

            getAdById: function (id, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/user/ads/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            deactivateAd: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/ads/deactivate/' + id,
                    headers: authService.getAuthHeaders()
                }
                $http(request).success(success).error(error);
            },

            publishAdAgain: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/ads/publishagain/' + id,
                    headers: authService.getAuthHeaders()
                }
                $http(request).success(success).error(error);
            },

            editAd: function (id, adData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/ads/' + id,
                    headers: authService.getAuthHeaders(),
                    data: adData
                }
                $http(request).success(success).error(error);
            },

            deleteAd: function (id, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/user/ads/' + id,
                    headers: authService.getAuthHeaders()
                }
                $http(request).success(success).error(error);
            },

            getUserData: function (success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/user/profile',
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            updateProfile: function (userData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/profile',
                    headers: authService.getAuthHeaders(),
                    data: userData
                };
                $http(request).success(success).error(error);
            },

            changePassword: function (passData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/user/changepassword',
                    headers: authService.getAuthHeaders(),
                    data: passData
                };
                $http(request).success(success).error(error);
            }
        }
    }
)