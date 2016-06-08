var Cozinha = Cozinha || {};

Cozinha.Application = function () {

    var self = this;

    self.AtualizarPedidos = function (pedidos) {
        connector.server.AtualizarPedidos(pedidos);
    }

    self.AtualizarPedidosCozinha = function ($container, data) {
        var pedidos = $.parseJSON(data);
        var html = '<div class="container-fluid">' +
            '<div class="row">' +
            '<div class="col-sm-8" style="background-color: lavender;">Pedido: ' + pedido.Itens + ' Garcom: ' + pedido.Garcom.Nome + '</div> </div>' +
            '</div>   <div class="container-fluid"></div>';
        $($container).append(html);
    }
    
}