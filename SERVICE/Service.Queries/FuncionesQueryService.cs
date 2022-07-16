

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
    public interface IFuncionesQueryService
    {
        Task<DataCollection<FuncionesDTO>> GetAllAsync(int page, int take, IEnumerable<int> titulos = null);
        Task<FuncionesDTO> GetAsync(int id);
        Task<UpdateFuncionesDTO> PutAsync(UpdateFuncionesDTO funcion, int id);
        Task<FuncionesDTO> DeleteAsync(int id);
    }
    public class FuncionesQueryService : IFuncionesQueryService
    {
        private readonly Context _context;
        public FuncionesQueryService(Context context)
        {
            _context = context;
        }
        public async Task<DataCollection<FuncionesDTO>> GetAllAsync(int page, int take, IEnumerable<int> funciones = null)
        {
            try
            {
                var collection = await _context.Funciones
                .Where(x => funciones == null || funciones.Contains(x.IdFuncion))
                .OrderByDescending(x => x.IdFuncion)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<FuncionesDTO>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<FuncionesDTO> GetAsync(int id)
        {
            try
            {
                var unidad = await _context.Funciones.FindAsync(id);

                if (await _context.Funciones.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Función, la Función con id" + " " + id + " " + "no existe");
                }
                return unidad.MapTo<FuncionesDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UpdateFuncionesDTO> PutAsync(UpdateFuncionesDTO funcion, int id)
        {
            if (await _context.Funciones.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Función, la Función con id" + " " + id + " " + "no existe");
            }
            if (funcion.Descripcion == "" || funcion.Descripcion is null)
            {
                throw new EmptyCollectionException("Debe colocar la Descripción");
            }
            var updateFuncion = await _context.Funciones.FindAsync(id);

            updateFuncion.Descripcion = funcion.Descripcion;
            updateFuncion.Obs = funcion.Obs ?? updateFuncion.Obs;


            await _context.SaveChangesAsync();

            return funcion.MapTo<UpdateFuncionesDTO>();
        }
        public async Task<FuncionesDTO> DeleteAsync(int id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
            {
                throw new EmptyCollectionException("Error al eliminar la Función, la Función con id" + " " + id + " " + "no existe");
            }

            _context.Funciones.Remove(funcion);

            await _context.SaveChangesAsync();

            return funcion.MapTo<FuncionesDTO>();
        }
    }
}
