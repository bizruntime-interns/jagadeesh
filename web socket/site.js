var connectionForm = document.getElementById("connectionForm");
var connectionUrl = document.getElementById("connectionUrl");
var connectionButton = document.getElementById("connectionButton");
var stateLabel = document.getElementById("stateLabel");
var sendMessage = document.getElementById("sendMessage");
var sendButton = document.getElementById("sendButton");
var sendForm = document.getElementById("sendForm");
var closeButton = document.getElementById("closeButton");
var commslog = document.getElementById("commslog");
var socket;
var scheme = document.location.protocol === "https:" ? "wss" : "ws";
var port = document.location.port ? (":" + document.location.port) : "";
connectionUrl.value = scheme + "://" + document.location.hostname + port + "/ws";


function updateState() {
    function disable() {
        sendMessage.disabled = true;
        sendButton.disabled = true;
        closeButton.disabled = true;

    }
    function enable() {
        sendMessage.disabled = false;
        sendButton.disabled = false;
        closeButton.disabled = false;

    }
    connectionUrl.disable = true;
    connectionButton.disabled = true;
    if (!socket) {
        disable();

    } else {
        switch (socket.readyState) {
            case WebSocket.CLOSED:
                stateLabel.innerHTML = "Closed";
                disable();
                connectionUrl.disabled = false;
                connectionButton.disabled = false;
                break;
            case WebSocket.CLOSING:
                stateLabel.innerHTML = "Closingg...";
                disable();
                break;
            case WebSocket.CONNECTING:
                stateLabel.innerHTML = "Connecting...";
                disable();
                break;
            case WebSocket.OPEN:
                stateLabel.innerHTML = "Open";
                enable();
                break;
            default:
                stateLabel.innerHTML = "Unknown WebSocket State: " + htmlEscape(socket.readyState);
                disable();
                break;


        }
    }
}
closeButton.onclick = function () {
    if (!socket || socket.readyState !== WebSocket.OPEN) {
        alert("socket not connected");
    }
    socket.close(1000, "Closing from client");
        
}
sendButton.onclick = function () {
    if (!socket || socket.readyState !== WebSocket.OPEN) {
        alert("socket not connected");
    }
    var data = sendMessage.value;
    socket.send(data);
    commslog.innerHTML += '<tr>' +
        '<td class="commslog-client">client</td>' +
        '<td class="commslog-server">server</td>' +
        '<td class="commslog-data">' + htmlEscape(data) + '</td></tr>';
}
connectionButton.onclick = function () {
    stateLabel.innerHTML = "Connection...........";
    socket = new WebSocket(connectionUrl.value);
    socket.onopen = function (event) {
        updateState();
        commslog.innerHTML += '<tr>' +
            '<td colspan="3" class="commslog-data">Connection openened</td>' +
            '</tr>';
    };
    socket.onclose = function (event) {
        updateState();
        commslog.innerHTML += '<tr>' +
            '<td colspan="3" class="commslog-data">Connection Closed .Code:' + htmlEscape(event.code) + '.Reason: ' + htmlEscape(event.reason) + '</td>' +
            '</tr>';
    };
    socket.onerror = updateState;
    socket.onmessage = function (event) {
        commslog.innerHTML += '<tr>' +
            '<td class="commslog-server">Server</td>' +
            '<td class="commslog-client">Client</td>' +
            '<td class="commslog-data">' + htmlEscape(event.data) + '</td></tr>';

    };
};
    function htmlEscape(str) {
        return str.toString()
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');

    }
    
