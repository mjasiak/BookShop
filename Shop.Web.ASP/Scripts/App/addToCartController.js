var aTC = function () { }

var shoppingCartItems = [];

aTC.prototype.OnAddToCartButtonClicked = function() {
    var bookContainer = $('#bookContainer');
    bookContainer.on('click', '.addToCartButton', function () {
        $('#atcAdd').attr('id', $(this).attr('id'));
        OnFormLoad();        
    });
};

function OnFormLoad() {
    var loading = $('#loadingElement');
    $('#aTCForm').ready(function () {
        loading.show();
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            url: '/Additions/GetAdditions',
            success: function (data) {
                PopulateSelect(data.Covers, "#atcSelectCover", 'CoverId');
                PopulateSelect(data.Carriers, "#atcSelectCarrier", 'CarrierId');
                PopulateSelect(data.Publishers, "#atcSelectPublisher", 'PublisherId');
                PopulateSelect(data.Editions, "#atcSelectYear", 'EditionId');
                $('.addToCartModal').show();
                loading.hide();
            },
            error: function () {
                loading.hide();
                alert('Problem z połączeniem');
            }
        });        
    });
}
function PopulateSelect(data, selectToPopulate, property) {
    var selectItem = $(selectToPopulate);
    for (i = 0; i < data.length - 1; i++) {
        selectItem.append("<option value=" + data[i][property] + ">" + data[i].Name + "</option>");
    }
}

aTC.prototype.OnExitButtonClicked = function() {   
    $('#atcExit').click(function() {
        HideModal();
    });
    $('#atcCancel').click(function() {
        HideModal();
    });
};

function HideModal() {
    var addToCartModal = $('.addToCartModal');
    addToCartModal.hide();
    $('#aTCForm')[0].reset();
    ClearAdditions('#atcSelectCover');
    ClearAdditions('#atcSelectCarrier');
    ClearAdditions('#atcSelectPublisher');
    ClearAdditions('#atcSelectYear');
    ClearValidation($('#aTCForm select'));
    ClearValidation($('#aTCForm input'));
}
function ClearValidation(selector) {
    selector.removeClass('validationError');
}
function ClearAdditions(itemToClear) {
    var item = $(itemToClear);
    item.empty();
    item.append("<option selected value='null'>- wybierz --</option>");
}

aTC.prototype.OnOKButtonClicked = function () {
    $('#atcAdd').click(function () {
        if (FormValidation()) {
            var bookItem = $('#aTCForm').serializeArray();
            bookItem.push({ name: 'bookId', value: $(this).attr('id') });
            shoppingCartItems.push(bookItem);
            ShoppingCartCounterUpdate();
            HideModal();
        }        
    });
};

function FormValidation() {
    ClearValidation($('#aTCForm select'));
    ClearValidation($('#aTCForm input'));
    var validateCovers = ValidateSelect($('#atcSelectCover'));
    var validateCarriers = ValidateSelect($('#atcSelectCarrier'));
    var validateEditions = ValidateSelect($('#atcSelectYear'));
    var validatePublishers = ValidateSelect($('#atcSelectPublisher'));
    var validateInput = ValidateInput($('#atcInputQuantity'));
    if (validateCovers && validateCarriers && validateEditions && validatePublishers && validateInput) return true;
    else return false;
}
function ValidateSelect(selector) {
    if (selector.val() != 'null') return true;
    else {
        selector.addClass('validationError');
        return false;
    }
}
function ValidateInput(selector) {
    if (selector.val() > 0) return true;
    else {
        selector.addClass('validationError');
        return false;
    }
}
function ShoppingCartCounterUpdate() {
    var counter = 0;
    var cartItem = {};
    for (i = 0; i <= shoppingCartItems.length-1; i++) {
        cartItem = shoppingCartItems[i];
        counter += parseInt(cartItem[4].value);
    }
    $('#productCounter').text(counter);
}

aTC.prototype.PreventInputLetters = function () {
    $('#atcInputQuantity').keypress(function (e) {
        if ($(this).val().length < 3) {
            if (e.which == 45) {
                return false;
            }
            else if (e.which == 48 || e.which == 49 || e.which == 50 || e.which == 51 || e.which == 52 || e.which == 53 || e.which == 54 || e.which == 55 || e.which == 56 || e.which == 57 || e.which == 8) {
            }
            else return false;
        }
        else return false;
        });
};

$(document).ready(function() {
    var atc = new aTC();
    atc.OnExitButtonClicked();
    atc.OnAddToCartButtonClicked();
    atc.OnOKButtonClicked();
    atc.PreventInputLetters();
});