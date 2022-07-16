using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class UnidadesMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUnidadDeMedida { get; set; }
        [MaxLength(50)]
        public string UnidadDeMedida { get; set; }
        
    }
}
