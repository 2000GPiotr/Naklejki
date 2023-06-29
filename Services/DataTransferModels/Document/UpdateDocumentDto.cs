using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Document
{
    public class UpdateDocumentDto
    {
        public string DocumentTypeSymbol { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public List<ItemRangeTypeDto> ItemsList { get; set; } = new List<ItemRangeTypeDto>();
    }
}
