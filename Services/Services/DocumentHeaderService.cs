﻿using AutoMapper;
using Database.Entities;
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
    public class DocumentHeaderService : IDocumentHeaderService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentHeaderRepository _documentHeaderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentHeaderService(
            IMapper mapper, 
            IDocumentHeaderRepository documentRepository,
            IUserRepository userRepository,
            IItemRepository itemRepository)
        {
            _mapper = mapper;
            _documentHeaderRepository = documentRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        public async Task<DocumentDto> AddDocument(AddDocumentDto documentDto)
        {
            var newDocument = _mapper.Map<DocumentHeader>(documentDto);

            if (documentDto.UserId == null)
            {
                newDocument.User = null;
            }
            else
            {
                var user = await _userRepository.GetUserById((int)documentDto.UserId);

                if (user == null)
                    throw new Exception("Wrong User Id");

                newDocument.User = user;
            }

            newDocument.DocumentType = await _documentTypeRepository.GetDocumentTypeBySymbol(documentDto.DocumentTypeSymbol);

            var items = ItemRangeHelper.ConvertListItemRangesToItemList(documentDto.ItemsList, newDocument);

            newDocument.Items = items;

            await _documentHeaderRepository.AddDocument(newDocument);

            var toReturn = _mapper.Map<DocumentDto>(newDocument);
            return toReturn;
        }

        public async Task<DocumentDto> DeleteDocument(int id)
        {
            var document = await _documentHeaderRepository.GetDocumentById(id);

            if (document == null)
                throw new Exception("Wrong document id");

            var toReturn = _mapper.Map<DocumentDto>(document);

            await _documentHeaderRepository.DeleteDocument(document);

            return toReturn;
        }

        public async Task<List<DocumentDto>> GetAllDocuments()
        {
            var documents = await _documentHeaderRepository.GetAllDocuments();

            var toReturn = _mapper.Map<List<DocumentDto>>(documents);

            return toReturn;
        }

        public async Task<DocumentDto> GetDocumentById(int id)
        {
            var document = await _documentHeaderRepository.GetDocumentById(id);

            var toReturn = _mapper.Map<DocumentDto>(document);

            return toReturn;         
        }

        public async Task<List<DocumentDto>> GetDocumentsByType(string symbol)
        {
            var documents = await _documentHeaderRepository.GetDocumentsByType(symbol);

            var toReturn = _mapper.Map<List<DocumentDto>>(documents);

            return toReturn;
        }

        public async Task<List<DocumentDto>> GetDocumentsByUserId(int id)
        {
            var documents = await _documentHeaderRepository.GetDocumentsByUserId(id);

            var toReturn = _mapper.Map<List<DocumentDto>>(documents);

            return toReturn;
        }

        public async Task<DocumentDto> UpdateDocument(UpdateDocumentHeaderDto documentDto, int id)
        {
            var document = await _documentHeaderRepository.GetDocumentById(id);

            _mapper.Map(documentDto, document);

            await _documentHeaderRepository.UpdateDocument(document);

            var toReturn = _mapper.Map<DocumentDto>(document);

            return toReturn;
        }
    }
}
