using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Detail_Kardex
    {
        public int detail_id { get; set; }
        public int header_id { get; set; }
        public string cod_store { get; set; }
        public int id_detail_lot { get; set; }
        public int quantity { get; set; }
        public string cod_employed { get; set; }
        public int date_create { get; set; }
        public string user_register { get; set; }
    }
}
