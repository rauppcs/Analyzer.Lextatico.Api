using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Dtos.Responses;
using Lextatico.Domain.Interfaces.Services;
using Lextatico.Domain.Models;
using Lextatico.Infra.Identity.User;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IResponse _response;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAspNetUser _aspNetUser;
        public UserService(ITokenService tokenService, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, IAspNetUser aspNetUser, IResponse response)
        {
            _tokenService = tokenService;
            _userManager = userManger;
            _signInManager = signInManager;
            _aspNetUser = aspNetUser;
            _response = response;
        }

        public (string token, string refreshToken) GenerateFullJwt(string email)
        {
            return _tokenService
                    .WithUserManager(_userManager)
                    .WithEmail(email)
                    .WithJwtClaims()
                    .WithUserClaims()
                    .WithUserRoles()
                    .BuildToken();
        }

        public async Task<ApplicationUser> GetUserLoggedAsync()
        {
            var email = _aspNetUser.GetUserEmail();

            var applicationUser = await GetUserByEmailAsync(email);

            if (applicationUser == null)
                _response.AddError("", "Usuário não encontrado");

            return applicationUser;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            if (applicationUser == null)
                _response.AddError("", "Usuário não encontrado");

            return applicationUser;
        }

        public ApplicationUser GetUserByRefreshToken(string refreshToken)
        {
            var applicationUser = _userManager.Users.FirstOrDefault(user => user.RefreshTokens
                    .Any(refresh => refresh.Token == refreshToken
                        && DateTime.UtcNow <= refresh.TokenExpiration));

            if (applicationUser == null)
                _response.AddError(string.Empty, "Token ou RefreshToken inválido, faça o login novamente.");

            return applicationUser;
        }

        public async Task<bool> CreateAsync(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
            {
                _response.AddResult(false);
                foreach (var error in result.Errors)
                {
                    _response.AddError(string.Empty, error.Description);
                }
            }

            return result.Succeeded;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    _response.AddError(string.Empty, "Usuário bloqueado.");
                else if (result.IsNotAllowed)
                    _response.AddError(string.Empty, "Usuário não está liberado para logar.");
                else
                    _response.AddError(string.Empty, "Usuário ou senha incorreto.");
            }

            return result.Succeeded;
        }

        public async Task UpdateRefreshTokenAsync(string email, string refreshToken, DateTime refreshTokenExpiration)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            var refreshTokenModel = new RefreshTokenModel(refreshToken, refreshTokenExpiration, applicationUser.Id, applicationUser);

            if (applicationUser.RefreshTokens == null)
                applicationUser.RefreshTokens = new List<RefreshTokenModel>();

            applicationUser.RefreshTokens.Add(refreshTokenModel);
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            throw new NotImplementedException();
        }
    }
}
