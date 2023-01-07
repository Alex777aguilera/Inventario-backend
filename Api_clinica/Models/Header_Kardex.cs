using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Header_Kardex
    {
        public int header_id { get; set; }
        public int type_move { get; set; }
        public string n_trazability { get; set; }
        public Boolean origin_product { get; set; }
        public string reference { get; set; }
        public DateTime date_tranzaction { get; set; }
        public DateTime date_create { get; set; }
        public string user_register { get; set; }
        public int id_enterprise { get; set; }
    }
}
