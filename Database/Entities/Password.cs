using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Round { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
