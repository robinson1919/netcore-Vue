using Demo.Entities.PermisoE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Mapping
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("permiso")
                .HasKey(p => p.id_permiso);
            builder.Property(p => p.nombre_empleado)
                .HasMaxLength(50);
            builder.Property(p => p.apellido_empleado)
                .HasMaxLength(50);
        }
    }
}
