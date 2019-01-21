(function (app) {
    app.controller('serviceEditController', serviceEditController);

    serviceEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function serviceEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.service = {
            Status: true
        };
        $scope.moreImages = [];
        $scope.EditService = EditService;

        function loadserviceDetail() {
            apiService.get('api/service/getbyid/' + $stateParams.id, null, function (result) {
                $scope.service = result.data;
                //$scope.moreImages = JSON.parse($scope.service.Avatar);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function EditService() {
            //$scope.service.Avatar = JSON.stringify($scope.moreImages)
            apiService.put('api/service/update', $scope.service,
                function (result) {
                    notificationService.displaySuccess(result.data.Title + ' đã được cập nhật.');
                    $state.go('services');
                }, function (error) {
                    notificationService.dispalyError('Thêm mới không thành công.');

                });
        }
        $scope.ChooseImageIcon = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.service.Icon = fileUrl;
                });
            };
            finder.popup();
        };

        $scope.ChooseImageAvatar = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.service.Avatar = fileUrl;
                });
            };
            finder.popup();
        };

        function loadCategory() {
            apiService.get('api/service/getallparents', null, function (result) {
                $scope.category = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadCategory();
        //$scope.ChooseMoreImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.moreImages.push(fileUrl);
        //        });

        //    };
        //    finder.popup();
        //};

        loadserviceDetail();
    }
})(angular.module('gotodanang.services'));