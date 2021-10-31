namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _TIPOS_VEHICULOS
    {
        public string ID { get; set; }

        [DisplayName("NOMBRE TIPO")]
        public string NOMBRE_TIPO { get; set; }

        [DisplayName("DESCRIPCIÓN")]
        public string DESC_TIPO { get; set; }

        public string ESTADO { get; set; }
    }
}
