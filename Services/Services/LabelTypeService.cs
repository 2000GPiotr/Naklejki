using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.DataTransferModels.LabelType;
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
        private readonly ILabelTypeRepository _labelTypeRepository;
        private readonly IMapper _mapper;
        public LabelTypeService(ILabelTypeRepository labelTypeRepository, IMapper mapper)
        {
            _labelTypeRepository = labelTypeRepository;
            _mapper = mapper;
        }

        public async Task<LabelTypeDto> CreateLabelType(LabelTypeDto labelTypeDto)
        {
            var newLabelType = _mapper.Map<LabelType>(labelTypeDto);

            await _labelTypeRepository.AddLabelType(newLabelType);

            var toReturn = _mapper.Map<LabelTypeDto>(newLabelType);
            return toReturn;
        }

        public async Task<List<LabelTypeDto>> GetAllLabelTypes()
        {
            var labels = await _labelTypeRepository.GetAllLabelTypes();

            var toReturn = _mapper.Map<List<LabelTypeDto>>(labels);
            return toReturn;
        }

        public async Task<LabelTypeDto> DeleteLabelTypeBySymbol(string symbol)
        {
            var labelType = await _labelTypeRepository.GetLabelTypeBySymbol(symbol);

            if (labelType == null)
                throw new Exception(String.Format("No LabelType with symbol: {0}", symbol)); // TODO

            var toReturn = _mapper.Map<LabelTypeDto>(labelType);

            await _labelTypeRepository.DeleteLabelTypeBySymbol(symbol);
            return toReturn;
            
        }

        public async Task<LabelTypeDto> GetLabelTypeBySymbol(string symbol)
        {
            var labelType = await _labelTypeRepository.GetLabelTypeBySymbol(symbol);

            if (labelType == null)
                throw new Exception("Wrong labelType Symbol");

            var toReturn = _mapper.Map<LabelTypeDto>(labelType);
            return toReturn;
        }

        public async Task<LabelTypeDto> UpdateLabelTypeBySymbol(string symbol, UpdateLabelTypeDto labelTypeDto)
        {
            var labelType = await _labelTypeRepository.GetLabelTypeBySymbol(symbol);

            if (labelType == null)
                throw new Exception("Wrong LabelType Symbol");

            labelType.Description = labelTypeDto.Description;
            labelType.Count = labelTypeDto.Count;

            await _labelTypeRepository.UpdateLabelType(labelType);

            var toReturn = _mapper.Map<LabelTypeDto>(labelType);
            return toReturn;
        }
    }
}
