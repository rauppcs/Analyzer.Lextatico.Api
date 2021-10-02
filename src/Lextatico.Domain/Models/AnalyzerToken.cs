using System;

namespace Lextatico.Domain.Models
{
    public class AnalyzerToken : Base
    {
        public AnalyzerToken()
            : base(DateTime.UtcNow)
        {

        }
        public Guid IdAnalyzer { get; set; }
        public virtual Analyzer Analyzer { get; set; }
        public Guid IdToken { get; set; }
        public virtual TerminalToken TerminalToken { get; set; }
    }
}
