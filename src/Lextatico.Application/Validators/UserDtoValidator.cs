using FluentValidation;
using Lextatico.Application.Dtos.User;
using Lextatico.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Lextatico.Application.Validators
{
    public abstract class UserDtoValidator<T> : AbstractValidator<T> where T : UserDto
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserDtoValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected void ValidateEmail()
        {
            RuleFor(userLoginDto => userLoginDto.Email)
                .EmailAddress()
                .WithMessage("Insira um endereço de email válido.");
        }

        protected void ValidatePassword()
        {
            RuleFor(userLoginDto => userLoginDto.Password)
               .MustAsync(async (password, cancelationToken) =>
               {
                   var passwordValidator = new PasswordValidator<ApplicationUser>();
                   return (await passwordValidator.ValidateAsync(_userManager, null, password)).Succeeded;
               })
               .WithMessage("Senha informada não é válida.");
        }
    }
}
