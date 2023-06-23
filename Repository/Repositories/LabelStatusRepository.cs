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
    public class LabelStatusRepository : ILabelStatusRepository
    {
        private readonly LabelDbContext _dbContext;
        public LabelStatusRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LabelStatus>> GetAllLabelStatus()
        {
            return await _dbContext
                .LabelStatus
                .ToListAsync();
        }

        public async Task<LabelStatus?> GetLabelStatusBySymbol(string symbol)
        {
            return await _dbContext
                .LabelStatus
                .FirstOrDefaultAsync(s => s.Symbol == symbol);
        }
    }
}
