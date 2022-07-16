using Common.Collection;
using DATA.DTOS;
using DATA.DTOS.Updates;
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
    public interface IEmpresasQueryService
    {
        Task<DataCollection<EmpresasDTO>> GetAllAsync(int page, int take, IEnumerable<int> Empresas = null);
        Task<EmpresasDTO> GetAsync(int id);
        Task<UpdateEmpresaDTO> PutAsync(UpdateEmpresaDTO Empresa, int it);
        Task<EmpresasDTO> DeleteAsync(int id);
    }

    public class EmpresasQueryService : IEmpresasQueryService
    {
        private readonly Context _context;

        public EmpresasQueryService(Context context)
        {
            _context = context;
        }

        public async Task<DataCollection<EmpresasDTO>> GetAllAsync(int page, int take, IEnumerable<int> empresas = null)
        {
            try
            {
                var collection = await _context.Empresas
                .Where(x => empresas == null || empresas.Contains(x.IdEmpresa))
                .OrderByDescending(x => x.IdEmpresa)
                .GetPagedAsync(page, take);
                if (!collection.HasItems)
                {
                    throw new EmptyCollectionException("No se encontró ningun Item en la Base de Datos");
                }
                return collection.MapTo<DataCollection<EmpresasDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las Empresas");
            }

        }

        public async Task<EmpresasDTO> GetAsync(int id)
        {
            try
            {
                if (await _context.Empresas.FindAsync(id) == null)
                {
                    throw new EmptyCollectionException("Error al obtener la Empresa, la Empresa con id" + " " + id + " " + "no existe");
                }
                return (await _context.Empresas.FindAsync(id)).MapTo<EmpresasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Empresa");
            }

        }
        public async Task<UpdateEmpresaDTO> PutAsync(UpdateEmpresaDTO Empresa, int id)
        {
            if (await _context.Empresas.FindAsync(id) == null)
            {
                throw new EmptyCollectionException("Error al actualizar la Empresa, la Empresa con id" + " " + id + " " + "no existe");
            }
            var empresa = await _context.Empresas.SingleAsync(x => x.IdEmpresa == id);
            empresa.Descripcion = Empresa.Descripcion;
            empresa.Obs = Empresa.Obs;

            await _context.SaveChangesAsync();

            return Empresa.MapTo<UpdateEmpresaDTO>();
        }
        public async Task<EmpresasDTO> DeleteAsync(int id)
        {
            try
            {
                var empresa = await _context.Empresas.SingleAsync(x => x.IdEmpresa == id);
                if (empresa == null)
                {
                    throw new EmptyCollectionException("Error al eliminar la Empresa, la Empresa con id" + " " + id + " " + "no existe");
                }
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
                return empresa.MapTo<EmpresasDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Empresa");
            }

        }

    }
}
