namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdutoPrecoSet")]
    public partial class ProdutoPrecoSet
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        [Column(TypeName = "money")]
        public decimal Valor { get; set; }

        public DateTime InicioVigencia { get; set; }

        public DateTime FimVigencia { get; set; }

        public virtual ProdutoSet ProdutoSet { get; set; }
    }
}
