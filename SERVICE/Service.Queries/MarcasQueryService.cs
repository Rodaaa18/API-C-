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
    public interface IMarcasQueryService
    {
        Task<DataCollection<MarcasDTO>> GetAllAsync(int page, int take, IEnumerable<long> Marcas = null);
        Task<MarcasDTO> GetAsync(long id);
        Task<UpdateMarcaDTO> PutAsync(UpdateMarcaDTO Convenio, long it);
        Task<MarcasDTO> DeleteAsync(long id);
    }

    public class MarcasQueryService : IMarcasQueryService
    {
        private readonly Context _context;

        public MarcasQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<MarcasDTO>> GetAllAsync(int page, int take, IEnumerable<long> marcas = null)
        {
            try
            {
                var collection = await _context.Marcas
                .Where(x => marcas == null || marcas.Contains(x.IdMarca))
                .OrderByDescending(x => x.IdMarca)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<MarcasDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Marcas");
            }

        }

        public async Task<MarcasDTO> GetAsync(long id)
        {
            try
            {
                if (await _context.Marcas.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Marca, la Marca con id" + " " + id + " " + "no existe");
                }
                return (await _context.Marcas.FindAsync(id)).MapTo<MarcasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener  la Marca");
            }

        }
        public async Task<UpdateMarcaDTO> PutAsync(UpdateMarcaDTO Marca, long id)
        {
            if (await _context.Marcas.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Marca, la Marca con id" + " " + id + " " + "no existe");
            }
            var marca = await _context.Marcas.SingleAsync(x => x.IdMarca == id);
            marca.Marca = Marca.Marca;
            marca.Obs = Marca.Obs;

            await _context.SaveChangesAsync();

            return Marca.MapTo<UpdateMarcaDTO>();
        }
        public async Task<MarcasDTO> DeleteAsync(long id)
        {
            try
            {
                var marca = await _context.Marcas.SingleAsync(x => x.IdMarca == id);
                if (marca == null)
                {
                    throw new EmptyCollectionException("Error al eliminar la Marca, la Marca con id" + " " + id + " " + "no existe");
                }
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
                return marca.MapTo<MarcasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Marca");
            }

        }

    }

}


