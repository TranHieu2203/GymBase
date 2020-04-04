app.controller("logincontroller", ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {

    //toastr.warning('')

    //toastr.success('')

    //toastr.error('')

    //toastr.remove()

    //toastr.clear()

    // toastr.success('We do have the Kapua suite available.', 'Turtle Bay Resort', { timeOut: 5000 })
    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
            vars[key] = value;
        });
        return vars;
    }

    function getUrlParam(parameter, defaultvalue) {
        var urlparameter = defaultvalue;
        if (window.location.href.indexOf(parameter) > -1) {
            urlparameter = getUrlVars()[parameter];
        }
        return urlparameter;
    }

    $scope.Login = function () {
        $http({
            method: "post",
            url: "/Home/UserLogin",
            datatype: "json",
            data: JSON.stringify($scope.loginModel)
        }).then(function (response) {
            if (response.data.success) {
                toastr.success('Đăng nhập thành công.', 'Thông báo', { timeOut: 5000 });
                var ReturnUrl = getUrlParam('ReturnUrl', '/Home');
                ReturnUrl = ReturnUrl.replace('%2f', '/');
                window.location.assign(ReturnUrl);
            } else {
                toastr.error(response.data.mess, 'Thông báo', { timeOut: 5000 });
            }
        });
    };
}]);
