﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Registry
    {
        public DateTime LabelEndTime { get; set; }
        public string LabelNumber { get; set; }
        public string LabelTypeId { get; set; }
        public int UserId { get; set; }
        public string LabelStatusId { get; set; }

        //Relations
        public LabelType LabelType { get; set; }
        public User User { get; set; }
        public List<Items> Items { get; set; } = new List<Items>();
        public LabelStatus LabelStatus { get; set; }
    }   
}
