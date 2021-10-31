using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALLERM.Models;
using TALLERM.Models.DB;
using TALLERM.Support;

namespace TALLERM.Controllers
{
    class LoginController
    {
        DBContext db = new DBContext();
        public GR LoginUser(string _user, string _pass)
        {
            GR result = new GR();

            try
            {
                _pass = Security.Base64Encode(_pass);

                var user_match = db.USUARIOS.Where(x => x.NOMBRE_USUARIO.ToUpper().Equals(_user.ToUpper()) && x.CONTRASENIA.Equals(_pass)).FirstOrDefault();

                if (user_match != null)
                {
                    if (1 == user_match.ESTADO)
                    {
                        result.CodeResult = 100;
                        result.TextResult = user_match.TIPO_USUARIO;
                    }
                    else
                    {
                        result.CodeResult = 99;
                        result.TextResult = "El usuario no se encuentra activo.";
                    }
                }
                else
                {
                    result.CodeResult = 99;
                    result.TextResult = "Credenciales incorrectas.";
                }

                return result;

            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("LoginController-LoginUser", ex.ToString());
                result.CodeResult = 99;
                result.TextResult = "Error encontrado al intentar autenticar.";

                return result;
            }


        }

    }
}
