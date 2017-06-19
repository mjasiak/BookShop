angular.module('mainApp').directive('addToCart', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function () {
                angular.element('.addToCartModal').show();
            });
        }
    };
});