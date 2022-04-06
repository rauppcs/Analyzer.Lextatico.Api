using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Application.Dtos.NonTerminalToken;
using Analyzer.Lextatico.Application.Dtos.TerminalToken;

namespace Analyzer.Lextatico.Application.Dtos.Analyzer
{
    public class AnalyzerWithTerminalTokensAndNonTerminalTokensDto : AnalyzerDto
    {
        public IEnumerable<TerminalTokenDto> TerminalTokens { get; set; }
        public IEnumerable<NonTerminalTokenWithRulesAndClausesDto> NonTerminalTokens { get; set; }
    }
}
