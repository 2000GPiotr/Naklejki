using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities.Enums;

namespace Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Relations
        public ICollection<Roles> Roles { get; set; } = new List<Roles>();
        public Password Password { get; set; }
        public int PasswordId { get; set; }
    }
}
