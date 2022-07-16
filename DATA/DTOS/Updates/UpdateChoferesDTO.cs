

using System;

namespace DATA.DTOS.Updates
{
    public class UpdateChoferesDTO
    {
        public string ApellidoyNombres { get; set; }
        public string Legajo { get; set; }
        public DateTime CarnetVence { get; set; }
        public string Obs { get; set; }
        public string Foto { get; set; }
        public bool Activo { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdEmpresa { get; set; }
        public int IdAgrupacionSindical { get; set; }
        public int IdConvenio { get; set; }
        public int IdFuncion { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdTitulo { get; set; }
    }
}
