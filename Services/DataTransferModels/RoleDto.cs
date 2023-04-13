using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels
{
    public class RoleDto
    {
        public RoleDto(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
