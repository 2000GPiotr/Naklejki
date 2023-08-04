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

            CreateMap<DocumentHeader, DocumentDto>()
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
