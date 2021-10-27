using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class AnalyzerNonTerminalToken : Base
    {
        public AnalyzerNonTerminalToken()
        {
        }

        public AnalyzerNonTerminalToken(Guid analyzerId, Guid nonTerminalTokenId)
        {
            AnalyzerId = analyzerId;
            NonTerminalTokenId = nonTerminalTokenId;
        }

        public Guid AnalyzerId { get; private set; }
        public virtual Analyzer Analyzer { get; private set; }
        public Guid NonTerminalTokenId { get; private set; }
        public virtual NonTerminalToken NonTerminalToken { get; private set; }
    }
}