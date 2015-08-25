/// <reference path="../external/rx.js" />
/// <reference path="../external/angular.js" />
/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function TimeReportService($q, $location) {
        var port = getPort();
        var endpoint = 'ws://127.0.0.1:' + port;
        var deferredInitalReports = $q.defer();
        var approvedReportObserver = Rx.Observable.create(createApprovedReportObserver);

        var connection = new XSockets.WebSocket(endpoint, ['reports']);
        connection.setAutoReconnect();

        var socketController = connection.controller('reports');
        socketController.onopen = socketConnectionOpen;

        socketController.on('initialReports', function onNewReport(data) {
            deferredInitalReports.resolve(data);
        });

        function socketConnectionOpen() {
            console.log('Reports connection opened');
        }

        function createApprovedReportObserver(observer) {
            socketController.on('approvedReport', function onApprovedReport(data) {
                observer.onNext(data);
            });
        }

        function getPort() {
            return $location.search().port || '4502';
        }

        return {
            getReports: function getReports() {
                return deferredInitalReports.promise;
            },
            save: function (report) {
                socketController.invoke('saveReport', report);
            },
            approvedReportObserver: approvedReportObserver,
            endpoint: endpoint
        };
    }

    TimeReportService.$inject = ['$q', '$location'];

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

}(angular, XSockets, Rx));