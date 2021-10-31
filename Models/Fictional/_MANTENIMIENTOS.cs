namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _MANTENIMIENTOS
    {
        public string ID { get; set; }
        public string FECHA_HORA { get; set; }
        public string VEHICULO { get; set; }
        public string ENCARGADO { get; set; }
        //public string KM_ACTUAL { get; set; }

    }
}
