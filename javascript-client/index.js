var signalR = require("@microsoft/signalr");

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:44314/chat")
    .configureLogging(signalR.LogLevel.Information)
    .build()


connection.start().then(function () {
    console.log("connected");
    connection.invoke("SendMessage", "user", "message")
    .catch(err => console.error(err.toString()))
})



connection.on("ReceiveMessage", (user, message) => {
    const encodedMsg = user + " says " + message;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});