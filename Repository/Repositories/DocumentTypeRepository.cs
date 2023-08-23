using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly LabelDbContext _dbContext;
        public DocumentTypeRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DocumentType>> GetAllDocumentTypes()
        {
            return await _dbContext
                .DocumentTypes
                .ToListAsync();
        }

        public async Task<DocumentType?> GetDocumentTypeBySymbol(string symbol)
        {
            return await _dbContext
                .DocumentTypes
                .FirstOrDefaultAsync(t => t.Symbol == symbol);
        }
    }
}
