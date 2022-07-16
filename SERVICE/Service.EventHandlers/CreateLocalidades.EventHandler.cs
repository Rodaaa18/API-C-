using DATA.Extensions;
using DATA.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateLocalidades : INotificationHandler<CreateLocalidadesCommand>
    {
        private readonly Context _context;
        public CreateLocalidades(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateLocalidadesCommand notification, CancellationToken cancellationToken)
        {
            if (notification.CodigoPostal == "")
            {
                throw new EmptyCollectionException("Debe ingresar el Código Postal");
            }
            if (notification.idProvincia == 0)
            {
                throw new EmptyCollectionException("Debe ingresar la Provincia");
            }
            
            var result = await _context.AddAsync(new Localidades
            {
                Localidad = notification.Localidad,
                CodigoPostal = notification.CodigoPostal,
                idProvincia = notification.idProvincia,
            });
            var localidad = await _context.Localidades.FirstOrDefaultAsync(l => l.Localidad == result.Entity.Localidad);
            if (localidad != null && localidad.Localidad == notification.Localidad)
            {
                throw new EmptyCollectionException("La Localidad" + " " + notification.Localidad + ", ya existe con id:"+ " " + localidad.IdLocalidad);
            }                                  
           
            await _context.SaveChangesAsync();
        }
    }
}
