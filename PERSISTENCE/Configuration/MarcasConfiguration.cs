

using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class MarcasConfiguration
    {
        public MarcasConfiguration(EntityTypeBuilder<Marcas> entity)
        {
            entity.HasKey(e => e.IdMarca);

            entity.HasIndex(e => e.Marca)
                .HasName("det_marcaunica")
                .IsUnique();

            entity.Property(e => e.IdMarca).HasColumnName("idMarca");

            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
