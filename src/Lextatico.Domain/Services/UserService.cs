using System;
using System.Collections.Generic;
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
        public Response Response { get; } = new();
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAspNetUser _aspNetUser;
        public UserService(ITokenService tokenService, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, IAspNetUser aspNetUser)
        {
            _tokenService = tokenService;
            _userManager = userManger;
            _signInManager = signInManager;
            _aspNetUser = aspNetUser;
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

            return await GetUserByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            return applicationUser;
        }

        public async Task<Response> CreateAsync(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                Response.Result = true;
            }
            else
            {
                Response.Result = false;
                foreach (var error in result.Errors)
                {
                    Response.AddError(string.Empty, error.Description);
                }
            }

            return Response;
        }

        public async Task<Response> SignInAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    Response.AddError(string.Empty, "Usuário bloqueado.");
                else if (result.IsNotAllowed)
                {
                    Response.AddError(string.Empty, "Usuário não está liberado para logar.");
                }
                else
                {
                    Response.AddError(string.Empty, "Usuário ou senha incorreto.");
                }
            }

            return Response;
        }

        public async Task UpdateRefreshTokenAsync(string email, string refreshToken, DateTime refreshTokenExpiration)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            var refreshTokenModel = new RefreshTokenModel(refreshToken, refreshTokenExpiration, applicationUser.Id, applicationUser);

            if (applicationUser.RefreshTokens == null)
                applicationUser.RefreshTokens = new List<RefreshTokenModel>();

            applicationUser.RefreshTokens.Add(refreshTokenModel);
        }

        public async Task<Response> ForgotPasswordAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            throw new NotImplementedException();
        }
    }
}
