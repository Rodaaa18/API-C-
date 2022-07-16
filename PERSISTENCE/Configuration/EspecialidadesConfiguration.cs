

using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class EspecialidadesConfiguration
    {
        public EspecialidadesConfiguration(EntityTypeBuilder<Especialidades> entity)
        {
            entity.HasKey(e => e.IdEspecialidad);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionEspecialidadUnica")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
