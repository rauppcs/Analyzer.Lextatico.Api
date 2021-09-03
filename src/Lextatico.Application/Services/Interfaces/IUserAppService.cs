using System.Threading.Tasks;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Dtos.Responses;

namespace Lextatico.Application.Services.Interfaces
{
    public interface IUserAppService : IAppService
    {
        Task<Response> GetUserLoggedAsync();
        Task<Response> CreateAsync(UserSignInDto userSignIn);
        Task<Response> LogInAsync(UserLogInDto userLogIn);
        Task<Response> RefreshTokenAsync(UserRefreshDto userRefresh);
        Task<Response> ForgotPasswordAsync(UserForgotPasswordDto userForgotPassword);
    }
}
