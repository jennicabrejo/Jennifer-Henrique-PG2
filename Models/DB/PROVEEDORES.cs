namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROVEEDORES
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_PROVEEDOR { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_PROVEEDOR { get; set; }

        [Required]
        [StringLength(200)]
        public string DIRECCION { get; set; }

        [Required]
        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(30)]
        public string CORREO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

    }
}
