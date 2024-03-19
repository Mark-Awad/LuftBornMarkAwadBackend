using AutoMapper;
using LuftbornBackendApi.Dtos.Request;
using LuftbornBackendApi.Dtos.Response;
using LuftbornBackendCore.Entities;

namespace LuftbornBackendApi.Mapping
{
    public class UserMappingProfiles:Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<UserRequestDto, User>()
               .ForMember(dest => dest.ID, opt => opt.Ignore())
                 .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Fullname))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
               .ForMember(dest => dest.Role, opt => opt.Ignore())
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               ;

            CreateMap<RoleRequestDto, Role>()
                               .ForMember(dest => dest.ID, opt => opt.Ignore())
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
                               ;

            CreateMap<User, UserResponseDto>()
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                 .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Fullname))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               ;

            CreateMap<Role, RoleResponseDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               // .ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               //.ForMember(dest => dest., opt => opt.MapFrom(src => src.))
               ;

            CreateMap<UserRequestDto, UserResponseDto>();
        }

    }
}
