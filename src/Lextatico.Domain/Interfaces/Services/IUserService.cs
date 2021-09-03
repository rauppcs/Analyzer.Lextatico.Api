using System;
using System.Threading.Tasks;
using Lextatico.Domain.Dtos.Responses;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IUserService
    {
        (string token, string refreshToken) GenerateFullJwt(string email);
        Task<ApplicationUser> GetUserLoggedAsync();
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        ApplicationUser GetUserByRefreshToken(string refreshToken);
        Task<bool> CreateAsync(ApplicationUser applicationUser, string password);
        Task<bool> SignInAsync(string email, string password);
        Task UpdateRefreshTokenAsync(string email, string refreshToken, DateTime refreshTokenExpiration);
        Task<bool> ForgotPasswordAsync(string email);
    }
}
