using System;

namespace Lextatico.Domain.Models
{
    public class AnalyzerToken : Base
    {
        public AnalyzerToken()
            : base(DateTime.UtcNow)
        {

        }
        public Guid IdAnalizer { get; set; }
        public virtual Analyzer Analizer { get; set; }
        public Guid IdToken { get; set; }
        public TerminalToken TerminalToken { get; set; }
    }
}
