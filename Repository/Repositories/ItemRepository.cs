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
    public class ItemRepository : IItemRepository
    {
        private readonly LabelDbContext _dbContext;
        public ItemRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItem(Item item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddItemRange(List<Item> items)
        {
            await _dbContext.AddRangeAsync(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Item item)
        {
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItemRange(List<Item> items)
        {
            _dbContext.Items.RemoveRange(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Item>> GetItemByDocumentId(int id)
        {
            return await _dbContext
                .Items
                .Include(i => i.LabelType)
                .Where(i => i.DocumentHeaderId == id)
                .ToListAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
