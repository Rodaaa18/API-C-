using System;

namespace DATA.DTOS
{
    public class ChoferesDTO
    {
        public long IdChofer { get; set; }
        public string ApellidoyNombres { get; set; }
        public string Legajo { get; set; }
        public DateTime CarnetVence { get; set; }
        public string Obs { get; set; }
        public string Foto { get; set; }
        public bool Activo { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Empresa { get; set; }
        public string AgrupacionSindical { get; set; }
        public string Convenio { get; set; }
        public string Funcion { get; set; }
        public string Especialidad { get; set; }
        public string Titulo { get; set; }
    }
}
