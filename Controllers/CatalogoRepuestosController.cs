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
    public class CatalogoRepuestosController
    {
        public IList<_REPUESTOS> getDataList()
        {
            try
            {
                DBContext db = new DBContext();
            
                IList<REPUESTOS> felist = new List<REPUESTOS>();
                IList<_REPUESTOS> _felist = new List<_REPUESTOS>();

                felist = db.REPUESTOS.ToList();

                foreach (var item in felist)
                {
                    _REPUESTOS en = new _REPUESTOS();
                    en.ID = item.ID_REPUESTO.ToString();
                    en.NOMBRE_PROVEEDOR = db.PROVEEDORES.Where(x => x.ID_PROVEEDOR == item.ID_PROVEEDOR).Select(x => x.NOMBRE_PROVEEDOR).FirstOrDefault();
                    en.NOMBRE = item.NOMBRE_REPUESTO;
                    en.DESCRIPCION = item.DESC_REPUESTO;
                    en.PRECIO = item.PRECIO_REPUESTO.ToString();
                    en.ESTADO = (item.ESTADO == 1) ? "Activo" : "Inactivo";

                    _felist.Add(en);
                }

                return _felist;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-getDataList", ex.ToString());
                return null;
            }
        }
        public REPUESTOS getData(int _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.REPUESTOS.Where(x => x.ID_REPUESTO == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-getData", ex.ToString());
                return null;
            }
        }

        public IList<_PROVEEDORES_COMBO> getDataListCombo()
        {
            try
            {
                DBContext db = new DBContext();
                IList<_PROVEEDORES_COMBO> lista = new List<_PROVEEDORES_COMBO>();
                var result = db.PROVEEDORES.Select(x => new { x.ID_PROVEEDOR, x.NOMBRE_PROVEEDOR }).OrderBy(x => x.NOMBRE_PROVEEDOR).ToList();

                foreach (var item in result)
                {
                    _PROVEEDORES_COMBO element = new _PROVEEDORES_COMBO();
                    element.ID_PROVEEDOR = item.ID_PROVEEDOR;
                    element.NOMBRE_PROVEEDOR = item.NOMBRE_PROVEEDOR;

                    lista.Add(element);
                }

                return lista;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-getDataListCombo", ex.ToString());
                return null;
            }

        }

        public PROVEEDORES getDataCombo(decimal _id)
        {
            try
            {
                DBContext db = new DBContext();
                return db.PROVEEDORES.Where(x => x.ID_PROVEEDOR == _id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-getDataCombo", ex.ToString());
                return null;
            }
        }
        public bool AddData(REPUESTOS data)
        {
            try
            {
                DBContext db = new DBContext();

                REPUESTOS model = new REPUESTOS();
                int? maximo = db.REPUESTOS.Select(x => (int?)x.ID_REPUESTO).Max() ?? 0;

                model.ID_REPUESTO = (int)maximo + 1;
                model.ID_PROVEEDOR = data.ID_PROVEEDOR;
                model.NOMBRE_REPUESTO = data.NOMBRE_REPUESTO;
                model.DESC_REPUESTO = data.DESC_REPUESTO;
                model.STOCK = data.STOCK;
                model.PRECIO_REPUESTO = data.PRECIO_REPUESTO;
                model.ESTADO = data.ESTADO;

                db.REPUESTOS.Add(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-AddData", ex.ToString());
                return false;
            }
        }
        public bool UpdateData(REPUESTOS data)
        {
            try
            {
                DBContext db = new DBContext();

                var dat = db.REPUESTOS.SingleOrDefault(b => b.ID_REPUESTO == data.ID_REPUESTO);
                if (dat != null)
                {
                    dat.ID_PROVEEDOR = data.ID_PROVEEDOR;
                    dat.NOMBRE_REPUESTO = data.NOMBRE_REPUESTO;
                    dat.DESC_REPUESTO = data.DESC_REPUESTO;
                    dat.STOCK = data.STOCK;
                    dat.PRECIO_REPUESTO = data.PRECIO_REPUESTO;
                    dat.ESTADO = data.ESTADO;

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
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-UpdateData", ex.ToString());
                return false;
            }
        }
        public bool DeleteData(int _id)
        {
            try
            {
                using (var dbContext = new DBContext())
                {
                    var singleRec = dbContext.REPUESTOS.FirstOrDefault(x => x.ID_REPUESTO == _id);
                    dbContext.REPUESTOS.Remove(singleRec);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                WarnToBinnacle.SaveToBinnacle("CatalogoRepuestosController-DeleteData", ex.ToString());
                return false;
            }

        }
    }
}
