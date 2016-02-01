app.controller('textBinderController', function ($scope) {
    var value = document.getElementById('input').value;

    $scope.image = value;
})