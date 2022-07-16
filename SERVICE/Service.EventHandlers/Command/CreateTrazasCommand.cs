using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Service.EventHandlers.Command
{
    public class CreateTrazasCommand : INotification
    {
        [Required]
        public long IdLocalidadDesde { get; set; }
        [Required]
        public long IdLocalidadHasta { get; set; }
        public string Obs { get; set; }
        public int DistanciaKm { get; set; }
        public int Litros { get; set; }
    }
}
