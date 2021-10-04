using System;
using System.Collections;
using System.Collections.Generic;

namespace Lextatico.Domain.Models
{
    public class Analyzer : Base
    {
        public Analyzer() : base(DateTime.UtcNow)
        {
        }

        public string Name { get; set; }

        public virtual ICollection<AnalyzerToken> AnalyzerTokens { get; set; }
    }
}