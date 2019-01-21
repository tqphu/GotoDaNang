(function (app) {
    app.controller('placeAddController', placeAddController);

    placeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function placeAddController(apiService, $scope, notificationService, $state) {
        $scope.place = {
            Status: true,
            Title: "New Title",
            ServiceID: null,
            FolderSlider: false,
            HomeSlider: false
        };
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };

        $scope.AddPlace = AddPlace;
        function AddPlace() {
            $scope.place.Icon = JSON.stringify($scope.moreImages);
            apiService.post('api/place/add', $scope.place,
                function (result) {
                    notificationService.displaySuccess(result.data.Title + ' đã được thêm mới.');
                    $state.go('places');
                }, function (error) {
                    notificationService.dispalyError('Thêm mới không thành công.');

                });
        }

        $scope.ChooseImageAvatar = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.place.Avatar = fileUrl;
                });
            };
            finder.popup();
        };
        
        $scope.moreImages = [];

        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });

            };
            finder.popup();
        };

        loadCategory();
        function loadCategory() {
            apiService.get('api/service/getallparents', null, function (result) {
                $scope.category = result.data;

            }, function () {
                console.log('Cannot get list parent');
            });
        }

        $scope.getCategoryById = getCategoryById;
        function getCategoryById() {
            apiService.get('api/service/getcategorybyid/' + $scope.category.ID, null, function (result) {
                $scope.categoryId = result.data;
                console.log('$scope.categoryId', $scope.categoryId);
            }, function () {
                console.log('Cannot get list parent');
            });
        }


        $scope.selectService = function () {
            console.log('Place', $scope.place);
        };

        
    }
})(angular.module('gotodanang.places'));