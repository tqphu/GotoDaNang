/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.services', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('services', {
            url: "/services",
            templateUrl: "/app/components/services/serviceListView.html",
            controller: "serviceListController"
        }).state('add_services', {
            url: "/add_services",
            templateUrl: "/app/components/services/serviceAddView.html",
            controller: "serviceAddController"
            }).state('edit_services', {
                url: "/edit_services/:id",
                templateUrl: "/app/components/services/serviceEditView.html",
                controller: "serviceEditController"
        });
    }
})();