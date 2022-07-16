using MediatR;

namespace Service.EventHandlers.Command
{
    public class CreateGrupoCommand : INotification
    {
        public string Descripcion { get; set; }
        public string Obs { get; set; }
        public string RutaImagen { get; set; }
    }
}
