using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrangoFone.EntryPoint.Models
{
    public class DetalhesClienteEnderecoViewModel
    {
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }      
    }
}
