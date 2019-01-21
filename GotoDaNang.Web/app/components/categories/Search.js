(function () {
    'use strict';
    angular
        .module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
        .controller('AutoCompleteCtrl', AutoCompleteCtrl);
    function AutoCompleteCtrl($http, $timeout, $q, $log) {
        var self = this;
        self.simulateQuery = true;
        self.categories = loadAllCategoris($http);
        self.querySearch = querySearch;
        function querySearch(query) {
            var results = query ? self.categories.filter(createFilterFor(query)) : self.categories, deferred;
            if (self.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }
        function loadAllCategoris($http) {
            var allCategories = [];
            var url = '';
            var result = [];
            url = 'api/category/getall';
            $http({
                method: 'GET',
                url: url
            }).then(function successCallback(response) {
                allCategories = response.data;
                angular.forEach(allCategories, function (category, key) {
                    result.push(
                        {
                            value: category.Title.toLowerCase(),
                            display: category.Title
                        });
                });
            }, function errorCallback(response) {
                console.log('Oops! Something went wrong while fetching the data. Status Code: ' + response.status + ' Status statusText: ' + response.statusText);
            });
            return result;
        }
        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(category) {
                return (category.value.indexOf(lowercaseQuery) === 0);
            };

        }
    }
})();