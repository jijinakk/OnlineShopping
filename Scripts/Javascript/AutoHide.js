window.setTimeout(function () {
    // Code to execute after the delay
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 4000);