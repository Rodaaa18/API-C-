using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Equipamientos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEquipamiento { get; set; }
        public long? idNombreEquipamiento { get; set; }
        public long? idArticulo { get; set; }
        public long? Cantidad { get; set; }
    }
}
