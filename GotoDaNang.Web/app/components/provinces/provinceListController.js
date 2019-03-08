﻿(function (app) {
    app.controller('provinceListController', provinceListController);

    provinceListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function provinceListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.province = [];
        $scope.getProvinces = getProvinces;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteProvince = deleteProvince;

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var listId = [];

            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProvinces: JSON.stringify(listId)
                }
            };
            apiService.del('api/Province/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.province, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.province, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("province", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);


        $scope.deleteProvince = deleteProvince;
        function deleteProvince(id) {
            $ngBootbox.confirm('Bạn có muốn xóa bản ghi ID= ' + id + ' không???').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('api/Province/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!!!');
                    search();
                }, function () {
                    notificationService.displayError('Xoá không thành công !!!');
                });
            });
        }

        function search() {
            getProvinces();
        }
        function getProvinces(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            };
            apiService.get('/api/Province/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!!!');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }

                $scope.province = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
               
            }, function () {
                console.log('Load Provinces failed.');
            });
        }
       $scope.getProvinces();
    }
})(angular.module('gotodanang.provinces'));