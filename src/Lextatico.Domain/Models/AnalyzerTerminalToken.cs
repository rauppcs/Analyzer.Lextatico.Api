using System;

namespace Lextatico.Domain.Models
{
    public class AnalyzerTerminalToken : Base
    {
        public AnalyzerTerminalToken()
        {
        }
        public Guid AnalyzerId { get; private set; }
        public virtual Analyzer Analyzer { get; private set; }
        public Guid TerminalTokenId { get; private set; }
        public virtual TerminalToken TerminalToken { get; private set; }
    }
}
