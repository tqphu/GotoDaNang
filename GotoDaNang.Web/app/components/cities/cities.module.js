/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.cities', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('cities', {
            url: "/cities",
            parent: 'base',
            templateUrl: "/app/components/cities/cityListView.html",
            controller: "cityListController"
        }).state('add_cities', {
            url: "/add_cities",
            parent: 'base',
            templateUrl: "/app/components/cities/cityAddView.html",
            controller: "cityAddController"
        }).state('edit_cities', {
            url: "/edit_cities/:id",
            parent: 'base',
            templateUrl: "/app/components/cities/cityEditView.html",
            controller: "cityEditController"
        });
    }
})();