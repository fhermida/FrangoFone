using FrangoFone.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FrangoFone.Models
{
    public class CupomViewModel
    {
        public ClienteSet Cliente { get; private set; }
        public EnderecoSet Endereco { get; private set; }
        public PedidoSet Pedido { get; private set; }
        public List<ItemPedidoSet> ItensPedido { get; private set; }

        public CupomViewModel(ClienteSet cliente, EnderecoSet endereco, PedidoSet pedido, List<ItemPedidoSet> itensPedido)
        {
            this.Cliente = cliente;
            this.Endereco = endereco;
            this.Pedido = pedido;
            this.ItensPedido = itensPedido;
        }

        public string MontaCupom(string idCabecalho)
        {

            string cupom = string.Concat("#################################################");
            cupom = string.Concat(cupom, Convert.ToChar(10));
            if (idCabecalho == "loja")
            {
                cupom = string.Concat(cupom, "#            FRANGO FONE - VIA DA LOJA          #");
            }
            else
            {
                cupom = string.Concat(cupom, "#            FRANGO FONE - VIA DA ENTREGA       #");
            }
            
            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, "#                 CUPOM NAO FISCAL              #");
            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, "#################################################");
            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Pedido: {0}", Pedido.Id), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Data/Hora: {0}", Pedido.DataPedido), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Nome: {0}", Cliente.Nome), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("End: {0}, {1}, {2}", Endereco.Logradouro, Endereco.Numero, Endereco.Complemento), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Bairro: {0}/{1}", Endereco.Bairro, Endereco.Municipio), Convert.ToChar(10));


            ContatoSet contato = Cliente.ContatoSet.FirstOrDefault(p => p.TipoContatoId == 1 || p.TipoContatoId == 3);

            string telefone = "";
            if (contato != null)
            {
                telefone = contato.Valor;
            }

            cupom = string.Concat(cupom, string.Format("Tel: {0}", telefone), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Obs: {0}", Pedido.Obs), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Tp Pgto: {0}", Pedido.TipoPagamentoSet.Nome), Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Entrega: {0}", Pedido.TipoEntregaSet.Nome), Convert.ToChar(10));
            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, "--------------------------------------------------");
            cupom = string.Concat(cupom, "|                 Produto          | Qtd | Valor |");
            cupom = string.Concat(cupom, "--------------------------------------------------");

            decimal somaTotal = 0;
            foreach (var item in ItensPedido)
            {
                decimal somaProdutos = item.Quantidade * item.ProdutoSet.Valor;

                string nomeproduto = Left(item.ProdutoSet.Nome, 34);  
                                                                      
                cupom = string.Concat(cupom, string.Format("{0}", nomeproduto), string.Format("  {0}   ", item.Quantidade), string.Format(" {0} ", somaProdutos.ToString("0,0.00")));
                cupom = string.Concat(cupom, Convert.ToChar(10));

                somaTotal = somaTotal + somaProdutos;
            }

            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, Convert.ToChar(10));
            cupom = string.Concat(cupom, string.Format("Total: R${0}", somaTotal.ToString("0,0.00")), Convert.ToChar(10));

            return cupom;
        }

        public string Left(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value.PadRight(maxLength)
                   : value.Substring(0, maxLength)
                   );
        } 
    }
}
