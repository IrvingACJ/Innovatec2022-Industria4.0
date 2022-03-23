namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tBasculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tBasculas()
        {
            tLineasComponentesBasculas = new HashSet<tLineasComponentesBasculas>();
        }

        [Key]
        [StringLength(25)]
        public string ID_Bascula { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tLineasComponentesBasculas> tLineasComponentesBasculas { get; set; }
    }
}
