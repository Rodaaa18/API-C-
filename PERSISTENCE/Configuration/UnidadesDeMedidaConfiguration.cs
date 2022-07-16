using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class UnidadesDeMedidaConfiguration
    {
        public UnidadesDeMedidaConfiguration(EntityTypeBuilder<UnidadesMedida> entity)
        {
            entity.HasKey(e => e.IdUnidadDeMedida)
                    .HasName("PK_UnidadesMedida");

            entity.HasIndex(e => e.UnidadDeMedida)
                .HasName("det_unidaddemedidaunica")
                .IsUnique();

            entity.HasIndex(e => new { e.IdUnidadDeMedida, e.UnidadDeMedida })
                .HasName("IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida");

            entity.Property(e => e.UnidadDeMedida)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
