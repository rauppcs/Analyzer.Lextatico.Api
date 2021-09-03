using System;
using System.Collections.Generic;

namespace Lextatico.Domain.Models
{
    public class NonTerminalToken : Base
    {
        public NonTerminalToken()
            : base(DateTime.UtcNow)
        {
        }

        public string Name { get; set; }
        public virtual ICollection<NonTerminalLeadingToken> NonTerminalLeadingTokens { get; set; }
        public virtual ICollection<NonTerminalRule> NonTerminalRules { get; set; }
    }
}
