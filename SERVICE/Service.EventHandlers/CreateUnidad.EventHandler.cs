using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{/// <summary>
/// //////////////////////////////////////////Se utilizan Handlers para hacer peticiones que modifiquen la base de datos.
/// </summary>
    public class CreateUnidad : INotificationHandler<CreateUnidadCommand>
    {
        private readonly Context _context;
        public CreateUnidad(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateUnidadCommand notification, CancellationToken cancellationToken)
        {
            if(notification.idEstadoUnidad == 0 && notification.idModelo == 0 && notification.idSituacionUnidad == 0)
            {
                throw new EmptyCollectionException("El Estado, Modelo y Situación de la Unidad son Obligatorios");
            }
            if (notification.idEstadoUnidad == 0)
            {
                throw new EmptyCollectionException("El Estado de la Unidad es Obligatorio");
            }
            if (notification.idModelo == 0)
            {
                throw new EmptyCollectionException("El Modelo de la Unidad es Obligatorio");
            }
            if (notification.idSituacionUnidad == 0)
            {
                throw new EmptyCollectionException("La Situación de la Unidad es Obligatoria");
            }
            await _context.AddAsync(new Unidades
            {
                NroUnidad = notification.NroUnidad,
                Dominio = notification.Dominio,
                Motor = notification.Motor,
                Chasis = notification.Chasis,
                Titular = notification.Titular,
                idEstadoUnidad = (int?)notification.idEstadoUnidad ?? throw new EmptyCollectionException("El Estado no puede ser nulo"),
                idModelo = (int?)notification.idModelo ?? throw new EmptyCollectionException("El Modelo no puede ser nulo"),
                idSituacionUnidad = (int?)notification.idSituacionUnidad ?? throw new EmptyCollectionException("La Situación no puede ser nula")
            });;
            await _context.SaveChangesAsync();
        }
    }
}
