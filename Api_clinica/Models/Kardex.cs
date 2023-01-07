using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Kardex
    {
        public int cod_correlative { get; set; }
        public int type_move { get; set; }
        public int cod_store { get; set; }
        public Boolean origin_product { get; set; }
        public string cod_prod { get; set; }
        public int n_tranzability { get; set; }
        public string reference { get; set; }
        public int quantity { get; set; }
        public string cod_lot { get; set; }
        public string cod_employed { get; set; }
        public string user_register { get; set; }
        public DateTime date_exp { get; set;} 
        public DateTime date_create { get; set; }

    }
}
