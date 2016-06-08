using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrangoFone.Models
{
    public class ListaPedidoClienteViewModel
    {
        public int IdPedido { get; set; }
        public string NomeCliente { get; set; }
        public string EnderecoEntrega { get; set; }
        public string TipoEntrega { get; set; }
        public string TipoPagamento { get; set; }
        public DateTime DataPedido { get; set; }
        public StatusPedidoEnum Status { get; set; }
        public decimal ValorTotal { get; set; }
        public string Login { get; set; }
        public List<DetalheItemPedidoVeiwModel> ListaDetalhesItensPedido { get; set; }

        public string ObterImpressaoPedido()
        {
            StringBuilder strImpressao = new StringBuilder();
            strImpressao.AppendLine(string.Format("Cliente:{0}", NomeCliente));
            strImpressao.AppendLine(string.Format("Endereco:{1}", EnderecoEntrega));

            return strImpressao.ToString();

        }
    }
}
