using Database.Entities;
using Services.DataTransferModels.Document;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestsServices
{
    public class ItemRangeHelperTests
    {
        [Fact]
        public void ItemRangeToListTest_Base()
        {
            // Arrange
            var itemRange = new ItemRangeDto()
            {
                FirstItem = new CreateItemDto()
                {
                    LabelNumberPrefix = "A",
                    LabelNumber = "1",
                    LabelNumberSufix = ""
                },
                LastItem = new CreateItemDto()
                {
                    LabelNumberPrefix = "A",
                    LabelNumber = "3",
                    LabelNumberSufix = ""
                },
                LabelTypeSymbol = "S2"
            };

            var header = new DocumentHeader()
            {
                Id = 1,
                Number = 1,
                Date = DateTime.Now,
                User = null,
                Description = "abc",
                Year = 2020,
                DocumentType = new DocumentType()
                {
                    Symbol = "D1",
                    Description = "efg"
                },
            };

            Type type = typeof(ItemRangeHelper);
            MethodInfo method = type.GetMethod("ItemRangeToList", BindingFlags.NonPublic | BindingFlags.Static);


            // Act
            List<Item> items = (List<Item>)method.Invoke(null, new object[] { itemRange, header }); // Czy to jest ok?

            // Assert
            Assert.NotNull(method);
            Assert.NotNull(items);
            Assert.Equal(3, items.Count);
            Assert.Equal(header, items[0].DocumentHeader);
            Assert.Equal(header, items[1].DocumentHeader);
            Assert.Equal(header, items[2].DocumentHeader);
            Assert.Equal("0002", items[1].LabelNumber);
            Assert.Equal("A", items[1].LabelNumberPrefix);
            Assert.Equal("", items[1].LabelNumberSufix);
            Assert.Equal("S2", items[1].LabelTypeSymbol);
        }

        [Fact]
        public void ConvertListItemRangesToItemListTest_Base()
        {
            // Arrange
            var itemRanges = new List<ItemRangeDto>()
            {
                new ItemRangeDto()
                {
                    FirstItem = new CreateItemDto()
                    {
                        LabelNumberPrefix = "A",
                        LabelNumber = "1",
                        LabelNumberSufix = ""
                    },
                    LastItem = new CreateItemDto()
                    {
                        LabelNumberPrefix = "A",
                        LabelNumber = "3",
                        LabelNumberSufix = ""
                    },
                    LabelTypeSymbol = "S2"
                },
                new ItemRangeDto()
                {
                    FirstItem = new CreateItemDto()
                    {
                        LabelNumberPrefix = "",
                        LabelNumber = "1",
                        LabelNumberSufix = "B"
                    },
                    LastItem = new CreateItemDto()
                    {
                        LabelNumberPrefix = "",
                        LabelNumber = "4",
                        LabelNumberSufix = "B"
                    },
                    LabelTypeSymbol = "S3"
                }
            };  
            
            var header = new DocumentHeader()
            {
                Id = 1,
                Number = 1,
                Date = DateTime.Now,
                User = null,
                Description = "abc",
                Year = 2020,
                DocumentType = new DocumentType()
                {
                    Symbol = "D1",
                    Description = "efg"
                },
            };

            // Act
            var items = ItemRangeHelper.ConvertListItemRangesToItemList(itemRanges, header);

            // Assert
            Assert.NotNull(items);
            Assert.Equal(7, items.Count);
            Assert.All(items, i => Assert.Equal(header, i.DocumentHeader));
            
            Assert.Equal("0002", items[1].LabelNumber);
            Assert.Equal("A", items[1].LabelNumberPrefix);
            Assert.Equal("", items[1].LabelNumberSufix);
            Assert.Equal("S2", items[1].LabelTypeSymbol);
            
            Assert.Equal("0003", items[5].LabelNumber);
            Assert.Equal("", items[5].LabelNumberPrefix);
            Assert.Equal("B", items[5].LabelNumberSufix);
            Assert.Equal("S3", items[5].LabelTypeSymbol);

        }
    }
}
