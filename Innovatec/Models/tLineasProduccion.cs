namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tLineasProduccion")]
    public partial class tLineasProduccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tLineasProduccion()
        {
            tLineasComponentesBasculas = new HashSet<tLineasComponentesBasculas>();
        }

        [Key]
        [StringLength(25)]
        public string ID_Linea { get; set; }

        [StringLength(25)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tLineasComponentesBasculas> tLineasComponentesBasculas { get; set; }
    }
}
