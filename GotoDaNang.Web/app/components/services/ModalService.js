var app = angular.module('app', ['angularModalService']);

app.controller('Controller', function ($scope, ModalService) {

    $scope.show = function () {
        ModalService.showModal({
            templateUrl: '/app/components/services/serviceAddView.html',
            controller: "ModalController"
        }).then(function (modal) {
            modal.element.modal();
            
        });
    };

});

app.controller('ModalController', function ($scope, close) {

    $scope.close = function (result) {
        close(result, 500); // close, but give 500ms for bootstrap to animate
    };

});
