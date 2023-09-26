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
    public class RegistryRepository : IRegistryRepository
    {
        private readonly LabelDbContext _dbContext;
        public RegistryRepository(LabelDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddRegistry(RegistryItem registry)
        {
            await _dbContext.AddAsync(registry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRegistryRange(List<RegistryItem> registry)
        {
            await _dbContext.AddRangeAsync(registry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RegistryItem>> GetAllRegistry()
        {
            return await _dbContext
                .Registry
                .Include(i => i.LabelType)
                .Include(i => i.LabelStatus)
                .Include(i => i.User)
                .ToListAsync();
        }

        public async Task<List<RegistryItem>> GetRegistryByStatus(string symbol)
        {
            return await _dbContext
                .Registry
                .Include(i => i.LabelType)
                .Include(i => i.LabelStatus)
                .Where(i => i.LabelStatusId == symbol)
                .ToListAsync();
        }

        public async Task RemoveRegistry(RegistryItem registry)
        {
            _dbContext.Remove(registry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRegistry(RegistryItem registry)
        {
            _dbContext.Entry(registry).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateManyRegistryItems(List<RegistryItem> items)
        {
            foreach (var item in items)
                _dbContext.Entry(item).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<RegistryItem?> GetRegistryById(string labelNumberPrefix, string labelNumber, string labelNumberSufix, string labelTypeSymbol)
        {
            return await _dbContext
                .Registry
                .Include(i => i.LabelType)
                .Include(i => i.LabelStatus)
                .FirstOrDefaultAsync(r =>
                    r.LabelNumberPrefix == labelNumberPrefix &&
                    r.LabelNumber == labelNumber &&
                    r.LabelNumberSufix == labelNumberSufix &&
                    r.LabelTypeId == labelTypeSymbol);
        }
    }
}
