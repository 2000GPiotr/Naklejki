
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.User
{
    public class UpdateUserDto
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> RolesId { get; set; }
    }
}
