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

        public Analyzer(string name, Guid applicationUserId)
        {
            Name = name;
            ApplicationUserId = applicationUserId;
        }

        public string Name { get; private set; }
        public Guid ApplicationUserId { get; private set; }
        public void SetApplicationUserId(Guid applicationUserId) => ApplicationUserId = applicationUserId;
        public virtual ApplicationUser ApplicationUser { get; private set; }
        public virtual ICollection<AnalyzerTerminalToken> AnalyzerTerminalTokens { get; } = new List<AnalyzerTerminalToken>();
        public virtual ICollection<AnalyzerNonTerminalToken> AnalyzerNonTerminalTokens { get; } = new List<AnalyzerNonTerminalToken>();
    }
}
