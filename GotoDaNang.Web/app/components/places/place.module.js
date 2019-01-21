/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.places', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('places', {
            url: "/places",
            parent: 'base',
            templateUrl: "/app/components/places/placeListView.html",
            controller: "placeListController"
        }).state('add_places', {
            url: "/add_places",
            parent: 'base',
            templateUrl: "/app/components/places/placeAddView.html",
            controller: "placeAddController"
        }).state('edit_places', {
            url: "/edit_places/:id",
            parent: 'base',
            templateUrl: "/app/components/places/placeEditView.html",
            controller: "placeEditController"
        });
    }
})();