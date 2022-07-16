using MediatR;


namespace Service.EventHandlers.Command
{
    public class CreateMarcaCommand : INotification
    {

        public string Marca { get; set; }
        public string Obs { get; set; }
    }
}
