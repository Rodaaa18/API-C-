using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class EstadosUnidadesConfiguration
    {
        public EstadosUnidadesConfiguration(EntityTypeBuilder<EstadosUnidades> entity)
        {
            entity.HasKey(e => e.IdEstadoUnidad);

            entity.HasIndex(e => e.Estado)
                .HasName("det_estadounico")
                .IsUnique();

            entity.Property(e => e.IdEstadoUnidad).HasColumnName("idEstadoUnidad");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);

        }
    }
}
