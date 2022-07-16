
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
    public class CreateConvenio : INotificationHandler<CreateConvenioCommand>
    {
        private readonly Context _context;
        public CreateConvenio(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateConvenioCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Convenios
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}