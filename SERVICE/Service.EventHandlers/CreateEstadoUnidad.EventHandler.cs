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
    public class CreateEstadoUnidad : INotificationHandler<CreateEstadoUnidadCommand>
    {
        private readonly Context _context;
        public CreateEstadoUnidad(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateEstadoUnidadCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new EstadosUnidades
            {
                Estado = notification.Estado,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}