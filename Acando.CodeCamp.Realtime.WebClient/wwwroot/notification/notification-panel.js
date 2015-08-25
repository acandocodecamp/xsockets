/// <reference path="../external/angular.js" />

(function (angular) {
    'use strict';

    function notificationPanel() {
        var directive = {
            templateUrl: '/notification/panel.html',
            restrict: 'E',
            controller: NotificationController,
            controllerAs: 'vm',
            bindToController: true
        };

        return directive;
    }

    NotificationController.$inject = ['$scope', 'connectionService'];
    function NotificationController($scope, connectionService) {
        var vm = this;
        var socketController = connectionService.connection.controller('notification');

        socketController.onopen = function socketConnectionOpen() {
            console.log('Notification connection opened');
        };

        vm.message = 'No messages';

        socketController.subscribe('newMessage', function (message) {
            vm.message = message;
            $scope.$apply();
        });
    }

    angular
        .module('app')
        .directive('notificationPanel', notificationPanel);

})(angular);