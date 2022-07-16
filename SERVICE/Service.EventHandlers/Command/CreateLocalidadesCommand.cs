using MediatR;

namespace Service.EventHandlers.Command
{
    public class CreateLocalidadesCommand : INotification
    {
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public long idProvincia { get; set; }
    }
}
