using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class UnidadesConfiguration
    {
        public UnidadesConfiguration(EntityTypeBuilder<Unidades> entity)
        {
            entity.HasKey(e => e.IdUnidad);

            entity.HasIndex(e => new { e.IdUnidad, e.NroUnidad })
                .HasName("Unidades_IdUnidadNroUnidad");

            entity.HasIndex(e => new { e.IdUnidad, e.UnidadMedTrabajo })
                .HasName("Unidades_IdUnidadUnidadMedTrabajo");

            entity.HasIndex(e => new { e.IdUnidad, e.NroUnidad, e.UnidadMedTrabajo })
                .HasName("Unidades_IdUnidadNroUnidadUnidadMedTrabajo");

            entity.Property(e => e.IdUnidad).HasColumnName("idUnidad");

            entity.Property(e => e.AcreedorPrendario).IsUnicode(false);

            entity.Property(e => e.Chasis)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CodigoLlave).IsUnicode(false);

            entity.Property(e => e.CodigoRadio).IsUnicode(false);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Dominio)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Foto).IsUnicode(false);
                    

            entity.Property(e => e.idNombreEquipamiento).HasColumnName("idNombreEquipamiento");

            entity.Property(e => e.MarcaTacografo).IsUnicode(false);

            entity.Property(e => e.Motor)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NroUnidad)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);

            entity.Property(e => e.Potencia)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Radicacion).IsUnicode(false);

            entity.Property(e => e.Tacografo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Titular).IsUnicode(false);

            entity.Property(e => e.UnidadMedTrabajo).HasComment("1) Km - 2) Hs");

            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoUnidad)
                .WithMany(p => p.Unidades)
                .HasForeignKey(d => d.idEstadoUnidad)
                .HasConstraintName("FK_Unidades_EstadosUnidads");

            entity.HasOne(d => d.IdModelo)
                .WithMany(p=>p.Unidades)
                .HasForeignKey(d => d.idModelo)
                .HasConstraintName("FK_Unidades_Modelos");

            entity.Property(d => d.idNombreEquipamiento);                

            entity.HasOne(d => d.IdSituacionUnidad)
                .WithMany(p=>p.Unidades)
                .HasForeignKey(d => d.idSituacionUnidad)
                .HasConstraintName("FK_Unidades_SituacionesUnidades");
        }
    }
}
