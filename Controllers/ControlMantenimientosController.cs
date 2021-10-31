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
    public class ControlMantenimientosController
    {

        public IList<_VEHICULOS_COMBO> getDataListComboVehiculos()
        {
            try
            {
                DBContext db = new DBContext();
                IList<_VEHICULOS_COMBO> lista = new List<_VEHICULOS_COMBO>();
                var result = db.VEHICULOS.Select(x => new { x.ID_VEHICULO, x.MARCA, x.LINEA, x.PLACA }).OrderBy(x => x.MARCA).ToList();

                foreach (var item in result)
                {
                    _VEHICULOS_COMBO element = new _VEHICULOS_COMBO();
                    element.ID_VEHICULO = item.ID_VEHICULO;
                    element.DATOS_VEHICULO = item.MARCA + ", " + item.LINEA + " ("+item.PLACA+")";

                    lista.Add(element);
                }

                return lista;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getDataListComboVehiculos", ex.ToString());
                return null;
            }
        }
        public IList<_ENCARGADOS_COMBO> getDataListComboEncargados()
        {
            try
            {
                DBContext db = new DBContext();
                IList<_ENCARGADOS_COMBO> lista = new List<_ENCARGADOS_COMBO>();
                var result = db.ENCARGADOS.Select(x => new { x.ID_ENCARGADO, x.NOMBRES_ENCARGADO, x.APELLIDOS_ENCARGADO }).OrderBy(x => x.NOMBRES_ENCARGADO).ToList();

                foreach (var item in result)
                {
                    _ENCARGADOS_COMBO element = new _ENCARGADOS_COMBO();
                    element.ID_ENCARGADO = item.ID_ENCARGADO;
                    element.NOMBRES_ENCARGADO = item.NOMBRES_ENCARGADO + " "+ item.APELLIDOS_ENCARGADO;

                    lista.Add(element);
                }

                return lista;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getDataListComboEncargados", ex.ToString());
                return null;
            }
        }

        public IList<_MANTENIMIENTOS> getDataList(DateTime dateini, DateTime datend)
        {
            try
            {
                DBContext db = new DBContext();

                IList<MANTENIMIENTOS> felist = new List<MANTENIMIENTOS>();
                IList<_MANTENIMIENTOS> _felist = new List<_MANTENIMIENTOS>();

                felist = db.MANTENIMIENTOS.Where(x => x.FECHA_HORA >= dateini && x.FECHA_HORA <= datend).OrderByDescending(x => x.ID_MANTENIMIENTO).ToList();

                foreach (var item in felist)
                {
                    _MANTENIMIENTOS en = new _MANTENIMIENTOS();
                    en.ID = item.ID_MANTENIMIENTO.ToString();
                    en.FECHA_HORA = item.FECHA_HORA.ToString("dd/MM/yyyy HH:mm");

                    var _vehiculo_ = db.VEHICULOS.Where(x => x.ID_VEHICULO == item.ID_VEHICULO).Select(x => new { x.MARCA, x.LINEA, x.PLACA }).FirstOrDefault();
                    en.VEHICULO = _vehiculo_.MARCA + ", " + _vehiculo_.LINEA + " (" + _vehiculo_.PLACA + ")";

                    var _encargado_ = db.ENCARGADOS.Where(x => x.ID_ENCARGADO == item.ID_ENCARGADO).Select(x => new { x.NOMBRES_ENCARGADO, x.APELLIDOS_ENCARGADO }).FirstOrDefault();
                    en.ENCARGADO = _encargado_.NOMBRES_ENCARGADO + " " + _encargado_.APELLIDOS_ENCARGADO;

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getDataList", ex.ToString());
                return null;
            }
        }

        public string getEncargadoNombre(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                var result = db.ENCARGADOS.Where(x => x.ID_ENCARGADO == _id).Select(x => new { x.NOMBRES_ENCARGADO, x.APELLIDOS_ENCARGADO}).FirstOrDefault();
                return result.NOMBRES_ENCARGADO + " " + result.APELLIDOS_ENCARGADO;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getEncargadosNombre", ex.ToString());
                return null;
            }
        }
        public string getVehiculoNombre(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                var result = db.VEHICULOS.Where(x => x.ID_VEHICULO == _id).Select(x => new { x.ID_VEHICULO, x.MARCA, x.LINEA, x.PLACA }).OrderBy(x => x.MARCA).FirstOrDefault();
                return result.MARCA + ", " + result.LINEA + " (" + result.PLACA + ")";
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getVehiculoNombre", ex.ToString());
                return null;
            }
        }

        public decimal getNextID()
        {
            try
            {
                DBContext db = new DBContext();
                int maximo = db.MANTENIMIENTOS.Select(x => (int?)x.ID_MANTENIMIENTO).Max() ?? 0;
                return maximo + 1;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getData", ex.ToString());
                return 0;
            }
        }

        public MANTENIMIENTOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.MANTENIMIENTOS.Where(x => x.ID_MANTENIMIENTO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getData", ex.ToString());
                return null;
            }
        }
        public bool AddData(MANTENIMIENTOS data)
        {
            try
            {
                DBContext db = new DBContext();

                MANTENIMIENTOS model = new MANTENIMIENTOS();
                int? maximo = db.MANTENIMIENTOS.Select(x => (int?)x.ID_MANTENIMIENTO).Max() ?? 0;

                model.ID_MANTENIMIENTO = (int)maximo + 1;
                model.FECHA_HORA = data.FECHA_HORA;
                model.ID_VEHICULO = data.ID_VEHICULO;
                model.ID_ENCARGADO = data.ID_ENCARGADO;
                model.KM_ACTUAL = data.KM_ACTUAL;
                model.COMENTARIOS = data.COMENTARIOS;
                model.PSERVICIO_KM = data.PSERVICIO_KM;
                model.PSERVICIO_TIEMPO = data.PSERVICIO_TIEMPO;
                model.DESC_FALLA = data.DESC_FALLA;
                model.DESC_SOLUCION = data.DESC_SOLUCION;

                db.MANTENIMIENTOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(MANTENIMIENTOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.MANTENIMIENTOS.SingleOrDefault(b => b.ID_MANTENIMIENTO == data.ID_MANTENIMIENTO);
                if (dat != null)
                {
                    dat.ID_VEHICULO = data.ID_VEHICULO;
                    dat.ID_ENCARGADO = data.ID_ENCARGADO;
                    dat.KM_ACTUAL = data.KM_ACTUAL;
                    dat.COMENTARIOS = data.COMENTARIOS;
                    dat.PSERVICIO_KM = data.PSERVICIO_KM;
                    dat.PSERVICIO_TIEMPO = data.PSERVICIO_TIEMPO;
                    dat.DESC_FALLA = data.DESC_FALLA;
                    dat.DESC_SOLUCION = data.DESC_SOLUCION;

                    db.MANTENIMIENTOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.MANTENIMIENTOS.FirstOrDefault(x => x.ID_MANTENIMIENTO == _id);
                    dbContext.MANTENIMIENTOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-DeleteData", ex.ToString());
                return false;
            }

        }



        public IList<_MANTENIMIENTOS_REPORTE> getDataListREPORTE(DateTime dateini, DateTime datend)
        {
            try
            {
                DBContext db = new DBContext();

                IList<_MANTENIMIENTOS_REPORTE> _felist = new List<_MANTENIMIENTOS_REPORTE>();

                var result = (from m in db.MANTENIMIENTOS
                            join e in db.ENCARGADOS on m.ID_ENCARGADO equals e.ID_ENCARGADO
                            join v in db.VEHICULOS on m.ID_VEHICULO equals v.ID_VEHICULO
                            join tv in db.TIPOS_VEHICULOS on v.ID_TIPO_VEHICULO equals tv.ID_TIPO_VEHICULO
                            where m.FECHA_HORA >= dateini && m.FECHA_HORA <= datend
                            orderby m.ID_MANTENIMIENTO descending
                            select new
                            {
                                FECHA_HORA = m.FECHA_HORA,
                                NOMBRES_ENCARGADO = e.NOMBRES_ENCARGADO + " " + e.APELLIDOS_ENCARGADO,
                                TIPO_VEHICULO = tv.NOMBRE_TIPO,
                                MARCA = v.MARCA,
                                LINEA = v.LINEA,
                                PLACA = v.LINEA,
                                KM_ACTUAL = m.KM_ACTUAL,
                                PSERVICIO_KM = m.PSERVICIO_KM,
                                PSERVICIO_TIEMPO = m.PSERVICIO_TIEMPO,
                            }).ToList();

                foreach (var item in result)
                {
                    _MANTENIMIENTOS_REPORTE dat = new _MANTENIMIENTOS_REPORTE();
                    dat.FECHA_HORA = item.FECHA_HORA.ToString("dd/MM/yyyy HH:mm");
                    dat.NOMBRES_ENCARGADO = item.NOMBRES_ENCARGADO;
                    dat.TIPO_VEHICULO = item.TIPO_VEHICULO;
                    dat.MARCA = item.MARCA;
                    dat.LINEA = item.LINEA;
                    dat.PLACA = item.PLACA;
                    dat.KM_ACTUAL = item.KM_ACTUAL.ToString();
                    dat.PSERVICIO_KM = item.PSERVICIO_KM.ToString();
                    dat.PSERVICIO_TIEMPO = item.PSERVICIO_TIEMPO.ToString("dd/MM/yyyy");

                    _felist.Add(dat);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlMantenimientosController-getDataListREPORTE", ex.ToString());
                return null;
            }
        }
    }
}
