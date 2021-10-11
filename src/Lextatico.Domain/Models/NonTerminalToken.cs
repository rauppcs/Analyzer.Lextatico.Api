using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class NonTerminalToken : Base
    {
        public NonTerminalToken()
        // : base(DateTime.UtcNow)
        {
        }

        public string Name { get; set; }
        public int Sequence { get; set; }
        public bool IsStart { get; set; }
        public virtual ICollection<AnalyzerNonTerminalToken> AnalyzerNonTerminalTokens { get; set; }
        public virtual ICollection<NonTerminalTokenRule> NonTerminalTokenRules { get; set; }
        public virtual ICollection<NonTerminalTokenRuleClause> NonTerminalTokenRuleClauses { get; set; }
    }
}