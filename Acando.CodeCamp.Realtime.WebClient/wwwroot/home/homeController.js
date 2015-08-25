(function (angular) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function HomeController($scope, timeReportService) {
        var vm = this;
        var reportClone = null;
        vm.edit = edit;
        vm.save = save;
        vm.cancel = cancel;
        vm.add = add;

        timeReportService.getReports()
            .then(function reportsLoaded(data) {
                console.log(data);
                vm.reports = data;
            })
            .catch(function reportsFailed(reason) {
                console.log(reason);
            });

        timeReportService.approvedReportObserver.subscribe(subscribe, subscriptionError);

        function subscribe(approvedReport) {
            var matchedReport = vm.reports.find(function findReport(report) {
                return report.year === approvedReport.year && report.week === approvedReport.week;
            });
            if (matchedReport) {
                matchedReport.approved = approvedReport.approved;
                $scope.$apply();
            }
        }
        
        function subscriptionError(err) {
            console.log(err);
        }

        function add() {
            vm.reports.unshift({
                year: getCurrentYear(),
                week: getCurrentWeek(),
                isEditing: true,
                isNew: true,
                projects: [{
                    name: 'H&M dev'
                }, {
                    name: 'Internal'
                }]
            });
        }

        function edit(report) {
            reportClone = angular.copy(report);
            report.isEditing = true;
        }

        function save(report) {
            report.isEditing = false;
            report.approved = false;
            timeReportService.save(report);
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
    }

    HomeController.$inject = ['$scope', 'timeReportService'];
    angular
        .module('app')
        .controller('HomeController', HomeController);

}(angular));