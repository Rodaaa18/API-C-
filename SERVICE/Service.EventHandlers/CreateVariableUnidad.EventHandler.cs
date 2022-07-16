using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateVariableUnidad : INotificationHandler<CreateVariableUnidadCommand>
    {
        private readonly Context _context;
        public CreateVariableUnidad(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateVariableUnidadCommand notification, CancellationToken cancellationToken)
        {
            if (notification.Nombre == "")
            {
                throw new EmptyCollectionException("Debe ingresar el Nombre");
            }
            
            await _context.AddAsync(new VariablesUnidades
            {
                Nombre = notification.Nombre,
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
