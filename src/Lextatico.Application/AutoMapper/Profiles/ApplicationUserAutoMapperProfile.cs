using AutoMapper;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Models;

namespace Lextatico.Application.AutoMapper.Profiles
{
    public class ApplicationUserAutoMapperProfile : Profile
    {
        public ApplicationUserAutoMapperProfile()
        {
            CreateMap<UserSignInDto, ApplicationUser>()
                .ForMember(applicationUser => applicationUser.UserName,
                options => options.MapFrom(userSignin => userSignin.Email));

        }
    }
}
