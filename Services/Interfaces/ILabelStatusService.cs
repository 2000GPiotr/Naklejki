using Services.DataTransferModels.LabelStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILabelStatusService
    {
        Task<List<LabelStatusDto>> GetLabelStatuses();
        Task<LabelStatusDto> GetLabelStatusBySymbol(string symbol);
    }
}
