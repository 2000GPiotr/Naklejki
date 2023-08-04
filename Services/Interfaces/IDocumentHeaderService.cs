using Services.DataTransferModels.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentHeaderService
    {
        Task<List<DocumentDto>> GetAllDocuments();
        Task<DocumentDto> AddDocument(AddDocumentDto documentDto);
        Task<DocumentDto> GetDocumentById(int id);
        Task<DocumentDto> UpdateDocument(UpdateDocumentHeaderDto documentDto, int id);
        Task<DocumentDto> DeleteDocument(int id);
        Task<List<DocumentDto>> GetDocumentsByType(string symbol);
        Task<List<DocumentDto>> GetDocumentsByUserId(int id);
    }
}
