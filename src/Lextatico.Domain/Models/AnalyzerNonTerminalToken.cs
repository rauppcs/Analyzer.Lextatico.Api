using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class AnalyzerNonTerminalToken : Base
    {
        public Guid AnalyzerId { get; set; }
        public virtual Analyzer Analyzer { get; set; }
        public Guid NonTerminalTokenId { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
    }
}