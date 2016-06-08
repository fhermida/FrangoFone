using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Models
{
    public class VendaDiariaViewModel
    {
        public DateTime DataVendas { get; set; }
        public int QuantidadePedidos { get; set; }
        public decimal ValorDiario { get; set; }
    }
}
