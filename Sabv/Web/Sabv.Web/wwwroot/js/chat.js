﻿
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

$("#submitButton").attr("disabled", true);

connection.on("ReceiveMessage", function (username, message, currentUserImageUrl, createdOn) {
    let outerDiv = document.createElement('div');
    outerDiv.className = "media";

    let imageElement = document.createElement('img');
    imageElement.className = "media-object float-left mr-4";
    imageElement.src = currentUserImageUrl;
    imageElement.alt = "";
    imageElement.width = "93";
    imageElement.height = "93";

    let innerDiv = document.createElement('div');
    innerDiv.className = "media-body";

    let h4Element = document.createElement('h4');
    h4Element.className = "media-heading";
    h4Element.innerHTML = username;

    let paragraph = document.createElement('p');
    paragraph.innerHTML = escapeHtml(message);

    let ul = document.createElement('ul');
    ul.className = "list-unstyled list-inline media-detail float-left";

    let li = document.createElement('li');
    li.className = "list-inline-item";
    li.id = 'when';
    var currentdate = new Date();

    let iForLi = document.createElement('i');
    iForLi.className = "fa fa-calendar";

    // Appendings
    outerDiv.appendChild(imageElement);

    li.appendChild(iForLi);

    li.innerHTML += "<time datetime='" + createdOn.toString("O") + "'></time>";

    ul.appendChild(li);

    innerDiv.appendChild(h4Element);
    innerDiv.appendChild(paragraph);
    innerDiv.appendChild(ul);

    outerDiv.appendChild(innerDiv);

    document.getElementById("chat").appendChild(outerDiv);

    $(function () {
        $("time").each(function (i, e) {
            const dateTimeValue = $(e).attr("datetime");
            if (!dateTimeValue) {
                return;
            }

            const time = moment.utc(dateTimeValue).local();
            $(e).html(time.format("llll"));
            $(e).attr("title", $(e).attr("datetime"));
        });
    });
});


connection.start().then(function () {
    $("#submitButton").attr("disabled", false);
}).catch(function (err) {
    return alert(err.toString());
})

$("#submitButton").on("click", function () {
    var message = $("#message").val();
    $("#message").val("");

    if (message.trim().length < 1) {
        $.notify('Content cannot be empty!');
    }

    connection.invoke("SendMessage", message);
});