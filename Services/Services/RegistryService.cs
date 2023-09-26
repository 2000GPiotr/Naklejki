using AutoMapper;
using Database.Entities;
using Repository.Interfaces;
using Services.DataTransferModels.Document;
using Services.DataTransferModels.Registry;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RegistryService : IRegistryService
    {
        private readonly IMapper _mapper;
        private readonly IRegistryRepository _registryRepository;
        public RegistryService(IMapper mapper, IRegistryRepository registryRepository)
        {
            _mapper = mapper;
            _registryRepository = registryRepository;
        }

        public async Task<RegistryItemDto> AddRegistryItem(AddRegistryItemDto registryItemDto)
        {
            var newRegistryItem = _mapper.Map<RegistryItem>(registryItemDto);

            await _registryRepository.AddRegistry(newRegistryItem);

            var toReturn = _mapper.Map<RegistryItemDto>(newRegistryItem);
            return toReturn;
        }

        public async Task<List<RegistryItemDto>> AddManyRegistryItem(List<ItemRangeDto> itemRanges, int? userId, string statusId, DateTime time)
        {
            var newRegistryItems = ItemRangeHelper.ConvertListItemRangesToRegistryItemList(itemRanges, userId, statusId, time);

            await _registryRepository.AddRegistryRange(newRegistryItems);

            var toReturn = _mapper.Map<List<RegistryItemDto>>(newRegistryItems);
            return toReturn;
        }

        public async Task<RegistryItemDto> DeleteRegistryItem(RegistryItemIdDto registryItemId)
        {
            var registryItem = await _registryRepository.GetRegistryById(registryItemId.LabelNumberPrefix, registryItemId.LabelNumber, registryItemId.LabelNumberSufix, registryItemId.LabelTypeId);

            if (registryItem == null)
                throw new Exception("Wrong RegistryItemId");

            var toReturn = _mapper.Map<RegistryItemDto>(registryItem);

            await _registryRepository.RemoveRegistry(registryItem);
            return toReturn;
        }

        public async Task<List<RegistryItemDto>> GetAllRegistryItems()
        {
            var registryItems = await _registryRepository.GetAllRegistry();

            var toReturn = _mapper.Map<List<RegistryItemDto>>(registryItems);
            return toReturn;
        }

        public async Task<RegistryItemDto> GetRegistryItemByNumber(RegistryItemIdDto registryItemId)
        {
            var registryItem = await _registryRepository.GetRegistryById(registryItemId.LabelNumberPrefix, registryItemId.LabelNumber, registryItemId.LabelNumberSufix, registryItemId.LabelTypeId);

            if (registryItem == null)
                throw new Exception("Wrong RegistryItemId");

            var toReturn = _mapper.Map<RegistryItemDto>(registryItem);
            return toReturn;
        }

        public Task<RegistryItemDto> UpdateRegistryItem(RegistryItemDto registryItem)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RegistryItemDto>> UpdateManyRegistryItems(List<ItemRangeDto> itemRanges, int userId, string statusId, DateTime time)
        {
            var registryItemsNumber = ItemRangeHelper.ConvertListItemRangesToRegistryItemIdList(itemRanges);

            var items = new List<RegistryItem>();
            foreach (var number in registryItemsNumber)
            {
                var item = await _registryRepository.GetRegistryById(number.LabelNumberPrefix, number.LabelNumber, number.LabelNumberSufix, number.LabelTypeId);
                
                if(item == null)
                    throw new Exception("Somethink went wrong when taking registryItems");

                if (item.LabelStatusId != "Dostepna")
                    throw new Exception($"Naklejka nie jest dostepna; numer: {item.LabelType} {item.LabelNumberPrefix} {item.LabelNumber} {item.LabelNumberSufix}");

                items.Add(item);
            }

            foreach (var item in items)
            {
                item.LabelStatusId = statusId;
                item.UserId = userId;
                item.LabelEndTime = time;
            }


            await _registryRepository.UpdateManyRegistryItems(items);

            var toReturn = _mapper.Map<List<RegistryItemDto>>(items);

            return toReturn;
        }

        public async Task HandleRegistryChanges(AddDocumentDto documentDto)
        {
            var documentType = documentDto.DocumentTypeSymbol;

            switch(documentType)
            {
                case "Przyjecie":
                    await HandlePrzyjecieDocument(documentDto);
                    break;
                case "Wydanie":
                    await HandleWydanieDocument(documentDto);
                    break;
                default:
                    throw new Exception("Somethink went wrong in HandleRegistryChanges()");
            }
        }

        private async Task HandlePrzyjecieDocument(AddDocumentDto documentDto)
        {
            var status = "Dostepna";
            await AddManyRegistryItem(documentDto.ItemsList, documentDto.UserId, status, documentDto.Date);
        }

        private async Task HandleWydanieDocument(AddDocumentDto documentDto)
        {
            var status = "Wydana";
            await UpdateManyRegistryItems(documentDto.ItemsList, documentDto.UserId, status, documentDto.Date);
        }
    }
}
