angular.module('mainApp').directive('searchButton', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function () {
                var elem = angular.element('.buttonActive');
                var resourceString = elem.attr('href');
                scope.getBooks(resourceString, scope.searchValue);
            });
        }
    };
});