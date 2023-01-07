using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clinica.Models
{
    [Table("Users")]
    public class Users
    {   [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime last_login { get; set; }
        public Boolean active { get; set; }
        public int user_type { get; set; }
        public string cod_employed { get; set; }
    }
}
