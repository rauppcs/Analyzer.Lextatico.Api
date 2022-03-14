using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Lexer.Fsm;
using Analyzer.Lextatico.Sly.Parser.Builder;

namespace Analyzer.Lextatico.Sly.Parser
{
    public interface ISyntaxParser<T> where T : Token
    {
        string StartingNonTerminal { get; set; }

        SyntaxParseResult<T> Parse(IList<LexerToken<T>> tokens, string startingNonTerminal = null);

        void Init(ParserConfiguration<T> configuration, string root);
    }
}
