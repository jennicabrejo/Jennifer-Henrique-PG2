namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _REPUESTOS_X_MANTENIMIENTOS
    {
        public string ID { get; set; }
        public string NOMBRE_REPUESTO { get; set; }

        public string CANTIDAD { get; set; }
    }
}
