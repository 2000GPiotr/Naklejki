using Services.DataTransferModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Document
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public DocumentTypeDto DocumentType { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public UserDto? User { get; set; }
        public List<ItemDto> ItemList { get; set; } = new List<ItemDto>();
    }
}
