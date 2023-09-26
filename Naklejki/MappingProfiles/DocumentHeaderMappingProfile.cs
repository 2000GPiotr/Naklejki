using AutoMapper;
using Database.Entities;
using Services.DataTransferModels.Document;

namespace API.MappingProfiles
{
    public class DocumentHeaderMappingProfile : Profile
    {
        public DocumentHeaderMappingProfile()
        {
            CreateMap<AddDocumentDto, DocumentHeader>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number));

            CreateMap<DocumentType, DocumentTypeDto>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Symbol));

            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.LabelTypeSymbol, opt => opt.MapFrom(src => src.LabelTypeSymbol))
                .ForMember(dest => dest.LabelNumberPrefix, opt => opt.MapFrom(src => src.LabelNumberPrefix))
                .ForMember(dest => dest.LabelNumber, opt => opt.MapFrom(src => src.LabelNumber))
                .ForMember(dest => dest.LabelNumberSufix, opt => opt.MapFrom(src => src.LabelNumberSufix));

            CreateMap<DocumentHeader, DocumentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
                .ForMember(dest => dest.ItemList, opt => opt.MapFrom(src => src.Items));

            CreateMap<UpdateDocumentHeaderDto, DocumentHeader>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number));
        }
    }
}
