using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Localidades
    {
        
        public Localidades()
        {
            LocalidadDesde = new HashSet<Trazas>();
            LocalidadHasta = new HashSet<Trazas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdLocalidad { get; set; }
        [Key]
        [MaxLength(50)]
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        [ForeignKey("idProvincia")]
        public long idProvincia { get; set; }
        public virtual Provincias IdProvincia { get; set; }
        [NotMapped]
        public virtual ICollection<Trazas> LocalidadDesde { get; set; } //En la BD salen como FK pero no se de donde las saca ni hay columna a la que vayan 
        [NotMapped]
        public virtual ICollection<Trazas> LocalidadHasta
        {
            get; set; //En la BD salen como FK pero no se de donde las saca ni hay columna a la que vayan 
        }
    }
}
