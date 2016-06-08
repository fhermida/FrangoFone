using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using FrangoFone.Models;

namespace FrangoFone.EntryPoint.SignalR
{
    public class PedidosCozinha : Hub
    {
        public void AtualizarPedidos(PedidoClienteViewModel pedidos)
        {
            Clients.All.AtualizarPedidosCozinha(pedidos);
        }
    }
}