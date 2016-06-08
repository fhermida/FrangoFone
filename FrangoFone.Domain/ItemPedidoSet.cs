namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemPedidoSet")]
    public partial class ItemPedidoSet
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public virtual PedidoSet PedidoSet { get; set; }

        public virtual ProdutoSet ProdutoSet { get; set; }
    }
}
