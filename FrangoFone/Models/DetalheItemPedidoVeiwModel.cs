using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Models
{
    public class DetalheItemPedidoVeiwModel
    {
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
