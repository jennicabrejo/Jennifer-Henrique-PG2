using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALLERM.Models.DB;
using TALLERM.Models.Fictional;
using TALLERM.Support;

namespace TALLERM.Controllers
{
    public class VistaBitacoraController
    {
        public IList<_BITACORAS> getDataList(DateTime dateini, DateTime datend)
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<BITACORAS> felist = new List<BITACORAS>();
                IList<_BITACORAS> _felist = new List<_BITACORAS>();

                felist = db.BITACORAS.Where(x => x.FECHA_HORA >= dateini && x.FECHA_HORA < datend).OrderByDescending(x => x.ID_BITACORA).ToList();

                foreach (var item in felist)
                {
                    _BITACORAS en = new _BITACORAS();
                    en.ID = item.ID_BITACORA.ToString();
                    en.NOMBRE_EVENTO = item.NOMBRE_EVENTO;
                    en.DESC_EVENTO = item.DESC_EVENTO;
                    en.FECHA_HORA = item.FECHA_HORA.ToString("dd/MM/yyyy HH:mm:ss");

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("VistaBitacoraController-getDataList", ex.ToString());
                return null;
            }
        }

        public BITACORAS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.BITACORAS.Where(x => x.ID_BITACORA == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("VistaBitacoraController-getData", ex.ToString());
                return null;
            }
        }

    }
}
