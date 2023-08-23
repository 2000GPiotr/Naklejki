using Services.DataTransferModels.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<List<DocumentTypeDto>> GetAllDocumentTypes();
        Task<DocumentTypeDto> UpdateDocumentType(string symbol, string newDescription);
    }
}
