app.config(function($routeProvider) {  
    $routeProvider
    .when('/userList', { //Routing for show list of employee
        templateUrl: '/views/UsersList.html',
        controller: 'userListController'
    })
    .otherwise({ //Default Routing
        redirectTo:'/'
    })
});