namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _VEHICULOS
    {
        public string ID { get; set; }

        public string PLACA { get; set; }

        public string MARCA { get; set; }

        public string LINEA { get; set; }

        public string MODELO { get; set; }

        [DisplayName("TIPO VEHICULO")]
        public string TIPO_VEHICULO { get; set; }

        [DisplayName("FECHA INGRESO")]
        public string FECHA_INGRESO { get; set; }

        public string ESTADO { get; set; }

    }
}
