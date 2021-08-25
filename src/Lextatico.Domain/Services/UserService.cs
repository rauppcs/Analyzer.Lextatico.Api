using System;
using System.Threading.Tasks;
using Lextatico.Domain.Interfaces.Services;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserService(ITokenService tokenService, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager)
        {
            _tokenService = tokenService;
            _userManger = userManger;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password)
        {
            var result = await _userManger.CreateAsync(applicationUser, password);

            return result;
        }

        public async Task<SignInResult> SignInAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);

            return result;
        }

        public async Task UpdateRefreshToken(string email, string refreshToken, DateTime refreshTokenExpiration)
        {
            var applicationUser = await _userManger.FindByEmailAsync(email);

            var refreshTokenModel = new RefreshTokenModel(refreshToken, DateTime.UtcNow, applicationUser.Id, applicationUser);

            applicationUser.RefreshTokens.Add(refreshTokenModel);
        }
    }
}
