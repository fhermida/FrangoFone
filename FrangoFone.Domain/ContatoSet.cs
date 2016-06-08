namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContatoSet")]
    public partial class ContatoSet
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Valor { get; set; }

        public int TipoContatoId { get; set; }

        public virtual ClienteSet ClienteSet { get; set; }

        public virtual TipoContatoSet TipoContatoSet { get; set; }
    }
}
