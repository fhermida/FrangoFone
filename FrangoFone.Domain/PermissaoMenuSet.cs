namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissaoMenuSet")]
    public partial class PermissaoMenuSet
    {
        public int Id { get; set; }

        public int Permissao_Id { get; set; }

        public int Menu_Id { get; set; }

        public virtual MenuSet MenuSet { get; set; }

        public virtual PermissaoSet PermissaoSet { get; set; }
    }
}
