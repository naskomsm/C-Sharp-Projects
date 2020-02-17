// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#categorySelect").on("change", function () {
    var selectedText = $("#categorySelect option:selected").text();
    $("#pageHeader").html(selectedText);
});


$("#makesSelect").on("change", function () {
    var selectedText = $("#makesSelect option:selected").text();


    if (selectedText == 'BMW') {

    }
    else if (selectedText == 'Mercedes') {

    }
    else if (selectedText == 'Audi') {

    }
    else {
        // dont have other cars..
    }
});


