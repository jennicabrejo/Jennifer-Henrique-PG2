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
    public class ControlTiposVehiculosController
    {
        public IList<_TIPOS_VEHICULOS> getDataList()
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<TIPOS_VEHICULOS> felist = new List<TIPOS_VEHICULOS>();
                IList<_TIPOS_VEHICULOS> _felist = new List<_TIPOS_VEHICULOS>();

                felist = db.TIPOS_VEHICULOS.ToList();

                foreach (var item in felist)
                {
                    _TIPOS_VEHICULOS en = new _TIPOS_VEHICULOS();
                    en.ID = item.ID_TIPO_VEHICULO.ToString();
                    en.NOMBRE_TIPO = item.NOMBRE_TIPO;
                    en.DESC_TIPO = item.DESC_TIPO;
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-getDataList", ex.ToString());
                return null;
            }
        }
        public TIPOS_VEHICULOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.TIPOS_VEHICULOS.Where(x => x.ID_TIPO_VEHICULO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-getData", ex.ToString());
                return null;
            }
        }
        public bool AddData(TIPOS_VEHICULOS data)
        {
            try
            {
                DBContext db = new DBContext();

                TIPOS_VEHICULOS model = new TIPOS_VEHICULOS();
                int? maximo = db.TIPOS_VEHICULOS.Select(x => (int?)x.ID_TIPO_VEHICULO).Max() ?? 0;

                model.ID_TIPO_VEHICULO = (int)maximo + 1;
                model.NOMBRE_TIPO = data.NOMBRE_TIPO;
                model.DESC_TIPO = data.DESC_TIPO;
                model.ESTADO = data.ESTADO;

                db.TIPOS_VEHICULOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(TIPOS_VEHICULOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.TIPOS_VEHICULOS.SingleOrDefault(b => b.ID_TIPO_VEHICULO == data.ID_TIPO_VEHICULO);
                if (dat != null)
                {
                    dat.NOMBRE_TIPO = data.NOMBRE_TIPO;
                    dat.DESC_TIPO = data.DESC_TIPO;
                    dat.ESTADO = data.ESTADO;

                    db.TIPOS_VEHICULOS.Attach(dat);
                    db.Entry(dat).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.TIPOS_VEHICULOS.FirstOrDefault(x => x.ID_TIPO_VEHICULO == _id);
                    dbContext.TIPOS_VEHICULOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
