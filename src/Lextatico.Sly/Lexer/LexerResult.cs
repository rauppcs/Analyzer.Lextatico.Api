using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Sly.Lexer
{
    public class LexerResult<T> where T : Token
    {
        public bool IsError { get; set; }

        public bool IsOk => !IsError;

        public LexicalError Error { get; }

        public List<T> Tokens { get; set; }

        public LexerResult(List<T> tokens)
        {
            IsError = false;
            Tokens = tokens;
        }

        public LexerResult(LexicalError error)
        {
            IsError = true;
            Error = error;
        }
    }
}