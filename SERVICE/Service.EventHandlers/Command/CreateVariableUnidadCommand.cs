using MediatR;


namespace Service.EventHandlers.Command
{
    public class CreateVariableUnidadCommand : INotification
    {
        public string Nombre { get; set; }
    }
}
