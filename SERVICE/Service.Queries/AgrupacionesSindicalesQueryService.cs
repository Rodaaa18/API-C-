using Common.Collection;
using DATA.DTOS;
using DATA.DTOS.Updates;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE;
using DATA.DTOS;
using DATA.DTOS.Updates;
using DATA.Extensions;
using Service.Queries.DTOS;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Queries
{
    public interface IAgrupacionesSindicalesQueryService
    {
        Task<DataCollection<AgrupacionesSindicalesDTO>> GetAllAsync(int page, int take, IEnumerable<int> AgrupacionesSindicales = null);
        Task<AgrupacionesSindicalesDTO> GetAsync(int id);
        Task<UpdateAgrupacionSindicalDTO> PutAsync(UpdateAgrupacionSindicalDTO AgrupacionSindical, int it);
        Task<AgrupacionesSindicalesDTO> DeleteAsync(int id);
    }

    public class AgrupacionesSindicalesQueryService : IAgrupacionesSindicalesQueryService
    {
        private readonly Context _context;

        public AgrupacionesSindicalesQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<AgrupacionesSindicalesDTO>> GetAllAsync(int page, int take, IEnumerable<int> agrupaciones = null)
        {
            try
            {
                var collection = await _context.AgrupacionesSindicales
                .Where(x => agrupaciones == null || agrupaciones.Contains(x.IdAgrupacionSindical))
                .OrderByDescending(x => x.IdAgrupacionSindical)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<AgrupacionesSindicalesDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Agrupaciones Sindicales");
            }

        }

        public async Task<AgrupacionesSindicalesDTO> GetAsync(int id)
        {
            try
            {
                if (await _context.AgrupacionesSindicales.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Agrupacion Sindical, la Agrupacion Sindical con id" + " " + id + " " + "no existe");
                }
                return (await _context.AgrupacionesSindicales.SingleAsync(x => x.IdAgrupacionSindical == id)).MapTo<AgrupacionesSindicalesDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateAgrupacionSindicalDTO> PutAsync(UpdateAgrupacionSindicalDTO AgrupacionSindical, int id)
        {
            if (await _context.AgrupacionesSindicales.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Agrupacion Sindical, la Agrupacion Sindical con id" + " " + id + " " + "no existe");
            }
            var agrupacion = await _context.AgrupacionesSindicales.FindAsync(id);
            
            agrupacion.Descripcion = AgrupacionSindical.Descripcion;
            agrupacion.Obs = AgrupacionSindical.Obs;

            await _context.SaveChangesAsync();

            return AgrupacionSindical.MapTo<UpdateAgrupacionSindicalDTO>();
        }
        public async Task<AgrupacionesSindicalesDTO> DeleteAsync(int id)
        {
            try
            {
                var agrupacion = await _context.AgrupacionesSindicales.FindAsync(id);
                if (agrupacion == null)
                {
                    throw new EmptyCollectionException("Error al eliminar la Agrupacion Sindical, la Agrupacion Sindical con id" + " " + id + " " + "no existe");
                }
                _context.AgrupacionesSindicales.Remove(agrupacion);
                
                await _context.SaveChangesAsync();
                
                return agrupacion.MapTo<AgrupacionesSindicalesDTO>();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }




}