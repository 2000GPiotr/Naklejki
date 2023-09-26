using AutoMapper;
using Database.Entities;
using Services.DataTransferModels.Registry;
using Services.DataTransferModels.User;

namespace API.MappingProfiles
{
    public class RegistryItemMappingProfile : Profile
    {
        public RegistryItemMappingProfile()
        {
            CreateMap<AddRegistryItemDto, RegistryItem>()
                .ForMember(dest => dest.LabelTypeId, opt => opt.MapFrom(src => src.LabelTypeId))
                .ForMember(dest => dest.LabelNumberPrefix, opt => opt.MapFrom(src => src.LabelNumberPrefix))
                .ForMember(dest => dest.LabelNumber, opt => opt.MapFrom(src => src.LabelNumber))
                .ForMember(dest => dest.LabelNumberSufix, opt => opt.MapFrom(src => src.LabelNumberSufix))
                .ForMember(dest => dest.LabelStatusId, opt => opt.MapFrom(src => src.LabelStatusId))
                .ForMember(dest => dest.LabelEndTime, opt => opt.MapFrom(src => src.LabelEndTime))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UpdateRegistryItemDto, RegistryItem>()
                .ForMember(dest => dest.LabelStatusId, opt => opt.MapFrom(src => src.LabelStatusId))
                .ForMember(dest => dest.LabelEndTime, opt => opt.MapFrom(src => src.LabelEndTime))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<RegistryItem, RegistryItemDto>()
                .ForMember(dest => dest.LabelNumberPrefix, opt => opt.MapFrom(src => src.LabelNumberPrefix))
                .ForMember(dest => dest.LabelNumber, opt => opt.MapFrom(src => src.LabelNumber))
                .ForMember(dest => dest.LabelNumberSufix, opt => opt.MapFrom(src => src.LabelNumberSufix))
                .ForMember(dest => dest.LabelTypeSymbol, opt => opt.MapFrom(src => src.LabelType.Symbol))
                .ForMember(dest => dest.LabelStatus, opt => opt.MapFrom(src => src.LabelStatus))
                .ForMember(dest => dest.LabelEndTime, opt => opt.MapFrom(src => src.LabelEndTime))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<UpdateRegistryItemDto, RegistryItemIdDto>()
                .ForMember(dest => dest.LabelNumberPrefix, opt => opt.MapFrom(src => src.LabelNumberPrefix))
                .ForMember(dest => dest.LabelNumber, opt => opt.MapFrom(src => src.LabelNumber))
                .ForMember(dest => dest.LabelNumberSufix, opt => opt.MapFrom(src => src.LabelNumberSufix))
                .ForMember(dest => dest.LabelTypeId, opt => opt.MapFrom(src => src.LabelTypeId));

        }
    }
}
