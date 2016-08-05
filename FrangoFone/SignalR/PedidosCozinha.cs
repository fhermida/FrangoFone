using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using FrangoFone.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace FrangoFone.EntryPoint.SignalR
{                                

    public class PedidosCozinha : Hub
    {
        public void AtualizarPedidos(dynamic pedido)
        {

            var context = GlobalHost.ConnectionManager.GetHubContext<PedidosCozinha>();
            context.Clients.All.AtualizarPedidosCozinha(pedido);
        }
    }
}