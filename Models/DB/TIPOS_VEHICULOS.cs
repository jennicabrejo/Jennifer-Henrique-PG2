namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIPOS_VEHICULOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_TIPO_VEHICULO { get; set; }

        [Required]
        [StringLength(25)]
        public string NOMBRE_TIPO { get; set; }

        [Required]
        [StringLength(150)]
        public string DESC_TIPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

    }
}
