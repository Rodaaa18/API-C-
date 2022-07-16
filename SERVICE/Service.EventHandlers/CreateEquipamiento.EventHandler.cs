using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateEquipamiento : INotificationHandler<CreateEquipamientoCommand>
    {
        private readonly Context _context;
        public CreateEquipamiento(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateEquipamientoCommand notification, CancellationToken cancellationToken)
        {
            

            await _context.AddAsync(new Equipamientos
            {
                idNombreEquipamiento = notification.idNombreEquipamiento,
                idArticulo = notification.idArticulo,
                Cantidad = notification.Cantidad
            }); ;
            await _context.SaveChangesAsync();
        }
    }
}
