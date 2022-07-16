using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.DTOS
{
    public class ModelosDTO
    {
        public long IdModelo { get; set; }
        public string Modelo { get; set; }
        public long idMarca { get; set; }
        public long IdGrupo { get; set; }
        public string Obs { get; set; }
    }
}
