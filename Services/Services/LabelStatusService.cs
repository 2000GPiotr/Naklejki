using AutoMapper;
using Repository.Interfaces;
using Services.DataTransferModels.LabelStatus;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LabelStatusService : ILabelStatusService
    {
        private readonly ILabelStatusRepository _labelStatusRepository;
        private readonly IMapper _mapper;
        public LabelStatusService(ILabelStatusRepository labelStatusRepository, IMapper mapper)
        {
            _labelStatusRepository = labelStatusRepository;
            _mapper = mapper;
        }
        public async Task<LabelStatusDto> GetLabelStatusBySymbol(string symbol)
        {
            var status = await _labelStatusRepository.GetLabelStatusBySymbol(symbol);

            if (status == null)
                throw new Exception("Wrong Status Symbol");

            var toReturn = _mapper.Map<LabelStatusDto>(status);
            return toReturn;
        }

        public async Task<List<LabelStatusDto>> GetLabelStatuses()
        {
            var statuses = await _labelStatusRepository.GetAllLabelStatus();
            var toReturn = _mapper.Map<List<LabelStatusDto>>(statuses);
            return toReturn;
        }
    }
}
