var connector = connector || {};
$(function () {
    connector = $.connection.pedidosCozinha;
    $.connection.hub.start();
});