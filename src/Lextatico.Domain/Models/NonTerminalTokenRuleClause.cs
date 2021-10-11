using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class NonTerminalTokenRuleClause : Base
    {
        public string Name { get; set; }
        public int Sequence { get; set; }
        public bool IsTerminalToken { get; set; }
        public Guid IdTerminalToken { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
        public Guid IdNonTerminalToken { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
        public Guid IdNonTerminalTokenRule { get; set; }
        public NonTerminalTokenRule NonTerminalTokenRule { get; set; }
    }
}