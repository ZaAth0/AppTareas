// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(document).ready(function () {
//    alert("Hola desde JQUERY");
//})
$(document).ready(function () {
    $('a[data-toggle="modal"]').on('click', function (e) {
        e.preventDefault();

        var url = $(this).data('url');
        var message = $(this).data('message');

        $('#modalMessage').text(message);
        $('#modalConfirmBtn').attr('href', url);

        $('#confirmModal').modal('show');
    });
});