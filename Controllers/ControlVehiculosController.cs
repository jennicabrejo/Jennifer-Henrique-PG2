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
    public class ControlVehiculosController
    {
        public IList<_TIPOS_VEHICULOS_COMBO> getDataListCombo()
        {
            try
            {
                DBContext db = new DBContext();
                IList<_TIPOS_VEHICULOS_COMBO> lista = new List<_TIPOS_VEHICULOS_COMBO>();
                var result = db.TIPOS_VEHICULOS.Select(x => new { x.ID_TIPO_VEHICULO, x.NOMBRE_TIPO }).OrderBy(x => x.NOMBRE_TIPO).ToList();

                foreach (var item in result)
                {
                    _TIPOS_VEHICULOS_COMBO element = new _TIPOS_VEHICULOS_COMBO();
                    element.ID_TIPO_VEHICULO = item.ID_TIPO_VEHICULO;
                    element.NOMBRE_TIPO = item.NOMBRE_TIPO;

                    lista.Add(element);
                }

                return lista;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-getDataListCombo", ex.ToString());
                return null;
            }

        }

        public IList<_VEHICULOS> getDataList()
        {
            try
            {
                DBContext db = new DBContext();

                IList<VEHICULOS> felist = new List<VEHICULOS>();
                IList<_VEHICULOS> _felist = new List<_VEHICULOS>();

                felist = db.VEHICULOS.ToList();

                foreach (var item in felist)
                {
                    _VEHICULOS en = new _VEHICULOS();
                    en.ID = item.ID_VEHICULO.ToString();
                    en.TIPO_VEHICULO = db.TIPOS_VEHICULOS.Where(x => x.ID_TIPO_VEHICULO == item.ID_TIPO_VEHICULO).Select(x => x.NOMBRE_TIPO).FirstOrDefault();
                    en.PLACA = item.PLACA;
                    en.MARCA = item.MARCA;
                    en.LINEA = item.LINEA;
                    en.MODELO = item.MODELO.ToString();
                    en.FECHA_INGRESO = item.FECHA_INGRESO.ToString("dd/MM/yyyy HH:mm");
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-getDataList", ex.ToString());
                return null;
            }
        }
        public VEHICULOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.VEHICULOS.Where(x => x.ID_VEHICULO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-getData", ex.ToString());
                return null;
            }
        }

        public TIPOS_VEHICULOS getDataCombo(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.TIPOS_VEHICULOS.Where(x => x.ID_TIPO_VEHICULO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlTiposVehiculosController-getDataCombo", ex.ToString());
                return null;
            }
        }

        public bool AddData(VEHICULOS data)
        {
            try
            {
                DBContext db = new DBContext();

                VEHICULOS model = new VEHICULOS();
                int? maximo = db.VEHICULOS.Select(x => (int?)x.ID_VEHICULO).Max() ?? 0;

                model.ID_VEHICULO = (int)maximo + 1;
                model.ID_TIPO_VEHICULO = data.ID_TIPO_VEHICULO;
                model.PLACA = data.PLACA;
                model.MARCA = data.MARCA;
                model.LINEA = data.LINEA;
                model.MODELO = data.MODELO;
                model.FECHA_INGRESO = data.FECHA_INGRESO;
                model.ESTADO = data.ESTADO;

                db.VEHICULOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(VEHICULOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.VEHICULOS.SingleOrDefault(b => b.ID_VEHICULO == data.ID_VEHICULO);
                if (dat != null)
                {
                    dat.ID_TIPO_VEHICULO = data.ID_TIPO_VEHICULO;
                    dat.PLACA = data.PLACA;
                    dat.MARCA = data.MARCA;
                    dat.LINEA = data.LINEA;
                    dat.MODELO = data.MODELO;
                    dat.FECHA_INGRESO = data.FECHA_INGRESO;
                    dat.ESTADO = data.ESTADO;

                    db.VEHICULOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.VEHICULOS.FirstOrDefault(x => x.ID_VEHICULO == _id);
                    dbContext.VEHICULOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("ControlVehiculosController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
