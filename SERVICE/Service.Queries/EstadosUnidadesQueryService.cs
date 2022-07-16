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
using System.Threading.Tasks;

namespace Service.Queries
{
    public interface IEstadosUnidadesQueryService
    {
        Task<DataCollection<EstadosUnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> EstadosUnidades = null);
        Task<EstadosUnidadesDTO> GetAsync(long id);
        Task<UpdateEstadoUnidadDTO> PutAsync(UpdateEstadoUnidadDTO EstadosUnidades, long it);
        Task<EstadosUnidadesDTO> DeleteAsync(long id);
    }

    public class EstadosUnidadesQueryService : IEstadosUnidadesQueryService
    {
        private readonly Context _context;

        public EstadosUnidadesQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<EstadosUnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> estadosunidades = null)
        {
            try
            {
                var collection = await _context.EstadosUnidades
                .Where(x => estadosunidades == null || estadosunidades.Contains(x.IdEstadoUnidad))
                .OrderByDescending(x => x.IdEstadoUnidad)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<EstadosUnidadesDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Estados");
            }

        }

        public async Task<EstadosUnidadesDTO> GetAsync(long id)
        {
            try
            {
                if (await _context.EstadosUnidades.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener el Estado de la Unidad, el Estado con id" + " " + id + " " + "no existe");
                }
                return (await _context.EstadosUnidades.FindAsync(id)).MapTo<EstadosUnidadesDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Estado");
            }

        }
        public async Task<UpdateEstadoUnidadDTO> PutAsync(UpdateEstadoUnidadDTO EstadoUnidad, long id)
        {
            if (await _context.EstadosUnidades.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar el Estado de la Unidad, el Estado con id" + " " + id + " " + "no existe");
            }
            var estadounidad = await _context.EstadosUnidades.SingleAsync(x => x.IdEstadoUnidad == id);
            estadounidad.Estado = EstadoUnidad.Estado;
            estadounidad.Obs = EstadoUnidad.Obs;

            await _context.SaveChangesAsync();

            return EstadoUnidad.MapTo<UpdateEstadoUnidadDTO>();
        }
        public async Task<EstadosUnidadesDTO> DeleteAsync(long id)
        {
            try
            {
                var estadounidad = await _context.EstadosUnidades.SingleAsync(x => x.IdEstadoUnidad == id);
                if (estadounidad == null)
                {
                    throw new EmptyCollectionException("Error al eliminar el Estado de la Unidad, el Estado con id" + " " + id + " " + "no existe");
                }
                _context.EstadosUnidades.Remove(estadounidad);
                await _context.SaveChangesAsync();
                return estadounidad.MapTo<EstadosUnidadesDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Estado");
            }

        }

    }




}