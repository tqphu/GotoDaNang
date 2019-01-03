(function (app) {
    app.controller('categoryAddController', categoryAddController);

    categoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function categoryAddController(apiService, $scope, notificationService, $state) {
        $scope.category = {
            Status: true,
            Title: "New Title"
        };
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };

        $scope.AddCategory = AddCategory;
        function AddCategory() {
            //$scope.category.Avatar = JSON.stringify($scope.moreImages)
            apiService.post('api/category/add', $scope.category,
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
}) (angular.module('gotodanang.categories'));