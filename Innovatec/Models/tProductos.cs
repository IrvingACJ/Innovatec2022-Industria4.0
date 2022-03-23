namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tProductos()
        {
            tBOM = new HashSet<tBOM>();
        }

        [Key]
        [StringLength(25)]
        public string ID_Producto { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tBOM> tBOM { get; set; }
    }
}
