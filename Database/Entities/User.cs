using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities.Enums;

namespace Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Relations
        public List<Roles> Roles { get; set; } = new List<Roles>();
        public Password Password { get; set; }
        public List<DocumentHeader> DocumentHeaders  { get; set; } = new List<DocumentHeader>();
        public List<Registry> Registries { get; set; } = new List<Registry>();
    }
}
