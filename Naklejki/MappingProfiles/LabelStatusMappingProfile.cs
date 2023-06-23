using AutoMapper;
using Database.Entities;
using Services.DataTransferModels.LabelStatus;

namespace API.MappingProfiles
{
    public class LabelStatusMappingProfile : Profile
    {
        public LabelStatusMappingProfile()
        {
            CreateMap<LabelStatus, LabelStatusDto>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<LabelStatusDto, LabelStatus>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
