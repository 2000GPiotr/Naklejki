﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Document
{
    public class ItemDto
    {
        public string LabelTypeSymbol { get; set; }
        public string LabelNumberPrefix { get; set; }
        public string LabelNumber { get; set; }
        public string LabelNumberSufix { get; set; }
    }
}
