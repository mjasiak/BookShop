var Tabs = function () { }

Tabs.prototype.OnButtonClicked = function () {
    $('.bookContainerButton').click(function (e) {
        e.preventDefault();
        var clickedButton = $(this);
        var inputText = $('.searchInput input').val();
        var searchTab = $(this).attr('href');
        var loading = $('#loadingElement');
        loading.show();
        $.ajax({
            type: 'GET',
            url: searchTab,
            data: { searchString: inputText },
            success: function (data) {
                if ($(data).find('tbody').children().length > 0) {
                    $('#bookContainer').html(data);
                    $('.bookContainerButton').removeClass('buttonActive');
                    clickedButton.addClass('buttonActive');
                    loading.hide();
                }
                else {
                    alert("W bazie danych nie odnaleziono produktów spełniających podane kryteria szukania.");
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

$(document).ready(function () {
    var tabs = new Tabs();
    tabs.OnButtonClicked();
});