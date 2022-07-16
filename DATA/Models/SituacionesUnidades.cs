using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class SituacionesUnidades
    {
        public SituacionesUnidades()
        {
            Unidades = new HashSet<Unidades>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdSituacionUnidad { get; set; }
        public string Situacion { get; set; }
        public string Obs { get; set; }
        public virtual ICollection<Unidades> Unidades { get; set; }
    }
}
