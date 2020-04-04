app.controller("controller", ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {
    $scope.loginModel = {};
    console.log('aa')
    $scope.Logout = function () {
    
        $http({
            method: "post",
            url: "/Home/UserLogout",
            datatype: "json"
        }).then(function (response) {
            if (response.data.Success) {
                window.location.reload();
            }
        })
    }
}])
