using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Grupos
    {
        public Grupos()
        {
            Modelos = new HashSet<Modelos>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdGrupo { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public string Obs { get; set; }
        public string RutaImagen { get; set; }
        public virtual ICollection<Modelos> Modelos { get; set; }
    }
}
