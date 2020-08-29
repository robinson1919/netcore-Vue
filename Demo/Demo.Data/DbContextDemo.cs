using Demo.Data.Mapping;
using Demo.Entities.PermisoE;
using Demo.Entities.PermisoTipo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    public class DbContextDemo : DbContext
    {
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPermiso> TipoPermisos { get; set; }

        public DbContextDemo(DbContextOptions<DbContextDemo> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new TipoPermisoMap());
        }
    }
}
