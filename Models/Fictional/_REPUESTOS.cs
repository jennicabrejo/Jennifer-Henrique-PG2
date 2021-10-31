namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _REPUESTOS
    {
        public string ID { get; set; }

        [DisplayName("NOMBRE PROVEEDOR")]
        public string NOMBRE_PROVEEDOR { get; set; }

        public string NOMBRE { get; set; }

        [DisplayName("DESCRIPCIÓN")]
        public string DESCRIPCION { get; set; }

        public string PRECIO { get; set; }
        public string ESTADO { get; set; }

    }
}
