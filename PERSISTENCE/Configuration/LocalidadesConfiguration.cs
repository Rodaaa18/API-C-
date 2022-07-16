using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class LocalidadesConfiguration
    {
        public LocalidadesConfiguration(EntityTypeBuilder<Localidades> entity)
        {
            entity.HasKey(e => e.IdLocalidad);

            entity.HasIndex(e => e.Localidad)
                .HasName("det_localidadaunica")
                .IsUnique();

            entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

            entity.Property(e => e.CodigoPostal).IsUnicode(false);

            entity.Property(e => e.idProvincia).HasColumnName("idProvincia");

            entity.Property(e => e.Localidad)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvincia)
                .WithMany(p=>p.Localidades)
                .HasForeignKey(d => d.idProvincia)
                .HasConstraintName("FK_Localidades_Provincias");
        }
    }
}
