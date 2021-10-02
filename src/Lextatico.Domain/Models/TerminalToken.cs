using System;
using System.Collections.Generic;

namespace Lextatico.Domain.Models
{
    public class TerminalToken : Base
    {
        public TerminalToken()
            : base(DateTime.UtcNow)
        {

        }

        public string Name { get; set; }
        public string Lexeme { get; set; }
        public string TokenType { get; set; }

        public virtual ICollection<AnalyzerToken> AnalyzerTokens { get; set; }
    }
}
