using System.Threading.Tasks;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Dtos.Response;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Application.Services.Interfaces
{
    public interface IUserAppService : IAppService
    {
        Task<UserDetailDto> GetUserLoggedAsync();
        Task<bool> CreateAsync(UserSignInDto userSignIn);
        Task<AuthenticatedUserDto> LogInAsync(UserLogInDto userLogIn);
        Task<AuthenticatedUserDto> RefreshTokenAsync(UserRefreshDto userRefresh);
        Task<bool> ForgotPasswordAsync(UserForgotPasswordDto userForgotPassword);
        Task<bool> ResetPasswordAsync(UserResetPasswordDto userResetPassword);
    }
}
