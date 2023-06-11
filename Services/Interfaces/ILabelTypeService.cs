using Database.Entities;
using Services.DataTransferModels.LabelType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILabelTypeService
    {
        Task<List<LabelTypeDto>> GetAllLabelTypes();
        Task<LabelTypeDto> GetLabelTypeBySymbol(string symbol);
        Task<LabelTypeDto> CreateLabelType(LabelTypeDto labelTypeDto);
        Task<LabelTypeDto> UpdateLabelTypeBySymbol(string symbol, UpdateLabelTypeDto labelTypeDto);
        Task<LabelTypeDto> DeleteLabelTypeBySymbol(string symbol);
    }
}
