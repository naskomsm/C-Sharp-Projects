﻿// Car models
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

$("#commentBtn").click(function () {
    var content = $("#message").val();
    var postId = $("#postId").val();

    $.get({
        url: "/Comments/Create",
        data: { content: content, postId: parseInt(postId) }
    }).done(function (data) {
        attachCommentToDom(data.username, data.content, data.currentUserImageUrl, data.commentId);
    });
});

function attachCommentToDom(username, content, currentUserImageUrl, commentId) {
    var commentsCountElement = document.getElementById("commentsCount").innerHTML;
    commentsCountElement = commentsCountElement.replace(" Comments", "");
    var commentsCount = Number(commentsCountElement) + 1;
    document.getElementById("commentsCount").innerHTML = commentsCount + " Comments";

    let outerDiv = document.createElement('div');
    outerDiv.className = "media";

    let aElement = document.createElement('a');
    aElement.className = "float-left mr-4";
    aElement.href = "#";

    let imageForAElement = document.createElement('img');
    imageForAElement.className = "media-object";
    imageForAElement.src = currentUserImageUrl;
    imageForAElement.alt = "";
    imageForAElement.width = "93";
    imageForAElement.height = "93";

    let innerDiv = document.createElement('div');
    innerDiv.className = "media-body";

    let h4Element = document.createElement('h4');
    h4Element.className = "media-heading";
    h4Element.innerHTML = username;

    let paragraph = document.createElement('p');
    paragraph.innerHTML = content;

    let ul = document.createElement('ul');
    ul.className = "list-unstyled list-inline media-detail float-left";

    let li = document.createElement('li');
    li.className = "list-inline-item";
    li.id = 'when';
    var currentdate = new Date();

    let iForLi = document.createElement('i');
    iForLi.className = "fa fa-calendar";

    let secondLi = document.createElement('li');
    secondLi.id = "comment" + "(" + commentId + ")" + "Likes";
    secondLi.className = "list-inline-item";

    let iForSecondLi = document.createElement('i');
    iForSecondLi.className = "fa fa-thumbs-up";

    let secondUl = document.createElement('ul');
    secondUl.className = "list-unstyled list-inline media-detail float-right";

    let liForSecondUl = document.createElement('li');
    liForSecondUl.className = "list-inline-item";

    let textarea = document.createElement('textarea');
    textarea.innerHTML = commentId;
    textarea.id = "currentCommentId";
    textarea.hidden = true;

    let likeBtn = document.createElement('button');
    likeBtn.className = "btn btn-primary";
    likeBtn.type = "submit";
    likeBtn.name = "likeBtn";
    likeBtn.innerHTML = "Like";
    likeBtn.addEventListener('click', function () {
        giveLike(commentId);
    });

    // Appendings
    aElement.appendChild(imageForAElement);
    outerDiv.appendChild(aElement);

    li.appendChild(iForLi);

    li.innerHTML +=
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true, timeZone: 'UTC' })

    secondLi.appendChild(iForSecondLi);
    secondLi.innerHTML += "0";

    ul.appendChild(li);
    ul.appendChild(secondLi);

    liForSecondUl.appendChild(textarea);
    liForSecondUl.appendChild(likeBtn);
    secondUl.appendChild(liForSecondUl);

    innerDiv.appendChild(h4Element);
    innerDiv.appendChild(paragraph);
    innerDiv.appendChild(ul);
    innerDiv.appendChild(secondUl);

    outerDiv.appendChild(innerDiv);

    document.getElementById("commentsSection").appendChild(outerDiv);
};

function giveLike(commentId) {
    $.get({
        url: "/Comments/Like",
        data: { commentId: parseInt(commentId) },
    }).done(function (data) {
        updateLikesDOM(data);
    });
};

function updateLikesDOM(commentId) {
    var id = "comment" + "(" + commentId + ")" + "Likes";
    var element = document.getElementById(id);
    var currentLikesAsString = element.innerHTML.replace('<i class="fa fa-thumbs-up"></i>', '');
    var currentLikesAsInteger = parseInt(currentLikesAsString);
    var updatedLikes = currentLikesAsInteger + 1;

    element.innerHTML = '<i class="fa fa-thumbs-up"></i>' + updatedLikes;
};