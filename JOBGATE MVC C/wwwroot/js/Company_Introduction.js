$(document).ready(function () {
    $(".star-click").click(function () {
        $('.star').toggleClass("far fa");
    });
});

window.onscroll = function () { myFunction() };
var header = document.getElementById("header");
var sticky = header.offsetTop;
function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("position-fixed w-100");
    } else {
        header.classList.remove("position-fixed w-100");
    }
}
