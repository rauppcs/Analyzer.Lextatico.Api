using System;

namespace Lextatico.Domain.Models
{
    public class RefreshToken : Base
    {
        public RefreshToken()
            // : base(DateTime.UtcNow)
        {
        }
        public RefreshToken(string token, DateTime tokenExpiration, Guid applicationUserId, ApplicationUser applicationUser)
            // : base(DateTime.UtcNow)
        {
            Token = token;
            TokenExpiration = tokenExpiration;
            ApplicationUserId = applicationUserId;
            ApplicationUser = applicationUser;
        }

        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
