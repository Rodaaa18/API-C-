using Common.Collection;
using DATA.DTOS;
using DATA.DTOS.Updates;
using DATA.Extensions;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries
{
    public interface ITitulosQueryService
    {
        Task<DataCollection<TitulosDTO>> GetAllAsync(int page, int take, IEnumerable<int> titulos = null);
        Task<TitulosDTO> GetAsync(int id);
        Task<UpdateTitulosDTO> PutAsync(UpdateTitulosDTO titulo, int id);
        Task<TitulosDTO> DeleteAsync(int id);
    }
    public class TitulosQueryService : ITitulosQueryService
    {
        private readonly Context _context;
        public TitulosQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<TitulosDTO>> GetAllAsync(int page, int take, IEnumerable<int> titulos = null)
        {
            try
            {
                var collection = await _context.Titulos
                .Where(x => titulos == null || titulos.Contains(x.IdTitulo))
                .OrderByDescending(x => x.IdTitulo)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<TitulosDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TitulosDTO> GetAsync(int id)
        {
            try
            {
                var unidad = await _context.Titulos.FindAsync(id);

                if (await _context.Titulos.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener el Titulo, el Titulo con id" + " " + id + " " + "no existe");
                }
                return unidad.MapTo<TitulosDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateTitulosDTO> PutAsync(UpdateTitulosDTO titulo, int id)
        {
            if (await _context.Titulos.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al obtener el Titulo, el Titulo con id" + " " + id + " " + "no existe");
            }
            if (titulo.Descripcion == "" || titulo.Descripcion is null)
            {
                throw new EmptyCollectionException("Debe colocar la Descripción");
            }
            var updateTitulo = await _context.Titulos.FindAsync(id);

            updateTitulo.Descripcion = titulo.Descripcion;
            updateTitulo.Obs = titulo.Obs ?? updateTitulo.Obs;
            

            await _context.SaveChangesAsync();

            return titulo.MapTo<UpdateTitulosDTO>();
        }
        public async Task<TitulosDTO> DeleteAsync(int id)
        {
            
            var titulo = await _context.Titulos.FindAsync(id);
            if (titulo == null)
            {
                throw new EmptyCollectionException("Error al eliminar el Titulo, el Titulo con id" + " " + id + " " + "no existe");
            }
            var tituloChofer = await _context.Titulos.Include(x => x.Choferes).Where(c => c.IdTitulo == id).SingleOrDefaultAsync();
            if(tituloChofer.Choferes.Count > 0)
            {
                throw new EmptyCollectionException("No se puede eliminar el Titulo, tiene Choferes asociados");
            }

            _context.Titulos.Remove(titulo);
            await _context.SaveChangesAsync();
            
            return titulo.MapTo<TitulosDTO>();
            
            
        }
    }
}
