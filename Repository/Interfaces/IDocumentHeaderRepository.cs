using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDocumentHeaderRepository
    {
        Task AddDocument(DocumentHeader documentHeader);
        Task DeleteDocument(DocumentHeader documentHeader);
        Task UpdateDocument(DocumentHeader documentHeader);
        Task<List<DocumentHeader>> GetAllDocuments();
        Task<DocumentHeader> GetDocumentById(int id);
        Task<List<DocumentHeader>> GetDocumentsByUserId(int userId);
        Task<List<DocumentHeader>> GetDocumentsByType(string symbol);
    }
}
