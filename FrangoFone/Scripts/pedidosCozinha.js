var Cozinha = Cozinha || {};

Cozinha.Application = function () {

    var self = this;

    self.AtualizarPedidos = function (pedido) {
        connector.server.atualizarPedidos(pedido);
    }

    self.RemoverPedido = function (idPedido, status) {
        connector.server.removerPedido(idPedido, status);
    }

    self.AtualizarPedidosCozinha = function ($container, data) {

        var html = '<div id="panel_' + data.IdPedido + '" class="panel panel-primary">' +
                        '<div class="panel-heading">' +
                            '<h3 class="panel-title">Id Pedido:' + data.IdPedido + '    Cliente:' + data.NomeCliente +
                            '<input type="button" name="pronto" id="pronto_' + data.IdPedido + '" value="Pronto" class="btn btn-default btn-xs pull-right" /></h3>' +
                        '</div>' +
                        '<div class="panel-body">' +
                            '<table class="table" id="detalhesPedido">' +
                                '<tr>' +
                                    '<th>Prato</th>' +
                                    '<th>Descrição</th>' +
                                    '<th>Quantidade</th>' +
                               '</tr>';

        for (var i = 0; i < data.Itens.length; i++) {

                        html = html + '<tr>' +
                                       '<td>' + data.Itens[i].NomeProduto + '</td>' +
                                       '<td>' + data.Itens[i].Descricao + '</td>' +
                                       '<td>' + data.Itens[i].Quantidade + '</td>' +
                                   '</tr>';
                    }
        
        html = html + '</table>' +
                    '</div>'+
                '</div>';
        $($container).prepend(html);

        $.playSound("../Scripts/alarm_pedido");
        
    }

    self.RemoverPedidoCozinha = function ($container, data) {
        console.log(data);
        $($container).find(data).remove();
    }
    
}