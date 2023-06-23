using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILabelStatusRepository
    {
        Task<List<LabelStatus>> GetAllLabelStatus();
        Task<LabelStatus?> GetLabelStatusBySymbol(string symbol);
    }
}
