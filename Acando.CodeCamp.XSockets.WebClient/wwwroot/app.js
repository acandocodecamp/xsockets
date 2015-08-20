(function () {
    'use strict';

    angular
        .module('app', ['ngRoute'])
        .config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/', {
            templateUrl: 'home/index.html',
            controller: 'HomeController',
            controllerAs: 'vm'
        }).
        otherwise({
            redirectTo: '/'
        });
  }]);

}(angular));