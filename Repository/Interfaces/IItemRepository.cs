using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IItemRepository
    {
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Item item);
        Task<List<Item>> GetItemByDocumentId(int id);
        Task AddItemRange(List<Item> items);
        Task DeleteItemRange(List<Item> items);
    }
}
