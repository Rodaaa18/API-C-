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
    public class CreateAgrupacionSindical : INotificationHandler <CreateAgrupacionSindicalCommand>
    {
        private readonly Context _context;
        public CreateAgrupacionSindical(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateAgrupacionSindicalCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new AgrupacionesSindicales
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}
