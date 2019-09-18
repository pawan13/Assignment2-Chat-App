"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

function clearTyping() {
    var root = document.getElementById("typing list");
    while (root.firstChild) {
        root.removeChild(root.firstChild);
    }
}
function cleanMessage() {
    return message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
}
function AddMessage() {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
}

connection.on("ReceiveMessage", function (user, message) {

    AddMessage(user + " says " + cleanMessage(message);
   
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
document.getElementById("enterButton").addEventListener("click", function (event) {
   
        var groupName = document.getElementById("groupInput").value;
        connection.invoke("Addtogroup", groupName, user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
});
document.getElementById("messageInput").addEventListener("input", function (event) {
    var group = document.getElementById("groupInput").value;
    if (IsNullOrWhiteSpace(group)) {
        connection.invoke("Typing", group, user).catch(function (err) {
            return console.error(err.toString());
        });
    }
    else {
        connection.invoke("TypingGroup", group, user).catch(function (err) {
            return console.error(err.toString());
        });
    }
document.getElementById("exitButton").addEventListener("click", function (event) {
           
            var groupName = document.getElementById("groupInput").value;
            connection.invoke("RemoveFromthegroup", groupName, user, message).catch(function (err) {
                return console.error(err.toString());
            });
    event.preventDefault();
});
document.getElementById("groupsendButton").addEventListener("click", function (event) {
    var groupName = document.getElementById("groupInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessageGroup", groupName, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});