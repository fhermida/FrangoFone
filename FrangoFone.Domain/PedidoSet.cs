namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidoSet")]
    public partial class PedidoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoSet()
        {
            ItemPedidoSet = new HashSet<ItemPedidoSet>();
        }

        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataPedido { get; set; }

        public int TipoEntregaId { get; set; }

        public int TipoPagamentoId { get; set; }

        public int Endereco_Id { get; set; }

        public StatusPedidoEnum Status { get; set; }
        
        public string Obs { get; set; }

        public int UsuarioId { get; set; }

        public virtual ClienteSet ClienteSet { get; set; }

        public virtual EnderecoSet EnderecoSet { get; set; }

        public virtual UsuarioSet UsuarioSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPedidoSet> ItemPedidoSet { get; set; }

        public virtual TipoEntregaSet TipoEntregaSet { get; set; }

        public virtual TipoPagamentoSet TipoPagamentoSet { get; set; }
    }
}
