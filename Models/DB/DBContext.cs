using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TALLERM.Models.DB
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<BITACORAS> BITACORAS { get; set; }
        public virtual DbSet<ENCARGADOS> ENCARGADOS { get; set; }
        public virtual DbSet<MANTENIMIENTOS> MANTENIMIENTOS { get; set; }
        public virtual DbSet<PROVEEDORES> PROVEEDORES { get; set; }
        public virtual DbSet<REPUESTOS> REPUESTOS { get; set; }
        public virtual DbSet<REPUESTOS_X_MANTENIMIENTOS> REPUESTOS_X_MANTENIMIENTOS { get; set; }
        public virtual DbSet<TIPOS_VEHICULOS> TIPOS_VEHICULOS { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
        public virtual DbSet<VEHICULOS> VEHICULOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BITACORAS>()
                .Property(e => e.ID_BITACORA)
                .HasPrecision(5, 0);

            modelBuilder.Entity<BITACORAS>()
                .Property(e => e.NOMBRE_EVENTO)
                .IsUnicode(false);

            modelBuilder.Entity<BITACORAS>()
                .Property(e => e.DESC_EVENTO)
                .IsUnicode(false);

            modelBuilder.Entity<ENCARGADOS>()
                .Property(e => e.ID_ENCARGADO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<ENCARGADOS>()
                .Property(e => e.NOMBRES_ENCARGADO)
                .IsUnicode(false);

            modelBuilder.Entity<ENCARGADOS>()
                .Property(e => e.APELLIDOS_ENCARGADO)
                .IsUnicode(false);

            modelBuilder.Entity<ENCARGADOS>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);


            modelBuilder.Entity<ENCARGADOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.ID_MANTENIMIENTO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.ID_VEHICULO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.ID_ENCARGADO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.COMENTARIOS)
                .IsUnicode(false);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.DESC_FALLA)
                .IsUnicode(false);

            modelBuilder.Entity<MANTENIMIENTOS>()
                .Property(e => e.DESC_SOLUCION)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.ID_PROVEEDOR)
                .HasPrecision(5, 0);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.NOMBRE_PROVEEDOR)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.CORREO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORES>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.ID_REPUESTO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.ID_PROVEEDOR)
                .HasPrecision(5, 0);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.NOMBRE_REPUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.DESC_REPUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.PRECIO_REPUESTO)
                .HasPrecision(10, 2);

            modelBuilder.Entity<REPUESTOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<REPUESTOS_X_MANTENIMIENTOS>()
                .Property(e => e.ID_REP_X_MANTE)
                .HasPrecision(5, 0);

            modelBuilder.Entity<REPUESTOS_X_MANTENIMIENTOS>()
                .Property(e => e.ID_MANTENIMIENTO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<REPUESTOS_X_MANTENIMIENTOS>()
                .Property(e => e.ID_REPUESTO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<TIPOS_VEHICULOS>()
                .Property(e => e.ID_TIPO_VEHICULO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<TIPOS_VEHICULOS>()
                .Property(e => e.NOMBRE_TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOS_VEHICULOS>()
                .Property(e => e.DESC_TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOS_VEHICULOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);


            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.ID_USUARIO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.NOMBRE_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.TIPO_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.CONTRASENIA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);


            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.ID_VEHICULO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.ID_TIPO_VEHICULO)
                .HasPrecision(5, 0);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.PLACA)
                .IsUnicode(false);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.LINEA)
                .IsUnicode(false);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.MODELO)
                .HasPrecision(4, 0);

            modelBuilder.Entity<VEHICULOS>()
                .Property(e => e.ESTADO)
                .HasPrecision(1, 0);

        }
    }
}
