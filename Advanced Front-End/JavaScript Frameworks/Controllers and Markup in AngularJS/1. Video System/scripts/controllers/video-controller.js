app.controller('videoController', function ($scope, videoCatalogue) {
    $scope.videos = [];

    for (var i in videoCatalogue) {
        $scope.videos.push(videoCatalogue[i]);
    }
})