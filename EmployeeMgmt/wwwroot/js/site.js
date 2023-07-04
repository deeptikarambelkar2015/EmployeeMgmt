// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $.ajaxSetup({ cache: false });

//$("a").on("click", function (e) {
    
//    var url = this.href;
//    $('#').load(url, function () {
//        $('#').modal('show');
//        onSubmitOfModal(this);
//    });

//    return false;
//});

function onSubmitOfModal(dialog) {
    $('form', dialog).submit(function () {

        var action = this.action;
        var method = this.method;
        var formSubmissionData = $(this).serialize();

        $.ajax({
            url: action,
            type: method,
            data: formSubmissionData,
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    location.reload();
                } else {
                    $('#myModalContent').html(result);
                    onSubmitOfModal();
                }
            }
        });
        return false;
    });
}




});

