(function (angular) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function HomeController(timeReportService) {
        var vm = this;
        var reportClone = null;
        var projects = [{
            name: 'H&M dev'
        }, {
            name: 'Internal'
        }];

        vm.reports = [{
            year: 2015,
            week: 1,
            projects: [{
                name: 'H&M dev',
                monday: 8,
                tuesday: 8,
                wednesday: 8,
                thursday: 8,
                friday: 8,
                saturday: 8,
                sunday: 8
            }, {
                name: 'Internal',
                monday: 0,
                tuesday: 0,
                wednesday: 0,
                thursday: 0,
                friday: 0,
                saturday: 0,
                sunday: 0
            }]
        }];
        vm.edit = edit;
        vm.save = save;
        vm.cancel = cancel;
        vm.add = add;

        function add() {
            vm.reports.unshift({
                year: getCurrentYear(),
                week: getCurrentWeek(),
                isEditing: true,
                isNew: true,
                projects: angular.copy(projects)
            });
        }

        function edit(report) {
            reportClone = angular.copy(report);
            report.isEditing = true;
        }

        function save(report) {
            report.isEditing = false;
        }

        function cancel(report) {
            var index = vm.reports.indexOf(report);
            if (reportClone) {
                vm.reports[index] = reportClone;
                reportClone = null;
            } else {
                vm.reports.splice(index, 1);
            }
        }

        function getCurrentYear() {
            return new Date().getFullYear();
        }

        function getCurrentWeek() {
            var now = new Date();
            var firstJan = new Date(now.getFullYear(), 0, 1);
            return Math.ceil((((now - firstJan) / 86400000) + firstJan.getDay() + 1) / 7);
        }

        timeReportService.newReportObserver.subscribe(function (report) {
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