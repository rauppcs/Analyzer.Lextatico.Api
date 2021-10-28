using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Application.Dtos.Analyzer
{
    public class AnalyzerDto : AnalyzerDetailDto
    {
        public Guid Id { get; set; }
    }
}