using System;

namespace Lextatico.Domain.Models
{
    public class NonTerminalClause : Base
    {
        public NonTerminalClause()
            : base(DateTime.UtcNow)
        {
        }

        public Guid IdNonTerminalToken { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
        public Guid IdTerminalToken { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
    }
}
