using AutoMapper;
using Database.Entities;
using Services.DataTransferModels.LabelType;

namespace API.MappingProfiles
{
    public class LabelTypeMappingProfile : Profile
    {
        public LabelTypeMappingProfile()
        {
            CreateMap<LabelTypeDto, LabelType>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));

            CreateMap<LabelType, LabelTypeDto>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));

            CreateMap<UpdateLabelTypeDto, LabelType>()
                .ForMember(dest => dest.Symbol, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));
        }
    }
}
