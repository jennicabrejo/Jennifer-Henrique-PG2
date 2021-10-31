namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ENCARGADOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_ENCARGADO { get; set; }

        [Required]
        [StringLength(15)]
        public string NOMBRES_ENCARGADO { get; set; }

        [Required]
        [StringLength(15)]
        public string APELLIDOS_ENCARGADO { get; set; }

        [Required]
        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(25)]
        public string CORREO { get; set; }

        public DateTime FECHA_NACIMIENTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }
    }
}
