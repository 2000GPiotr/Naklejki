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
        Task<DocumentDto> GetDocument(int id);
        Task<DocumentDto> UpdateDocument(UpdateDocumentDto documentDto, int id);
        Task<DocumentDto> DeleteDocument(int id);
        Task<List<DocumentDto>> GetDocumentByType(string symbo);
        Task<List<DocumentDto>> GetDocumentByUserId(int id);
    }
}
