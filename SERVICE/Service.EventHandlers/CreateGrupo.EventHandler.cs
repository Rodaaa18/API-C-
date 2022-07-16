using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateGrupo : INotificationHandler<CreateGrupoCommand>
    {
        private readonly Context _context;
        public CreateGrupo(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateGrupoCommand notification, CancellationToken cancellationToken)
        {
            if (notification.Descripcion == "")
            {
                throw new EmptyCollectionException("Debe ingresar la Descripcion");
            }

            await _context.AddAsync(new Grupos
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,
                RutaImagen = notification.RutaImagen
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
