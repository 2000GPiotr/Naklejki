using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordPlain { get; set; }

        public List<Roles> Roles { get; set; } = new List<Roles>();
        //public string Password { get; set; }
    }
}
