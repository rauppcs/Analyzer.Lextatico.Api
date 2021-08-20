using System;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Infra.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
