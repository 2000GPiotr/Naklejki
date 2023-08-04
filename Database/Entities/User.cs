using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Relations

        public Password Password { get; set; }
        public List<DocumentHeader> DocumentHeaders  { get; set; } = new List<DocumentHeader>();
        public List<RegistryItem> Registries { get; set; } = new List<RegistryItem>();
        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
}
