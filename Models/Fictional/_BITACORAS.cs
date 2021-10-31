namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _BITACORAS
    {
        public string ID { get; set; }

        [DisplayName("FECHA HORA")]
        public string FECHA_HORA { get; set; }

        [DisplayName("NOMBRE EVENTO")]
        public string NOMBRE_EVENTO { get; set; }
        [DisplayName("DESCRIPCIÓN")]
        public string DESC_EVENTO { get; set; }

    }
}
