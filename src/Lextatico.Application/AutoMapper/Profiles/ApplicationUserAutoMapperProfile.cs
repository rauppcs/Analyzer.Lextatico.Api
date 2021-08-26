using AutoMapper;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Models;

namespace Lextatico.Application.AutoMapper.Profiles
{
    public class ApplicationUserAutoMapperProfile : Profile
    {
        public ApplicationUserAutoMapperProfile()
        {
            // MODEL TO DTO
            CreateMap<UserSignInDto, ApplicationUser>()
                .ForMember(applicationUser => applicationUser.UserName,
                options => options.MapFrom(userSignin => userSignin.Email));

            // DTO TO MODEL
            CreateMap<ApplicationUser, UserDetailDto>();
        }
    }
}
