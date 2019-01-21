/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.provinces', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('provinces', {
            url: "/provinces",
            parent: 'base',
            templateUrl: "/app/components/provinces/provinceListView.html",
            controller: "provinceListController"
        }).state('add_provinces', {
            url: "/add_provinces",
            parent: 'base',
            templateUrl: "/app/components/provinces/provinceAddView.html",
            controller: "provinceAddController"
        }).state('edit_provinces', {
            url: "/edit_provinces/:id",
            parent: 'base',
            templateUrl: "/app/components/provinces/provinceEditView.html",
            controller: "provinceEditController"
        });
    }
})();