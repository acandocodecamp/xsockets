(function (angular) {
    'use strict';

    // ReSharper disable once InconsistentNaming
    function HomeController() {
        var vm = this;
    }

    HomeController.$inject = [];

    angular
        .module('app')
        .controller('HomeController', HomeController);

}(angular));