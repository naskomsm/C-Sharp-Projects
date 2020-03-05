// Car models
$("#makesSelect").on("change", function () {
    var selectedMakeId = $("#makesSelect option:selected").val();

    $.getJSON("../datasets/MakesAndItsModels.json", function (data) {
        $("#modelsSelect").html("");

        var optionElement = document.createElement("option");
        optionElement.innerHTML = "Всички";
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

$("#pageHeader").html("Всички");

$("#categorySelect").on("change", function () {
    var selectedText = $("#categorySelect option:selected").text().trim();
    $("#pageHeader").html(selectedText);
});