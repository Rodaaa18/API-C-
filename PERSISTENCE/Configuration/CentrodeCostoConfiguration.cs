using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class CentrodeCostoConfiguration
    {
        public CentrodeCostoConfiguration(EntityTypeBuilder<CentrodeCosto> entity)
        {
            entity.HasKey(e => e.idCentrodeCosto)
                    .HasName("PK_CentroCosto");

            entity.HasIndex(e => e.CentroDeCosto)
                .HasName("det_centrodecostounico")
                .IsUnique();

            entity.Property(e => e.idCentrodeCosto).HasColumnName("idCentrodeCosto");

            entity.Property(e => e.CentroDeCosto)
                .HasColumnName("CentrodeCosto")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CodigoBas).HasColumnName("codigobas");

            entity.Property(e => e.Obs).IsUnicode(false);
            
            entity.HasOne(d => d.IdEstadoUnidad)
                .WithMany(p=>p.CentrodeCosto)
                .HasForeignKey(d => d.idEstadoUnidad)
                .HasConstraintName("FK_CentrodeCosto_EstadosUnidades");
        }
    }
}
