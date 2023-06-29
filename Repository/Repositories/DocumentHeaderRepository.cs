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
    public class DocumentHeaderRepository : IDocumentRepository
    {
        private readonly LabelDbContext _dbContext;
        public DocumentHeaderRepository(LabelDbContext dbContext)
        {
            _dbContext =dbContext;
        }
        public async Task AddDocument(DocumentHeader documentHeader)
        {
            await _dbContext.AddAsync(documentHeader);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDocument(DocumentHeader documentHeader)
        {
            _dbContext.DocumentHeaders.Remove(documentHeader);
            _dbContext.SaveChangesAsync();
        }

        public async Task<List<DocumentHeader>> GetAllDocuments()
        {
            return await _dbContext
                .DocumentHeaders
                .Include(h => h.User)
                .Include(h => h.DocumentType)
                .Include(h => h.Items)
                .ToListAsync();
        }

        public async Task<DocumentHeader?> GetDocumentById(int id)
        {
            return await _dbContext
                .DocumentHeaders
                .Include(h => h.User)
                .Include(h => h.DocumentType)
                .Include(h => h.Items)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<DocumentHeader>> GetDocumentByType(string symbol)
        {
            return await _dbContext
                .DocumentHeaders
                .Include(h => h.User)
                .Include(h => h.DocumentType)
                .Include(h => h.Items)
                .Where(h => h.DocumentType.Symbol == symbol)
                .ToListAsync();
        }

        public async Task<List<DocumentHeader>> GetDocumentByUserId(int userId)
        {
            return await _dbContext
                .DocumentHeaders
                .Include(h => h.User)
                .Include(h => h.DocumentType)
                .Include(h => h.Items)
                .Where(h => h.User.Id == userId)
                .ToListAsync();
        }

        public async Task UpdateDocument(DocumentHeader documentHeader)
        {
            _dbContext.Entry(documentHeader).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
