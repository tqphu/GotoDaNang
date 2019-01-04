(function (app) {
    app.controller('cityAddController', cityAddController);

    cityAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function cityAddController(apiService, $scope, notificationService, $state) {
        $scope.city = {
            Status: true
        };

        $scope.Addcity = Addcity;
        function Addcity() {
            apiService.post('api/city/add', $scope.city,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('cities');
                }, function (error) {
                    notificationService.dispalyError('Thêm mới không thành công.');
                });
        }
    }

})(angular.module('gotodanang.cities'));