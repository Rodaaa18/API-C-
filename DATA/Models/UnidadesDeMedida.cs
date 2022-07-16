using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class UnidadesDeMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUnidadDeMedida { get; set; }
        [MaxLength(50)]
        public string UnidadDeMedida { get; set; }
        
    }
}
