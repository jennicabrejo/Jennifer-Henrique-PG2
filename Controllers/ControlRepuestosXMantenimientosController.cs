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
    public class ControlRepuestosXMantenimientosController
    {
        public IList<_REPUESTOS_X_MANTENIMIENTOS> getDataListDiff(decimal ID_MANT)
        {
            try
            {
                DBContext db = new DBContext();

                IList<REPUESTOS_X_MANTENIMIENTOS> felist = new List<REPUESTOS_X_MANTENIMIENTOS>();
                IList<_REPUESTOS_X_MANTENIMIENTOS> _felist = new List<_REPUESTOS_X_MANTENIMIENTOS>();

                DateTime Today = DateTime.Now.Date;

                felist = db.REPUESTOS_X_MANTENIMIENTOS.Where(x => x.ID_MANTENIMIENTO == ID_MANT).ToList();

                foreach (var item in felist)
                {
                    _REPUESTOS_X_MANTENIMIENTOS en = new _REPUESTOS_X_MANTENIMIENTOS();
                    en.ID = item.ID_REP_X_MANTE.ToString();
                    en.CANTIDAD = item.CANTIDAD.ToString();
                    var repu = db.REPUESTOS.Where(x => x.ID_REPUESTO == item.ID_REPUESTO).Select(x => new { x.NOMBRE_REPUESTO, x.PRECIO_REPUESTO }).FirstOrDefault();
                    en.NOMBRE_REPUESTO = repu.NOMBRE_REPUESTO;

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-getDataList", ex.ToString());
                return null;
            }
        }

        public IList<_REPUESTOS_X_MANTENIMIENTOS> getDataList(decimal ID_MANT)
        {
            try
            {
                DBContext db = new DBContext();

                IList<REPUESTOS_X_MANTENIMIENTOS> felist = new List<REPUESTOS_X_MANTENIMIENTOS>();
                IList<_REPUESTOS_X_MANTENIMIENTOS> _felist = new List<_REPUESTOS_X_MANTENIMIENTOS>();

                DateTime Today = DateTime.Now.Date;

                felist = db.REPUESTOS_X_MANTENIMIENTOS.Where(x => x.FECHA_HORA > Today && x.ID_MANTENIMIENTO == ID_MANT).ToList();

                foreach (var item in felist)
                {
                    _REPUESTOS_X_MANTENIMIENTOS en = new _REPUESTOS_X_MANTENIMIENTOS();
                    en.ID = item.ID_REP_X_MANTE.ToString();
                    en.CANTIDAD = item.CANTIDAD.ToString();
                    var repu = db.REPUESTOS.Where(x => x.ID_REPUESTO == item.ID_REPUESTO).Select(x => new { x.NOMBRE_REPUESTO, x.PRECIO_REPUESTO }).FirstOrDefault();
                    en.NOMBRE_REPUESTO = repu.NOMBRE_REPUESTO;

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-getDataList", ex.ToString());
                return null;
            }
        }



        public IList<_REPUESTOS_COMBO> getDataListCombo()
        {
            try
            {
                DBContext db = new DBContext();
                IList<_REPUESTOS_COMBO> lista = new List<_REPUESTOS_COMBO>();
                var result = db.REPUESTOS.Where(x => x.ESTADO == 1).OrderBy(x => x.NOMBRE_REPUESTO).ToList();

                foreach (var item in result)
                {
                    _REPUESTOS_COMBO element = new _REPUESTOS_COMBO();
                    element.ID = item.ID_REPUESTO.ToString();
                    element.NOMBRE = item.NOMBRE_REPUESTO;

                    lista.Add(element);
                }

                return lista;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-getDataListCombo", ex.ToString());
                return null;
            }

        }

        public bool SumarStock(decimal _id, decimal _cant)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.REPUESTOS.SingleOrDefault(b => b.ID_REPUESTO == _id);
                if (dat != null)
                {
                    dat.STOCK = dat.STOCK + _cant;

                    db.REPUESTOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-SumarStock", ex.ToString());
                return false;
            }
        }

        public decimal GetRepID(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                decimal result = db.REPUESTOS_X_MANTENIMIENTOS.Where(x => x.ID_REP_X_MANTE == _id).Select(x => x.ID_REPUESTO).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-GetRepID", ex.ToString());
                return 0;
            }

        }

        public bool RestarStock(decimal _id, decimal _cant)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.REPUESTOS.SingleOrDefault(b => b.ID_REPUESTO == _id);
                if (dat != null)
                {
                    dat.STOCK = dat.STOCK - _cant;

                    db.REPUESTOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-RestarStock", ex.ToString());
                return false;
            }
        }

        public decimal ValidarStock(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                var _value = db.REPUESTOS.Where(x => x.ID_REPUESTO == _id).Select(x => x.STOCK).FirstOrDefault();

                return _value;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-ValidarStock", ex.ToString());
                return 0;
            }
        }

        public bool AddData(REPUESTOS_X_MANTENIMIENTOS data)
        {
            try
            {
                DBContext db = new DBContext();

                REPUESTOS_X_MANTENIMIENTOS model = new REPUESTOS_X_MANTENIMIENTOS();
                int? maximo = db.REPUESTOS_X_MANTENIMIENTOS.Select(x => (int?)x.ID_REP_X_MANTE).Max() ?? 0;

                model.ID_REP_X_MANTE = (int)maximo + 1;
                model.ID_MANTENIMIENTO = data.ID_MANTENIMIENTO;
                model.ID_REPUESTO = data.ID_REPUESTO;
                model.FECHA_HORA = data.FECHA_HORA;
                model.CANTIDAD = data.CANTIDAD;

                db.REPUESTOS_X_MANTENIMIENTOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-AddData", ex.ToString());
                return false;
            }
        }

        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.REPUESTOS_X_MANTENIMIENTOS.FirstOrDefault(x => x.ID_REP_X_MANTE == _id);
                    dbContext.REPUESTOS_X_MANTENIMIENTOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlRespuestosXMantenimientosController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
