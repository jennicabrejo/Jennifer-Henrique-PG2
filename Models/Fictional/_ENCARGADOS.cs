using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALLERM.Models.Fictional
{
    public class _ENCARGADOS
    {
        public string ID { get; set; }

        [DisplayName("NOMBRES")]
        public string NOMBRES_ENCARGADO { get; set; }

        [DisplayName("APELLIDOS")]
        public string APELLIDOS_ENCARGADO { get; set; }

        public string TELEFONO { get; set; }

        public string CORREO { get; set; }

        [DisplayName("FECHA NACIMIENTO")]
        public string FECHA_NACIMIENTO { get; set; }

        public string ESTADO { get; set; }
    }
}
