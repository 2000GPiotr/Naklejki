using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Roles
    {
        [Key]
        public int Key { get; set; }
        public string Nazwa { get; set; }
        public string? Description { get; set; }

        // Relations
        public List<User> Users = new List<User>();
    }
}

        //Admin,
        //Director,
        //User