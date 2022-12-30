using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Registry
    {
        public Enums.LabelStatus LabelStatus { get; set; }
        public DateTime LabelEndTime { get; set; }
        public string LabelNumber { get; set; }

        //Relations
        public LabelType LabelType { get; set; }
        public string LabelTypeId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
