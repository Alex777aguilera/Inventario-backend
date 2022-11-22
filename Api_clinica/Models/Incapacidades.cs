using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Incapacidades
    {
        public int id { get; set; }
        public string cod_employed { get; set; }
        public string days { get; set; }
        public string condition { get; set; }
        public string diagnostic { get; set; }
        public DateTime creation { get; set; }
        public string user_register { get; set; }
    }
}
