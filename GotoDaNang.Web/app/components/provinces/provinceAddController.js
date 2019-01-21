(function (app) {
    app.controller('provinceAddController', provinceAddController);

    provinceAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function provinceAddController(apiService, $scope, notificationService, $state) {
        $scope.province = {
            Status: true
        };

        $scope.AddProvice = AddProvice;
        function AddProvice() {
            apiService.post('api/Province/add', $scope.province,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('provinces');
                }, function (error) {
                    notificationService.dispalyError('Thêm mới không thành công.');
                });
        }

        function loadCity() {
            apiService.get('api/Province/getallparents', null, function (result) {
                $scope.city = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadCity();
    }

})(angular.module('gotodanang.provinces'));