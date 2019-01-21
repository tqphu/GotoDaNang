(function (app) {
    app.controller('provinceEditController', provinceEditController);

    provinceEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function provinceEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.province = {
            Status: true
        };

        $scope.EditProvince = EditProvince;

        function loadProvinceDetail() {
            apiService.get('api/Province/getbyid/' + $stateParams.id, null, function (result) {
                $scope.province = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function EditProvince() {
            apiService.put('api/Province/update', $scope.province,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được sửa mới.');
                    $state.go('provinces');
                }, function (error) {
                    notificationService.dispalyError('Sửa dữ liệu không thành công.');

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

        loadProvinceDetail();
    }
})(angular.module('gotodanang.provinces'));