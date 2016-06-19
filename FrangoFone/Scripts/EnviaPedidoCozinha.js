var Solicitacao = Solicitacao || {};
var Pedido = Pedido || {};

Solicitacao.InformarCozinha = function () {
    var form = Solicitacao.GetPedido();
    connector.server.InformarCozinha(JSON.stringify(form));
}

Solicitacao.GetPedido = function () {
    var form = $("form").serializeArray();
    var pedido = {};

    $.each(form, function (i, v) {
        console.log(v.value);
    });

    return pedido;
}