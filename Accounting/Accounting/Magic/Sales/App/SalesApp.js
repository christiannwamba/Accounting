/// <reference path="../Views/SalesList.html" />

var SalesApp = angular.module('SalesApp', ['ngRoute', 'ngResource']).config(function ($routeProvider) {
    $routeProvider
    .when('/', { controller: SalesListCtrl, templateUrl: '../Magic/Sales/Views/SalesList.html' })
    .otherwise({ redirectTo: '/' });
        
})

var SalesListCtrl = function ($scope, $location, $http) {

    $http.get("sales/indexjson").success(function (data) {
        $scope.customers = data;
    })

    $scope.getcustid = function () {
        $scope.meval = $scope.customers.cust.CustomerID
    }
}

