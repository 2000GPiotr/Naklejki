using Database.Entities;
using Services.DataTransferModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<RoleDto> Roles { get; set; } 
    }
}
