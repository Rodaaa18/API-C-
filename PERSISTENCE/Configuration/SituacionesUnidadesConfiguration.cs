using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class SituacionesUnidadesConfiguration
    {
        public SituacionesUnidadesConfiguration(EntityTypeBuilder<SituacionesUnidades> entity)
        {
            entity.HasKey(e => e.IdSituacionUnidad);

            entity.Property(e => e.IdSituacionUnidad).HasColumnName("idSituacionUnidad");

            entity.Property(e => e.Obs).IsUnicode(false);

            entity.Property(e => e.Situacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
