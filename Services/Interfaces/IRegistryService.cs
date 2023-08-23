using Database.Entities;
using Services.DataTransferModels.Document;
using Services.DataTransferModels.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRegistryService
    {
        Task<List<RegistryItemDto>> GetAllRegistryItems();
        Task<RegistryItemDto> GetRegistryItemByNumber(RegistryItemIdDto registryItemId);
        Task<RegistryItemDto> AddRegistryItem(AddRegistryItemDto registryItemDto);
        Task<RegistryItemDto> DeleteRegistryItem(RegistryItemIdDto registryItemId);
        Task<RegistryItemDto> UpdateRegistryItem(RegistryItemDto registryItem); // ???
        Task HandleRegistryChanges(AddDocumentDto documentDto);
    }
}
