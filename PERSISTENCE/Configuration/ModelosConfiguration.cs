using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PERSISTENCE.Configuration
{
    public class ModelosConfiguration
    {
        public ModelosConfiguration(EntityTypeBuilder<Modelos> entity)
        {
            entity.HasKey(e => e.IdModelo);

            entity.HasIndex(e => new { e.IdModelo, e.idMarca })
                .HasName("IX_Modelos_IdModeloIdMarca");

            entity.HasIndex(e => new { e.Modelo, e.idMarca })
                .HasName("det_modelounico")
                .IsUnique();

            entity.Property(e => e.IdModelo).HasColumnName("idModelo");

            entity.Property(e => e.idMarca).HasColumnName("idMarca");

            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);

            entity.HasOne(d => d.idGrupo)
                .WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK_Modelos_Grupos");


            entity.HasOne(d => d.IdMarca)
                .WithMany(p => p.Modelos)
                .HasForeignKey(d => d.idMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modelos_Marcas");
        }
    }
}
