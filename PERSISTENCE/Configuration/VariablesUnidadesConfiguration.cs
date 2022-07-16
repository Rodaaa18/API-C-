using DATA.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class VariablesUnidadesConfiguration
    {
        public VariablesUnidadesConfiguration(EntityTypeBuilder<VariablesUnidades> entity)
        {
            entity.HasKey(e => e.IdVariableUnidad);

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
