
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
    public class CreateMarca : INotificationHandler<CreateMarcaCommand>
    {
        private readonly Context _context;
        public CreateMarca(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateMarcaCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Marcas
            {
                Marca = notification.Marca,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}
