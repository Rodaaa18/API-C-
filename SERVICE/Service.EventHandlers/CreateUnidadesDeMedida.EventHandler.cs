using DATA.Extensions;
using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateUnidadesDeMedida : INotificationHandler<CreateUnidadesDeMedidaCommand>
    {
        private readonly Context _context;
        public CreateUnidadesDeMedida(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateUnidadesDeMedidaCommand notification, CancellationToken cancellationToken)
        {
            if (notification.UnidadDeMedida == "")
            {
                throw new EmptyCollectionException("Debe ingresar la Unidad de Medida");
            }
            
            await _context.AddAsync(new UnidadesMedida
            {
                UnidadDeMedida = notification.UnidadDeMedida,
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
