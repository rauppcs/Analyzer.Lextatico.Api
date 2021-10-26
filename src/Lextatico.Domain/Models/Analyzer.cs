using System;
using System.Collections;
using System.Collections.Generic;

namespace Lextatico.Domain.Models
{
    public class Analyzer : Base
    {
        public Analyzer()
        {
        }

        public string Name { get; private set; }
        public Guid ApplicationUserId { get; private set; }
        public virtual ApplicationUser ApplicationUser { get; private set; }
        public virtual ICollection<AnalyzerTerminalToken> AnalyzerTokens { get; private set; }
        public virtual ICollection<AnalyzerNonTerminalToken> AnalyzerNonTerminalTokens { get; private set; }
    }
}
