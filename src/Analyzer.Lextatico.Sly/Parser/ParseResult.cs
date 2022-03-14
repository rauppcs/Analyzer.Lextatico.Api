using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Sly.Lexer;

namespace Analyzer.Lextatico.Sly.Parser
{
    public class ParseResult<T> where T : Token
    {
        public ParseResult()
        {
            Errors = new List<ParseError>();
        }
        public bool IsError { get; set; }

        public bool IsOk => !IsError;

        public List<ParseError> Errors { get; }
    }
}
