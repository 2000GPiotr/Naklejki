using AutoMapper;
using Database;
using Database.Entities;
using Services.DataTransferModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DocumentHeaderService : IDocumentHeaderService
    {
        public readonly LabelDbContext _dbContext;
        public readonly IMapper _mapper;

        public DocumentHeaderService(LabelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DocumentHeaderDto> CreateDocumentHeader(DocumentHeaderDto documentHeaderDto)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == documentHeaderDto.UserId);

            var header = new DocumentHeader()
            {
                DocumentType = documentHeaderDto.DocumentType,
                Year = documentHeaderDto.Year,
                Number = documentHeaderDto.Number,
                Date = documentHeaderDto.Date,
                UserId = documentHeaderDto.UserId,
                Description = documentHeaderDto.Description,
                User = user
            };

            await _dbContext.DocumentHeaders.AddAsync(header);
            await _dbContext.SaveChangesAsync();

            return documentHeaderDto;
        }

        public Task<LabelTypeDto> DeleteDocumentHeaderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DocumentHeaderDto>> GetAllDocumentHeader()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentHeaderDto> GetDocumentHeaderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DocumentHeader> UpdateDocumentHeaderById(int id, DocumentHeaderDto documentHeaderDto)
        {
            throw new NotImplementedException();
        }
    }
}
