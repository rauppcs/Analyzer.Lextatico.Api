using System;

namespace Lextatico.Domain.Models
{
    public class NonTerminalLeadingToken : Base
    {
        public NonTerminalLeadingToken()
            : base(DateTime.UtcNow)
        {
        }

        public Guid IdNonTerminalToken { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
    }
}
