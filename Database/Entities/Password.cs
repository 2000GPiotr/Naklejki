using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Password
    {
        [Key]
        public int Id { get; set; }
        public int Round { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }

        //Relations
        public User User { get; set; }
    }
}
