using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.LabelType
{
    public class LabelTypeDto
    {
        public string Symbol { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
    }
}
