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
    public class CreateEmpresa : INotificationHandler<CreateEmpresaCommand>
    {
        private readonly Context _context;
        public CreateEmpresa(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateEmpresaCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Empresas
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}
