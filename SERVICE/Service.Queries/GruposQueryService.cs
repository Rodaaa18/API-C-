using Common.Collection;
using DATA.DTOS;
using DATA.DTOS.Updates;
using DATA.Extensions;
using PERSISTENCE;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Queries
{
    public interface IGruposQueryService
    {
        Task<DataCollection<GruposDTO>> GetAllAsync(int page, int take, IEnumerable<long> grupos = null);
        Task<GruposDTO> GetAsync(long id);
        Task<UpdateGruposDTO> PutAsync(UpdateGruposDTO grupo, long id);
        Task<GruposDTO> DeleteAsync(long id);
    }
    public class GruposQueryService : IGruposQueryService
    {
        private readonly Context _context;
        public GruposQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<GruposDTO>> GetAllAsync(int page, int take, IEnumerable<long> grupos = null)
        {
            try
            {
                var collection = await _context.Grupos
                .Where(x => grupos == null || grupos.Contains(x.IdGrupo))
                .OrderByDescending(x => x.IdGrupo)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<GruposDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<GruposDTO> GetAsync(long id)
        {
            try
            {
                var unidad = await _context.Grupos.FindAsync(id);

                if (await _context.Grupos.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener el Grupo, el Grupo con id" + " " + id + " " + "no existe");
                }
                return unidad.MapTo<GruposDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateGruposDTO> PutAsync(UpdateGruposDTO grupo, long id)
        {
            if (await _context.Grupos.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar el Grupo, el Grupo con id" + " " + id + " " + "no existe");
            }
            if (grupo.Descripcion == "" || grupo.Descripcion is null)
            {
                throw new EmptyCollectionException("Debe colocar la Descripción");
            }
            var updateGrupos = await _context.Grupos.FindAsync(id);

            updateGrupos.Descripcion = grupo.Descripcion;
            updateGrupos.Obs = grupo.Obs;
            updateGrupos.RutaImagen = grupo.RutaImagen;


            await _context.SaveChangesAsync();

            return grupo.MapTo<UpdateGruposDTO>();
        }
        public async Task<GruposDTO> DeleteAsync(long id)
        {
            var grupos = await _context.Grupos.FindAsync(id);
            if (grupos == null)
            {
                throw new EmptyCollectionException("Error al eliminar el Grupo, el Grupo con id" + " " + id + " " + "no existe");
            }

            _context.Grupos.Remove(grupos);

            await _context.SaveChangesAsync();

            return grupos.MapTo<GruposDTO>();
        }
    }
}
