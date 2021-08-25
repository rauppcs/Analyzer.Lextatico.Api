using System;

namespace Lextatico.Domain.Models
{
    public class RefreshTokenModel : BaseModel
    {
        public RefreshTokenModel()
        {
        }
        public RefreshTokenModel(string token, DateTime tokenExpiration, Guid idApplicationUser, ApplicationUser applicationUser)
        {
            Token = token;
            TokenExpiration = tokenExpiration;
            IdApplicationUser = idApplicationUser;
            ApplicationUser = applicationUser;
        }

        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public Guid IdApplicationUser { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}