/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.provinces', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('provinces', {
            url: "/provinces",
            templateUrl: "/app/components/provinces/provinceListView.html",
            controller: "provinceListController"
        }).state('add_provinces', {
            url: "/add_provinces",
            templateUrl: "/app/components/provinces/provinceAddView.html",
            controller: "provinceAddController"
        }).state('edit_provinces', {
            url: "/edit_provinces/:id",
            templateUrl: "/app/components/provinces/provinceEditView.html",
            controller: "provinceEditController"
        });
    }
})();