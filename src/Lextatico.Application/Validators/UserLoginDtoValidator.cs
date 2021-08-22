using System.Linq;
using FluentValidation;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Application.Validators
{
    public class UserLoginDtoValidator : UserDtoValidator<UserLogInDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserLoginDtoValidator(UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _userManager = userManager;

            ValidateEmail();

            ValidatePassword();
        }
    }
}
