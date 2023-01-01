using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LabelTypeService : ILabelTypeService
    {
        private readonly LabelDbContext _dbContext;
        public LabelTypeService(LabelDbContext bdContext)
        {
            _dbContext = bdContext;
        }

        public async Task<LabelType> CreateLabelType(LabelTypeDto labelTypeDto)
        {
            var newLabelType = new LabelType() { Symbol = labelTypeDto.Symbol, Count = labelTypeDto.Count, Description = labelTypeDto.Description };

            await _dbContext.AddAsync(newLabelType);
            await _dbContext.SaveChangesAsync();

            return newLabelType;
        }

        public async Task<IEnumerable<LabelTypeDto>> GetAllLabelTypes()
        {
            var labels = await _dbContext
                .LabelTypes
                .ToListAsync();

            var toReturn = new List<LabelTypeDto>();

            foreach(var labelType in labels)
            {
                toReturn.Add(new LabelTypeDto() { Count = labelType.Count, Symbol = labelType.Symbol, Description = labelType.Description });
            }
            return toReturn;
        }

        public async Task<LabelTypeDto> DeleteLabelTypeBySymbol(string symbol)
        {
            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(x => x.Symbol == symbol);

            if (labelType == null)
                throw new Exception(String.Format("No LabelType with symbol: {0}", symbol)); // TODO

            var toReturn = new LabelTypeDto() { Count = labelType.Count, Symbol = labelType.Symbol, Description = labelType.Description };

            _dbContext.LabelTypes.Remove(labelType);
            await _dbContext.SaveChangesAsync();

            return toReturn;
        }

        public async Task<LabelTypeDto> GetLabelTypeBySymbol(string symbol)
        {
            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(x => x.Symbol == symbol);

            var toReturn = new LabelTypeDto() { Count = labelType.Count, Symbol = labelType.Symbol, Description = labelType.Description };

            return toReturn;
        }

        public async Task<LabelType> UpdateLabelTypeBySymbol(string symbol, UpdateLabelTypeDto labelTypeDto)
        {
            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(x => x.Symbol == symbol);
 
            labelType.Count = labelTypeDto.Count;
            labelType.Description = labelTypeDto.Description;

            await _dbContext.SaveChangesAsync();
            return labelType;
        }
    }
}
