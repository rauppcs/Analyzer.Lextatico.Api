using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Application.Dtos.User;
using Lextatico.Application.Services.Interfaces;
using Lextatico.Domain.Dtos.Responses;
using Lextatico.Infra.Services.Interfaces;
using Lextatico.Infra.Services.Models.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers
{
    public class AccountController : LextaticoController
    {
        private readonly IUserAppService _userAppService;
        private readonly IEmailService _emailService;
        private readonly IResponse _response;

        public AccountController(IUserAppService userAppService, IEmailService emailService, IResponse response)
            : base(response)
        {
            _userAppService = userAppService;
            _emailService = emailService;
            _response = response;
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
        public async Task<IActionResult> ForgotPassword([FromBody] UserForgotPasswordDto userForgotPassword)
        {
            var result = await _userAppService.ForgotPasswordAsync(userForgotPassword);

            return ReturnOk(result);
        }

        [Route("[action]")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Teste()
        {
            await _emailService.SendEmailAsync(new EmailRequest
            {
                Name = "Cassiano",
                Email = "cassiano.raupp@outlook.com",
                Subject = "Teste Umbler",
                Body = "Umbler."
            });

            return Ok();
        }
    }
}
