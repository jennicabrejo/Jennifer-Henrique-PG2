namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _MANTENIMIENTOS_REPORTE
    {
        [DisplayName("FECHA Y HORA")]
        public string FECHA_HORA { get; set; }

        [DisplayName("ENCARGADO")]
        public string NOMBRES_ENCARGADO { get; set; }

        [DisplayName("TIPO VEHICULO")]
        public string TIPO_VEHICULO { get; set; }
        public string MARCA { get; set; }
        public string LINEA { get; set; }
        public string PLACA { get; set; }

        [DisplayName("KM. ACTUAL")]
        public string KM_ACTUAL { get; set; }

        [DisplayName("PROX. SERVICIO")]
        public string PSERVICIO_KM { get; set; }

        [DisplayName("PROX. SERVICIO")]
        public string PSERVICIO_TIEMPO { get; set; }

    }
}
