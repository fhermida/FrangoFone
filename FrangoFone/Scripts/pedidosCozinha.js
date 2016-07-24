var Cozinha = Cozinha || {};

Cozinha.Application = function () {

    var self = this;

    self.AtualizarPedidos = function (pedido) {
        connector.server.atualizarPedidos(pedido);
    }

    self.AtualizarPedidosCozinha = function ($container, data) {
        //var pedido = $.parseJSON(data);
        var html = '<div class="container-fluid">' +
            '<div class="row">' +
            '<div class="col-sm-8" style="background-color: lavender;">Cliente:  Endereco: </div> </div>' +
            '</div>   <div class="container-fluid"></div>';
        $($container).append(html);
    }
    
}