using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALLERM.Models.DB;

namespace TALLERM.Support
{
    public static class WarnToBinnacle
    {
        public static void SaveToBinnacle(string func, string message)
        {
            try
            {
                int status = ConfigsFromManager.getIntConfig("BINNACLE_STATUS");

                if (1 == status)
                {
                    DBContext dbprod = new DBContext();

                    BITACORAS bit = new BITACORAS();
                    int? IDmax = dbprod.BITACORAS.Select(x => (int?)x.ID_BITACORA).Max() ?? 0;
                    bit.ID_BITACORA = (int)IDmax + 1;
                    bit.NOMBRE_EVENTO = func;
                    bit.FECHA_HORA = DateTime.Now;
                    bit.DESC_EVENTO = (message.Count() > 1000) ? message.Substring(0, 1000) : message;

                    dbprod.BITACORAS.Add(bit);
                    dbprod.SaveChanges();
                    Trace.WriteLine("Bitácora (SaveToBinnacle) registrada.");
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error encontrado: " + ex);
            }
        }
    }
}
