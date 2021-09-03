using System;
using System.Collections.Generic;

namespace Lextatico.Domain.Models
{
    public class NonTerminalRule : Base
    {
        public NonTerminalRule()
            : base(DateTime.UtcNow)
        {
        }

        public string Name { get; set; }
        public Guid IdNonTerminalToken { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
        public virtual ICollection<NonTerminalClause> NonTerminalClauses { get; set; }

    }
}
