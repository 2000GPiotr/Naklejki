using AutoMapper;
using Database.Entities;
using Services.DataTransferModels.Roles;

namespace API.MappingProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Roles, RoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nazwa, opt => opt.MapFrom(src => src.Nazwa));

            CreateMap<RoleDto, Roles>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nazwa, opt => opt.MapFrom(src => src.Nazwa));
        }
    }
}
