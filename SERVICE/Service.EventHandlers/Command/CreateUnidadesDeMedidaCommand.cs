

using MediatR;

namespace Service.EventHandlers.Command
{
    public class CreateUnidadesDeMedidaCommand : INotification
    {
        public string UnidadDeMedida { get; set; }
    }
}
