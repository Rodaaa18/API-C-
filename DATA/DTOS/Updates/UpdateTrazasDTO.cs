using System.ComponentModel.DataAnnotations;


namespace DATA.DTOS.Updates
{
    public class UpdateTrazasDTO
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
