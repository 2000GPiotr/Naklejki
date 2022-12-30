using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    internal class Items
    {
        public int Id { get; set; }
        public int Lp { get; set; }
        public string LabelNumber { get; set; }

        //Relations
        public DocumentHeader DocumentHeader { get; set; }
        public int DocumentHeaderId { get; set; }

        public LabelType LabelType { get; set; }
        public string LabelTypeId { get; set; }
    }
}
