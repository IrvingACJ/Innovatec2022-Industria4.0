namespace Innovatec.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tUsuarios
    {
        [Key]
        [StringLength(250)]
        public string ID_Usuario { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string EMail { get; set; }
    }
}
