/// <reference path="../Views/SalesList.html" />

var SalesApp = angular.module('SalesApp', ['ngRoute', 'ngResource']).config(function ($routeProvider) {
    $routeProvider
    .when('/', { controller: SalesListCtrl, templateUrl: '../Magic/Sales/Views/SalesList.html' })
     
    .otherwise({ redirectTo: '/' });

})

/*SalesApp.directive('autoComplete', function () {
    return {
        restric: 'A',
        link: function (scope, element, attrs) {
            $(element).autocomplete(scope.$eval(attrs.autoComplete))
        }

    }
});

SalesApp.directive('autoComplete', function ($timeout) {
    return function (scope, iElement, iAttrs) {
        iElement.autocomplete({
            source: scope[iAttrs.uiItems],
            select: function () {
                $timeout(function () {
                    iElement.trigger('input');
                }, 0);
            }
        });
    };
});
*/


var SalesListCtrl = function ($scope, $location, $http) {

    $http.get("sales/getcustomers").success(function (data) {
        $scope.customers = data;
        
        
    })

    $http.get("sales/getproducts").success(function (data) {
        $scope.products = data;
    })

    
    $scope.getcustName = function (val) {
        $scope.meval2 = val
    }

    $scope.getcustid = function (val) {
        $scope.meval = val;
        $scope.userID = $('#HiddenUserId').val();
        $scope.meval2 
        var mydateoptions = {
            year: "numeric", month: "numeric", second: "2-digit",
            day: "numeric", hour: "2-digit", minute: "2-digit"
        };

        $scope.orderDate = new Date().toLocaleTimeString("en-Us", mydateoptions);

        $http.get("sales/getcustomerbyid/"+val).success(function (data) {
            var customer = data;
            angular.forEach(customer, function (cust, key) {
                $scope.custID = cust.CustomerID
                

                var toBeBought = { CustomerID: $scope.custID, EmployeeID: $scope.userID, OrderDate: $scope.orderDate, RequiredDate: $scope.orderDate, Ordered: 0 }

                $.post("Sales/SaveOrder", toBeBought, function (data) {
                    // get the result and do some magic with it
                    var message = data.Message;
                    $scope.OrderId = data.OrderID;
                    alert(message);//Used to get inner exception
                    
                });

                
            })

        })


        $('#custDiv').fadeOut();
        $('#prodDiv').fadeOut(function () {
            $(this).fadeIn();
        });
    }

    //Remove selected customer
    
    $scope.removeCust = function (ordid) {
        $.get("Sales/RemoveOrder/" + ordid, function () {
            
        });

        $scope.meval2 = "";
        $scope.meval = "";
    }

    $scope.selectBuy = function (prodid) {
        
        $http.get("Sales/GetProductById/" + prodid).success(function (data) {
            var product = data;
            angular.forEach(product, function (prod, key) {
                $scope.prodName = prod.ProductName;
                $scope.prodID = prod.ProductID;
                $scope.unitPrice = prod.UnitPrice;
                $scope.quantity;
                $scope.discount;
                
                $scope.buyTotal = function () {
                    var disc = parseInt($scope.unitPrice) * (parseInt($scope.discount)/100);
                    return (parseInt($scope.unitPrice) * parseInt($scope.quantity)) - parseInt(disc);
                };
                
            });


        })

    }

    $scope.buy = function () {
        
        var bought = { ProductID: $scope.prodID, UnitPrice: $scope.unitPrice, Quantity: $scope.quantity, Discount: $scope.discount, OrderID: $scope.OrderId };
        $.post('Sales/SaveOrderDetail', bought, function (data) {
            alert(data.Message);
        });
    }

    $http.get('Sales/GetOrderDetails/' + $scope.OrderId, function (data) {
        $scope.orderDetails = data;
    })
}

