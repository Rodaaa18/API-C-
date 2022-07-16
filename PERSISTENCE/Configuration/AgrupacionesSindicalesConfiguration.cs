using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class AgrupacionesSindicalesConfiguration
    {
        public AgrupacionesSindicalesConfiguration(EntityTypeBuilder<AgrupacionesSindicales> entity)
        {
            entity.HasKey(e => e.IdAgrupacionSindical);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionAgrupacionSindicalUnica")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
