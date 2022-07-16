using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class ConveniosConfiguration
    {
        public ConveniosConfiguration(EntityTypeBuilder<Convenios> entity)
        {
            entity.HasKey(e => e.IdConvenio);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionConvenioUnico")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
