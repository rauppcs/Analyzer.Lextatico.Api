using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Sly.Lexer
{
    public interface ILexer<T> where T : Token
    {
        void AddDefinition(TokenDefinition tokenDefinition);

        LexerResult<T> Tokenize(string source);

        LexerResult<T> Tokenize(ReadOnlyMemory<char> source);

        // string I18n { get; set; }
    }
}