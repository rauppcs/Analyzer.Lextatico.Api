using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lextatico.Domain.Interfaces.Services;
using Lextatico.Domain.Models;
using Lextatico.Infra.Identity.User;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Services
{
    public class UserService : IUserService
    {
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

        public async Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);

            return result;
        }

        public async Task<SignInResult> SignInAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);

            return result;
        }

        public async Task UpdateRefreshToken(string email, string refreshToken, DateTime refreshTokenExpiration)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            var refreshTokenModel = new RefreshTokenModel(refreshToken, refreshTokenExpiration, applicationUser.Id, applicationUser);

            if (applicationUser.RefreshTokens == null)
                applicationUser.RefreshTokens = new List<RefreshTokenModel>();

            applicationUser.RefreshTokens.Add(refreshTokenModel);
        }
    }
}
