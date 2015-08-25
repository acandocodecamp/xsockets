/// <reference path="../external/angular.js" />
/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets) {
    'use strict';

    ConnectionService.$inject = ['$location'];
    function ConnectionService($location) {
        var port = getPort();
        var endpoint = 'ws://127.0.0.1:' + port;

        var connection = new XSockets.WebSocket(endpoint, ['reports', 'notification']);
        connection.setAutoReconnect();

        function getPort() {
            return $location.search().port || '4502';
        }

        return {
            connection: connection,
            endpoint: endpoint
        };
    }

    angular
    .module('app')
    .service('connectionService', ConnectionService);

}(angular, XSockets));