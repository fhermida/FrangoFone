namespace FrangoFone.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuSet")]
    public partial class MenuSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuSet()
        {
            PermissaoMenuSet = new HashSet<PermissaoMenuSet>();
        }

        public int Id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string action { get; set; }

        public string controller { get; set; }

        public string route { get; set; }

        public bool ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissaoMenuSet> PermissaoMenuSet { get; set; }
    }
}
