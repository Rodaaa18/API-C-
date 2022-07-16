

using DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSISTENCE.Configuration
{
    public class ChoferesConfiguration
    {
        public ChoferesConfiguration(EntityTypeBuilder<Choferes> entity)
        {
            entity.HasKey(e => e.IdChofer);

            entity.Property(e => e.IdChofer).HasColumnName("idChofer");

            entity.Property(e => e.AgrupacionSindical).IsUnicode(false);

            entity.Property(e => e.ApellidoyNombres)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CarnetVence).HasColumnType("datetime");

            entity.Property(e => e.Convenio).IsUnicode(false);

            entity.Property(e => e.Empresa).IsUnicode(false);

            entity.Property(e => e.Especialidad).HasMaxLength(50);

            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            entity.Property(e => e.Foto).IsUnicode(false);

            entity.Property(e => e.Funcion).IsUnicode(false);

            entity.Property(e => e.Legajo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.NroDocumento).IsUnicode(false);

            entity.Property(e => e.Obs).IsUnicode(false);

            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.idAgrupacionSindical)
                .WithMany(p=>p.Choferes)
                .HasForeignKey(d => d.IdAgrupacionSindical)
                .HasConstraintName("FK_Choferes_AgrupacionesSindicales");

            entity.HasOne(d => d.idConvenio)
                .WithMany(p => p.Choferes)
                .HasForeignKey(d => d.IdConvenio)
                .HasConstraintName("FK_Choferes_Convenios");

            entity.HasOne(d => d.idEmpresa)
                .WithMany(p => p.Choferes)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Choferes_Empresas");

            entity.HasOne(d => d.idEspecialidad)
                .WithMany(p => p.Choferes)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK_Choferes_Especialidades");

            entity.HasOne(d => d.idFuncion)
                .WithMany(p => p.Choferes)
                .HasForeignKey(d => d.IdFuncion)
                .HasConstraintName("FK_Choferes_Funciones");

            entity.HasOne(d => d.idTitulo)
                .WithMany(p => p.Choferes)
                .HasForeignKey(d => d.IdTitulo)
                .HasConstraintName("FK_Choferes_Titulos")
                .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
