using DATA.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PERSISTENCE.Configuration
{
    public class EquipamientosConfiguration
    {
        public EquipamientosConfiguration(EntityTypeBuilder<Equipamientos> entity)
        {
            entity.HasKey(k => k.IdEquipamiento);
            entity.Property(p => p.idNombreEquipamiento)
                .IsUnicode(false);
            entity.Property(p => p.idArticulo)
                .IsUnicode(false);
            entity.Property(p=>p.Cantidad)
                .IsUnicode(false);
        }
    }
}
