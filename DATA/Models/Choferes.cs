using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATA.Models
{
    public class Choferes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdChofer { get; set; }
        [MaxLength(50)]
        public string ApellidoyNombres { get; set; }
        [MaxLength(20)]
        public string? Legajo { get; set; }
        
        public DateTime? CarnetVence { get; set; }
        
        public string? Obs { get; set; }
        
        public string? Foto { get; set; }

        public bool? Activo { get; set; }
        public string NroDocumento { get; set; }
        
        public DateTime FechaNacimiento { get; set; }
        
        

        //[ForeignKey("IdTaller")]
        //public int? IdTaller { get; set; }
        //public Talleres Taller { get; set; }
        [ForeignKey("IdEmpresa")]
        public string Empresa { get; set; }
        public int IdEmpresa { get; set; }
        public virtual Empresas idEmpresa { get; set; }
        [ForeignKey("IdAgrupacionSindical")]
        public string AgrupacionSindical { get; set; }
        public int? IdAgrupacionSindical { get; set; }
        public virtual AgrupacionesSindicales idAgrupacionSindical { get; set; }        
        [ForeignKey("IdConvenio")]
        public string Convenio { get; set; }
        public int? IdConvenio { get; set; }
        public virtual Convenios idConvenio { get; set; }
        [ForeignKey("IdFuncion")]
        public string Funcion { get; set; }
        public int? IdFuncion { get; set; }
        public virtual Funciones idFuncion { get; set; }
        [ForeignKey("IdEspecialidad")]
        public string Especialidad { get; set; }
        public int? IdEspecialidad { get; set; }
        [MaxLength(50)]
        public virtual Especialidades idEspecialidad { get; set; }
        [ForeignKey("IdTitulo")]
        public string Titulo { get; set; }
        public int? IdTitulo { get; set; }
        [MaxLength(50)]
        public virtual Titulos idTitulo { get; set; }
    }
}
