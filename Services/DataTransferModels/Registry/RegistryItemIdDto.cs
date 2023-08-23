using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Registry
{
    public class RegistryItemIdDto
    {
        public string LabelNumberPrefix { get; set; }
        public string LabelNumber { get; set; }
        public string LabelNumberSufix { get; set; }
        public string LabelTypeId { get; set; }
    }
}
