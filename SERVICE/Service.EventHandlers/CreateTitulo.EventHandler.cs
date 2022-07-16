using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateTitulo : INotificationHandler<CreateTituloCommand>
    {
        private readonly Context _context;
        public CreateTitulo(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateTituloCommand notification, CancellationToken cancellationToken)
        {
            if (notification.Descripcion == "")
            {
                throw new EmptyCollectionException("Debe ingresar la Situación");
            }

            await _context.AddAsync(new Titulos
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
