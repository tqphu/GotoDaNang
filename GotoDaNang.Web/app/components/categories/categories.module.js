/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang.categories', ['gotodanang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('categories', {
            url: "/categories",
            parent: 'base',
            templateUrl: "/app/components/categories/categoryListView.html",
            controller: "categoryListController"
        }).state('add_categories', {
            url: "/add_categories",
            parent: 'base',
            templateUrl: "/app/components/categories/categoryAddView.html",
            controller: "categoryAddController"
        }).state('edit_categories', {
            url: "/edit_categories/:id",
            parent: 'base',
            templateUrl: "/app/components/categories/categoryEditView.html",
            controller: "categoryEditController"
        });
    }
})();