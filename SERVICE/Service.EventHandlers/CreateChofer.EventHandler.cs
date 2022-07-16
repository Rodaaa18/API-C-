using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateChofer : INotificationHandler<CreateChoferesCommand>
    {
        private readonly Context _context;
        public CreateChofer(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateChoferesCommand notification, CancellationToken cancellationToken)
        {
            //if (notification.idEstadoUnidad == 0 && notification.idModelo == 0 && notification.idSituacionUnidad == 0)
            //{
            //    throw new EmptyCollectionException("El Estado, Modelo y Situación de la Unidad son Obligatorios");
            //}
            if (notification.ApellidoyNombres == "")
            {
                throw new EmptyCollectionException("Debe ingresar el Nombre y Apellido del Chofer");
            }
            //if (notification.idModelo == 0)
            //{
            //    throw new EmptyCollectionException("El Modelo de la Unidad es Obligatorio");
            //}
            //if (notification.idSituacionUnidad == 0)
            //{
            //    throw new EmptyCollectionException("La Situación de la Unidad es Obligatoria");
            //}
            await _context.AddAsync(new Choferes
            {
                ApellidoyNombres = notification.ApellidoyNombres,
                Legajo = notification.Legajo,
                CarnetVence = notification.CarnetVence,
                Obs = notification.Obs,
                Foto = notification.Foto,
                Activo = notification.Activo,
                NroDocumento = notification.NroDocumento,
                FechaNacimiento = notification.FechaNacimiento,
                IdEmpresa = notification.IdEmpresa,
                IdAgrupacionSindical = notification.IdAgrupacionSindical,
                IdConvenio = notification.IdConvenio,
                IdFuncion = notification.IdFuncion,
                IdEspecialidad = notification.IdEspecialidad,
                IdTitulo = notification.IdTitulo,
            });
            await _context.SaveChangesAsync();
        }
    }
}
