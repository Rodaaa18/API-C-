using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Marcas
    {
        public Marcas()
        {
            Modelos = new HashSet<Modelos>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdMarca { get; set; }
        [MaxLength(50)]
        public string Marca { get; set; }
        public string Obs { get; set; }
        public virtual ICollection<Modelos> Modelos { get; set; }
    }
}
