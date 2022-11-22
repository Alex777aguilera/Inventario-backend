using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Empleados
    {
        public int id { get; set; }
        public string cod_employed { get; set; }
        public string names { get; set; }
        public string email { get; set; }
        public string charge { get; set; }
    }
}
