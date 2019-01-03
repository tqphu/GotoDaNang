(function (app) {
    app.controller('categoryEditController', categoryEditController);

    categoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function categoryEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.category = {
            Status: true
        };
        $scope.moreImages = [];
        $scope.EditCategory = EditCategory;

        function loadCategoryDetail() {
            apiService.get('api/category/getbyid/' + $stateParams.id, null, function (result) {
                $scope.category = result.data;
                $scope.moreImages = JSON.parse($scope.category.Avatar);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function EditCategory() {
            //$scope.category.Avatar = JSON.stringify($scope.moreImages)
            apiService.put('api/category/update', $scope.category,
                function (result) {
                    notificationService.displaySuccess(result.data.Title + ' đã được thêm mới.');
                    $state.go('categories');
                }, function (error) {
                    notificationService.dispalyError('Thêm mới không thành công.');

                });
        }
        $scope.ChooseImageIcon = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.category.Icon = fileUrl;
                });
            };
            finder.popup();
        };

        $scope.ChooseImageAvatar = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.category.Avatar = fileUrl;
                });
            };
            finder.popup();
        };
        //$scope.ChooseMoreImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.moreImages.push(fileUrl);
        //        });

        //    };
        //    finder.popup();
        //};

        loadCategoryDetail();
    }
})(angular.module('gotodanang.categories'));