/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function TimeReportService($q) {
        var deferredInitalReports = $q.defer();
        var connection = new XSockets.WebSocket('ws://localhost:4502', ['reports']);
        connection.setAutoReconnect();

        var socketController = connection.controller('reports');
        socketController.onopen = socketConnectionOpen;

        socketController.on('initialReports', function onNewReport(data) {
            deferredInitalReports.resolve(data);
        });

        function socketConnectionOpen() {
            console.log('Reports connection opened');
        }

        return {
            getReports: function getReports() {
                return deferredInitalReports.promise;
            }
        };
    }

    TimeReportService.$inject = ['$q'];

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

    //var newReportObserver = Rx.Observable.create(createObserver);
    //        function createObserver(observer) {
    //observer.onNext(data);
    //      }
    //newReportObserver: newReportObserver

}(angular, XSockets, Rx));