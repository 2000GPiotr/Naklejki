using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string? Description { get; set; }
    }
}
