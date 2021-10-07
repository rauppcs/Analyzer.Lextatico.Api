using Lextatico.Sly.Lexer;
using Lextatico.Sly.Result;

namespace Lextatico.Sly.Parser.Builder
{
    public interface IParserBuilder<T> where T : Token
    {
        BuildResult<Parser<T>> BuildParser();
    }
}