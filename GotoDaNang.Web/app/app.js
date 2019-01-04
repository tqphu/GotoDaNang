/// <reference path="../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('gotodanang',
        ['gotodanang.categories',
         'gotodanang.services',
         'gotodanang.cities',
         'gotodanang.provinces',
         'gotodanang.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();