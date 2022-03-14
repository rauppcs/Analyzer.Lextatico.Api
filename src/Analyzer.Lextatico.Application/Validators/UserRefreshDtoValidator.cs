using System.Data;
using FluentValidation;
using Analyzer.Lextatico.Application.Dtos.User;

namespace Analyzer.Lextatico.Application.Validators
{
    public class UserRefreshDtoValidator : AbstractValidator<UserRefreshDto>
    {
        public UserRefreshDtoValidator()
        {
            ValidateRefreshToken();
        }

        public void ValidateRefreshToken()
        {
            RuleFor(userRefresh => userRefresh.RefreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken deve ser informado");
        }
    }
}
