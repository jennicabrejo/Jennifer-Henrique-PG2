namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _PROVEEDORES
    {
        public string ID { get; set; }

        [DisplayName("NOMBRE PROVEEDORE")]
        public string NOMBRE_PROVEEDOR { get; set; }

        public string DIRECCION { get; set; }

        public string TELEFONO { get; set; }

        public string CORREO { get; set; }

        public string ESTADO { get; set; }

    }
}
