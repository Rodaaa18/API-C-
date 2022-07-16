
using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class TitulosConfiguration
    {
        public TitulosConfiguration(EntityTypeBuilder<Titulos> entity)
        {
            entity.HasKey(e => e.IdTitulo);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionTituloUnico")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
