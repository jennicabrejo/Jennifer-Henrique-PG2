namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VEHICULOS
    {

        [Key]
        [Column(TypeName = "numeric")]
        public decimal ID_VEHICULO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ID_TIPO_VEHICULO { get; set; }

        [Required]
        [StringLength(15)]
        public string PLACA { get; set; }

        [Required]
        [StringLength(15)]
        public string MARCA { get; set; }

        [Required]
        [StringLength(15)]
        public string LINEA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MODELO { get; set; }

        public DateTime FECHA_INGRESO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTADO { get; set; }

    }
}
