using System.Threading.Tasks;
using Lextatico.Application.Dtos.Responses;
using Lextatico.Application.Dtos.User;

namespace Lextatico.Application.Services.Interfaces
{
    public interface IUserAppService : IAppService
    {
        Task<Response> GetUserLoggedAsync();
        Task<Response> CreateAsync(UserSignInDto userSignIn);
        Task<Response> LogInAsync(UserLogInDto userLogIn);
        Task<Response> RefreshTokenAsync(UserRefreshDto userRefresh);
    }
}
