using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;

namespace FrangoFone.Models
{
    public class DetalhePedidoCozinhaViewModel
    {
        public int IdPedido { get; set; }
        public string NomeCliente { get; set; }
        public IList<DetalheItemPedidoCozinhaViewModel> Itens { get; set; }
    }
}
