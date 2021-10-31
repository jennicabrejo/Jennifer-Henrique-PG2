namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REPUESTOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_REPUESTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_PROVEEDOR { get; set; }

        [Required]
        [StringLength(25)]
        public string NOMBRE_REPUESTO { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_REPUESTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PRECIO_REPUESTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal STOCK { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

    }
}
