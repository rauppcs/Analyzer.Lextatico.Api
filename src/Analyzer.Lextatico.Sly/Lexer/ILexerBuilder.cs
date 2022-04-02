using Analyzer.Lextatico.Sly.Result;

namespace Analyzer.Lextatico.Sly.Lexer
{
    public interface ILexerBuilder<T> where T : Token
    {
        BuildResult<ILexer<T>> Build();
    }
}
