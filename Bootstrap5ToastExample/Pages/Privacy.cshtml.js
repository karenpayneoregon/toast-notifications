document.getElementById("toastButton1").onclick = function () {
    topToast();
}

document.getElementById("toastButton2").onclick = function () {
    bottomToast();
}

document.getElementById("bothToast").onclick = function () {
    topToast();
    bottomToast();
}
document.getElementById("buttonSample").addEventListener("click", function () {
    var toastElList = [].slice.call(document.querySelectorAll('#buttonExample'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl);
    });
    toastList.forEach(toast => toast.show());
});

document.getElementById("takeAction").addEventListener("click", function () {
    alert('Take action!!!');
});
function topToast() {
    var toastElList = [].slice.call(document.querySelectorAll('#topToast'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl);
    });
    toastList.forEach(toast => toast.show());
}

function bottomToast() {
    var toastElList = [].slice.call(document.querySelectorAll('#bottomToast'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl);
    });
    toastList.forEach(toast => toast.show());
}