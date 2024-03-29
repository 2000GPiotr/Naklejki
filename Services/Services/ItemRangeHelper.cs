﻿using Database.Entities;
using Repository.Interfaces;
using Services.DataTransferModels.Document;
using Services.DataTransferModels.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public static class ItemRangeHelper
    {
        public static List<Item> ConvertListItemRangesToItemList(List<ItemRangeDto> rangeList, DocumentHeader header)
        {
            var list = new List<Item>();
            foreach (var range in rangeList)
                list.AddRange(ItemRangeToList(range, header));

            return list;
        }

        private static List<Item> ItemRangeToList(ItemRangeDto itemRange, DocumentHeader header)
        {
            var prefix = itemRange.FirstItem.LabelNumberPrefix;
            var sufix = itemRange.FirstItem.LabelNumberSufix;
            var type = itemRange.LabelTypeSymbol;

            var firstNumber = Convert.ToInt64(itemRange.FirstItem.LabelNumber);
            var lastNumber = Convert.ToInt64(itemRange.LastItem.LabelNumber);

            var items = new List<Item>();

            for (var i = firstNumber; i <= lastNumber; i++)
            {
                var item = new Item()
                {
                    LabelNumberPrefix = prefix,
                    LabelNumberSufix = sufix,
                    LabelNumber = i.ToString("D4"),
                    DocumentHeader = header,
                    LabelTypeSymbol = type,
                };
                items.Add(item);
            }
            return items;
        }

        public static List<RegistryItem> ConvertListItemRangesToRegistryItemList(List<ItemRangeDto> rangeList, int? userId, string statusId, DateTime time)
        {
            var list = new List<RegistryItem>();
            foreach (var range in rangeList)
                list.AddRange(ItemRangeToRegistryItemList(range, userId, statusId, time));

            return list;
        }

        private static List<RegistryItem> ItemRangeToRegistryItemList(ItemRangeDto itemRange, int? userId, string statusId, DateTime time)
        {
            var prefix = itemRange.FirstItem.LabelNumberPrefix;
            var sufix = itemRange.FirstItem.LabelNumberSufix;
            var type = itemRange.LabelTypeSymbol;

            var firstNumber = Convert.ToInt64(itemRange.FirstItem.LabelNumber);
            var lastNumber = Convert.ToInt64(itemRange.LastItem.LabelNumber);

            var registryItems = new List<RegistryItem>();

            for (var i = firstNumber; i <= lastNumber; i++)
            {
                if (userId == null)
                    throw new Exception("Wrong UserId");

                var registryItem = new RegistryItem()
                {
                    LabelNumberPrefix = prefix,
                    LabelNumberSufix = sufix,
                    LabelNumber = i.ToString("D4"),
                    LabelTypeId = type,
                    UserId = (int)userId,
                    LabelStatusId = statusId,
                    LabelEndTime = time,
                };
                registryItems.Add(registryItem);
            }

            return registryItems;
        }

        public static List<UpdateRegistryItemDto> ConvertListItemRangesToUpdateRegistryItemList(List<ItemRangeDto> rangeList, int? userId, string statusId, DateTime time)
        {
            var list = new List<UpdateRegistryItemDto>();
            foreach (var range in rangeList)
                list.AddRange(ItemRangeToUpdateRegistryItemList(range, userId, statusId, time));

            return list;
        }

        private static List<UpdateRegistryItemDto> ItemRangeToUpdateRegistryItemList(ItemRangeDto itemRange, int? userId, string statusId, DateTime time)
        {
            var prefix = itemRange.FirstItem.LabelNumberPrefix;
            var sufix = itemRange.FirstItem.LabelNumberSufix;
            var type = itemRange.LabelTypeSymbol;

            var firstNumber = Convert.ToInt64(itemRange.FirstItem.LabelNumber);
            var lastNumber = Convert.ToInt64(itemRange.LastItem.LabelNumber);

            var registryItems = new List<UpdateRegistryItemDto>();

            for (var i = firstNumber; i <= lastNumber; i++)
            {
                if (userId == null)
                    throw new Exception("Wrong UserId");

                var registryItem = new UpdateRegistryItemDto()
                {
                    LabelNumberPrefix = prefix,
                    LabelNumberSufix = sufix,
                    LabelNumber = i.ToString("D4"),
                    LabelTypeId = type,
                    UserId = (int)userId,
                    LabelStatusId = statusId,
                    LabelEndTime = time,
                };
                registryItems.Add(registryItem);
            }

            return registryItems;
        }

        public static List<RegistryItemIdDto> ConvertListItemRangesToRegistryItemIdList(List<ItemRangeDto> itemRanges)
        {
            var list = new List<RegistryItemIdDto>();
            foreach (var itemRange in itemRanges)
                list.AddRange(ItemListToRegistryIdList(itemRange));

            return list;
        }

        private static List<RegistryItemIdDto> ItemListToRegistryIdList(ItemRangeDto itemRange)
        {
            var prefix = itemRange.FirstItem.LabelNumberPrefix;
            var sufix = itemRange.FirstItem.LabelNumberSufix;
            var type = itemRange.LabelTypeSymbol;

            var firstNumber = Convert.ToInt64(itemRange.FirstItem.LabelNumber);
            var lastNumber = Convert.ToInt64(itemRange.LastItem.LabelNumber);

            var registryItemsId = new List<RegistryItemIdDto>();

            for (var i = firstNumber; i <= lastNumber; i++)
            {
                var registryItem = new RegistryItemIdDto()
                {
                    LabelNumberPrefix = prefix,
                    LabelNumberSufix = sufix,
                    LabelNumber = i.ToString("D4"),
                    LabelTypeId = type
                };
                registryItemsId.Add(registryItem);
            }

            return registryItemsId;
        }
    }
}
