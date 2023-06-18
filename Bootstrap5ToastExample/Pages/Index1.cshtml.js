$(document).ready(function () {

    console.log(document.getElementById('navBar').offsetHeight);
    console.log(document.querySelector('body').offsetHeight);
    console.log(document.querySelector('footer').offsetHeight);

    $("#toastButton1").click(function () {
        $("#toast1").toast("show");
    });
});