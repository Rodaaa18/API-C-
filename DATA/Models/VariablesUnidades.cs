using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class VariablesUnidades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVariableUnidad { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        
    }
}
