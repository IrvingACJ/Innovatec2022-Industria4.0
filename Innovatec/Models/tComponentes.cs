namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tComponentes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tComponentes()
        {
            tBOM = new HashSet<tBOM>();
            tLineasComponentesBasculas = new HashSet<tLineasComponentesBasculas>();
        }

        [Key]
        [StringLength(25)]
        public string ID_Componente { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public decimal? PesoUnitarioGramos { get; set; }

        public decimal? Minimo { get; set; }

        public decimal? Maximo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tBOM> tBOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tLineasComponentesBasculas> tLineasComponentesBasculas { get; set; }
    }
}
