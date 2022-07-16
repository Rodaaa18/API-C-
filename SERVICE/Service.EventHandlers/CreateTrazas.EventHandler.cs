using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateTrazas : INotificationHandler<CreateTrazasCommand>
    {
        private readonly Context _context;

        public CreateTrazas(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateTrazasCommand notification, CancellationToken cancellationToken)
        {
            if (notification.IdLocalidadDesde == 0 && notification.IdLocalidadHasta == 0)
            {
                throw new EmptyCollectionException("Los campos Localidad Desde y Localidad Hasta son obligatorios");
            }
            if(notification.IdLocalidadDesde == 0)
            {
                throw new EmptyCollectionException("El campo Localidad Desde es obligatorio");
            }
            if(notification.IdLocalidadHasta == 0)
            {
                throw new EmptyCollectionException("El campo Localidad Hasta es obligatorio");
            }

            await _context.AddAsync(new Trazas
            {
                IdLocalidadDesde = notification.IdLocalidadDesde,
                IdLocalidadHasta = notification.IdLocalidadHasta,
                Obs = notification.Obs,
                DistanciaKM = notification.DistanciaKm,
                Litros = notification.Litros
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
