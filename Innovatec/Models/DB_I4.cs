using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Innovatec.Models
{
    public partial class DB_I4 : DbContext
    {
        public DB_I4()
            : base("name=DB_I4_Jehu")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tBasculas> tBasculas { get; set; }
        public virtual DbSet<tBOM> tBOM { get; set; }
        public virtual DbSet<tComponentes> tComponentes { get; set; }
        public virtual DbSet<tLineasComponentesBasculas> tLineasComponentesBasculas { get; set; }
        public virtual DbSet<tLineasProduccion> tLineasProduccion { get; set; }
        public virtual DbSet<tProductos> tProductos { get; set; }
        public virtual DbSet<tUsuarios> tUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tBasculas>()
                .Property(e => e.ID_Bascula)
                .IsUnicode(false);

            modelBuilder.Entity<tBasculas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tBOM>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<tBOM>()
                .Property(e => e.ID_Componente)
                .IsUnicode(false);

            modelBuilder.Entity<tBOM>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 7);

            modelBuilder.Entity<tComponentes>()
                .Property(e => e.ID_Componente)
                .IsUnicode(false);

            modelBuilder.Entity<tComponentes>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tComponentes>()
                .Property(e => e.PesoUnitarioGramos)
                .HasPrecision(18, 7);

            modelBuilder.Entity<tComponentes>()
                .Property(e => e.Minimo)
                .HasPrecision(18, 7);

            modelBuilder.Entity<tComponentes>()
                .Property(e => e.Maximo)
                .HasPrecision(18, 7);

            modelBuilder.Entity<tLineasComponentesBasculas>()
                .Property(e => e.ID_Linea)
                .IsUnicode(false);

            modelBuilder.Entity<tLineasComponentesBasculas>()
                .Property(e => e.ID_Componente)
                .IsUnicode(false);

            modelBuilder.Entity<tLineasComponentesBasculas>()
                .Property(e => e.ID_Bascula)
                .IsUnicode(false);

            modelBuilder.Entity<tLineasProduccion>()
                .Property(e => e.ID_Linea)
                .IsUnicode(false);

            modelBuilder.Entity<tLineasProduccion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tProductos>()
                .Property(e => e.ID_Producto)
                .IsUnicode(false);

            modelBuilder.Entity<tProductos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tUsuarios>()
                .Property(e => e.ID_Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tUsuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tUsuarios>()
                .Property(e => e.EMail)
                .IsUnicode(false);
        }
    }
}
