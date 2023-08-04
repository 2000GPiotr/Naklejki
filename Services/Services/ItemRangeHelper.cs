using Database.Entities;
using Repository.Interfaces;
using Services.DataTransferModels.Document;
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
            var sufix = itemRange.FirstItem.LabelNumberSuffix;
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
    }
}
