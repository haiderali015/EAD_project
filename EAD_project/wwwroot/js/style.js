$(document).ready(function () {
    $("#b1").click(function () {
        $.get('/Home/NewsView', function (result) {
            $("#partialPlaceHolder").html(result)

        })
    })
});