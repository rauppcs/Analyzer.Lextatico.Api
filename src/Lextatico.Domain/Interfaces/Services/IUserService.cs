using System;
using System.Threading.Tasks;
using Lextatico.Domain.Dtos.Responses;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Response Response { get; }
        (string token, string refreshToken) GenerateFullJwt(string email);
        Task<ApplicationUser> GetUserLoggedAsync();
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<Response> CreateAsync(ApplicationUser applicationUser, string password);
        Task<Response> SignInAsync(string email, string password);
        Task UpdateRefreshTokenAsync(string email, string refreshToken, DateTime refreshTokenExpiration);
        Task<Response> ForgotPasswordAsync(string email);
    }
}
