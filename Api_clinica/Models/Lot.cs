﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    public class Lot
    {
        public int correlative { get; set; }
        public string cod_lot { get; set; }
        public DateTime date_create { get; set; }
    }
}
