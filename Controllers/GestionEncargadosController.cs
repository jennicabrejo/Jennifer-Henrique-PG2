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
    public class GestionEncargadosController
    {
        public IList<_ENCARGADOS> getDataList()
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<ENCARGADOS> felist = new List<ENCARGADOS>();
                IList<_ENCARGADOS> _felist = new List<_ENCARGADOS>();

                felist = db.ENCARGADOS.ToList();

                foreach (var item in felist)
                {
                    _ENCARGADOS en = new _ENCARGADOS();
                    en.ID = item.ID_ENCARGADO.ToString();
                    en.NOMBRES_ENCARGADO = item.NOMBRES_ENCARGADO;
                    en.APELLIDOS_ENCARGADO = item.APELLIDOS_ENCARGADO;
                    en.CORREO = item.CORREO;
                    en.TELEFONO = item.TELEFONO;
                    en.FECHA_NACIMIENTO = item.FECHA_NACIMIENTO.ToString("dd/MM/yyyy");
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-getDataList", ex.ToString());
                return null;
            }
        }

        public IList<_ENCARGADOS> getDataListREPORTE(DateTime dateini, DateTime datend)
        {
            try
            {
                DBContext db = new DBContext();

                IList<ENCARGADOS> felist = new List<ENCARGADOS>();
                IList<_ENCARGADOS> _felist = new List<_ENCARGADOS>();

                felist = db.ENCARGADOS.ToList();

                foreach (var item in felist)
                {
                    _ENCARGADOS en = new _ENCARGADOS();
                    en.ID = item.ID_ENCARGADO.ToString();
                    en.NOMBRES_ENCARGADO = item.NOMBRES_ENCARGADO;
                    en.APELLIDOS_ENCARGADO = item.APELLIDOS_ENCARGADO;
                    en.CORREO = item.CORREO;
                    en.TELEFONO = item.TELEFONO;
                    en.FECHA_NACIMIENTO = item.FECHA_NACIMIENTO.ToString("dd/MM/yyyy");
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-getDataList", ex.ToString());
                return null;
            }
        }

        public ENCARGADOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.ENCARGADOS.Where(x => x.ID_ENCARGADO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-getData", ex.ToString());
                return null;
            }
        }
        public bool AddData(ENCARGADOS data)
        {
            try
            {
                DBContext db = new DBContext();

                ENCARGADOS model = new ENCARGADOS();
                int? maximo = db.ENCARGADOS.Select(x => (int?)x.ID_ENCARGADO).Max() ?? 0;

                model.ID_ENCARGADO = (int)maximo + 1;
                model.NOMBRES_ENCARGADO = data.NOMBRES_ENCARGADO;
                model.APELLIDOS_ENCARGADO = data.APELLIDOS_ENCARGADO;
                model.FECHA_NACIMIENTO = data.FECHA_NACIMIENTO;
                model.TELEFONO = data.TELEFONO;
                model.CORREO = data.CORREO;
                model.ESTADO = data.ESTADO;

                db.ENCARGADOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(ENCARGADOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.ENCARGADOS.SingleOrDefault(b => b.ID_ENCARGADO == data.ID_ENCARGADO);
                if (dat != null)
                {
                    dat.NOMBRES_ENCARGADO = data.NOMBRES_ENCARGADO;
                    dat.APELLIDOS_ENCARGADO = data.APELLIDOS_ENCARGADO;
                    dat.FECHA_NACIMIENTO = data.FECHA_NACIMIENTO;
                    dat.TELEFONO = data.TELEFONO;
                    dat.CORREO = data.CORREO;
                    dat.ESTADO = data.ESTADO;

                    db.ENCARGADOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.ENCARGADOS.FirstOrDefault(x => x.ID_ENCARGADO == _id);
                    dbContext.ENCARGADOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionEncargadosController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
