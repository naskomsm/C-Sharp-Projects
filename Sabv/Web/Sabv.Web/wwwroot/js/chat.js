
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

$("#submitButton").attr("disabled", true);

connection.on("ReceiveMessage", function (username, message, currentUserImageUrl) {
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
    paragraph.innerHTML = message;

    let ul = document.createElement('ul');
    ul.className = "list-unstyled list-inline media-detail float-left";

    let li = document.createElement('li');
    li.className = "list-inline-item";
    li.id = 'when';
    var currentdate = new Date();

    let iForLi = document.createElement('i');
    iForLi.className = "fa fa-calendar";

    // Appendings
    aElement.appendChild(imageForAElement);
    outerDiv.appendChild(aElement);

    li.appendChild(iForLi);

    li.innerHTML +=
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true, timeZone: 'UTC' })

    ul.appendChild(li);

    innerDiv.appendChild(h4Element);
    innerDiv.appendChild(paragraph);
    innerDiv.appendChild(ul);

    outerDiv.appendChild(innerDiv);

    document.getElementById("chat").appendChild(outerDiv);
});

connection.on("PostComment", function (username, content, currentUserImageUrl, commentId) {
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
    secondLi.id = "likesCount";
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
    likeBtn.addEventListener('click', function (e) {

        var commentId = e.target.parentElement.children[0].innerHTML;
        var likesCount = Number(e.target.parentElement.parentElement.parentElement.children[2].children[1].innerHTML.replace('<i class="fa fa-thumbs-up"></i>', ""));
        likesCount++;
        e.target.parentElement.parentElement.parentElement.children[2].children[1].innerHTML = '<i class="fa fa-thumbs-up"></i>' + likesCount;

        connection.invoke("LikeComment", commentId);
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
});

connection.on("LikeComment", function () {
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
        alert("Message should not be empty!");
    }

    connection.invoke("SendMessage", message);
});

$("#commentBtn").on("click", function () {
    var content = $("#message").val();
    var postId = $("#postId").val();
    $("#message").val("");

    if (content.trim().length < 1) {
        alert("Comment should not be empty!");
    }

    connection.invoke("SendComment", content, postId);
})

document.getElementsByName("likeBtn").forEach(function (button) {
    button.addEventListener('click', function (e) {
        if (sessionStorage.getItem('status') != null) {
            var commentId = e.target.parentElement.children[0].innerHTML;
            var likesCount = Number(e.target.parentElement.parentElement.parentElement.children[2].children[1].innerHTML.replace('<i class="fa fa-thumbs-up"></i>', ""));
            likesCount++;
            e.target.parentElement.parentElement.parentElement.children[2].children[1].innerHTML = '<i class="fa fa-thumbs-up"></i>' + likesCount;

            connection.invoke("LikeComment", commentId);
        }
    });
});

$("#loginBtn").on("click", function () {
    sessionStorage.setItem('status', 'loggedIn');
});

$("#logoutBtn").on("click", function () {
    sessionStorage.removeItem('status');
});