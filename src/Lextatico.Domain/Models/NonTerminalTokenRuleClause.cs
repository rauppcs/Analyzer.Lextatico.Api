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
        public Guid TerminalTokenId { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
        public Guid NonTerminalTokenId { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
        public Guid NonTerminalTokenRuleId { get; set; }
        public NonTerminalTokenRule NonTerminalTokenRule { get; set; }
    }
}