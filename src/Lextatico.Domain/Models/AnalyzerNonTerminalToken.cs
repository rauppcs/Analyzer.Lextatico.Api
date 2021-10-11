using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Domain.Models
{
    public class AnalyzerNonTerminalToken : Base
    {
        public Guid IdAnalyzer { get; set; }
        public virtual Analyzer Analyzer { get; set; }
        public Guid IdNonTerminalToken { get; set; }
        public virtual NonTerminalToken NonTerminalToken { get; set; }
    }
}