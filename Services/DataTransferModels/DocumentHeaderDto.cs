using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels
{
    public class DocumentHeaderDto
    {
        public int Id { get; set; }
        public Database.Entities.DocumentType DocumentType { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;

        //Relations 
        public int UserId { get; set; }
        public List<ItemsDto> Items { get; set; } = new List<ItemsDto>();
    }
}
