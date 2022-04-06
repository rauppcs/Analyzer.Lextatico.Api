using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Application.Dtos.Analyzer;
using FluentValidation;

namespace Analyzer.Lextatico.Application.Validators
{
    public class AnalyzerWithTerminalTokensAndNonTerminalTokensDtoValidator : AbstractValidator<AnalyzerWithTerminalTokensAndNonTerminalTokensDto>
    {
        public AnalyzerWithTerminalTokensAndNonTerminalTokensDtoValidator()
        {
            RuleFor(analyzer => analyzer.Name)
                .NotEmpty()
                .WithMessage("Insira um nome para o analisador.");
        }
    }
}
