using System.Data;
using FluentValidation;
using Lextatico.Application.Dtos.User;

namespace Lextatico.Application.Validators
{
    public class UserRefreshDtoValidator : AbstractValidator<UserRefreshDto>
    {
        public UserRefreshDtoValidator()
        {
            ValidateToken();

            ValidateRefreshToken();
        }

        public void ValidateToken()
        {
            RuleFor(userRefresh => userRefresh.Token)
                .NotEmpty()
                .WithMessage("Token deve ser informado.");
        }

        public void ValidateRefreshToken()
        {
            RuleFor(userRefresh => userRefresh.RefreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken deve ser informado");
        }
    }
}
