using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Convenios : BaseEntity
    {
        public Convenios()
        {
            Choferes = new HashSet<Choferes>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConvenio { get; set; }//Entidad base
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public string Obs { get; set; } //Entidad base
        public virtual ICollection<Choferes> Choferes { get; set; }
    }
}
