/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function TimeReportService() {
        var newReportObserver = null;
        var connection = new XSockets.WebSocket('ws://localhost:4502', ['reportscontroller']);

        console.log(connection);
        var socketController = connection.controller('reportscontroller');


        socketController.onopen = function socketConnectionOpen() {
            console.log('reports connection opened');

            newReportObserver = Rx.Observable.create(function createObserver(observer) {
                socketController.on('newReport', function onNewReport(data) {
                });
            });
        };

        return {
            newReportObserver: newReportObserver
        };
    }

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

}(angular, XSockets, Rx));