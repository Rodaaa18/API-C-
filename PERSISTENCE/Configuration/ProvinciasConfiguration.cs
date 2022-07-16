using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class ProvinciasConfiguration
    {
        public ProvinciasConfiguration(EntityTypeBuilder<Provincias> entity)
        {
            entity.HasKey(e => e.IdProvincia);

            entity.HasIndex(e => e.Provincia)
                .HasName("det_provinciaunica")
                .IsUnique();

            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

            entity.Property(e => e.Provincia)
                .HasMaxLength(200)
                .IsUnicode(false);

        }
    }
}
