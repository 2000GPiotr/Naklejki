using Database.Entities;
using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentHeaderService
    {
        Task<IEnumerable<DocumentHeaderDto>> GetAllDocumentHeader();
        Task<DocumentHeaderDto> GetDocumentHeaderById(int id);
        Task<DocumentHeaderDto> CreateDocumentHeader(DocumentHeaderDto documentHeaderDto);
        Task<DocumentHeader> UpdateDocumentHeaderById(int id, DocumentHeaderDto documentHeaderDto);
        Task<LabelTypeDto> DeleteDocumentHeaderById(int id);
    }
}
