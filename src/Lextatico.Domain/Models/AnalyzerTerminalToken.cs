using System;

namespace Lextatico.Domain.Models
{
    public class AnalyzerTerminalToken : Base
    {
        public AnalyzerTerminalToken()
            // : base(DateTime.UtcNow)
        {

        }
        public Guid IdAnalyzer { get; set; }
        public virtual Analyzer Analyzer { get; set; }
        public Guid IdTerminalToken { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
    }
}
