(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmailNotificationController', EmailNotificationController);

    EmailNotificationController.$inject = ['$filter', '$window', 'EmailNotificationService'];

    function EmailNotificationController($filter, $window, EmailNotificationService) {
        var vm = this;

        vm.EmailNotifications = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        function GoToUpdatePage(emailNotificationId) {
            $window.location.href = '../EmailNotification/Update/' + emailNotificationId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
            EmailNotificationService.Read()
                .then(function (response) {
                    vm.EmailNotifications = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }
    }
})();