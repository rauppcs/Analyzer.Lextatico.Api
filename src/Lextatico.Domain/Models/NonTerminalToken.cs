using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class NonTerminalToken : Base
    {
        public NonTerminalToken()
        {
        }

        public string Name { get; private set; }
        public int Sequence { get; private set; }
        public bool IsStart { get; private set; }
        public virtual ICollection<AnalyzerNonTerminalToken> AnalyzerNonTerminalTokens { get; } = new List<AnalyzerNonTerminalToken>();
        public virtual ICollection<NonTerminalTokenRule> NonTerminalTokenRules { get; } = new List<NonTerminalTokenRule>();
        public virtual ICollection<NonTerminalTokenRuleClause> NonTerminalTokenRuleClauses { get; } = new List<NonTerminalTokenRuleClause>();
    }
}