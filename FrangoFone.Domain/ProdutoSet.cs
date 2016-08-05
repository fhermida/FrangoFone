namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdutoSet")]
    public partial class ProdutoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProdutoSet()
        {
            ItemPedidoSet = new HashSet<ItemPedidoSet>();
            ProdutoPrecoSet = new HashSet<ProdutoPrecoSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public bool Ativo { get; set; }

        public int CategoriaId { get; set; }

        public int AreaPedidoId { get;  set; }

        [Column(TypeName = "money")]
        public decimal Valor { get; set; }

        public virtual CategoriaSet CategoriaSet { get; set; }

        public virtual AreaPedidoSet AreaPedidoSet { get; set; }
                        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPedidoSet> ItemPedidoSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoPrecoSet> ProdutoPrecoSet { get; set; }
    }
}
