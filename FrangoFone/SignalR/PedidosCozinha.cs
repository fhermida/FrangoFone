using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using FrangoFone.Models;
using Microsoft.AspNet.SignalR.Hubs;
using FrangoFone.Repository.Interface;
using FrangoFone.Repository.Concrete;
using FrangoFone.Domain;


namespace FrangoFone.EntryPoint.SignalR
{                                

    public class PedidosCozinha : Hub
    {
        public void AtualizarPedidos(PedidoSet pedido)
        {
                                                                          
            IProdutoRepository produtoRepository = new ProdutoRepository();

            DetalhePedidoCozinhaViewModel detalhePedidoCozinha = new DetalhePedidoCozinhaViewModel
            {
                IdPedido = pedido.Id,
                NomeCliente = new ClienteRepository().ObterPorId(pedido.ClienteId).Nome,
                Itens = new List<DetalheItemPedidoCozinhaViewModel>()
            };                                                         

            foreach (var item in pedido.ItemPedidoSet)
            {
                DetalheItemPedidoCozinhaViewModel detalhe = new DetalheItemPedidoCozinhaViewModel();
                ProdutoSet produto = new ProdutoRepository().ObterPorId(item.ProdutoId);

                if (produto.AreaPedidoId != 1)
                    continue;

                detalhe.NomeProduto = produto.Nome;
                detalhe.Descricao = produto.Descricao;
                detalhe.Quantidade = item.Quantidade;
                detalhePedidoCozinha.Itens.Add(detalhe);
            }

            if (!detalhePedidoCozinha.Itens.Any())
                return;

            var context = GlobalHost.ConnectionManager.GetHubContext<PedidosCozinha>();
            context.Clients.All.AtualizarPedidosCozinha(detalhePedidoCozinha);
        }

        public void RemoverPedido(int idPedido, StatusPedidoEnum status)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<PedidosCozinha>();
            context.Clients.All.RemoverPedidoCozinha(idPedido, status);
        }
    }
}