using System;

namespace Lextatico.Domain.Models
{
    public class TerminalToken : Base
    {
        public TerminalToken()
            : base(DateTime.UtcNow)
        {

        }

        public string Name { get; set; }
        public string TokenType { get; set; }
    }
}
