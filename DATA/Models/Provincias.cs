using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    
    public class Provincias
    {
        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProvincia { get; set; }
        [MaxLength(200)]
        public string Provincia { get; set; }
        public virtual ICollection<Localidades> Localidades { get; set; }
                
    }
}
