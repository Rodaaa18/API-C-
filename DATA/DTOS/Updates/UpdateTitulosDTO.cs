

using System.ComponentModel.DataAnnotations;

namespace DATA.DTOS.Updates
{
    public class UpdateTitulosDTO
    {
        [Required]
        public string Descripcion { get; set; }
        public string Obs { get; set; }
    }
}
