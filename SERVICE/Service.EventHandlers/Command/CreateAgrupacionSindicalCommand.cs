using MediatR;

namespace Service.EventHandlers.Command
{
    public class CreateAgrupacionSindicalCommand  : INotification
    { 

        public string Descripcion { get; set; }
        public string Obs { get; set; }

    }
}