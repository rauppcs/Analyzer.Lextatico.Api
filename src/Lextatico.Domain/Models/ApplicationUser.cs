using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public ICollection<RefreshTokenModel> RefreshTokens { get; set; }
    }
}
