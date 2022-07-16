using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DATA.Models
{
    public class HistoricoPartesNeumaticos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdHistoricoParteNeumatico { get; set; }
        public long IdNeumatico { get; set; }
        public DateTime? Fecha { get; set; }
        public int? KmAgregados { get; set; }
        public long? IdUnidad { get; set; }
        public long? IdParte { get; set; }
        [ForeignKey("IdTraza")]
        public long? IdTraza { get; set; }
        public virtual Trazas idTraza { get; set; }
    }
}
