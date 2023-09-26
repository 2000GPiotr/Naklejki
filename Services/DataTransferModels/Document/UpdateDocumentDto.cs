using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Document
{
    public class UpdateDocumentHeaderDto
    {
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
    }
}
