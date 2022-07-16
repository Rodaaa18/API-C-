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
    public interface IUnidadesDeMedidaQueryService
    {
        Task<DataCollection<UnidadesDeMedidaDTO>> GetAllAsync(int page, int take, IEnumerable<long> unidadesMedida = null);
        Task<UnidadesDeMedidaDTO> GetAsync(long id);
        Task<UpdateUnidadDeMedidaDTO> PutAsync(UpdateUnidadDeMedidaDTO titulo, long id);
        Task<UnidadesDeMedidaDTO> DeleteAsync(long id);
    }
    public class UnidadesDeMedidaQueryService : IUnidadesDeMedidaQueryService
    {
        private readonly Context _context;
        public UnidadesDeMedidaQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<UnidadesDeMedidaDTO>> GetAllAsync(int page, int take, IEnumerable<long> unidadesMedida = null)
        {
            try
            {
                var collection = await _context.UnidadesDeMedida
                .Where(x => unidadesMedida == null || unidadesMedida.Contains(x.IdUnidadDeMedida))
                .OrderByDescending(x => x.IdUnidadDeMedida)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<UnidadesDeMedidaDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UnidadesDeMedidaDTO> GetAsync(long id)
        {
            try
            {
                var unidadMedida = await _context.UnidadesDeMedida.FindAsync(id);

                if (await _context.UnidadesDeMedida.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Unidad de Medida, la Unidad con id" + " " + id + " " + "no existe");
                }
                return unidadMedida.MapTo<UnidadesDeMedidaDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateUnidadDeMedidaDTO> PutAsync(UpdateUnidadDeMedidaDTO titulo, long id)
        {
            if (await _context.UnidadesDeMedida.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al obtener La Unidad de Medida, la Unidad con id" + " " + id + " " + "no existe");
            }
            var updateTitulo = await _context.UnidadesDeMedida.FindAsync(id);

            updateTitulo.UnidadDeMedida = titulo.UnidadDeMedida;


            await _context.SaveChangesAsync();

            return titulo.MapTo<UpdateUnidadDeMedidaDTO>();
        }
        public async Task<UnidadesDeMedidaDTO> DeleteAsync(long id)
        {
            var unidadMedida = await _context.UnidadesDeMedida.FindAsync(id);
            if (unidadMedida == null)
            {
                throw new EmptyCollectionException("Error al eliminar el Titulo, el Titulo con id" + " " + id + " " + "no existe");
            }

            _context.UnidadesDeMedida.Remove(unidadMedida);

            await _context.SaveChangesAsync();

            return unidadMedida.MapTo<UnidadesDeMedidaDTO>();
        }
    }
}
