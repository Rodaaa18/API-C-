using Common.Collection;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE;
using DATA.DTOS;
using DATA.DTOS.Updates;
using Service.Queries.DTOS;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA.Extensions;

namespace Service.Queries
{
    public interface IProvinciasQueryService
    {
        Task<DataCollection<ProvinciasDTO>> GetAllAsync(int page, int take, IEnumerable<long> Provincias = null);
        Task<ProvinciasDTO> GetAsync(long id);
        Task<UpdateProvinciaDTO> PutAsync(UpdateProvinciaDTO Provincias, long it);
        Task<ProvinciasDTO> DeleteAsync(long id);
    }

    public class ProvinciasQueryService : IProvinciasQueryService
    {
        private readonly Context _context;

        public ProvinciasQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProvinciasDTO>> GetAllAsync(int page, int take, IEnumerable<long> provincias = null)
        {
            try
            {
                var collection = await _context.Provincias
                .Where(x => provincias == null || provincias.Contains(x.IdProvincia))
                .OrderByDescending(x => x.IdProvincia)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<ProvinciasDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Provincias");
            }

        }

        public async Task<ProvinciasDTO> GetAsync(long id)
        {
            try
            {
                if (await _context.Provincias.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Provincia, la Provincia con id" + " " + id + " " + "no existe");
                }                
                return (await _context.Provincias.FindAsync(id)).MapTo<ProvinciasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Provincia");
            }

        }
        public async Task<UpdateProvinciaDTO> PutAsync(UpdateProvinciaDTO Provincia, long id)
        {
            if (await _context.Provincias.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Provincia, la Provincia con id" + " " + id + " " + "no existe");
            }
            var provincia = await _context.Provincias.FindAsync(id);
            provincia.Provincia = Provincia.Provincia;

            await _context.SaveChangesAsync();

            return Provincia.MapTo<UpdateProvinciaDTO>();
        }
        public async Task<ProvinciasDTO> DeleteAsync(long id)
        {
            try
            {
                var provincia = await _context.Provincias.SingleAsync(x => x.IdProvincia == id);
                if (provincia == null)
                {
                    throw new EmptyCollectionException("Error al eliminar la Provincia, la Provincia con id" + " " + id + " " + "no existe");
                }
                _context.Provincias.Remove(provincia);
                await _context.SaveChangesAsync();
                return provincia.MapTo<ProvinciasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Provincia");
            }

        }

    }

}


