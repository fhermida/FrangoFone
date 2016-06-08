var connector = connector || {};
$(function () {
    appCozinha = $.connection.cozinha;
    $.connection.hub.start();
});