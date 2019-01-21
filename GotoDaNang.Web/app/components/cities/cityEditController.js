(function (app) {
    app.controller('cityEditController', cityEditController);

    cityEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function cityEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.city = {
            Status: true
        };
      
        $scope.EditCity = EditCity;

        function loadCityDetail() {
            apiService.get('api/city/getbyid/' + $stateParams.id, null, function (result) {
                $scope.city = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function EditCity() {
            apiService.put('api/city/update', $scope.city,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được sửa mới.');
                    $state.go('cities');
                }, function (error) {
                    notificationService.dispalyError('Sửa dữ liệu không thành công.');

                });
        }
       
        loadCityDetail();
    }
})(angular.module('gotodanang.cities'));