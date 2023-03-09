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
        public int status_p { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string date_p { get; set; }
        public string days_p { get; set; }
        public string type_date { get; set; }
        public string diagnostic { get; set; }
        public DateTime creation_date { get; set; }
        public string n_tranzability { get; set; }
        public string user_register { get; set; }

    }
}
