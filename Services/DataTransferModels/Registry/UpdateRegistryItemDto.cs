using Services.DataTransferModels.LabelStatus;
using Services.DataTransferModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Registry
{
    public class UpdateRegistryItemDto
    {
        public DateTime LabelEndTime { get; set; }
        public string LabelNumberPrefix { get; set; }
        public string LabelNumber { get; set; }
        public string LabelNumberSufix { get; set; }
        public string LabelTypeId { get; set; }
        public int UserId { get; set; }
        public string LabelStatusId { get; set; }
    }
}
