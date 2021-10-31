namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _PROVEEDORES_COMBO
    {
        public decimal ID_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
    }
}
