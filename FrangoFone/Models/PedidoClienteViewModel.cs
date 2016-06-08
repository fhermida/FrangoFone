using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        

namespace FrangoFone.Models
{
    public class PedidoClienteViewModel
    {
        [Required]
        public int Cliente { get; set; }
        [Required]    
        public List<ItemPedidoViewModel> ItensPedido { get; set; }
        [Required]
        public int Endereco { get; set; }
        [Required]
        public int TipoEntrega { get; set; }  
        [Required]
        public int TipoPagamento { get; set; }

        public string Obs { get; set; }     
    }
}
