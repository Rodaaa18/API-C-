using Common.Collection;
using DATA.DTOS;
using DATA.Extensions;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE;
using Service.Queries.DTOS;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Queries
{/// <summary>
/// //////////////////////////////////////////Se utilizan Queries para hacer peticiones que no modifiquen la base de datos.(Excepto el PUT)
/// </summary>
    public interface IUnidadesQueryService
    {
        Task<DataCollection<UnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> unidades = null);
        Task<UnidadesDTO> GetAsync(long id);
        Task<UpdateUnidadDTO> PutAsync(UpdateUnidadDTO unidad, long it);
        Task<UnidadesDTO> DeleteAsync(long id);
    }
    public class UnidadesQueryService : IUnidadesQueryService
    {
        private readonly Context _context;

        public UnidadesQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<UnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> unidades = null)
        {
            try
            {
                var collection = await _context.Unidades
                .Where(x => unidades == null || unidades.Contains(x.IdUnidad))
                .OrderByDescending(x => x.IdUnidad)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<UnidadesDTO>>();
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<UnidadesDTO> GetAsync(long id)
        {
            try
            {
                var unidad = await _context.Unidades.SingleAsync(x => x.IdUnidad == id);
                                
                if (await _context.Unidades.SingleAsync(x => x.IdUnidad == id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la unidad, la unidad con id" + " " + id + " " + "no existe");
                }
                return unidad.MapTo<UnidadesDTO>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<UpdateUnidadDTO> PutAsync(UpdateUnidadDTO unidad, long id)
        {
            if(unidad.idEstadoUnidad == 0 && unidad.idModelo == 0 && unidad.idSituacionUnidad == 0)
            {
                throw new EmptyCollectionException("El Estado, Modelo y Situación de la Unidad son Obligatorios");
            }
            if (unidad.idEstadoUnidad == 0)
            {
                throw new EmptyCollectionException("El Estado de la Unidad es Obligatorio");
            }
            if (unidad.idModelo == 0)
            {
                throw new EmptyCollectionException("El Modelo de la Unidad es Obligatorio");
            }
            if (unidad.idSituacionUnidad == 0)
            {
                throw new EmptyCollectionException("La Situación de la Unidad es Obligatoria");
            }
            if (await _context.Unidades.FindAsync(id) is null)
            {
                throw new EmptyCollectionException("Error al obtener la unidad, la unidad con id" + " " + id + " " + "no existe");
            }
            var unidade = await _context.Unidades.FindAsync(id);

            unidade.NroUnidad = unidad.NroUnidad ?? unidade.NroUnidad;
            unidade.Dominio = unidad.Dominio ?? unidade.Dominio;
            unidade.Motor = unidad.Motor ?? unidade.Motor;
            unidade.Chasis = unidad.Chasis ?? unidade.Chasis;
            unidade.Titular = unidad.Titular ?? unidade.Titular;
            unidade.idEstadoUnidad = unidad.idEstadoUnidad;
            unidade.idModelo = unidad.idModelo;
            unidade.idSituacionUnidad = unidad.idSituacionUnidad;


                await _context.SaveChangesAsync();
                
            return unidad.MapTo<UpdateUnidadDTO>();
        }
        public async Task<UnidadesDTO> DeleteAsync(long id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null)
            {
               throw new EmptyCollectionException("Error al eliminar la unidad, la unidad con id" + " " + id + " " + "no existe");
            }
            
            _context.Unidades.Remove(unidade);
                
            await _context.SaveChangesAsync();
            return unidade.MapTo<UnidadesDTO>();                        
        }
        
    }
    
}
