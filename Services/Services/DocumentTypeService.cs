using AutoMapper;
using Repository.Interfaces;
using Services.DataTransferModels.Document;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;
        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<DocumentTypeDto>> GetAllDocumentTypes()
        {
            var documentTypes = await _documentTypeRepository.GetAllDocumentTypes();

            var toReturn = _mapper.Map<List<DocumentTypeDto>>(documentTypes);
            return toReturn;
        }

        public Task<DocumentTypeDto> UpdateDocumentType(string symbol, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
