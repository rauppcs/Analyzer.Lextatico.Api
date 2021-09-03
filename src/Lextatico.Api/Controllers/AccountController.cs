using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Application.Dtos.User;
using Lextatico.Application.Services.Interfaces;
using Lextatico.Infra.Services.Interfaces;
using Lextatico.Infra.Services.Models.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers
{
    public class AccountController : MyControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IEmailService _emailService;
        public AccountController(IUserAppService userAppService, IEmailService emailService)
        {
            _userAppService = userAppService;
            _emailService = emailService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var result = await _userAppService.GetUserLoggedAsync();

            return ReturnOk(result);
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogInDto userLogin)
        {
            var result = await _userAppService.LogInAsync(userLogin);

            return ReturnOk(result);
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromBody] UserSignInDto userSignIn)
        {
            var result = await _userAppService.CreateAsync(userSignIn);

            return ReturnCreated(result);
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] UserRefreshDto userRefresh)
        {
            var result = await _userAppService.RefreshTokenAsync(userRefresh);

            return ReturnOk(result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult ValidateToken()
        {
            return ReturnOk();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Forgot([FromBody] UserForgotPasswordDto userForgotPassword)
        {
            var result = await _userAppService.ForgotPasswordAsync(userForgotPassword);

            return ReturnOk(result);
        }
    }
}
