using Demo.Entities.PermisoTipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Mapping
{
    public class TipoPermisoMap : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable("tipo_permiso")
                .HasKey(p => p.id_tipopermiso);
            builder.Property(p => p.nombre)
                .HasMaxLength(50);
            builder.Property(p => p.descripcion)
                .HasMaxLength(255);
        }
    }
}
