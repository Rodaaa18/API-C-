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
    public interface ITrazasQueryService
    {
        Task<DataCollection<TrazasDTO>> GetAllAsync(int page, int take, IEnumerable<long> trazas = null);
        Task<TrazasDTO> GetAsync(long id);
        Task<UpdateTrazasDTO> PutAsync(UpdateTrazasDTO traza, long id);
        Task<TrazasDTO> DeleteAsync(long id);
    }
    public class TrazasQueryService : ITrazasQueryService
    {
        private readonly Context _context;
        public TrazasQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<TrazasDTO>> GetAllAsync(int page, int take, IEnumerable<long> trazas = null)
        {
            try
            {
                var collection = await _context.Trazas
                .Where(x => trazas == null || trazas.Contains(x.IdTraza))
                .OrderByDescending(x => x.IdTraza)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<TrazasDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TrazasDTO> GetAsync(long id)
        {
            try
            {
                var traza = await _context.Trazas.FindAsync(id);

                if (await _context.Trazas.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Traza, la Traza con id" + " " + id + " " + "no existe");
                }
                return traza.MapTo<TrazasDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<UpdateTrazasDTO> PutAsync(UpdateTrazasDTO traza, long id)
        {
            if (await _context.Trazas.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al obtener la Traza, la Traza con id" + " " + id + " " + "no existe");
            }
            if (traza.IdLocalidadDesde == 0 && traza.IdLocalidadHasta == 0)
            {
                throw new EmptyCollectionException("Los campos Localidad Desde y Localidad Hasta son obligatorios");
            }
            if (traza.IdLocalidadDesde == 0)
            {
                throw new EmptyCollectionException("El campo Localidad Desde es obligatorio");
            }
            if (traza.IdLocalidadHasta == 0)
            {
                throw new EmptyCollectionException("El campo Localidad Hasta es obligatorio");
            }
            var updateTraza = await _context.Trazas.FindAsync(id);
            updateTraza.IdLocalidadDesde = traza.IdLocalidadDesde;
            updateTraza.IdLocalidadHasta = traza.IdLocalidadHasta;
            updateTraza.DistanciaKM = traza.DistanciaKm;
            updateTraza.Obs = traza.Obs;
            updateTraza.Litros = traza.Litros;


            await _context.SaveChangesAsync();
            
            return traza.MapTo<UpdateTrazasDTO>();
        }
        public async Task<TrazasDTO> DeleteAsync(long id)
        {
            var traza = await _context.Trazas.FindAsync(id);
            if (traza == null)
            {
                throw new EmptyCollectionException("Error al eliminar la Traza, la Traza con id" + " " + id + " " + "no existe");
            }

            _context.Trazas.Remove(traza);

            await _context.SaveChangesAsync();

            return traza.MapTo<TrazasDTO>();
        }
    }
}
