using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class FuncionesConfiguration
    {
        public FuncionesConfiguration(EntityTypeBuilder<Funciones> entity)
        {
            entity.HasKey(e => e.IdFuncion);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionFuncionUnica")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
