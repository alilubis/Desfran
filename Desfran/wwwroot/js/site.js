$(document).ready(function () {
    $('#weather').DataTable({
        "lengthMenu": [[5, 10, 20, -1], [5, 10, 20, "All"]],
        "pageLength": 5
    });
});

let getUrlParameter = function getUrlParameter(sParam) {
    let sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return typeof sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
    return false;
};

let params = window.location.toString();
let icon = getUrlParameter('icon');
let title = getUrlParameter('title');
if (icon != false) {
    alert(icon, title);
    if (params.indexOf("?") > 0) {
        let clean_uri = params.substring(0, params.indexOf("?"));
        window.history.replaceState({}, document.title, clean_uri);
    }
}

function alert(icon, title) {
    const Toast = Swal.mixin({
        toast: true,
        position: "center-end",
        grow: true,
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener("mouseenter", Swal.stopTimer);
            toast.addEventListener("mouseleave", Swal.resumeTimer);
        },
    });
    Toast.fire({
        icon: icon,
        title: title,
    });
}