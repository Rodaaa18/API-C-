using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Service.EventHandlers.Command
{
    public class CreateUnidadCommand : INotification
    {
        public string NroUnidad { get; set; }
        public string Dominio { get; set; }
        public string Motor { get; set; }
        public string Chasis { get; set; }
        public string Titular { get; set; }
        [Required]
        public int idEstadoUnidad { get; set; }
        [Required]
        public int idModelo { get; set; }
        [Required]
        public int idSituacionUnidad { get; set; }
    }
}
