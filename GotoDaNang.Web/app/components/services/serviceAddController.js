(function (app) {
    app.controller('serviceAddController', serviceAddController);

    serviceAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function serviceAddController(apiService, $scope, notificationService, $state) {
        $scope.service = {
            Status: true,
            Title: "New Title",
            SowAllCity: false
        };
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };

        $scope.Addservice = Addservice;
        function Addservice() {
            //$scope.service.Avatar = JSON.stringify($scope.moreImages)
            apiService.post('api/service/add', $scope.service,
                function (result) {
                    notificationService.displaySuccess(result.data.Title + ' đã được thêm mới.');
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
        //$scope.moreImages = [];
        //$scope.ChooseMoreImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.moreImages.push(fileUrl);
        //        });

        //    };
        //    finder.popup();
        //};
    }
})(angular.module('gotodanang.services'));