using FluentValidation;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Application.Validators
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
            RuleFor(userSignin => new { userSignin.Password, userSignin.ConfirmPassword })
                .Must((userPassword) =>
                {
                    return userPassword.Password == userPassword.ConfirmPassword;
                })
                .OverridePropertyName(nameof(UserSignInDto.ConfirmPassword))
                .WithMessage("As senhas não conferem.");
        }
    }
}
