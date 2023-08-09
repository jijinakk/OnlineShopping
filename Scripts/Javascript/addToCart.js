
function addToCart(productID) {
    console.log("Adding product with ID: " + productID);

    $.ajax({
        type: 'POST',
        url: '@Url.Action("AddToCart", "Product")',

        data: { productID: productID },
        success: function (response) {
            console.log("AJAX success response:", response);
            if (response.success) {
                $('#cart-item-count').text(response.cartItemCount);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log("AJAX error:", errorThrown);
        }
    });
}

    