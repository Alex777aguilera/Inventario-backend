using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Stock
    {
        public int cod_correlative { get; set; }
        public int detail_lot { get; set; }
        public int cod_store {get; set;}
        public int total_quantity { get; set; }
        public DateTime date_create { get; set; }
    }
}
