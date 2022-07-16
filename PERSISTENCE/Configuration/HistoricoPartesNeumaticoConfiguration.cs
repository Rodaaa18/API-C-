using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PERSISTENCE.Configuration
{
    public class HistoricoPartesNeumaticoConfiguration
    {
        public HistoricoPartesNeumaticoConfiguration(EntityTypeBuilder<HistoricoPartesNeumaticos> entity)
        {
            entity.HasKey(e => e.IdHistoricoParteNeumatico);

            entity.Property(e => e.IdNeumatico).IsUnicode(false);
            entity.Property(p => p.Fecha).IsUnicode(false);
            entity.Property(p => p.KmAgregados).IsUnicode(false);
            entity.Property(p => p.IdUnidad).IsUnicode(false);
            entity.Property(p => p.IdParte).IsUnicode(false);
            entity.HasOne(d => d.idTraza)
                .WithMany(p => p.HistoricoPartes)
                .HasForeignKey(d => d.IdTraza)
                .HasConstraintName("FK_Historico_Trazas")
                .OnDelete(DeleteBehavior.ClientCascade);

            
        }
        
    }
}
