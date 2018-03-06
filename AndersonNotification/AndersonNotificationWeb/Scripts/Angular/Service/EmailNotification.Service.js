(function () {
    'use strict';

    angular
        .module('App')
        .factory('EmailNotificationService', EmailNotificationService);

    EmailNotificationService.$inject = ['$http'];

    function EmailNotificationService($http) {
        return {
            Read: Read,
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/EmailNotification/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();