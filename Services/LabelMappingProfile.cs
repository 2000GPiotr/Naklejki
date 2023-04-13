using AutoMapper;
using Database.Entities;
using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LabelMappingProfile : Profile
    {
        public LabelMappingProfile()
        {
            CreateMap<Roles, RoleDto>()
                .ConvertUsing(d => new RoleDto(d.Id, d.Name, d.Description));

            CreateMap<RoleDto, Roles>()
                .ForMember(r => r.Id, d => d.MapFrom(r => r.Id))
                .ForMember(r => r.Name, d => d.MapFrom(r => r.Name))
                .ForMember(r => r.Description, d => d.MapFrom(r => r.Description));


            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.Name, u => u.MapFrom(s => s.Name))
                .ForMember(d => d.Surname, u => u.MapFrom(s => s.Surname));

            CreateMap<User, UserDto>()
                .ForMember(d => d.Name, u => u.MapFrom(u => u.Name))
                .ForMember(d => d.Surname, u => u.MapFrom(u => u.Surname))
                .ForMember(d => d.Roles, u => u.MapFrom(u=> u.Roles));

            CreateMap<UserDto, User>()
                .ForMember(d => d.Name, u => u.MapFrom(u => u.Name))
                .ForMember(d => d.Surname, u => u.MapFrom(u => u.Surname))
                .ForMember(d => d.Roles, u => u.MapFrom(u => u.Roles));
        }
    }
}
