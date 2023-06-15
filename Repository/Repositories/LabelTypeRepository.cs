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
    public class LabelTypeRepository : ILabelTypeRepository
    {
        private readonly LabelDbContext _dbContext;

        public LabelTypeRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task AddLabelType(LabelType labelType)
        {
            await _dbContext.LabelTypes.AddAsync(labelType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLabelTypeBySymbol(string symbol)
        {
            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == symbol);

            if (labelType == null)
                throw new Exception("LabelType not found");

            _dbContext.LabelTypes.Remove(labelType);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<LabelType>> GetAllLabelTypes()
        {
            return await _dbContext
                .LabelTypes
                .ToListAsync();
        }

        public async Task<LabelType?> GetLabelTypeBySymbol(string symbol)
        {
            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == symbol);

            return labelType;
        }

        public async Task UpdateLabelType(LabelType labelType)
        {
            _dbContext.Entry(labelType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
