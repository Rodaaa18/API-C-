using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class EstadosUnidades
    {
        public EstadosUnidades()
        {
            Unidades = new HashSet<Unidades>();
            CentrodeCosto = new HashSet<CentrodeCosto>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEstadoUnidad { get; set; }
        public string Estado { get; set; }
        public string Obs { get; set; }
        public virtual ICollection<CentrodeCosto> CentrodeCosto { get; set; }
        public virtual ICollection<Unidades> Unidades { get; set; }
    }
}
