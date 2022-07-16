
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
    public class CreateModelo : INotificationHandler<CreateModeloCommand>
    {
        private readonly Context _context;
        public CreateModelo(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateModeloCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Modelos
            {
                Modelo = notification.Modelo,
                idMarca= notification.IdMarca,
                IdGrupo= notification.IdGrupo,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}
