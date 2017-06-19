var Search = function () { }

Search.prototype.OnSearchButtonClicked = function () {
    $('#searchButton').click(function () {
        var inputText = $('.searchInput input').val();
        var searchTab = $('.bookContainerButton.buttonActive').attr('href');
        var loading = $('#loadingElement');
        loading.show();
            $.ajax({
                type: 'GET',
                url: searchTab,
                data: { searchString: inputText },
                success: function (data) {
                    if ($(data).find('tbody').children().length >0) {
                        $('#bookContainer').html(data);
                        loading.hide();
                    }
                    else {
                        alert("W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania");
                        loading.hide();
                    }
                },
                error: function () {
                    alert("Nieznany błąd podczas próby połączenia!");
                    loading.hide();
                }
            });        
    });
};
Search.prototype.PreventLength = function () {
    $('.searchInput input').keypress(function (e) {
        if ($(this).val().length >= 10)
            if (e.which != 8) return false;
    });
};

$(document).ready(function () {
    var search = new Search();
    search.OnSearchButtonClicked();
    search.PreventLength();
});