namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_USUARIO { get; set; }

        [Required]
        [StringLength(15)]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [StringLength(10)]
        public string TIPO_USUARIO { get; set; }

        [Required]
        [StringLength(200)]
        public string CONTRASENIA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

    }
}
