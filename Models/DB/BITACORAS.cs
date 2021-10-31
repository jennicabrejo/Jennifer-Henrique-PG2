namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BITACORAS
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_BITACORA { get; set; }

        [Required]
        [StringLength(100)]
        public string NOMBRE_EVENTO { get; set; }

        [StringLength(1000)]
        public string DESC_EVENTO { get; set; }

        public DateTime FECHA_HORA { get; set; }
    }
}
