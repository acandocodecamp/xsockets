/// <reference path="../external/rx.js" />
/// <reference path="../external/angular.js" />
/// <reference path="../external/xsockets.latest.js" />

// ReSharper disable once InconsistentNaming
(function (angular, XSockets, Rx) {
    'use strict';

    TimeReportService.$inject = ['$q', 'connectionService'];
    function TimeReportService($q, connectionService) {
        var deferredInitalReports = $q.defer();
        var approvedReportObserver = Rx.Observable.create(createApprovedReportObserver);
        var socketController = connectionService.connection.controller('reports');

        socketController.onopen = function socketConnectionOpen() {
            console.log('Reports connection opened');
        };

        socketController.on('initialReports', function onNewReport(data) {
            deferredInitalReports.resolve(data);
        });

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

    angular
        .module('app')
        .service('timeReportService', TimeReportService);

}(angular, XSockets, Rx));