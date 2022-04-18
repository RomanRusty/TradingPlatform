$(document).ready(function () {
    $('.AddItemToCartForm').submit(function (e) {
        e.preventDefault();
        var $inputs = $('.AddItemToCartForm :input');
        var values = {};
        $inputs.each(function () {
            values[this.name] = $(this).val();
        });
        var productId = values["productId"];
        $('#modalAddItemToCart').load("https://localhost:44359/Carts/AddProductToOrder?productId=" + productId, function (response, status, xhr) {
            $('#addItemToCartButton').click();
        });
    });
});