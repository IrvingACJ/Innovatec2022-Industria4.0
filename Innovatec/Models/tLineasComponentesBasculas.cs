namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tLineasComponentesBasculas
    {
        public int ID { get; set; }

        [StringLength(25)]
        public string ID_Linea { get; set; }

        [StringLength(25)]
        public string ID_Componente { get; set; }

        [StringLength(25)]
        public string ID_Bascula { get; set; }
        
        public int? Cantidad { get; set; }
        
        public virtual tBasculas tBasculas { get; set; }

        public virtual tComponentes tComponentes { get; set; }

        public virtual tLineasProduccion tLineasProduccion { get; set; }
    }
}
