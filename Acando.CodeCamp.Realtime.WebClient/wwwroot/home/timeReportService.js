/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function TimeReportService($q) {
        var deferredInitalReports = $q.defer();
        var approvedReportObserver = Rx.Observable.create(createApprovedReportObserver);

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

        function createApprovedReportObserver(observer) {
            socketController.on('approvedReport', function onApprovedReport(data) {
                observer.onNext(data);
            });
        }

        return {
            getReports: function getReports() {
                return deferredInitalReports.promise;
            },
            save: function (report) {
                socketController.invoke('saveReport', report);
            },
            approvedReportObserver: approvedReportObserver
        };
    }

    TimeReportService.$inject = ['$q'];

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

    //
    //        
    //newReportObserver: newReportObserver

}(angular, XSockets, Rx));