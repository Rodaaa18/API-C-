using System.ComponentModel.DataAnnotations;


namespace DATA.DTOS
{
    public class TrazasDTO
    {
        public long IdTraza { get; set; }
        [Required]
        public long IdLocalidadDesde { get; set; }
        [Required]
        public long IdLocalidadHasta { get; set; }
        public string Obs { get; set; }
        public int DistanciaKm { get; set; }
        public int Litros { get; set; }
        
    }
}
