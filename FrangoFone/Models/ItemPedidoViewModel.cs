using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrangoFone.Models
{
    public class ItemPedidoViewModel
    {
        [Required]
        public int Produto { get; set; }  
        [Required]
        public int Quantidade { get; set; }  
    }
}
