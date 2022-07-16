using MediatR;


namespace Service.EventHandlers.Command
{
    public class CreateEquipamientoCommand : INotification
    {
        public long? idNombreEquipamiento { get; set; }
        public long? idArticulo { get; set; }
        public long? Cantidad { get; set; }
    }
}
