using System;

namespace Lextatico.Domain.Models
{
    public class AnalyzerTerminalToken : Base
    {
        public AnalyzerTerminalToken()
            // : base(DateTime.UtcNow)
        {

        }
        public Guid AnalyzerId { get; set; }
        public virtual Analyzer Analyzer { get; set; }
        public Guid TerminalTokenId { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
    }
}
