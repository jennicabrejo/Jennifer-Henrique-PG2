namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REPUESTOS_X_MANTENIMIENTOS
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_REP_X_MANTE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_MANTENIMIENTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_REPUESTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CANTIDAD { get; set; }
        public DateTime FECHA_HORA { get; set; }
    }
}
