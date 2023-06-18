document.getElementById("toastButton1").onclick = function () {
    var toastElList = [].slice.call(document.querySelectorAll('#topToast'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl);
    });
    toastList.forEach(toast => toast.show());
}
document.getElementById("toastButton2").onclick = function () {
    var toastElList = [].slice.call(document.querySelectorAll('#bottomToast'));
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl);
    });
    toastList.forEach(toast => toast.show());
}