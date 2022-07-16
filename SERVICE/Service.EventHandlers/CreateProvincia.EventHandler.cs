using System;
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
    public class CreateProvincia : INotificationHandler<CreateProvinciaCommand>
    {
        private readonly Context _context;
        public CreateProvincia(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateProvinciaCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Provincias
            {
                Provincia = notification.Provincia,

            });
            await _context.SaveChangesAsync();
        }
    }
}
