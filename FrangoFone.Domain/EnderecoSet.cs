namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnderecoSet")]
    public partial class EnderecoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnderecoSet()
        {
            PedidoSet = new HashSet<PedidoSet>();
        }

        public int Id { get; set; }

        public int ClienteId { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        public int CEP { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Municipio { get; set; }

        [Required]
        public string Estado { get; set; }

        public virtual ClienteSet ClienteSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoSet> PedidoSet { get; set; }
    }
}
