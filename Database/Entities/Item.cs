using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Lp { get; set; }
        public string LabelNumberPrefix { get; set; }
        public string LabelNumber { get; set; }
        public string LabelNumberSufix { get; set; }
        public int DocumentHeaderId { get; set; }
        public string LabelTypeSymbol { get; set; }

        //Relations
        public DocumentHeader DocumentHeader { get; set; }
        public LabelType LabelType { get; set; }
        public RegistryItem Registry { get; set; }
    }
}
