using Services.DataTransferModels.LabelStatus;
using Services.DataTransferModels.LabelType;
using Services.DataTransferModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Registry
{
    public class RegistryItemDto
    {
        public DateTime LabelEndTime { get; set; }
        public string LabelNumberPrefix { get; set; }
        public string LabelNumber { get; set; }
        public string LabelNumberSufix { get; set; }
        public string LabelTypeSymbol { get; set; }
        public BaseUserDto User { get; set; }
        public LabelStatusDto LabelStatus { get; set; }
    }
}
