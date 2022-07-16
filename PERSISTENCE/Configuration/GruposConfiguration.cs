using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class GruposConfiguration
    {
        public GruposConfiguration(EntityTypeBuilder<Grupos> entity)
        {
            entity.HasKey(e => e.IdGrupo);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripciongrupounico")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);

            entity.Property(e => e.RutaImagen).IsUnicode(false);
        }
    }
}
