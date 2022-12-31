using Database.Entities;
using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILabelTypeService
    {
        Task<IEnumerable<LabelTypeDto>> GetAllLabelTypes();
        Task<LabelTypeDto> GetLabelTypeBySymbol(string symbol);
        Task<LabelType> CreateLabelType(LabelTypeDto labelTypeDto);
        Task<LabelType> UpdateLabelTypeBySymbol(string symbol, UpdateLabelTypeDto labelTypeDto);
        Task<LabelTypeDto> DeleteLabelTypeBySymbol(string symbol);
    }
}
