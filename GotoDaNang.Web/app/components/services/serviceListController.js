﻿(function (app) {
    app.controller('serviceListController', serviceListController);

    serviceListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function serviceListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.services = [];
        $scope.page = 0;
        $scope.pagesCount = 20;
        $scope.getServices = getServices;
        $scope.keyword = '';

        //$scope.moreImages = [];
        $scope.search = search;
        $scope.deleteService = deleteService;

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var listId = [];

            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedServices: JSON.stringify(listId)
                }
            };
            apiService.del('api/service/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.services, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.services, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("services", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);


        $scope.deleteService = deleteService;
        function deleteService(id) {
            $ngBootbox.confirm('Bạn có muốn xóa bản ghi ID= ' + id + ' không???').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('api/service/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!!!');
                    search();
                }, function () {
                    notificationService.displayError('Xoá không thành công !!!');
                });
            });
        }

        function search() {
            getServices();
        }
        function getServices(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            };
            apiService.get('/api/service/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!!!');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }

                $scope.services = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load Services failed.');
            });
        }
        //$scope.ChooseMoreImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.moreImages.push(fileUrl);
        //        });

        //    };
        //    finder.popup();
        //};


        $scope.getServices();
    }
})(angular.module('gotodanang.services'));