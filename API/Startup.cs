using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PERSISTENCE;
using Service.Queries;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddTransient<IUnidadesQueryService, UnidadesQueryService>();
            services.AddTransient<ISituacionesUnidadesQueryService, SituacionesUnidadesQueryService>();            
            services.AddTransient<ITitulosQueryService, TitulosQueryService>();
            services.AddTransient<ITrazasQueryService, TrazasQueryService>();
            services.AddTransient<IUnidadesDeMedidaQueryService, UnidadesDeMedidaQueryService>();
            services.AddTransient<IVariablesUnidadesQueryService, VariablesUnidadesQueryService>();
            services.AddTransient<IEquipamientoQueryService, EquipamientoQueryService>();    
            services.AddTransient<IAgrupacionesSindicalesQueryService, AgrupacionesSindicalesQueryService>();
            services.AddTransient<ICentrodeCostoQueryService, CentrodeCostoQueryService>();
            services.AddTransient<IConveniosQueryService, ConveniosQueryService>();
            services.AddTransient<IEmpresasQueryService, EmpresasQueryService>();
            services.AddTransient<IEspecialidadesQueryService, EspecialidadesQueryService>();
            services.AddTransient<IEstadosUnidadesQueryService, EstadosUnidadesQueryService>();
            services.AddTransient<IMarcasQueryService, MarcasQueryService>();
            services.AddTransient<IModelosQueryService, ModelosQueryService>();
            services.AddTransient<IProvinciasQueryService, ProvinciasQueryService>();
            services.AddTransient<IFuncionesQueryService, FuncionesQueryService>();
            services.AddTransient<IGruposQueryService, GruposQueryService>();
            services.AddTransient<ILocalidadQueryService, LocalidadesQueryService>();
            services.AddTransient<IChoferesQueryService, ChoferesQueryService>();
            services.AddMediatR(Assembly.Load("Service.EventHandlers"));

            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);


            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });
            
        }
    }
}
