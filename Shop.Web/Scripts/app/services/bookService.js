angular.module('mainApp').service('bookService', ['$http', function ($http) {
    this.getData = function (resource, searchString, $scope) {
        angular.element('.loadingModal').show();
        if (searchString != null && searchString.length > 0) {
            getSearchData(resource, $http, $scope, searchString);
        }
        else {
            getAllData(resource, $http, $scope);
        }
    }

    function getSearchData(resource, $http, $scope, searchString) {
        $http.get(resource, { timeout: 15000, params: { searchString: searchString } }).then(function successCallback(response) {
            if (response.data.length > 0)
                $scope.books = response.data;
            else
                alert("W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania");
            hideModal();
        }, function () {
            alert('Błąd podczas połączenia.')
            hideModal();
        });
    }
    function getAllData(resource, $http, $scope) {
        $http.get(resource, { timeout: 15000 }).then(function successCallback(response) {
            if (response.data.length > 0)
                $scope.books = response.data;
            else
                alert("W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania");
            hideModal();
        }, function () {
            alert('Błąd podczas połączenia.')
            hideModal();
        });
    }

    function hideModal() {
        angular.element('.loadingModal').hide();
    }
}]);