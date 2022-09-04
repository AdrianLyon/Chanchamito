app.controller("userListController", function ($scope, $http, $location, $routeParams) {
    $scope.listOfUser;
    $http.get('https://localhost:7213/api/User').then((data) => {
        $scope.listOfUser = data;
        console.log($scope.listOfUser);
    });
});