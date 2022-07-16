
using MediatR;

namespace Service.EventHandlers.Command
{
    public class CreateSituacionCommand : INotification
    {
        public string Situacion { get; set; }
        public string Obs { get; set; }
    }
}
