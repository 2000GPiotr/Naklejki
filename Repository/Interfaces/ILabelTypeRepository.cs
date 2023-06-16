using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILabelTypeRepository
    {
        Task<List<LabelType>> GetAllLabelTypes();
        Task<LabelType?> GetLabelTypeBySymbol(string symbol);
        Task AddLabelType(LabelType labelType);
        Task UpdateLabelType(LabelType labelType);
        Task DeleteLabelType(LabelType labelType);
    }
}
