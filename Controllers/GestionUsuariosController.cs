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
    public class GestionUsuariosController
    {
        public IList<_USUARIOS> getDataList()
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<USUARIOS> felist = new List<USUARIOS>();
                IList<_USUARIOS> _felist = new List<_USUARIOS>();

                felist = db.USUARIOS.ToList();

                foreach (var item in felist)
                {
                    _USUARIOS en = new _USUARIOS();
                    en.ID = item.ID_USUARIO.ToString();
                    en.NOMBRE_USUARIO = item.NOMBRE_USUARIO;
                    en.TIPO_USUARIO = item.TIPO_USUARIO;
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-getDataList", ex.ToString());
                return null;
            }
        }
        public USUARIOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.USUARIOS.Where(x => x.ID_USUARIO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-getData", ex.ToString());
                return null;
            }
        }
        public bool AddData(USUARIOS data)
        {
            try
            {
                DBContext db = new DBContext();

                USUARIOS model = new USUARIOS();
                int? maximo = db.USUARIOS.Select(x => (int?)x.ID_USUARIO).Max() ?? 0;

                model.ID_USUARIO = (int)maximo + 1;
                model.NOMBRE_USUARIO = data.NOMBRE_USUARIO;
                model.TIPO_USUARIO = data.TIPO_USUARIO;
                model.CONTRASENIA = data.CONTRASENIA;
                model.ESTADO = data.ESTADO;

                db.USUARIOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(USUARIOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.USUARIOS.SingleOrDefault(b => b.ID_USUARIO == data.ID_USUARIO);
                if (dat != null)
                {
                    dat.NOMBRE_USUARIO = data.NOMBRE_USUARIO;
                    dat.TIPO_USUARIO = data.TIPO_USUARIO;
                    dat.CONTRASENIA = data.CONTRASENIA;
                    dat.ESTADO = data.ESTADO;

                    db.USUARIOS.Attach(dat);
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
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.USUARIOS.FirstOrDefault(x => x.ID_USUARIO == _id);
                    dbContext.USUARIOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
