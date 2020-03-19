// Car models
$("#makesSelect").on("change", function () {
    var selectedMakeId = $("#makesSelect option:selected").val();

    $.getJSON("../datasets/MakesAndItsModels.json", function (data) {
        $("#modelsSelect").html("");

        var optionElement = document.createElement("option");
        optionElement.innerHTML = "All";
        $("#modelsSelect").append(optionElement);

        var filtered = data.filter(function (model) {
            return model.MakeId == selectedMakeId;
        });

        $.each(filtered, function (key, value) {
            var optionElement = document.createElement("option");
            optionElement.innerHTML = value.Name;
            $("#modelsSelect").append(optionElement);
        })
    })
});

$("#pageHeader").html("All");

$("#categorySelect").on("change", function () {
    var selectedText = $("#categorySelect option:selected").text().trim();
    $("#pageHeader").html(selectedText);
});

// Selected files
$("input#files").change(function () {
    var files = $(this)[0].files;
    if (files.length < 1) {
        alert("You have to upload at least 1 image.")
    }
    else if (files.length > 10) {
        alert("You can upload max to 10 images.");
    }
});