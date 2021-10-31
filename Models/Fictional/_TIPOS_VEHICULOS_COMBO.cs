namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _TIPOS_VEHICULOS_COMBO
    {
        public decimal ID_TIPO_VEHICULO { get; set; }
        public string NOMBRE_TIPO { get; set; }

    }
}
