using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class CentrodeCosto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idCentrodeCosto { get; set; }
        [MaxLength(50)]
        public string CentroDeCosto { get; set; }
        public string Obs { get; set; }
        public int Tipo { get; set; }
        [ForeignKey("idEstadoUnidad")]
        public long? idEstadoUnidad { get; set; }
        public virtual EstadosUnidades IdEstadoUnidad { get; set; }
        public int? CodigoBas { get; set; }

    }
}
