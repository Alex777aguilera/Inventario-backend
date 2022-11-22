using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Productos
    {   public int correlativo { get; set; }
        public string cod_prod { get; set; }
        public int id_type_p { get; set; }
        public string name_product { get; set; }
        public string full_name { get; set; }
        public DateTime creation_date { get; set; }
        public string user_register { get; set; }
        public string unit_price { get; set; }
    }
}
