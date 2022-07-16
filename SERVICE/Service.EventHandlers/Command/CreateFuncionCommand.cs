using MediatR;


namespace Service.EventHandlers.Command
{
    public class CreateFuncionCommand : INotification
    {
        public string Descripcion { get; set; }
        public string Obs { get; set; }
    }
}
