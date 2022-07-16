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
    public class CreateEspecialidad : INotificationHandler<CreateEspecialidadCommand>
    {
        private readonly Context _context;
        public CreateEspecialidad(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateEspecialidadCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Especialidades
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}