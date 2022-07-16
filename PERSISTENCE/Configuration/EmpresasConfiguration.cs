using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class EmpresasConfiguration
    {
        public EmpresasConfiguration(EntityTypeBuilder<Empresas> entity)
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.HasIndex(e => e.Descripcion)
                .HasName("det_descripcionEmpresaUnica")
                .IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);
        }
    }
}
