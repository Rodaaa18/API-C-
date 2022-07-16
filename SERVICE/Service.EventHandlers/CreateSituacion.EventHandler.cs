using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateSituacion : INotificationHandler<CreateSituacionCommand>
    {
        private readonly Context _context;
        public CreateSituacion(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateSituacionCommand notification, CancellationToken cancellationToken)
        {
            if (notification.Situacion == "")
            {
                throw new EmptyCollectionException("Debe ingresar la Situación");
            }
           
            await _context.AddAsync(new SituacionesUnidades
            {
                Situacion = notification.Situacion,
                Obs = notification.Obs,
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
