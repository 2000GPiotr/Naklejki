using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRegistryRepository
    {
        Task AddRegistry(RegistryItem registry);    //?
        Task RemoveRegistry(RegistryItem registry);
        Task UpdateRegistry(RegistryItem registry);
        Task<List<RegistryItem>> GetAllRegistry(); //?
        Task<List<RegistryItem>> GetRegistryByStatus(string symbol);
        Task AddRegistryRange(List<RegistryItem> registry);
        Task<RegistryItem?> GetRegistryById(string labelNumberPrefix, string labelNumber, string labelNumberSufix, string labelTypeSymbol);
    }
}
