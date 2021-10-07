using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer;
using Lextatico.Sly.Result;

namespace Lextatico.Sly.Parser.Builder
{
    public delegate BuildResult<Parser<T>> ParserChecker<T>(BuildResult<Parser<T>> result,
        NonTerminal<T> nonterminal) where T : Token;

    public class ParserBuilder<T> : IParserBuilder<T> where T : Token
    {
        public BuildResult<Parser<T>> BuildParser()
        {
            throw new NotImplementedException();
        }
    }
}