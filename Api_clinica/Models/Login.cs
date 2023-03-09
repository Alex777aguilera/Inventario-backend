using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string CodSistema { get; set; }
    }
}
