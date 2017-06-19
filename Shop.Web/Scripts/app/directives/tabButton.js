angular.module('mainApp').directive('tabButton',['bookService' ,function (bookService) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function (e) {
                e.preventDefault();
                var elemlist = element.parent().children();
                for (i = 0; i <= elemlist.length-1; i++) {
                    angular.element(elemlist[i]).removeClass('buttonActive');
                }
                var resource = element.attr('href');
                bookService.getData(resource, "", scope);
                element.addClass('buttonActive');
            });
        }
    };
}]);