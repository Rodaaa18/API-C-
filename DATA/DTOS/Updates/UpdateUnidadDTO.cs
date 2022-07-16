using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Queries.DTOS
{
    public class UpdateUnidadDTO
    {
        public string NroUnidad { get; set; }
        public string? Dominio { get; set; }
        public string? Motor { get; set; }
        public string? Chasis { get; set; }
        public string? Titular { get; set; }
        [Required]
        public long idEstadoUnidad { get; set; }
        [Required]
        public long idModelo { get; set; }
        [Required]        
        public long idSituacionUnidad { get; set; }
    }
}
