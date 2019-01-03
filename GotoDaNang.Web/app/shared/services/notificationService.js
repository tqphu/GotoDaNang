(function (app) {
    app.factory('notificationService', notificationService);
    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        function displaySuccess(messasega) {
            toastr.success(messasega);
        }

        function dispalyError(error) {
            if (Array.isArray(error)) {
                error.forEach(function (err) {
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error);
            }
        }

        function displayWarning(messasega) {
            toastr.warning(messasega);
        }

        function displayInfo(messasega) {
            toastr.info(messasega);
        }

        return {
            displaySuccess: displaySuccess,
            dispalyError: dispalyError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        };

    }
})(angular.module('gotodanang.common'));