namespace TALLERM.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class _USUARIOS
    {
        public string ID { get; set; }

        [DisplayName("NOMBRE USUARIO")]
        public string NOMBRE_USUARIO { get; set; }

        [DisplayName("TIPO USUARIO")]
        public string TIPO_USUARIO { get; set; }

        //[DisplayName("CONTRASEÑA")]
        //public string CONTRASENIA { get; set; }
        public string ESTADO { get; set; }

    }
}
