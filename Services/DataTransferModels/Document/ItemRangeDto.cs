using Services.DataTransferModels.LabelType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Document
{
    public class ItemRangeDto
    {
        public string Id { get; set; }
        public string LabelTypeSymbol { get; set; }
        public ItemDto FirstItem { get; set; }
        public ItemDto LastItem { get; set; }
    }
}
