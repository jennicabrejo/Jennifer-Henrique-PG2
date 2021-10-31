namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MANTENIMIENTOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_MANTENIMIENTO { get; set; }
        public DateTime FECHA_HORA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_VEHICULO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_ENCARGADO { get; set; }

        public decimal KM_ACTUAL { get; set; }

        [Required]
        [StringLength(500)]
        public string COMENTARIOS { get; set; }
        public decimal PSERVICIO_KM { get; set; }
        public DateTime PSERVICIO_TIEMPO { get; set; }

        [Required]
        [StringLength(1000)]
        public string DESC_FALLA { get; set; }

        [Required]
        [StringLength(1000)]
        public string DESC_SOLUCION { get; set; }

    }
}
