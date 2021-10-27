using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Application.Dtos.NonTerminalToken
{
    public class NonTerminalTokenDetailWithRulesAndClausesDto : NonTerminalTokenDetailDto
    {
        public IEnumerable<NonTerminalTokenRuleWithClausesDto> NonTerminalTokenRules { get; set; }
    }
}