using System.Collections.Generic;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Result;

namespace Analyzer.Lextatico.Sly.Parser.Builder
{
    public interface ILextaticoParserBuilder<T> where T : Token
    {
        BuildResult<Parser<T>> BuildParser(string rootRule, ParserType parserType, IEnumerable<string> productionRules);

        ParserConfiguration<T> ExtractParserConfiguration(IEnumerable<string> productionRules);
    }
}
