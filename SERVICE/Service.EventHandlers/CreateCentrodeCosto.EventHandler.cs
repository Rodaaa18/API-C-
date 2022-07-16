using DATA.Models;
using MediatR;
using PERSISTENCE;
using Service.EventHandlers.Command;
using System.Threading;
using System.Threading.Tasks;

namespace Service.EventHandlers
{
    public class CreateCentrodeCosto : INotificationHandler<CreateCentrodeCostoCommand>

    {
        private readonly Context _context;
        public CreateCentrodeCosto(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateCentrodeCostoCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new CentrodeCosto
            {
                CentroDeCosto = notification.CentrodeCosto,
                Tipo = notification.Tipo,
                CodigoBas = notification.codigobas,
                idEstadoUnidad = notification.idEstadoUnidad,
                Obs = notification.Obs,

            });
            await _context.SaveChangesAsync();
        }
    }
}