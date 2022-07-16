using DATA.Models;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE.Configuration;

namespace PERSISTENCE
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        #region DbSets
        public DbSet<EstadosUnidades> EstadosUnidades { get; set; }
        public DbSet<SituacionesUnidades> SituacionesUnidades { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<AgrupacionesSindicales> AgrupacionesSindicales { get; set; }
        public DbSet<CentrodeCosto> CentrodeCosto { get; set; }
        public DbSet<Choferes> Choferes { get; set; }
        public DbSet<Convenios> Convenios { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Localidades> Localidades { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Titulos> Titulos { get; set; }
        public DbSet<Trazas> Trazas { get; set; }
        public DbSet<UnidadesMedida> UnidadesDeMedida { get; set; }
        public DbSet<VariablesUnidades> VariablesUnidades { get; set; }
        public DbSet<Equipamientos> Equipamientos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {       
            base.OnModelCreating(modelBuilder);
            
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new EstadosUnidadesConfiguration(modelBuilder.Entity<EstadosUnidades>());
            new SituacionesUnidadesConfiguration(modelBuilder.Entity<SituacionesUnidades>());
            new UnidadesConfiguration(modelBuilder.Entity<Unidades>());
            new ModelosConfiguration(modelBuilder.Entity<Modelos>());
            new MarcasConfiguration(modelBuilder.Entity<Marcas>());
            new GruposConfiguration(modelBuilder.Entity<Grupos>());
            new AgrupacionesSindicalesConfiguration(modelBuilder.Entity<AgrupacionesSindicales>());
            new CentrodeCostoConfiguration(modelBuilder.Entity<CentrodeCosto>());
            new ChoferesConfiguration(modelBuilder.Entity<Choferes>());
            new ConveniosConfiguration(modelBuilder.Entity<Convenios>());
            new EmpresasConfiguration(modelBuilder.Entity<Empresas>());
            new EspecialidadesConfiguration(modelBuilder.Entity<Especialidades>());
            new FuncionesConfiguration(modelBuilder.Entity<Funciones>());
            new LocalidadesConfiguration(modelBuilder.Entity<Localidades>());
            new ProvinciasConfiguration(modelBuilder.Entity<Provincias>());
            new TitulosConfiguration(modelBuilder.Entity<Titulos>());
            new TrazasConfiguration(modelBuilder.Entity<Trazas>());
            new UnidadesDeMedidaConfiguration(modelBuilder.Entity<UnidadesMedida>());
            new VariablesUnidadesConfiguration(modelBuilder.Entity<VariablesUnidades>());
            new EquipamientosConfiguration(modelBuilder.Entity<Equipamientos>());
        }
    }
}
