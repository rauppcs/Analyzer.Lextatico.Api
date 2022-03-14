using AutoMapper;
using Analyzer.Lextatico.Application.Dtos.User;
using Analyzer.Lextatico.Domain.Models;

namespace Analyzer.Lextatico.Application.AutoMapper.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            // DTO TO MODEL
            CreateMap<UserSignInDto, ApplicationUser>()
                .ForMember(applicationUser => applicationUser.UserName,
                options => options.MapFrom(userSignin => userSignin.Email));

            // MODEL TO DTO
            CreateMap<ApplicationUser, UserDetailDto>();
        }
    }
}
