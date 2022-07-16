using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Trazas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdTraza { get; set; }
        [NotMapped]
        [ForeignKey("IdLocalidadDesde")]
        public long? IdLocalidadDesde { get; set; }
        public virtual Localidades idLocalidadDesde { get; set; }
        [NotMapped]
        [ForeignKey("IdLocalidadHasta")]
        public long? IdLocalidadHasta { get; set; }
        public virtual Localidades idLocalidadHasta { get; set; }
        public string? Obs { get; set; }
        public int? DistanciaKM { get; set; }
        public int? Litros { get; set; }
        public virtual ICollection<HistoricoPartesNeumaticos> HistoricoPartes { get; set; }
        
    }
}
