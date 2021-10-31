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
    public class GestionProveedoresController
    {
        public IList<_PROVEEDORES> getDataList()
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<PROVEEDORES> felist = new List<PROVEEDORES>();
                IList<_PROVEEDORES> _felist = new List<_PROVEEDORES>();

                felist = db.PROVEEDORES.ToList();

                foreach (var item in felist)
                {
                    _PROVEEDORES en = new _PROVEEDORES();
                    en.ID = item.ID_PROVEEDOR.ToString();
                    en.NOMBRE_PROVEEDOR = item.NOMBRE_PROVEEDOR;
                    en.DIRECCION = item.DIRECCION;
                    en.CORREO = item.CORREO;
                    en.TELEFONO = item.TELEFONO;
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
        public PROVEEDORES getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.PROVEEDORES.Where(x => x.ID_PROVEEDOR == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-getData", ex.ToString());
                return null;
            }
        }
        public bool AddData(PROVEEDORES data)
        {
            try
            {
                DBContext db = new DBContext();

                PROVEEDORES model = new PROVEEDORES();
                int? maximo = db.PROVEEDORES.Select(x => (int?)x.ID_PROVEEDOR).Max() ?? 0;

                model.ID_PROVEEDOR = (int)maximo + 1;
                model.NOMBRE_PROVEEDOR = data.NOMBRE_PROVEEDOR;
                model.DIRECCION = data.DIRECCION;
                model.TELEFONO = data.TELEFONO;
                model.CORREO = data.CORREO;
                model.ESTADO = data.ESTADO;

                db.PROVEEDORES.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("GestionProveedoresController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(PROVEEDORES data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.PROVEEDORES.SingleOrDefault(b => b.ID_PROVEEDOR == data.ID_PROVEEDOR);
                if (dat != null)
                {
                    dat.NOMBRE_PROVEEDOR = data.NOMBRE_PROVEEDOR;
                    dat.DIRECCION = data.DIRECCION;
                    dat.TELEFONO = data.TELEFONO;
                    dat.CORREO = data.CORREO;
                    dat.ESTADO = data.ESTADO;

                    db.PROVEEDORES.Attach(dat);
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
                    var singleRec = dbContext.PROVEEDORES.FirstOrDefault(x => x.ID_PROVEEDOR == _id);
                    dbContext.PROVEEDORES.Remove(singleRec);
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
