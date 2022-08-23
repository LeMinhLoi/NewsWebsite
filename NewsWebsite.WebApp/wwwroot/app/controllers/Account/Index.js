//validate email
var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

$(document).ready(function () {
    $("#btnConfirm").on('click', function (event) {
        event.preventDefault();
        var email = $("#inputEmail").val()
        if (email.length == 0) {
            alert("Vui lòng nhập email")
        } else if (!email.match(validRegex)) {
            alert("Vui lòng nhập đúng định dạng email của bạn.");
        } else {
            $("#formConfirm").submit();
        }
    });
});
