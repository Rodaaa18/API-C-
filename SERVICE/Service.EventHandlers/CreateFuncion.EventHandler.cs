using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateFuncion: INotificationHandler<CreateFuncionCommand>
    {
        private readonly Context _context;
        public CreateFuncion(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateFuncionCommand notification, CancellationToken cancellationToken)
        {
            if (notification.Descripcion == "")
            {
                throw new EmptyCollectionException("Debe ingresar la Situación");
            }

            await _context.AddAsync(new Funciones
            {
                Descripcion = notification.Descripcion,
                Obs = notification.Obs,
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
