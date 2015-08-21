(function (angular) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function HomeController(timeReportService) {
        var vm = this;

        timeReportService.newReportObserver.subscribe(function(report) {
            console.log('Received:');
            console.log(report);
        }, function onError(err) {
            console.log(err);
        }, function onDone() {
            console.log('Done!');
        });
    }

    HomeController.$inject = ['timeReportService'];
    angular
        .module('app')
        .controller('HomeController', HomeController);

}(angular));