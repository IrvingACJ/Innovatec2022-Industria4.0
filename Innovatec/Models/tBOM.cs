namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tBOM")]
    public partial class tBOM
    {
        public int ID { get; set; }

        [StringLength(25)]
        public string ID_Producto { get; set; }

        [StringLength(25)]
        public string ID_Componente { get; set; }

        public decimal? Cantidad { get; set; }

        public virtual tComponentes tComponentes { get; set; }

        public virtual tProductos tProductos { get; set; }
    }
}
