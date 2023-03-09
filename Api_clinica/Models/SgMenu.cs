using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class SgMenu
    {
        public int IdMenu { get; set; }
        public string NombreMenu { get; set; }
        public string NombreLogico { get; set; }
        public int Nivel { get; set; }
        public string IdMenuPadre { get; set; }
        public string CodSistema { get; set; }
    }
}
