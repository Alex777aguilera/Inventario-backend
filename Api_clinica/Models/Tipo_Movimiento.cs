﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Tippo Movimiento => Type_move

namespace Api_clinica.Models
{
    public class Tipo_Movimiento
    {
        public int id { get; set; }
        public string detail { get; set; }
        public int option_move { get; set; }
    }
}
