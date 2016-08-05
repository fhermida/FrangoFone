namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AreaPedidoSet")]
    public partial class AreaPedidoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaPedidoSet()
        {
            ProdutoSet = new HashSet<ProdutoSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public bool Ativa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoSet> ProdutoSet { get; set; }
    }
}
