using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public int Lp { get; set; }
        public string LabelNumber { get; set; }
        public int DocumentHeaderId { get; set; }
        public string LabelTypeId { get; set; }

        //Relations
        public DocumentHeader DocumentHeader { get; set; }
        public LabelType LabelType { get; set; }
        public Registry Registry { get; set; }
    }
}
