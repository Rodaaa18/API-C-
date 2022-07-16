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
    public interface ISituacionesUnidadesQueryService
    {
        Task<DataCollection<SituacionesUnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> situaciones = null);
        Task<SituacionesUnidadesDTO> GetAsync(long id);
        Task<UpdateSituacionesUnidadesDTO> PutAsync(UpdateSituacionesUnidadesDTO situacion, long id);
        Task<SituacionesUnidadesDTO> DeleteAsync(long id);
    }
    public class SituacionesUnidadesQueryService : ISituacionesUnidadesQueryService
    {
        private readonly Context _context;
        
        public SituacionesUnidadesQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<SituacionesUnidadesDTO>> GetAllAsync(int page, int take, IEnumerable<long> situaciones = null)
        {
            try
            {
                var collection = await _context.SituacionesUnidades
                .Where(x => situaciones == null || situaciones.Contains(x.IdSituacionUnidad))
                .OrderByDescending(x => x.IdSituacionUnidad)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<SituacionesUnidadesDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<SituacionesUnidadesDTO> GetAsync(long id)
        {
            try
            {
                var unidad = await _context.SituacionesUnidades.FindAsync(id);

                if (await _context.SituacionesUnidades.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la situación, la situación con id" + " " + id + " " + "no existe");
                }
                return unidad.MapTo<SituacionesUnidadesDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateSituacionesUnidadesDTO> PutAsync(UpdateSituacionesUnidadesDTO situacion, long id)
        {
            if (await _context.SituacionesUnidades.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al obtener la situación, la situación con id" + " " + id + " " + "no existe");
            }
            if(situacion.Situacion is null)
            {
                throw new EmptyCollectionException("Debe colocarl la Situación");
            }
            var updateSituacion = await _context.SituacionesUnidades.FindAsync(id);

            updateSituacion.Situacion = situacion.Situacion;
            updateSituacion.Obs = situacion.Obs ?? updateSituacion.Obs;


            await _context.SaveChangesAsync();

            return situacion.MapTo<UpdateSituacionesUnidadesDTO>();
        }
        public async Task<SituacionesUnidadesDTO> DeleteAsync(long id)
        {
            var situacion = await _context.SituacionesUnidades.FindAsync(id);
            if (situacion is null)
            {
                throw new EmptyCollectionException("Error al eliminar la Situacion, la Situacion con id" + " " + id + " " + "no existe");
            }
            
            _context.SituacionesUnidades.Remove(situacion);

            await _context.SaveChangesAsync();
            return situacion.MapTo<SituacionesUnidadesDTO>();
        }
    }
}
