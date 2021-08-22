using System;
using System.Threading.Tasks;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password);
        Task<SignInResult> SignInAsync(string email, string password);
        Task UpdateRefreshToken(string email, string refreshToken, DateTime refreshTokenExpiration);
    }
}
