using System.Threading.Tasks;
using Lextatico.Application.Dtos.User;

namespace Lextatico.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDetailDto> GetUserLoggedAsync();
        Task<bool> CreateAsync(UserSignInDto userSignIn);
        Task<bool> ForgotPasswordAsync(UserForgotPasswordDto userForgotPassword);
        Task<bool> ResetPasswordAsync(UserResetPasswordDto userResetPassword);
    }
}
