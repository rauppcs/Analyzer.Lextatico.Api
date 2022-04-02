using Analyzer.Lextatico.Sly.Lexer;

namespace Analyzer.Lextatico.Sly.Parser.Syntax.Grammar
{
    public interface IClause<T> : GrammarNode<T> where T : Token
    {
        bool MayBeEmpty();
    }
}
