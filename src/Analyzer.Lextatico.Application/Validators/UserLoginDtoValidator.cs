using System.Linq;
using FluentValidation;
using Analyzer.Lextatico.Application.Dtos.User;
using Analyzer.Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Analyzer.Lextatico.Application.Validators
{
    public class UserLoginDtoValidator : UserDtoValidator<UserLogInDto>
    {
        public UserLoginDtoValidator(UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            ValidateEmail();
        }
    }
}
