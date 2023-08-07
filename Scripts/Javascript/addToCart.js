
function addtoCart(productID) {
    console.log("Adding product with ID: " + productID);

    $.ajax({
        type: 'POST',
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

$(document).ready(function () {
    $('.item-button').click(function () {
        var productID = $(this).data('product-id');
        addtoCart(productID);
        return false; // Prevent default link behavior if applicable
    });
});