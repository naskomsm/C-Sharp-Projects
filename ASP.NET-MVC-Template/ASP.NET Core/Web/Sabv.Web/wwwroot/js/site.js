// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#categorySelect").on("change", function () {
    var selectedText = $("#categorySelect option:selected").text().trim();
    var expectedText = "Автомобили и джипове";

    if (selectedText.toLowerCase() == expectedText.toLowerCase()) {
        $.getJSON("http://192.168.1.6:8080/Makes.json", function (data) {
            $.each(data, function (key, val) {
                var optionElement = document.createElement("option");
                optionElement.innerHTML = val;
                $("#makesSelect").append(optionElement);
            });
        });
    }
    else {
        $("#makesSelect").html("<option>Всички</option>")
        $("#modelsSelect").html("<option>Всички</option>")
    }

    $("#pageHeader").html(selectedText);
});


$("#makesSelect").on("change", function () {
    var selectedText = $("#makesSelect option:selected").text().trim();

    $.getJSON("http://192.168.1.6:8080/Models.json", function (data) {
        $.each(data, function (key, val) {
            $("#modelsSelect").html("");

            if (selectedText == 'BMW') {
                var bmwArrays = val['BMW'];

                $.each(bmwArrays, function (bmwKey, bmwVal) {
                    var optionElement = document.createElement("option");
                    optionElement.innerHTML = bmwVal;
                    $("#modelsSelect").append(optionElement);
                })
            }
            else if (selectedText == 'Mercedes-Benz') {
                var mercedesArrays = val['Mercedes'];

                $.each(mercedesArrays, function (mercedesKey, mercedesVal) {
                    var optionElement = document.createElement("option");
                    optionElement.innerHTML = mercedesVal;
                    $("#modelsSelect").append(optionElement);
                })
            }
            else if (selectedText == 'Audi') {
                var audiArrays = val['Audi'];

                $.each(audiArrays, function (audiKey, audiVal) {
                    var optionElement = document.createElement("option");
                    optionElement.innerHTML = audiVal;
                    $("#modelsSelect").append(optionElement);
                })
            }
            else {
                $("#modelsSelect").html("<option>Всички</option>");
            }
        })
    })

});


