angular.module('mainApp')
       .controller('booksController', ['$scope', '$http', 'bookService', function ($scope, $http, bookService)
        {
            bookService.getData("/Books/GetAll", "", $scope);
            $scope.counter = 0;

            $scope.getBooks = function (resource, searchString) {
                bookService.getData(resource, searchString, $scope);
            }
            $scope.addToCart = function (quantity) {
                $scope.counter+=quantity;
            }
        }]);
