using FluentValidation;
using Analyzer.Lextatico.Application.Dtos.User;
using Analyzer.Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Analyzer.Lextatico.Application.Validators
{
    public class UserSigninDtoValidator : UserDtoValidator<UserSignInDto>
    {
        public UserSigninDtoValidator(UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            ValidateName();
            ValidateEmail();
            ValidatePassword();
            ValidatePasswordEqualConfirmPassword();
        }

        private void ValidateName()
        {
            RuleFor(userSignin => userSignin.Name)
                .NotEmpty()
                .WithMessage("Insira um nome válido.");
        }

        private void ValidatePasswordEqualConfirmPassword()
        {
            RuleFor(userSignin => userSignin.ConfirmPassword)
                .Equal(userSignin => userSignin.Password)
                .WithMessage("As senhas não conferem.");
        }
    }
}
