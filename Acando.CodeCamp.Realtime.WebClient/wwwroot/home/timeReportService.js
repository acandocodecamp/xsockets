/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function TimeReportService() {
        var newReportObserver = Rx.Observable.create(createObserver);
        var connection = new XSockets.WebSocket('ws://localhost:4502', ['reports']);
        var socketController = null;

        connection.setAutoReconnect();

        socketController = connection.controller('reports');
        socketController.onopen = socketConnectionOpen;

        function createObserver(observer) {
            socketController.on('newReport', function onNewReport(data) {
                observer.onNext(data);
            });
        }

        function socketConnectionOpen() {
            console.log('reports connection opened');
        }

        return {
            newReportObserver: newReportObserver
        };
    }

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

}(angular, XSockets, Rx));