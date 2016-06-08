
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using FrangoFone.Infraestructure;

namespace FrangoFone.Domain
{
    [Table("ClienteSet")]
    public partial class ClienteSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClienteSet()
        {
            ContatoSet = new HashSet<ContatoSet>();
            EnderecoSet = new HashSet<EnderecoSet>();
            PedidoSet = new HashSet<PedidoSet>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Sobrenone { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "O campo CPF deve ter 11 dígitos.")]
        [MaxLength(11, ErrorMessage = "O campo CPF deve ter 11 dígitos.")]
        [CPFAttribute(ErrorMessage ="CPF inválido.")]
        public string CPF { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataNascimento { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public int UsuarioId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContatoSet> ContatoSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnderecoSet> EnderecoSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoSet> PedidoSet { get; set; }

        public virtual UsuarioSet UsuarioSet { get; set; }
    }
}
