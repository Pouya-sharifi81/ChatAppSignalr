$("#register-btn").click(function () {
    $("#login").slideUp();
    $("#register").fadeIn();
})
$("#login-btn").click(function () {
    $("#register").slideUp();
    $("#login").slideDown();
})
$(document).ready(function () {
    var route = location.href.split("#")[1];
    var route2 = location.href.split("/")[4];
    if (route2) {
        if (route2 == "Register") {
            $("#login").slideUp();
            $("#register").fadeIn();
        } else {
            $("#register").slideUp();
            $("#login").slideDown();
        }
    }
    if (route) {
        if (route == "register") {
            $("#login").slideUp();
            $("#register").fadeIn();
        } else {
            $("#register").slideUp();
            $("#login").slideDown();
        }
    }

});