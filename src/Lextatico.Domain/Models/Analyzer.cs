using System;

namespace Lextatico.Domain.Models
{
    public class Analyzer : Base
    {
        public Analyzer() : base(DateTime.UtcNow)
        {
        }

        public string Name { get; set; }
    }
}
