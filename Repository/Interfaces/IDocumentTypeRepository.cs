using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<List<DocumentType>> GetAllDocumentTypes();
        Task<DocumentType> GetDocumentTypeBySymbol(string symbol);
    }
}
