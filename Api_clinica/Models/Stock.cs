using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Stock
    {
        public int cod_correlative { get; set; }
        public int cod_prod { get; set; }
        public int output_quantity { get; set; }
        public int input_quantity {get; set;}
        public string lot_number { get; set; }


    }
}
