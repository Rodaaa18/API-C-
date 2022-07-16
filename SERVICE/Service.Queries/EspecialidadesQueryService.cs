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
    public interface IEspecialidadesQueryService
    {
        Task<DataCollection<EspecialidadesDTO>> GetAllAsync(int page, int take, IEnumerable<int> Especialidades = null);
        Task<EspecialidadesDTO> GetAsync(int id);
        Task<UpdateEspecialidadesDTO> PutAsync(UpdateEspecialidadesDTO Especialidad, int it);
        Task<EspecialidadesDTO> DeleteAsync(int id);
    }

    public class EspecialidadesQueryService : IEspecialidadesQueryService
    {
        private readonly Context _context;

        public EspecialidadesQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<EspecialidadesDTO>> GetAllAsync(int page, int take, IEnumerable<int> especialidades = null)
        {
            try
            {
                var collection = await _context.Especialidades
                .Where(x => especialidades == null || especialidades.Contains(x.IdEspecialidad))
                .OrderByDescending(x => x.IdEspecialidad)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<EspecialidadesDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Especialidades");
            }

        }

        public async Task<EspecialidadesDTO> GetAsync(int id)
        {
            try
            {
                if (await _context.Especialidades.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Especialidad, la Especialidad con id" + " " + id + " " + "no existe");
                }
                return (await _context.Especialidades.FindAsync(id)).MapTo<EspecialidadesDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el especialidad");
            }

        }
        public async Task<UpdateEspecialidadesDTO> PutAsync(UpdateEspecialidadesDTO Especialidad, int id)
        {
            if (await _context.Especialidades.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Especialidad, la Especialidad con id" + " " + id + " " + "no existe");
            }
            var especialidad = await _context.Especialidades.SingleAsync(x => x.IdEspecialidad == id);
            especialidad.Descripcion = Especialidad.Descripcion;
            especialidad.Obs = Especialidad.Obs;

            await _context.SaveChangesAsync();

            return Especialidad.MapTo<UpdateEspecialidadesDTO>();
        }
        public async Task<EspecialidadesDTO> DeleteAsync(int id)
        {
            try
            {
                var especialidad = await _context.Especialidades.SingleAsync(x => x.IdEspecialidad == id);
                if (especialidad == null)
                {
                    throw new EmptyCollectionException("Error al eliminar la Especialidad, la Especialidad con id" + " " + id + " " + "no existe");
                }
                _context.Especialidades.Remove(especialidad);
                await _context.SaveChangesAsync();
                return especialidad.MapTo<EspecialidadesDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Especialidad");
            }

        }

    }




}
